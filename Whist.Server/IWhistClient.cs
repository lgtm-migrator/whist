namespace Whist.Server
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Rules;

    public interface IWhistClient
    {
        Task ReceiveBid(string user, string bid);
        Task ReceiveDealtCards(IEnumerable<string> cards);
    }
}