using Hoard.Core.Entities.Game;
using Hoard.Core.Interfaces;
using Hoard.Data.Persistence.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoard.Infrastructure.Persistence.Services
{
    public class GameDbService : IGameDbService
    {
        private readonly HoardDbContext context;

        public GameDbService(HoardDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Game newGame)
        {
            context.Add(newGame);

            newGame.PlayData = new List<PlayData>();
            foreach (var user in context.Players)
            {
                newGame.PlayData.Add(new PlayData { CurrentlyPlaying = false, Dropped = false, PlayerID = user.ID, GameID = newGame.ID });
            }

            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Game updatedGame)
        {
            var oldGenres = await context.GameGenres.Where(gg => gg.GameID == updatedGame.ID).ToListAsync();
            UpdateManyToManyRelation(oldGenres, updatedGame.Genres);

            context.Update(updatedGame);

            await context.SaveChangesAsync();
        }

        private void UpdateManyToManyRelation<T>(IEnumerable<T> oldItems, IEnumerable<T> newItems) where T : class
        {
            context.RemoveRange(oldItems);
            context.AddRange(newItems);
        }

        public async Task DeleteAsync(int id)
        {
            var game = await context.Games.Where(g => g.ID == id).FirstOrDefaultAsync();

            context.Games.Remove(game);

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Game>> GetAllAsync()
        {
            var items = await context.Games
                .Include(g => g.Platform)
                .Include(g => g.Genres).ThenInclude(genre => genre.Genre)
                .OrderBy(g => g.Platform.Name)
                .ToListAsync();

            return items;
        }

        public async Task<Game> GetDetailsAsync(int id)
        {
            var item = await context.Games
                .Include(g => g.PlayData).ThenInclude(pd => pd.Playthroughs).ThenInclude(pt => pt.PlayStatus)
                .Include(g => g.PlayData).ThenInclude(pd => pd.Player)
                .Include(g => g.Platform)
                .Include(g => g.Genres).ThenInclude(genre => genre.Genre)
                .Where(g => g.ID == id)
                .FirstOrDefaultAsync();

            return item;
        }

        public async Task<Game> GetUpdateDataAsync(int id)
        {
            var item = await context.Games
                .Include(g => g.Genres)
                .Where(g => g.ID == id).FirstOrDefaultAsync();

            return item;
        }

        public async Task<IEnumerable<Game>> FindGamesByTitleAsync(string title)
        {
            var items = await context.Games.Where(g => g.Title == title).ToListAsync();

            return items;
        }
    }
}
