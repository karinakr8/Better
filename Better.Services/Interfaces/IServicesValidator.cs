using Better.Domain.Models;

namespace Better.Services.Interfaces
{
    public interface IServicesValidator
    {
        void ValidateBet(BetRequest betRequest);
    }
}