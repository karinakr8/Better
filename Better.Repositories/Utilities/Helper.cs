using Better.Domain.Entities;
using Newtonsoft.Json;

namespace Better.Repositories.Utilities
{
    public static class Helper
    {
        private static readonly string betLogsFilePath = "BetterData/betsLogs.json";
        private static readonly string eventsFilePath = "BetterData/Events.json";
        private static readonly string playersFilePath = "BetterData/Players.json";

        public static Bet SaveBetToFile<Bet>(Bet bet)
        {
            CreateFile(betLogsFilePath);

            SaveObjectToFile(betLogsFilePath, bet);

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

        public static void UpdatePlayerFile(Player player, float betPrice)
        {
            if (!File.Exists(playersFilePath))
            {
                throw new ArgumentException($"No file by name {playersFilePath} was found");
            }
            
            var players = GetAllObjectsFromFile<Player>(playersFilePath);
            
            var playerToUpdate = players.FirstOrDefault(p => p.Id == player.Id);

            if (playerToUpdate == null)
            {
                throw new ArgumentException($"No player by id {player.Id} was found");
            }

            playerToUpdate.Balance -= betPrice;

            var updatedJson = JsonConvert.SerializeObject(players, Formatting.Indented);

            File.WriteAllText(playersFilePath, updatedJson);
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

        private static void CreateFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                var emptyJsonArray = "[]";
                File.WriteAllText(fileName, emptyJsonArray);
            }
        }

        private static void SaveObjectToFile<T>(string fileName, T obj)
        {
            CreateFile(fileName);

            var jsonContent = File.ReadAllText(fileName);
            var objects = JsonConvert.DeserializeObject<List<T>>(jsonContent) ?? new List<T>();

            objects.Add(obj);

            var updatedJson = JsonConvert.SerializeObject(objects, Formatting.Indented);

            File.WriteAllText(fileName, updatedJson);
        }
    }
}
