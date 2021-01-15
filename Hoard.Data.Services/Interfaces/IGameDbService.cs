using Hoard.Data.Entities.Game;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hoard.Data.Services.Interfaces
{
    public interface IGameDbService
    {
        public Task<ICollection<Game>> GetAllGames();
        public Task<Game> GetGameByID(int id);
        public Task<ICollection<Game>> GetGamesByTitle(string title);
        public Task CreateGame(Game game);
        public Task UpdateGame(Game game);
        public Task DeleteGame(Game game);
        public Task<Playthrough> GetPlaythroughByID(int pdID, int ordinalNumber);
    }
}
