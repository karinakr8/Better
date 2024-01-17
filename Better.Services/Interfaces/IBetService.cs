using Better.Domain.Entities;
using Better.Domain.Models;

namespace Better.Services.Interfaces
{
    public interface IBetService
    {
        string AddBet(Bet bet, float odd);
        List<BetLog> GetAllBetsLogs();
    }
}