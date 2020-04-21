using System.Diagnostics;
using System.Net.Http.Headers;
using System.Threading.Tasks.Dataflow;

namespace Whist.Console
{
    using System;
    using System.Linq;
    using Rules;

    public static class Program
    {
        private static readonly string[] playerNames =
        {
            "Albert",
            "Bruno",
            "Charlie",
            "David"
        };

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the whist console!");
            Console.WriteLine("Dealing cards:");
            var deck = new Deck();
            foreach (var name in playerNames)
                DealCards(deck, name);
            var (winner, winningBid) = ConductBiddingRound();
            Console.WriteLine($"{playerNames[winner]} won the bid with {winningBid}");
            var trump = PromptForTrump(winner, winningBid);
            var ace = PromptForBuddyAce(winner, winningBid);
            // TODO(jorgen.fogh): Exchange cards.
            var round = new PlayingRound(CreateTrickEvaluator(winningBid, trump));
        }

        private static void DealCards(Deck deck, string playerName)
        {
            Console.Write($"Dealt cards to {playerName}: ");
            var cards = deck.DealCards(13);
            Console.WriteLine(string.Join(' ', cards));
        }

        private static string PromptForBuddyAce(int winner, string winningBid)
        {
            Console.WriteLine($"Prompt {playerNames[winner]} for buddy ace:");
            return Console.ReadLine();
        }

        private static char PromptForTrump(int winner, string winningBid)
        {
            if (winningBid.EndsWith("common"))
            {
                Console.WriteLine($"Prompt {playerNames[winner]} for trump:");
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
                Console.WriteLine($"Prompt {playerNames[round.PlayerToBid]} for bid:");
                var bid = Console.ReadLine();
                round.Bid(bid);
            }

            return (round.Winner, round.WinningBid);
        }
    }
}
