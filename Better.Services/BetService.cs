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

            return _betRepository.AddBet(betRequest);
        }

        public List<BetLog> GetAllBetsLogs() => _betRepository.GetAllBetsLogs();
    }
}
