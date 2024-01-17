using Better.Domain.Entities;
using Better.Domain.Models;

namespace Better.Services.Interfaces
{
    public interface IBetService
    {
        Task<Bet> AddBet(Bet bet);
        Task<List<BetLog>> GetAllBetsLogs();
    }
}