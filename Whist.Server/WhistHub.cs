namespace Whist.Server
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.SignalR;
    using Rules;

    public sealed class WhistHub : Hub<IWhistClient>
    {
        // TODO(jorgen.fogh): Make the table name dynamic.
        private const string TableName = "Table";
        // TODO(jorgen.fogh): This only works, when there is only a single instance of WhistHub:
        private static readonly List<string> ConnectionIdsAtTable = new List<string>();
        private static List<Card> _cat;

        // TODO(jorgen.fogh): Move the business logic to Whist.Rules.
        private async Task StartGame()
        {
            var deck = new Deck();
            foreach (var connectionId in ConnectionIdsAtTable)
            {
                var cards = deck.DealCards(13);
                await this.Clients.Client(connectionId).ReceiveDealtCards(cards.Select(c => c.ToString()));
            }
            _cat = deck.DealCards(3);
        }

        public override async Task OnConnectedAsync()
        {
            await this.Groups.AddToGroupAsync(this.Context.ConnectionId, TableName);
            ConnectionIdsAtTable.Add(this.Context.ConnectionId);
            if (ConnectionIdsAtTable.Count == 4)
                await this.StartGame();
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await this.Groups.RemoveFromGroupAsync(this.Context.ConnectionId, TableName);
            ConnectionIdsAtTable.Remove(this.Context.ConnectionId);
            await base.OnDisconnectedAsync(exception);
        }

        public async Task SendBid(string user, string bid)
        {
            // TODO(jorgen.fogh): Only send to the current table!
            await this.Clients.Group(TableName).ReceiveBid(user, bid);
        }
    }
}