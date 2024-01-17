using Better.Domain.Models;
using Better.Services.Interfaces;

namespace Better.Services.Utilities
{
    public class Validator : IValidator
    {
        public void ValidateBet(BetRequest betRequest)
        {
            if (betRequest is null)
            {
                throw new ArgumentException("Bet parameters were defined incorrectly.");
            }

            ValidateEventId(betRequest.EventId);
            ValidatePlayerId(betRequest.PlayerId);
            ValidateOdd(betRequest.Odd);
            ValidatePrice(betRequest.Price);
        }

        private void ValidateOdd(float odd)
        {
            if (odd <= 0)
            {
                throw new ArgumentException("Odds can not have negative or zero value.");
            }
        }

        private void ValidateEventId(float eventId)
        {
            if (eventId <= 0)
            {
                throw new ArgumentException("Ids can not be negative or zero values. Please specify existing values.");
            }
        }

        private void ValidatePlayerId(float playerId)
        {
            if (playerId <= 0)
            {
                throw new ArgumentException("Ids can not be negative or zero values. Please specify existing values.");
            }
        }

        private void ValidatePrice(float betPrice)
        {
            if (betPrice <= 0)
            {
                throw new ArgumentException("Bet price can not be negative or zero value.");
            }
        }
    }
}
