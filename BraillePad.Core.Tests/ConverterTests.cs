using System.Linq;
using NUnit.Framework;

namespace BraillePad.Core.Tests
{
    [TestFixture]
    public class ConverterTests
    {
        private Converter _conv;

        [SetUp]
        public void SetUp()
        {
            _conv = new Converter();
        }

        [Test]
        public void Ctor_DoesNotThrow()
        {
            Assert.DoesNotThrow(() => new Converter());
        }

        [Test]
        public void Convert_SingleLetter_ReturnsCorrectShape()
        {
            var braille = _conv.Convert("A").First();

            Assert.That(braille.Derivation.Count, Is.EqualTo(3));
            Assert.That(braille.Derivation.All(x=>x.Count == 2));
        }

        [TestCase(" ", "  " + Nl +
                       "  " + Nl +
                       "  ")]
        [TestCase("a", ". " + Nl +
                       "  " + Nl +
                       "  ")]
        [TestCase("b", ". " + Nl +
                       ". " + Nl +
                       "  ")]
        public void ToString_SingleLetter_ReturnsStringRepresentation(string ch, string pattern)
        {
            var braille = _conv.Convert(ch).First().ToString();

            Assert.That(braille, Is.EqualTo(pattern));
        }

        [Test]
        public void Convert_AllLowerCaseLettersSupported()
        {
            var text = "thequickbrownfoxjumpedoverthelazydog";

            var brailled = _conv.Convert(text);

            Assert.That(brailled.Count, Is.EqualTo(text.Length));
        }

        private const string Nl = "\r\n";
    }
}
