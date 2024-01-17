using Better.Domain.Models;

namespace Better.Repositories.Interfaces
{
    public interface IBetRepository
    {
        string AddBet(BetRequest bet);
        List<BetLog> GetAllBetsLogs();
    }
}
