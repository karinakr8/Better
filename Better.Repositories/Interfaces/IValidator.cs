using Better.Domain.Models;

namespace Better.Repositories.Interfaces
{
    public interface IValidator
    {
        void ValidateBet(BetRequest betRequest);
    }
}