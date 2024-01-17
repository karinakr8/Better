using Better.Domain.Entities;

namespace Better.Repositories.Interfaces
{
    public interface IHelper
    {
        List<Bet> GetAllBetsFromFile();
        List<Event> GetAllEventsFromFile();
        List<Player> GetAllPlayersFromFile();
        void SaveBetToFile(Bet bet);
        void UpdatePlayerFile(Player outdatedPlayer, Player updatedPlayer);
    }
}