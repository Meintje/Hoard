using Hoard.Data.Entities.Game;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hoard.Data.Services.Interfaces
{
    public interface IGameDbService
    {
        public Task<ICollection<Game>> GetAllGames();
        public Task<Game> GetGameDetails(int id);
        public Task<ICollection<Game>> GetGamesByTitle(string title);
        public Task CreateGame(Game game);
        public Task UpdateGame(Game game);
        public Task DeleteGame(int id);

        public Task<ICollection<Platform>> GetAllPlatforms();

        public Task<Playthrough> GetPlaythroughDetails(int pdID, int ordinalNumber);
    }
}
