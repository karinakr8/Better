using Better.Domain.Models;

namespace Better.Services.Utilities
{
    public static class Validator
    {
        public static void ValidateBet(BetRequest betRequest)
        {
            if (betRequest is null)
            {
                throw new ArgumentException("Bet parameters were defined incorrectly.");
            }

            if (betRequest.EventId <= 0 || betRequest.PlayerId <= 0)
            {
                throw new ArgumentException("Ids can not be 0. Please specify existing values.");
            }

            ValidateOdd(betRequest.Odd);
        }

        private static void ValidateOdd(float odd)
        {
            if (odd < 0)
            {
                throw new ArgumentException("Odds can not have negative value.");
            }
        }
    }
}
