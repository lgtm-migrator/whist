namespace Whist.Server
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.SignalR;
    using Rules;

    public sealed class WhistHub : Hub<IWhistClient>
    {
        private readonly GameConductorService _gameConductorService;

        // TODO(jorgen.fogh): Make the table name dynamic.
        private const string TableName = "Table";
        // TODO(jorgen.fogh): This only works, when there is only a single instance of WhistHub:
        private static readonly List<string> ConnectionIdsAtTable = new List<string>();

        public WhistHub(GameConductorService gameConductorService)
        {
            this._gameConductorService = gameConductorService;
        }

        public override async Task OnConnectedAsync()
        {
            await this.Groups.AddToGroupAsync(this.Context.ConnectionId, TableName);;
            ConnectionIdsAtTable.Add(this.Context.ConnectionId);
            if (ConnectionIdsAtTable.Count == 4)
                this._gameConductorService.StartGame(ConnectionIdsAtTable);
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
            this._gameConductorService.ReceiveBid(bid);
            await this.Clients.Group(TableName).ReceiveBid(user, bid);
        }

        public async Task SendTrump(string trump)
        {
            this._gameConductorService.ReceiveTrump(trump);
            await this.Clients.Group(TableName).ReceiveTrump(trump);
        }

        public async Task SendBuddyAce(string buddyAce)
        {
            this._gameConductorService.ReceiveBuddyAce(buddyAce);
            await this.Clients.Group(TableName).ReceiveBuddyAce(buddyAce);
        }
    }
}