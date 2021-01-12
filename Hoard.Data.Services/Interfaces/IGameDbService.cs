using Hoard.Data.Entities.Game;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hoard.Data.Services.Interfaces
{
    public interface IGameDbService
    {
        public List<Game> GetAllGames();
        public Game GetGameByID(int id);
        public List<Game> GetGamesByTitle(string title);
        public void CreateGame(Game game);
        public void EditGame(Game game);
        public void DeleteGame(Game game);
    }
}
