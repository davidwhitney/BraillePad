using System.Collections.Generic;
using System.Text;

namespace BraillePad.Core
{
    public class BrailleSentence : List<BrailleCharacter>
    {
        public override string ToString()
        {
            return ToString(20);
        }

        public string ToString(int breakAfter)
        {
            var sb = new StringBuilder();

            var first = new StringBuilder();
            var second = new StringBuilder();
            var third = new StringBuilder();

            var letterCount = 0;
            for (var index = 0; index < Count; index++)
            {
                var item = this[index];
                first.Append(item.DerivationString[0]);
                second.Append(item.DerivationString[1]);
                third.Append(item.DerivationString[2]);

                if (letterCount == breakAfter)
                {
                    Flush(sb, first, second, third);
                    sb.AppendLine();
                    letterCount = 0;
                }
                else
                {
                    letterCount++;
                }
            }

            Flush(sb, first, second, third);

            return sb.ToString();
        }

        private static void Flush(StringBuilder sb, StringBuilder first, StringBuilder second, StringBuilder third)
        {
            sb.AppendLine(first.ToString());
            sb.AppendLine(second.ToString());
            sb.AppendLine(third.ToString());

            first.Clear();
            second.Clear();
            third.Clear();
        }
    }
}