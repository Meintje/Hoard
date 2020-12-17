using Hoard.Data.Persistence.DataAccess;
using Hoard.Data.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoard.Data.Services
{
    class GameService
    {
        private readonly HoardDbContext context;

        public GameService()
        {
            // How do I get access to the DbContext here, without doing this?
            context = new HoardDbContext();
        }

        public List<Game> GetGames()
        {
            return context.Games.ToList();
        }

        public Game GetGameByID(int id)
        {
            return context.Games.Find(id);
        }

        public List<Game> GetGamesByTitle(string title)
        {
            return context.Games.Where(g => g.Title == title).ToList();
        }

        public void CreateGame(Game game)
        {

        }

        public void EditGame(Game game)
        {

        }

        public void DeleteGame(Game game)
        {

        }
    }
}
