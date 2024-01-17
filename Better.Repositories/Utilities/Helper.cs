using Better.Domain.Entities;
using Newtonsoft.Json;

namespace Better.Repositories.Utilities
{
    public static class Helper
    {
        private static readonly string filePath = "BetterData/betsLogs.json";
        public static async Task<Bet> SaveBetToFile(Bet bet)
        {
            CreateFile();

            var jsonContent = await File.ReadAllTextAsync(filePath);
            var bets = JsonConvert.DeserializeObject<List<Bet>>(jsonContent) ?? new List<Bet>();

            bets.Add(bet);

            var updatedJson = JsonConvert.SerializeObject(bets, Formatting.Indented);

            await File.WriteAllTextAsync(filePath, updatedJson);

            return bet;
        }

        public static async Task<List<Bet>> GetAllBetsFromFile()
        {
            var jsonContent = await File.ReadAllTextAsync(filePath);

            return JsonConvert.DeserializeObject<List<Bet>>(jsonContent) ?? new List<Bet>();
        }

        private static async void CreateFile()
        {
            if (!File.Exists(filePath))
            {
                var emptyJsonArray = "[]";
                await File.WriteAllTextAsync(filePath, emptyJsonArray);
            }
        }
    }
}
