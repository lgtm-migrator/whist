namespace Whist.Rules
{
    using System;
    using System.Collections.Generic;

    public sealed class Player
    {
        public readonly string Name;
        public readonly List<Card> Cards;

        public Player(string name, List<Card> cards)
        {
            if (cards == null) throw new ArgumentNullException(nameof(cards));
            if (cards.Count == 0) throw new ArgumentException("Value cannot be an empty collection.", nameof(cards));
            this.Name = name ?? throw new ArgumentNullException(nameof(name));
            this.Cards = cards;
        }
    }
}
