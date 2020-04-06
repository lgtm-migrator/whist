namespace Whist.Rules
{
    public sealed class SansBid : Bid
    {
        protected override bool IsCandidateBetterThanCurrentBest(Card candidate, Card currentBest)
        {
            return !candidate.IsJoker &&
                   CardValue(candidate) > CardValue(currentBest) &&
                   candidate.Suit == currentBest.Suit;
        }

        private static int CardValue(Card candidate)
        {
            if (candidate.FaceValue == 1)
                return 14;
            return candidate.FaceValue;
        }
    }
}
