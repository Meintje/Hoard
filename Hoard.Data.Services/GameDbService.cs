using Hoard.Data.Persistence.DataAccess;
using Hoard.Data.Entities.Game;
using Hoard.Data.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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

        public async Task<ICollection<Game>> GetAllGames()
        {
            var items = await _context.Games.ToListAsync();

            return items;
        }

        public async Task<Game> GetGameByID(int id)
        {
            var item = await _context.Games
                .Include(g => g.PlayData).ThenInclude(pd => pd.Playthroughs).ThenInclude(pt => pt.PlayStatus)
                .Include(g => g.PlayData).ThenInclude(pd => pd.Player)
                .Where(g => g.ID == id).FirstOrDefaultAsync();

            return item;
        }

        public async Task<ICollection<Game>> GetGamesByTitle(string title)
        {
            var items = await _context.Games.Where(g => g.Title == title).ToListAsync();

            return items;
        }

        public async Task CreateGame(Game game)
        {
            _context.Add(game);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateGame(Game game)
        {
            _context.Entry(game).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteGame(Game game)
        {
            _context.Games.Remove(game);

            await _context.SaveChangesAsync();
        }

        public async Task<Playthrough> GetPlaythroughByID(int pdID, int ordinalNumber)
        {
            var item = await _context.Playthroughs
                .Include(pt => pt.PlayStatus)
                .Include(pt => pt.PlayData).ThenInclude(pd => pd.Player)
                .Include(pt => pt.PlayData).ThenInclude(pd => pd.Game)
                .Where(pt => pt.PlayDataID == pdID && pt.OrdinalNumber == ordinalNumber).FirstOrDefaultAsync();

            return item;
        }
    }
}
