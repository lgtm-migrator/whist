namespace Whist.Rules.Tests
{
    using NUnit.Framework;
    using System.Linq;

    internal static class AbstractTrickEvaluatorTests
    {
        public static void TestEvaluateTrick(TrickEvaluator trickEvaluator, string cardsPlayed, int winnerIndex)
        {
            var cards = cardsPlayed.Split(' ').Select(c => new Card(c)).ToArray();
            Assert.That(trickEvaluator.EvaluateTrick(cards), Is.EqualTo(winnerIndex));
        }
    }
}