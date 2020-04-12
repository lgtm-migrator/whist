namespace Whist.Rules
{
    using System.Collections.Generic;

    public sealed class Player
    {
        public readonly List<Card> Hand;

        public Player(List<Card> hand)
        {
            Hand = hand;
        }
    }
}
