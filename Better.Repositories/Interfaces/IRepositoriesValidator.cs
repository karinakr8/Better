using Better.Domain.Models;

namespace Better.Repositories.Interfaces
{
    public interface IRepositoriesValidator
    {
        void ValidateBet(BetRequest betRequest);
    }
}