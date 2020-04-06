﻿using NUnit.Framework;

namespace Whist.Rules.Tests
{
    public sealed class SoloBidTests
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
        [TestCase("S1 J S6 S4", 2)]
        public void EvaluateTrick(string cardsPlayed, int winnerIndex)
        {
            AbstractBidTests.TestEvaluateTrick(new SoloBid(), cardsPlayed, winnerIndex);
        }
    }
}