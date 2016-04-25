using System;
using NUnit.Framework;

namespace BraillePad.Core.Tests
{
    public class BrailleSentenceTests
    {
        private Converter _conv = new Converter();

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
        
    }
}