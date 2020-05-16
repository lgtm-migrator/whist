using System.Diagnostics;
using System.Net.Http.Headers;
using System.Threading.Tasks.Dataflow;

namespace Whist.Console
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Connections.Features;
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
            var connections = await Task.WhenAll(PlayerNames.Select(async player =>
                await OpenConnection(serverUri, player)));
            await Task.Delay(5000000);
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

            connection.On("PromptForBid", async () =>
                await connection.SendAsync("SendBid", playerName, PromptForBid(playerName)));
            connection.On("PromptForTrump", async () =>
                await connection.SendAsync("SendTrump", PromptForTrump(playerName)));
            connection.On("PromptForBuddyAce", async () =>
                await connection.SendAsync("SendBuddyAce", PromptForBuddyAce(playerName)));

            connection.On("ReceiveDealtCards", (List<string> cards) => WriteMessage("You were dealt the cards: " + string.Join(", ", cards)));
            connection.On("ReceiveBid", (string user, string bid) => WriteMessage($"Received bid \"{bid}\" from \"{user}.\""));
            connection.On("ReceiveTrump", (string trump) => WriteMessage($"The trump is {trump}."));
            connection.On("ReceiveBuddyAce", (string buddyAce) => WriteMessage($"The buddy ace is {buddyAce}."));
            await connection.StartAsync();
            Console.WriteLine("Connection opened.");
            return connection;
        }

        private static string PromptForBid(string playerName)
        {
            Console.WriteLine($"Prompt {playerName} for bid:");
            return Console.ReadLine();
        }

        private static string PromptForServerUrl()
        {
            Console.Write("Please input the base URL for the server:");
            return Console.ReadLine();
        }

        private static string PromptForTrump(string playerName)
        {
            Console.WriteLine($"Prompt {playerName} for trump:");
            var line = Console.ReadLine();
            Debug.Assert(line != null, nameof(line) + " != null");
            return line;
        }

        private static string PromptForBuddyAce(string playerName)
        {
            Console.WriteLine($"Prompt {playerName} for buddy ace:");
            return Console.ReadLine();
        }
    }
}
