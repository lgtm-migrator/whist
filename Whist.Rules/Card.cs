namespace Whist.Rules
{
    using System;

    public sealed class Card
    {
        private readonly string _name;

        private const string Joker = "Joker";

        public char Suit => this._name[0];

        public bool IsJoker => this._name == Joker;

        public int FaceValue =>
            this._name[1] switch
            {
                'K' => 13,
                'Q' => 12,
                'J' => 11,
                _ => int.Parse(this._name.Substring(1))
            };

        public Card(string name) => this._name = name ?? throw new ArgumentNullException(nameof(name));

        private bool Equals(Card other)
        {
            return this._name == other._name;
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is Card other && this.Equals(other);
        }

        public override int GetHashCode()
        {
            return this._name.GetHashCode();
        }

        public static bool operator ==(Card left, Card right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Card left, Card right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return this._name;
        }
    }
}
