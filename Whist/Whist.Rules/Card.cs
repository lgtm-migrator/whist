namespace Whist.Rules
{
    using System;

    public sealed class Card
    {
        private readonly string _name;

        private const char Spades = 'S';
        private const char Hearts = 'H';
        private const char Diamond = 'D';
        private const char Clubs = 'C';
        private const char Joker = 'J';

        public char Suit => this._name[0];

        public bool IsJoker => this._name[0] == Joker;

        public int FaceValue
        {
            get
            {
                switch (this._name[1])
                {
                    case 'K':
                        return 13;
                    case 'Q':
                        return 12;
                    case 'J':
                        return 11;
                    default:
                        return int.Parse(this._name.Substring(1));
                }
            }
        }

        /// <summary>
        /// Creates a playing card.
        /// </summary>
        /// <param name="name">TODO(jorgen.fogh): Describe the format.</param>
        public Card(string name) => this._name = name ?? throw new ArgumentNullException(nameof(name));
    }
}
