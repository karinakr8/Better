using Better.Domain.Entities;
using Better.Domain.Models;

namespace Better.Repositories.Interfaces
{
    public interface IBetRepository
    {
        Task<Bet> AddBet(Bet bet);
        Task<List<BetLog>> GetAllBetsLogs();
    }
}
