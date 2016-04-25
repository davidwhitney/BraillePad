using System.Linq;

namespace BraillePad.Core
{
    public class Converter
    {
        private readonly Dialect _dialect;

        public Converter(Dialect dialect = null)
        {
            _dialect = dialect ?? new StandardBraille();
        }

        public BrailleSentence Convert(string s)
        {
            var items = new BrailleSentence();
            foreach (var letter in s)
            {
                var lower = letter.ToString().ToLower();
                if (!_dialect.ContainsKey(lower)) continue;

                var value = _dialect[lower];
                items.Add(value);
            }

            return items;
        }
    }
}
