using Better.Domain.Entities;
using Better.Domain.Models;
using Better.Repositories.Interfaces;
using Better.Services.Utilities;
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

        public async Task<string> AddBet(Bet bet, float odd)
        {
            try
            {
                Validator.ValidateBet(bet);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return await _betRepository.AddBet(bet, odd);
        }

        public async Task<List<BetLog>> GetAllBetsLogs() => await _betRepository.GetAllBetsLogs();
    }
}
