using Better.Domain.Entities;
using Better.Domain.Models;

namespace Better.Repositories.Interfaces
{
    public interface IBetRepository
    {
        Task<string> AddBet(Bet bet, float odd);
        Task<List<BetLog>> GetAllBetsLogs();
    }
}
