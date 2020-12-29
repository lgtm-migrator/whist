namespace Whist.Rules
{
    public sealed class BiddingRound
    {
        private int _playerA;
        private int _playerB = 1;
        private bool _playerAsTurn = true;

        public void Bid(string bid)
        {
            if (bid == "pass")
            {
                if (this._playerAsTurn) this._playerA = this._playerB;
                this._playerB++;
            }
            else
            {
                this._playerAsTurn = !this._playerAsTurn;
                this.Winner = this.PlayerToBid;
                this.WinningBid = bid;
            }

            this.PlayerToBid = this._playerAsTurn ? this._playerA : this._playerB;
        }

        public bool IsBiddingDone => this.PlayerToBid == 4;
        public int PlayerToBid { get; private set; }
        public int Winner { get; private set; }
        public string? WinningBid { get; private set; }
    }
}
