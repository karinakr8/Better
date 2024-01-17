using Better.Domain.Entities;
using Better.Domain.Enums;
using Better.Domain.Models;
using Better.Repositories.Interfaces;

namespace Better.Repositories
{
    public class BetRepository : IBetRepository
    {
        private readonly IHelper _helper;
        private readonly IValidator _validator;

        public BetRepository(IHelper helper, IValidator validator)
        {
            _helper = helper;
            _validator = validator;
        }

        public string AddBet(BetRequest betRequest)
        {
            _validator.ValidateBet(betRequest);            

            var allEvents = _helper.GetAllEventsFromFile();
            var betEvent = allEvents.FirstOrDefault(e => e.Id == betRequest.EventId);

            var allPlayers = _helper.GetAllPlayersFromFile();
            var outdatedPlayer = allPlayers.FirstOrDefault(p => p.Id == betRequest.PlayerId);
            var updatedPlayer = new Player { Id = outdatedPlayer.Id, Balance = outdatedPlayer.Balance - betRequest.Price };

            _helper.UpdatePlayerFile(outdatedPlayer, updatedPlayer);

            var bet = new Bet
            {
                Event = betEvent,
                Player = updatedPlayer,
                Result = BetResult.Ongoing.ToString(),
                Price = betRequest.Price,
                OddId = betEvent.Odds.OrderBy(o => Math.Abs(o.Value - betRequest.Odd)).First().Id
            };

            _helper.SaveBetToFile(bet);

            return "Bet was successfully placed.";
        }

        public List<BetLog> GetAllBetsLogs()
        {
            var bets = _helper.GetAllBetsFromFile();
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
