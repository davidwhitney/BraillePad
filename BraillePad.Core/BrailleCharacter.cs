using System;
using System.Collections.Generic;

namespace BraillePad.Core
{
    public class BrailleCharacter
    {
        public string Character { get; set; }

        public List<List<byte>> Derivation { get; set; } = new List<List<byte>>
        {
            new List<byte> {0, 0},
            new List<byte> {0, 0},
            new List<byte> {0, 0}
        };

        public List<string> DerivationString { get; set; } = new List<string>();

        public BrailleCharacter(string character, string pattern = null)
        {
            Character = character;
            pattern = pattern ?? "";
            var row = 0;
            for (var index = 0; index < pattern.Length; index = index + 2)
            {
                var part = pattern[index] + pattern[index + 1].ToString();
                var ch1 = pattern[index] == '.' ? (byte)1 : (byte)0;
                var ch2 = pattern[index+1] == '.' ? (byte)1 : (byte)0;

                Derivation[row] = new List<byte> {ch1, ch2};
                DerivationString.Add(part);

                row++;
            }
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, DerivationString);
        }
    }
}