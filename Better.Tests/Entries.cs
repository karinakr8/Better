using Better.Domain.Entities;
using Better.Domain.Models;

namespace Better.Tests
{
    public static class Entries
    {
        public enum BetResult
        {
            Ongoing,
            Won,
            Lost
        }

        public static Bet BetTest(
            int id = 1,
            int oddId = 111,
            float price = 11.10F,
            string result = "Ongoing")
        {
            return new Bet()
            {
                Id = id,
                Event = EventTest(),
                OddId = oddId,
                Player = PlayerTest(),
                Price = price,
                Result = result
            };
        }

        public static BetRequest BetRequestTest(
            int eventId = 11,
            float odd = 1.5F,
            int playerId = 1111,
            float price = 11.10F)
        {
            return new BetRequest()
            {
                EventId = eventId,
                Odd = odd,
                PlayerId = playerId,
                Price = price,
            };
        }

        public static BetLog BetLogTest(
            int betId = 1,
            int eventId = 11,
            int oddId = 111,
            string resultCode = "Ongoing")
        {
            return new BetLog()
            {
                BetId = betId,
                EventId = eventId,
                OddId = oddId,
                ResultCode = resultCode,
            };
        }

        public static Event EventTest(
            int id = 11,
            bool isLive = false)
        {
            return new Event()
            {
                Id = id,
                IsLive = isLive,
                StartTime = DateTime.Parse("2024-01-17T15:30:00"),
                Odds = new List<Odd> { OddTest() },
            };
        }
        
        public static Player PlayerTest(
            int id = 1111,
            float balance = 100.00F)
        {
            return new Player()
            {
                Id = id,
                Balance = balance
            };
        }

        public static Odd OddTest(
            int id = 111,
            float value = 1.5F)
        {
            return new Odd()
            {
                Id = id,
                Value = value
            };
        }
    }
}
