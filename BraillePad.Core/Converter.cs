using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BraillePad.Core
{
    public class Converter
    {
        private readonly Dictionary<string, BrailleCharacter> _map = new Dictionary<string, BrailleCharacter>
        {
            { "a", new BrailleCharacter(".xxxxx")},
            { "b", new BrailleCharacter(".x.xxx")},
            { "c", new BrailleCharacter("..xxxx")},
            { "d", new BrailleCharacter("..x.xx")},
            { "e", new BrailleCharacter(".xx.xx")},
            { "f", new BrailleCharacter("...xxx")},
            { "g", new BrailleCharacter("....xx")},
            { "h", new BrailleCharacter(".x..xx")},
            { "i", new BrailleCharacter("x..xxx")},
            { "j", new BrailleCharacter("x...xx")},
            { "k", new BrailleCharacter(".xxxxx")},
            { "l", new BrailleCharacter(".x.x.x")},
            { "m", new BrailleCharacter("..xx.x")},
            { "n", new BrailleCharacter("..x..x")},
            { "o", new BrailleCharacter(".xx..x")},
            { "p", new BrailleCharacter("...x.x")},
            { "q", new BrailleCharacter(".....x")},
            { "r", new BrailleCharacter(".x...x")},
            { "s", new BrailleCharacter("x..x.x")},
            { "t", new BrailleCharacter("x....x")},
            { "u", new BrailleCharacter(".xxx..")},
            { "v", new BrailleCharacter(".x.x..")},
            { "w", new BrailleCharacter("x...x.")},
            { "x", new BrailleCharacter("..xx..")},
            { "y", new BrailleCharacter("..x...")},
            { "z", new BrailleCharacter(".xx...")},
            { " ", new BrailleCharacter("      ")}
        };

        public BrailleSentence Convert(string s)
        {
            var items = new BrailleSentence();
            foreach (var letter in s)
            {
                items.Add(_map[letter.ToString().ToLower()]);
            }

            return items;
        }
    }

    public class BrailleSentence : List<BrailleCharacter>
    {
        public override string ToString()
        {
            return ToString(20);
        }

        public string ToString(int breakAfter)
        {
            var sb = new StringBuilder();

            var firstBuffer = new StringBuilder();
            var second = new StringBuilder();
            var third = new StringBuilder();

            var letterCount = 0;
            for (int index = 0; index < Count; index++)
            {
                var item = this[index];
                firstBuffer.Append(item.DerivationString[0]);
                second.Append(item.DerivationString[1]);
                third.Append(item.DerivationString[2]);

                if (letterCount == breakAfter)
                {
                    Flush(sb, firstBuffer, second, third);
                    letterCount = 0;
                }
                else
                {
                    letterCount++;
                }
            }

            Flush(sb, firstBuffer, second, third);

            return sb.ToString();
        }

        private static void Flush(StringBuilder sb, StringBuilder firstBuffer, StringBuilder second, StringBuilder third)
        {
            sb.AppendLine(firstBuffer.ToString());
            sb.AppendLine(second.ToString());
            sb.AppendLine(third.ToString());

            firstBuffer.Clear();
            second.Clear();
            third.Clear();
        }
    }

    public class BrailleCharacter
    {
        private readonly string _asString;

        public List<List<byte>> Derivation { get; set; } = new List<List<byte>>
        {
            new List<byte> {0, 0},
            new List<byte> {0, 0},
            new List<byte> {0, 0},
        };

        public List<string> DerivationString { get; set; } = new List<string>();

        public BrailleCharacter(string pattern = null)
        {
            pattern = pattern ?? "";
            var row = 0;
            for (var index = 0; index < pattern.Length; index = index + 2)
            {
                var part = pattern[index].ToString() + pattern[index + 1].ToString();
                var ch1 = pattern[index] == '.' ? (byte)1 : (byte)0;
                var ch2 = pattern[index+1] == '.' ? (byte)1 : (byte)0;

                Derivation[row] = new List<byte> {ch1, ch2};
                DerivationString.Add(part.Replace("x", " "));

                row++;
            }

            _asString = pattern;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var mask in Derivation)
            {
                var s = mask.Select(byt => byt == 1 ? "." : " ").Aggregate("", (current, ch1) => current + ch1);
                sb.AppendLine(s);
            }
            sb.Remove(sb.Length - Environment.NewLine.Length, Environment.NewLine.Length);
            return sb.ToString();
        }
    }
}
