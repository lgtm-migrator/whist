namespace Whist.Rules
{
    public sealed class CommonTrickEvaluator : TrickEvaluator
    {
        private readonly char _trump;

        public CommonTrickEvaluator(char trump) => this._trump = trump;

        protected override bool IsCandidateBetterThanCurrentBest(Card candidate, Card currentBest)
        {
            if (candidate.Suit == this._trump && currentBest.Suit != this._trump)
                return true;
            return !candidate.IsJoker &&
                   candidate.FaceValue > currentBest.FaceValue &&
                   candidate.Suit == currentBest.Suit;
        }
    }
}