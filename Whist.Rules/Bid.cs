namespace Whist.Rules
{
    public abstract class Bid
    {
        public int EvaluateTrick(Card[] cards)
        {
            if (cards[0].IsJoker)
                return 0;
            var result = 0;
            for (var i = 0; i < 4; i++)
                if (this.IsCandidateBetterThanCurrentBest(cards[i], cards[result]))
                    result = i;
            return result;
        }

        protected abstract bool IsCandidateBetterThanCurrentBest(Card candidate, Card currentBest);
    }
}