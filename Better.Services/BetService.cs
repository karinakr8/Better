using Better.Domain.Entities;
using Better.Domain.Models;
using Better.Repositories.Interfaces;
using Better.Services.Utilities;
using Better.Services.Interfaces;
using Better.Domain.Enums;

namespace Better.Services
{
    public class BetService : IBetService
    {
        private readonly IBetRepository _betRepository;

        public BetService(IBetRepository betRepository)
        {
            _betRepository = betRepository;
        }

        public string AddBet(BetRequest betRequest)
        {
            Validator.ValidateBet(betRequest);

            var bet = new Bet
            {
                EventId = betRequest.EventId,
                PlayerId = betRequest.PlayerId,
                Result = BetResult.Ongoing.ToString(),
            };


            return _betRepository.AddBet(bet, betRequest.Odd);
        }

        public List<BetLog> GetAllBetsLogs() => _betRepository.GetAllBetsLogs();
    }
}
