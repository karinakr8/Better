using Better.Domain.Entities;
using Better.Domain.Models;
using Better.Repositories.Interfaces;
using Better.Repositories.Utilities;

namespace Better.Repositories
{
    public class BetRepository : IBetRepository
    {        
        public async Task<Bet> AddBet(Bet bet) => await Helper.SaveBetToFile(bet);
        public async Task<List<BetLog>> GetAllBetsLogs()
        {
            var bets = await Helper.GetAllBetsFromFile();
            var betLogs = new List<BetLog>();

            foreach (var bet in bets)
            {
                betLogs.Add(new BetLog()
                {
                    BetId = bet.Id,
                    EventId = bet.Event.Id,
                    OddId = bet.Odd.Id,
                    ResultCode = bet.Result,
                });
            }

            return betLogs;
        }
    }
}
