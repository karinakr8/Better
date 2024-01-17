using Better.Domain.Entities;
using Better.Domain.Models;

namespace Better.Services.Interfaces
{
    public interface IBetService
    {
        string AddBet(BetRequest betRequest);
        List<BetLog> GetAllBetsLogs();
    }
}