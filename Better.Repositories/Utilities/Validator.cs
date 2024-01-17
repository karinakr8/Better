using Better.Domain.Entities;
using Better.Domain.Enums;

namespace Better.Repositories.Utilities
{
    public class Validator
    {
        private static readonly float liveEventTolerance = 0.1F;
        private static readonly float regularEventTolerance = 0.05F;

        public static void ValidateBet(Bet bet, float odd)
        {
            ValidateEvent(bet.EventId);
            ValidateOdd(odd, bet.EventId);
            ValidatePlayer(bet.PlayerId);
            ValidateResult(bet.Result);
        }

        private static void ValidateEvent(int eventId)
        {
            var events = Helper.GetAllEventsFromFile();

            var eventDoesNotExist = !events.Any(e => e.Id == eventId);

            if (eventDoesNotExist)
            {
                throw new ArgumentException("Event does not exist.");
            }
        }

        private static void ValidateOdd(float playerOdd, int eventId)
        {
            var events = Helper.GetAllEventsFromFile();

            var betEvent = events.FirstOrDefault(e => e.Id == eventId);

            // For live events(IsLive - true), a tolerance of 10 % is accepted. (If the user's specified odds are within 10% of the actual odds, the system will accept the bet.)
            if (betEvent.IsLive & !OddAccepted(playerOdd, betEvent.Odds, liveEventTolerance))
            {
                throw new ArgumentException("Defined odd of live event was not accepted.");
            }

            // For pre-events (IsLive - false), a tolerance of 5% is accepted. (If the user's specified odds are within 5% of the actual odds, the system will accept the bet.)
            if (!betEvent.IsLive & !OddAccepted(playerOdd, betEvent.Odds, regularEventTolerance))
            {
                throw new ArgumentException("Defined odd of regular event was not accepted.");
            }
        }

        private static bool OddAccepted(float playerOdd, List<Odd> eventOdds, float tolerance)
        {
            foreach (var odd in eventOdds)
            {
                double lowerBound = odd.Value - (odd.Value * tolerance);
                double upperBound = odd.Value + (odd.Value * tolerance);

                if(playerOdd >= lowerBound && playerOdd <= upperBound)
                {
                    return true;
                }
            }

            return false;
        }

        private static void ValidatePlayer(int playerId)
        {
            var players = Helper.GetAllPlayersFromFile();

            var playerDoesNotExist = !players.Any(p => p.Id == playerId);

            if (playerDoesNotExist)
            {
                throw new ArgumentException("Player does not exist.");
            }
        }

        private static void ValidateResult(string result)
        {
            var valueIsIncorrect = !Enum.TryParse<BetResult>(result, out var _);

            if (valueIsIncorrect)
            {
                throw new ArgumentException("Result must be one of the defined values.");
            }
        }        
    }
}
