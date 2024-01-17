using Better.Domain.Entities;
using Better.Domain.Models;
using Better.Repositories.Interfaces;
using Better.Repositories.Utilities;

namespace Better.Repositories
{
    public class BetRepository : IBetRepository
    {
        public string AddBet(Bet bet, float odd)
        {
            Validator.ValidateBet(bet, odd);

            var allEvents = Helper.GetAllEventsFromFile();
            var betEvent = allEvents.FirstOrDefault(e => e.Id == bet.EventId);

            var betOdd = betEvent?.Odds?.OrderBy(o => Math.Abs(o.Value - odd)).First();
            bet.OddId = betOdd.Id;

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
                    EventId = bet.EventId,
                    OddId = bet.OddId,
                    ResultCode = bet.Result,
                });
            }

            return betLogs;
        }
    }
}
