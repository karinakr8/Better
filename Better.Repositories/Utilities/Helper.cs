using Better.Domain.Entities;
using Newtonsoft.Json;

namespace Better.Repositories.Utilities
{
    public static class Helper
    {
        private static readonly string betLogsFilePath = "BetterData/betsLogs.json";
        private static readonly string eventsFilePath = "BetterData/Events.json";
        private static readonly string playersFilePath = "BetterData/Players.json";
        public static async Task<Bet> SaveBetToFile(Bet bet)
        {
            CreateFile();

            var jsonContent = await File.ReadAllTextAsync(betLogsFilePath);
            var bets = JsonConvert.DeserializeObject<List<Bet>>(jsonContent) ?? new List<Bet>();

            bets.Add(bet);

            var updatedJson = JsonConvert.SerializeObject(bets, Formatting.Indented);

            await File.WriteAllTextAsync(betLogsFilePath, updatedJson);

            return bet;
        }

        public static async Task<List<Bet>> GetAllBetsFromFile()
        {
            return await GetAllObjectsFromFile<Bet>(betLogsFilePath);
        }        

        public static async Task<List<Event>> GetAllEventsFromFile()
        {
            return await GetAllObjectsFromFile<Event>(eventsFilePath);
        }

        public static async Task<List<Player>> GetAllPlayersFromFile()
        {
            return await GetAllObjectsFromFile<Player>(playersFilePath);
        }

        private static async Task<List<T>> GetAllObjectsFromFile<T>(string fileName)
        {
            if (!File.Exists(fileName))
            {
                return new List<T>();
            }

            var jsonContent = await File.ReadAllTextAsync(fileName);

            return JsonConvert.DeserializeObject<List<T>>(jsonContent) ?? new List<T>();
        }

        private static async void CreateFile()
        {
            if (!File.Exists(betLogsFilePath))
            {
                var emptyJsonArray = "[]";
                await File.WriteAllTextAsync(betLogsFilePath, emptyJsonArray);
            }
        }
    }
}
