using Better.Domain.Entities;
using Newtonsoft.Json;

namespace Better.Repositories.Utilities
{
    public static class Helper
    {
        private static readonly string betLogsFilePath = "BetterData/betsLogs.json";
        private static readonly string eventsFilePath = "BetterData/Events.json";
        private static readonly string playersFilePath = "BetterData/Players.json";

        public static List<Bet> GetAllBetsFromFile() => GetAllObjectsFromFile<Bet>(betLogsFilePath);       

        public static List<Event> GetAllEventsFromFile() => GetAllObjectsFromFile<Event>(eventsFilePath);

        public static List<Player> GetAllPlayersFromFile() => GetAllObjectsFromFile<Player>(playersFilePath);

        public static void SaveBetToFile(Bet bet)
        {
            CreateFileIfDontExist(betLogsFilePath);

            SaveObjectToFile(betLogsFilePath, bet);
        }

        public static void UpdatePlayerFile(Player outdatedPlayer, Player updatedPlayer)
        {
            if (!File.Exists(playersFilePath))
            {
                throw new ArgumentException($"No file by name {playersFilePath} was found");
            }

            UpdateObjecFile(playersFilePath, outdatedPlayer, updatedPlayer);
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

        private static void CreateFileIfDontExist(string fileName)
        {
            if (!File.Exists(fileName))
            {
                var emptyJsonArray = "[]";
                File.WriteAllText(fileName, emptyJsonArray);
            }
        }

        private static void SaveObjectToFile<T>(string fileName, T obj)
        {
            CreateFileIfDontExist(fileName);

            var jsonContent = File.ReadAllText(fileName);
            var objects = JsonConvert.DeserializeObject<List<T>>(jsonContent) ?? new List<T>();

            objects.Add(obj);

            var updatedJson = JsonConvert.SerializeObject(objects, Formatting.Indented);

            File.WriteAllText(fileName, updatedJson);
        }

        private static void UpdateObjecFile<T>(string fileName, T outdatedObj, T updatedObj)
        {
            CreateFileIfDontExist(fileName);

            var jsonContent = File.ReadAllText(fileName);
            var objects = JsonConvert.DeserializeObject<List<T>>(jsonContent) ?? new List<T>();

            objects.Remove(outdatedObj);
            objects.Add(updatedObj);

            var updatedJson = JsonConvert.SerializeObject(objects, Formatting.Indented);

            File.WriteAllText(fileName, updatedJson);
        }
    }
}
