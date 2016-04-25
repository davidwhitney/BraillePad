namespace BraillePad.Core
{
    public class StandardBraille : Dialect
    {
        public StandardBraille()
        {
            Add("a", new BrailleCharacter("a", ".     "));
            Add("b", new BrailleCharacter("b", ". .   "));
            Add("c", new BrailleCharacter("c", "..    "));
            Add("d", new BrailleCharacter("d", ".. .  "));
            Add("e", new BrailleCharacter("e", ".  .  "));
            Add("f", new BrailleCharacter("f", "...   "));
            Add("g", new BrailleCharacter("g", "....  "));
            Add("h", new BrailleCharacter("h", ". ..  "));
            Add("i", new BrailleCharacter("i", " ..   "));
            Add("j", new BrailleCharacter("j", " ...  "));
            Add("k", new BrailleCharacter("k", ".     "));
            Add("l", new BrailleCharacter("l", ". . . "));
            Add("m", new BrailleCharacter("m", "..  . "));
            Add("n", new BrailleCharacter("n", ".. .. "));
            Add("o", new BrailleCharacter("o", ".  .. "));
            Add("p", new BrailleCharacter("p", "... . "));
            Add("q", new BrailleCharacter("q", "..... "));
            Add("r", new BrailleCharacter("r", ". ... "));
            Add("s", new BrailleCharacter("s", " .. . "));
            Add("t", new BrailleCharacter("t", " .... "));
            Add("u", new BrailleCharacter("u", ".   .."));
            Add("v", new BrailleCharacter("v", ". . .."));
            Add("w", new BrailleCharacter("w", " ... ."));
            Add("x", new BrailleCharacter("x", "..  .."));
            Add("y", new BrailleCharacter("y", ".. ..."));
            Add("z", new BrailleCharacter("z", ".  ..."));
            Add(" ", new BrailleCharacter(" ", "      "));
        }
    }
}