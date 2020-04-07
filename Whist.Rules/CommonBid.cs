namespace Whist.Rules
{
    public sealed class CommonBid : Bid
    {
        private readonly char _trump;

        public CommonBid(char trump) => this._trump = trump;

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