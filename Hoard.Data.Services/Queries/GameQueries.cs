using Hoard.Data.Persistence.DataAccess;
using Hoard.Data.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoard.Data.Services.Queries
{
    class GameQueries
    {
        private readonly HoardDbContext context;

        public GameQueries()
        {
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
    }
}
