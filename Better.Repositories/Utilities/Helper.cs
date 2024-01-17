using Better.Domain.Entities;
using Better.Repositories.Interfaces;
using Newtonsoft.Json;

namespace Better.Repositories.Utilities
{
    public class Helper : IHelper
    {
        private readonly string betLogsFilePath = "BetterData/betsLogs.json";
        private readonly string eventsFilePath = "BetterData/Events.json";
        private readonly string playersFilePath = "BetterData/Players.json";

        public List<Bet> GetAllBetsFromFile() => GetAllObjectsFromFile<Bet>(betLogsFilePath);

        public List<Event> GetAllEventsFromFile() => GetAllObjectsFromFile<Event>(eventsFilePath);

        public List<Player> GetAllPlayersFromFile() => GetAllObjectsFromFile<Player>(playersFilePath);

        public void SaveBetToFile(Bet bet)
        {
            CreateFileIfDontExist(betLogsFilePath);

            SaveObjectToFile(betLogsFilePath, bet);
        }

        public void UpdatePlayerFile(Player outdatedPlayer, Player updatedPlayer)
        {
            if (!File.Exists(playersFilePath))
            {
                throw new ArgumentException($"No file by name {playersFilePath} was found");
            }

            UpdateObjecFile(playersFilePath, outdatedPlayer, updatedPlayer);
        }

        private List<T> GetAllObjectsFromFile<T>(string fileName)
        {
            if (!File.Exists(fileName))
            {
                return new List<T>();
            }

            var jsonContent = File.ReadAllText(fileName);

            return JsonConvert.DeserializeObject<List<T>>(jsonContent) ?? new List<T>();
        }

        private void CreateFileIfDontExist(string fileName)
        {
            if (!File.Exists(fileName))
            {
                var emptyJsonArray = "[]";
                File.WriteAllText(fileName, emptyJsonArray);
            }
        }

        private void SaveObjectToFile<T>(string fileName, T obj)
        {
            CreateFileIfDontExist(fileName);

            var jsonContent = File.ReadAllText(fileName);
            var objects = JsonConvert.DeserializeObject<List<T>>(jsonContent) ?? new List<T>();

            objects.Add(obj);

            var updatedJson = JsonConvert.SerializeObject(objects, Formatting.Indented);

            File.WriteAllText(fileName, updatedJson);
        }

        private void UpdateObjecFile<T>(string fileName, T outdatedObj, T updatedObj)
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
