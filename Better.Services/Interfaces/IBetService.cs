using Better.Domain.Entities;
using Better.Domain.Models;

namespace Better.Services.Interfaces
{
    public interface IBetService
    {
        Task<string> AddBet(Bet bet, float odd);
        Task<List<BetLog>> GetAllBetsLogs();
    }
}