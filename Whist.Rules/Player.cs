namespace Whist.Rules
{
    using System;
    using System.Collections.Generic;

    public sealed class Player
    {
        public readonly string Name;
        public readonly List<Card> Hand = new List<Card>();

        public Player(string name)
        {
            this.Name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}
