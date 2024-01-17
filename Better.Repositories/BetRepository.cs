using Better.Domain.Entities;
using Better.Domain.Enums;
using Better.Domain.Models;
using Better.Repositories.Interfaces;
using Better.Repositories.Utilities;

namespace Better.Repositories
{
    public class BetRepository : IBetRepository
    {
        public string AddBet(BetRequest betRequest)
        {
            Validator.ValidateBet(betRequest);            

            var allEvents = Helper.GetAllEventsFromFile();
            var betEvent = allEvents.FirstOrDefault(e => e.Id == betRequest.EventId);

            var allPlayers = Helper.GetAllPlayersFromFile();
            var betPlayer = allPlayers.FirstOrDefault(p => p.Id == betRequest.PlayerId);

            var bet = new Bet
            {
                Event = betEvent,
                Player = betPlayer,
                Result = BetResult.Ongoing.ToString(),
                Price = betRequest.Price
            };

            var betOdd = betEvent?.Odds?.OrderBy(o => Math.Abs(o.Value - betRequest.Odd)).First();
            bet.OddId = betOdd.Id;

            Validator.ValidateResult(bet.Result);

            Helper.UpdatePlayerFile(betPlayer, betRequest.Price);

            Helper.SaveBetToFile(bet);

            return "Bet was successfully placed.";
        }

        public List<BetLog> GetAllBetsLogs()
        {
            var bets = Helper.GetAllBetsFromFile();
            var betLogs = new List<BetLog>();

            foreach (var bet in bets)
            {
                betLogs.Add(new BetLog()
                {
                    BetId = bet.Id,
                    EventId = bet.Event.Id,
                    OddId = bet.OddId,
                    ResultCode = bet.Result,
                });
            }

            return betLogs;
        }
    }
}
