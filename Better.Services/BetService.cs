using Better.Domain.Entities;
using Better.Domain.Models;
using Better.Repositories.Interfaces;
using Better.Services.Interfaces;

namespace Better.Services
{
    public class BetService : IBetService
    {
        private readonly IBetRepository _betRepository;

        public BetService(IBetRepository betRepository)
        {
            _betRepository = betRepository;
        }

        public async Task<Bet> AddBet(Bet bet) => await _betRepository.AddBet(bet);

        public async Task<List<BetLog>> GetAllBetsLogs() => await _betRepository.GetAllBetsLogs();
    }
}
