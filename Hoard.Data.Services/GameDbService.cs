using Hoard.Data.Persistence.DataAccess;
using Hoard.Data.Entities.Game;
using Hoard.Data.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoard.Data.Services
{
    public class GameDbService : IGameDbService
    {
        private readonly HoardDbContext _context;

        public GameDbService(HoardDbContext context)
        {
            _context = context;
        }

        public List<Game> GetGames()
        {
            return _context.Games.ToList();
        }

        public Game GetGameByID(int id)
        {
            return _context.Games.Find(id);
        }

        public List<Game> GetGamesByTitle(string title)
        {
            return _context.Games.Where(g => g.Title == title).ToList();
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
