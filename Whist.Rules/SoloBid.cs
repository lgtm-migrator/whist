namespace Whist.Rules
{
    public sealed class SoloBid : Bid
    {
        protected override bool IsCandidateBetterThanCurrentBest(Card candidate, Card currentBest)
        {
            return !candidate.IsJoker &&
                   candidate.FaceValue > currentBest.FaceValue &&
                   candidate.Suit == currentBest.Suit;
        }
    }
}