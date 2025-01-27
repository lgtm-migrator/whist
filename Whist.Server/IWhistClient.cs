namespace Whist.Server
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IWhistClient : ILobbyClient
    {
        Task PromptForBid();
        Task PromptForTrump();
        Task PromptForBuddyAce();
        Task ReceiveDealtCards(IEnumerable<string> cards);
        Task ReceiveBid(string user, string bid);
        Task ReceiveTrump(string trump);
        Task ReceiveBuddyAce(string buddyAce);
    }
}