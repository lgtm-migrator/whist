using NUnit.Framework;

namespace Whist.Rules.Tests
{
    using System.Linq;

    public sealed class SansTests
    {
        // TODO(jorgen.fogh): Write move generator.
        // TODO(jorgen.fogh): Write move executor.

        [Test]
        [TestCase("S2 S3 S4 S5", 3)]
        [TestCase("S2 S3 S5 S4", 2)]
        [TestCase("S2 S5 S3 S4", 1)]
        [TestCase("S2 S5 S6 S4", 2)]
        [TestCase("S7 S5 S6 S4", 0)]
        [TestCase("S7 C9 S6 S4", 0)]
        [TestCase("J C9 S6 S4", 0)]
        [TestCase("S7 J S6 S4", 0)]
        [TestCase("S1 J S6 S4", 0)]
        public void EvaluateTrick(string input, int winnerIndex)
        {
            var cards = input.Split(' ').Select(c => new Card(c)).ToArray();
            var bid = new Sans();
            Assert.That(bid.EvaluateTrick(cards), Is.EqualTo(winnerIndex));
        }
    }
}