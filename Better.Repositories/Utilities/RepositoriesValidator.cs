using Better.Domain.Entities;
using Better.Domain.Models;
using Better.Repositories.Interfaces;

namespace Better.Repositories.Utilities
{
    public class RepositoriesValidator : IRepositoriesValidator
    {
        private readonly float liveEventTolerance = 0.1F;
        private readonly float regularEventTolerance = 0.05F;
        private readonly IHelper _helper;

        public RepositoriesValidator(IHelper helper)
        {
            _helper = helper;
        }

        public void ValidateBet(BetRequest betRequest)
        {
            ValidateEvent(betRequest.EventId);
            ValidateOdd(betRequest.Odd, betRequest.EventId);
            ValidatePlayer(betRequest.PlayerId);
            ValidatePlayerBalance(betRequest.PlayerId, betRequest.Price);
        }

        private void ValidateEvent(int eventId)
        {
            var events = _helper.GetAllEventsFromFile();

            if (!events.Any(e => e.Id == eventId))
            {
                throw new ArgumentException("Event does not exist.");
            }
        }

        private void ValidateOdd(float playerOdd, int eventId)
        {
            var events = _helper.GetAllEventsFromFile();

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

        private bool OddAccepted(float playerOdd, List<Odd> eventOdds, float tolerance)
        {
            foreach (var odd in eventOdds)
            {
                double lowerBound = odd.Value - (odd.Value * tolerance);
                double upperBound = odd.Value + (odd.Value * tolerance);

                if (playerOdd >= lowerBound && playerOdd <= upperBound)
                {
                    return true;
                }
            }

            return false;
        }

        private void ValidatePlayer(int playerId)
        {
            var players = _helper.GetAllPlayersFromFile();

            if (!players.Any(p => p.Id == playerId))
            {
                throw new ArgumentException("Player does not exist.");
            }
        }

        private void ValidatePlayerBalance(int playerId, float betPrice)
        {
            var players = _helper.GetAllPlayersFromFile();

            var playerBalance = players.FirstOrDefault(p => p.Id == playerId).Balance;

            if (playerBalance < betPrice)
            {
                throw new ArgumentException("Player balance is too low.");
            }
        }
    }
}
