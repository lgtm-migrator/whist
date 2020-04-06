namespace Whist.Rules
{
    using System.Collections.Generic;

    public sealed class Player
    {
        public readonly string Name;
        public readonly List<Card> Cards;

        public Player(string name, List<Card> cards)
        {
            this.Name = name;
            this.Cards = cards;
        }
    }
}
