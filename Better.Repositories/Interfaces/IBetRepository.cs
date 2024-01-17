using Better.Domain.Entities;
using Better.Domain.Models;

namespace Better.Repositories.Interfaces
{
    public interface IBetRepository
    {
        string AddBet(Bet bet, float odd);
        List<BetLog> GetAllBetsLogs();
    }
}
