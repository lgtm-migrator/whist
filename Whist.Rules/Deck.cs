namespace Whist.Rules
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public sealed class Deck
    {
        private readonly List<Card> _cards = CreateCards();
        
        public Deck()
        {
            this.Shuffle();
        }

        private static List<Card> CreateCards()
        {
            var result = new List<Card>();
            foreach (var suit in new[] {"S", "H", "C", "D"})
            {
                result.AddRange(Enumerable.Range(1, 10).Select(number =>
                    new Card(suit + number)));
                result.AddRange(new []{ "J", "Q", "K" }.Select(rank =>
                    new Card(suit + rank)));
            }
            result.AddRange(new []{ "Joker", "Joker", "Joker" }.Select(cardName =>
                new Card(cardName)));

            return result;
        }

        private void Shuffle()
        {
            var generator = new Random();
            foreach (var index in Enumerable.Range(0, this._cards.Count))
            {
                var swapIndex = generator.Next(index, this._cards.Count);
                var tmp = this._cards[index];
                this._cards[index] = this._cards[swapIndex];
                this._cards[swapIndex] = tmp;
            }
        }

        public List<Card> DealCards(int count)
        {
            var result = this._cards.GetRange(0, count);
            this._cards.RemoveRange(0, count);
            return result;
        }
    }
}
