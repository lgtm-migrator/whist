using NUnit.Framework;

namespace Whist.Rules.Tests
{
    using System.Linq;

    internal static class AbstractBidTests
    {
        public static void TestEvaluateTrick(Bid bid, string cardsPlayed, int winnerIndex)
        {
            var cards = cardsPlayed.Split(' ').Select(c => new Card(c)).ToArray();
            Assert.That(bid.EvaluateTrick(cards), Is.EqualTo(winnerIndex));
        }
    }
}