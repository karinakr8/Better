using Better.Domain.Entities;
using Newtonsoft.Json;

namespace Better.Repositories.Utilities
{
    public static class Helper
    {
        private static readonly string betLogsFilePath = "BetterData/betsLogs.json";
        private static readonly string eventsFilePath = "BetterData/Events.json";
        private static readonly string playersFilePath = "BetterData/Players.json";
        public static Bet SaveBetToFile(Bet bet)
        {
            CreateFile();

            var jsonContent = File.ReadAllText(betLogsFilePath);
            var bets = JsonConvert.DeserializeObject<List<Bet>>(jsonContent) ?? new List<Bet>();

            bets.Add(bet);

            var updatedJson = JsonConvert.SerializeObject(bets, Formatting.Indented);

            File.WriteAllText(betLogsFilePath, updatedJson);

            return bet;
        }

        public static List<Bet> GetAllBetsFromFile()
        {
            return GetAllObjectsFromFile<Bet>(betLogsFilePath);
        }        

        public static List<Event> GetAllEventsFromFile()
        {
            return GetAllObjectsFromFile<Event>(eventsFilePath);
        }

        public static List<Player> GetAllPlayersFromFile()
        {
            return GetAllObjectsFromFile<Player>(playersFilePath);
        }

        private static List<T> GetAllObjectsFromFile<T>(string fileName)
        {
            if (!File.Exists(fileName))
            {
                return new List<T>();
            }

            var jsonContent =  File.ReadAllText(fileName);

            return JsonConvert.DeserializeObject<List<T>>(jsonContent) ?? new List<T>();
        }

        private static void CreateFile()
        {
            if (!File.Exists(betLogsFilePath))
            {
                var emptyJsonArray = "[]";
                File.WriteAllText(betLogsFilePath, emptyJsonArray);
            }
        }
    }
}
