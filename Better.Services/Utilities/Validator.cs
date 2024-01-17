using Better.Domain.Models;
using System.Net;

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
            
            ValidateEventId(betRequest.EventId);
            ValidatePlayerId(betRequest.PlayerId);
            ValidateOdd(betRequest.Odd);
            ValidatePrice(betRequest.Price);
        }

        private static void ValidateOdd(float odd)
        {
            if (odd < 0)
            {
                throw new ArgumentException("Odds can not have negative value.");
            }
        }

        private static void ValidateEventId(float eventId)
        {
            if (eventId <= 0)
            {
                throw new ArgumentException("Ids can not be 0. Please specify existing values.");
            }
        }

        private static void ValidatePlayerId(float playerId)
        {
            if (playerId <= 0)
            {
                throw new ArgumentException("Ids can not be 0. Please specify existing values.");
            }
        }

        private static void ValidatePrice(float betPrice)
        {
            if (betPrice <= 0)
            {
                throw new ArgumentException("Bet price can not be negative or zero value.");
            }
        }
    }
}
