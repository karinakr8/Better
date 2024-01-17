using Better.Domain.Models;

namespace Better.Services.Interfaces
{
    public interface IValidator
    {
        void ValidateBet(BetRequest betRequest);
    }
}