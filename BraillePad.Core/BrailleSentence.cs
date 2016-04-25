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
}