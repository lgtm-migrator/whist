using System.Diagnostics;
using System.Net.Http.Headers;
using System.Threading.Tasks.Dataflow;

namespace Whist.Console
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.SignalR.Client;
    using Rules;

    public static class Program
    {
        private static readonly string[] PlayerNames =
        {
            "Albert",
            "Bruno",
            "Charlie",
            "David"
        };

        static async Task Main(string[] args)
        {
            Console.WriteLine("Welcome to the whist console!");
            var serverUri = PromptForServerUrl() + "WhistHub";
            var connections = await Task.WhenAll(PlayerNames.Select(async player => await OpenConnection(serverUri, player)));
            var (winner, winningBid) = ConductBiddingRound();
            Console.WriteLine($"{PlayerNames[winner]} won the bid with {winningBid}");
            var trump = PromptForTrump(winner, winningBid);
            var ace = PromptForBuddyAce(winner, winningBid);
            // TODO(jorgen.fogh): Exchange cards.
            var round = new PlayingRound(CreateTrickEvaluator(winningBid, trump));
        }

        private static async Task<HubConnection> OpenConnection(string serverUri, string playerName)
        {
            void WriteMessage(string message)
            {
                Console.WriteLine($"{playerName} received message: {message}");
            }

            Console.WriteLine($"Opening a SignalR connection for {playerName}...");
            var connection = new HubConnectionBuilder()
                .WithUrl(serverUri)
                .Build();
            connection.On("ReceiveDealtCards", (List<string> cards) => WriteMessage("You were dealt the cards: " + string.Join(", ", cards)));
            await connection.StartAsync();
            Console.WriteLine("Connection opened.");
            return connection;
        }

        private static string PromptForServerUrl()
        {
            Console.Write("Please input the base URL for the server:");
            return Console.ReadLine();
        }

        private static string PromptForBuddyAce(int winner, string winningBid)
        {
            Console.WriteLine($"Prompt {PlayerNames[winner]} for buddy ace:");
            return Console.ReadLine();
        }

        private static char PromptForTrump(int winner, string winningBid)
        {
            if (winningBid.EndsWith("common"))
            {
                Console.WriteLine($"Prompt {PlayerNames[winner]} for trump:");
                var line = Console.ReadLine();
                Debug.Assert(line != null, nameof(line) + " != null");
                return line[0];
            }
            return 'C';
        }

        // TODO(jorgen.fogh): Move this factory method and test it!
        private static TrickEvaluator CreateTrickEvaluator(string winningBid, char trump)
        {
            var bidKind = winningBid.Split(' ')[1];
            return bidKind switch
            {
                // ReSharper disable once PossibleInvalidOperationException
                "common" => new CommonTrickEvaluator(trump),
                "good" => new CommonTrickEvaluator(trump),
                "sans" => new SansTrickEvaluator(),
                "solo" => new SoloTrickEvaluator(),
                _ => throw new Exception($"Invalid bid: {winningBid}.")
            };
        }

        private static (int Winner, string WinningBid) ConductBiddingRound()
        {
            var round = new BiddingRound();
            while (!round.IsBiddingDone)
            {
                Console.WriteLine($"Prompt {PlayerNames[round.PlayerToBid]} for bid:");
                var bid = Console.ReadLine();
                round.Bid(bid);
            }

            return (round.Winner, round.WinningBid);
        }
    }
}
