namespace Whist.Rules
{
    public sealed class Sans
    {
        public int EvaluateTrick(Card[] cards)
        {
            if (cards[0].IsJoker)
                return 0;
            var result = 0;
            for (var i = 1; i < 4; i++)
            {
                var candidate = cards[i];
                var currentBest = cards[result];
                if (IsCandidateBetterThanCurrentBest(candidate, currentBest))
                    result = i;
            }
            return result;
        }

        private static bool IsCandidateBetterThanCurrentBest(Card candidate, Card currentBest)
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
