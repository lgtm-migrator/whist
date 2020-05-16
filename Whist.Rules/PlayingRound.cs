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
            this._evaluator = evaluator;
        }

        public int? Play(Card card)
        {
            this._cardsInTrick.Add(card);
            if (this._cardsInTrick.Count == 4)
                return this.WinnerTakesTrick();
            this.PlayerToPlay = (this.PlayerToPlay + 1) % 4;
            return null;
        }

        private int WinnerTakesTrick()
        {
            var winner = this._evaluator.EvaluateTrick(this._cardsInTrick);
            this._cardsInTrick.Clear();
            this.PlayerToPlay = winner;
            return winner;
        }

        public int PlayerToPlay { get; private set; }
    }
}
