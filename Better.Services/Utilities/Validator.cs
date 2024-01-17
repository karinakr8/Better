using Better.Domain.Entities;

namespace Better.Services.Utilities
{
    public static class Validator
    {
        public static void ValidateBet(Bet bet)
        {
            if (bet is null || bet.Id == 0 || bet.EventId == 0 || bet.PlayerId == 0 || bet.Result is null)
            {
                throw new ArgumentException("Bet was defined incorrectly. Please specify all bet values.");
            }
        }

        public static void ValidateOdd(float odd)
        {
            if (odd < 0)
            {
                throw new ArgumentException("Odds can not have negative value.");
            }
        }
    }
}
