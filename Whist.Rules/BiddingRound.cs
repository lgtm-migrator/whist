namespace Whist.Rules
{
    public sealed class BiddingRound
    {
        private int _playerA;
        private int _playerB = 1;
        private bool _playerAsTurn = true;

        public void Bid(string bidder, string bid)
        {
            if (bid == "pass")
            {
                if (_playerAsTurn) _playerA = _playerB;
                _playerB++;
            }
            else
            {
                _playerAsTurn = !_playerAsTurn;
                this.Winner = bidder;
                this.WinningBid = bid;
            }
            PlayerToBid = _playerAsTurn ? _playerA : _playerB;
        }

        public int PlayerToBid { get; private set; }
        public string Winner { get; private set; }
        public string WinningBid { get; private set; }
    }
}
