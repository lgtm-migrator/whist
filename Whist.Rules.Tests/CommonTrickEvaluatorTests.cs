using NUnit.Framework;

namespace Whist.Rules.Tests
{
    public sealed class CommonTrickEvaluatorTests
    {
        [Test]
        [TestCase('S', "S2 S3 S4 S5", 3)]
        [TestCase('S', "S2 S3 S5 S4", 2)]
        [TestCase('S', "S2 S5 S3 S4", 1)]
        [TestCase('S', "S2 S5 S6 S4", 2)]
        [TestCase('S', "S7 S5 S6 S4", 0)]
        [TestCase('S', "S7 C9 S6 S4", 0)]
        [TestCase('S', "J C9 S6 S4", 0)]
        [TestCase('S', "S7 J S6 S4", 0)]
        [TestCase('S', "S1 J S6 S4", 2)]
        [TestCase('C', "S1 J S6 C4", 3)]
        [TestCase('C', "S1 J C4 C6", 3)]
        public void EvaluateTrick(char trump, string cardsPlayed, int winnerIndex)
        {
            AbstractTrickEvaluatorTests.TestEvaluateTrick(new CommonTrickEvaluator(trump), cardsPlayed, winnerIndex);
        }
    }
}