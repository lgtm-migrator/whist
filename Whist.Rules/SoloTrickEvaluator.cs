namespace Whist.Rules
{
    public sealed class SoloTrickEvaluator : TrickEvaluator
    {
        protected override bool IsCandidateBetterThanCurrentBest(Card candidate, Card currentBest)
        {
            return !candidate.IsJoker &&
                   candidate.FaceValue > currentBest.FaceValue &&
                   candidate.Suit == currentBest.Suit;
        }
    }
}