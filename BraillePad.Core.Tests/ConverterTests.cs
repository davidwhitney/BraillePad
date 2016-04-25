﻿using System;
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

        [Test]
        public void Collection_ToString_ReturnsJoinedLetters()
        {
            var text = "thequickbrownfoxjumpedoverthelazydog";

            var brailled = _conv.Convert(text).ToString(int.MaxValue).Split(new[] {Environment.NewLine}, StringSplitOptions.None);

            Assert.That(brailled[0].Length == brailled[1].Length);
            Assert.That(brailled[0].Length == brailled[2].Length);
            Assert.That(brailled[0].Length, Is.EqualTo(text.Length*2));
        }

        [Test]
        public void Collection_ToStringWithBreaks_BreaksOk()
        {
            var text = "thequickbrownfoxjumpedoverthelazydog";

            var brailled = _conv.Convert(text).ToString().Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);

            Assert.That(brailled.Length == 6);
        }

        private const string Nl = "\r\n";
    }
}
