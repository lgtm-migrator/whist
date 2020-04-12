namespace Whist.Rules
{
    using System;
    using System.Collections.Generic;

    public sealed class PlayingRound
    {
        private readonly TrickEvaluator _evaluator;
        private readonly List<Card> _cardsInTrick = new List<Card>();

        public PlayingRound(TrickEvaluator evaluator)
        {
            _evaluator = evaluator;
        }

        public int? Play(Card card)
        {
            _cardsInTrick.Add(card);
            PlayerToPlay = (PlayerToPlay + 1) % 4;
            if (_cardsInTrick.Count == 4)
                return WinnerTakesTrick();
            return null;
        }

        private int WinnerTakesTrick()
        {
            var winner = _evaluator.EvaluateTrick(_cardsInTrick);
            _cardsInTrick.Clear();
            return winner;
        }

        public int PlayerToPlay { get; private set; }
    }
}
