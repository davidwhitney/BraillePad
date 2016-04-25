using System.Collections.Generic;
using System.Linq;

namespace BraillePad.Core
{
    public class Converter
    {
        private readonly Dictionary<string, BrailleCharacter> _map = new Dictionary<string, BrailleCharacter>
        {
            { "a", new BrailleCharacter(".     ")},
            { "b", new BrailleCharacter(". .   ")},
            { "c", new BrailleCharacter("..    ")},
            { "d", new BrailleCharacter(".. .  ")},
            { "e", new BrailleCharacter(".  .  ")},
            { "f", new BrailleCharacter("...   ")},
            { "g", new BrailleCharacter("....  ")},
            { "h", new BrailleCharacter(". ..  ")},
            { "i", new BrailleCharacter(" ..   ")},
            { "j", new BrailleCharacter(" ...  ")},
            { "k", new BrailleCharacter(".     ")},
            { "l", new BrailleCharacter(". . . ")},
            { "m", new BrailleCharacter("..  . ")},
            { "n", new BrailleCharacter(".. .. ")},
            { "o", new BrailleCharacter(".  .. ")},
            { "p", new BrailleCharacter("... . ")},
            { "q", new BrailleCharacter("..... ")},
            { "r", new BrailleCharacter(". ... ")},
            { "s", new BrailleCharacter(" .. . ")},
            { "t", new BrailleCharacter(" .... ")},
            { "u", new BrailleCharacter(".   ..")},
            { "v", new BrailleCharacter(". . ..")},
            { "w", new BrailleCharacter(" ... .")},
            { "x", new BrailleCharacter("..  ..")},
            { "y", new BrailleCharacter(".. ...")},
            { "z", new BrailleCharacter(".  ...")},
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
}
