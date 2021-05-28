using Hoard.Core.Entities.Games;
using Hoard.Core.Interfaces.Games;
using Hoard.Infrastructure.Persistence.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hoard.Infrastructure.Persistence.Services.Games
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
            foreach (var user in context.Hoarders.OrderBy(p => p.ID))
            {
                newGame.PlayData.Add(new PlayData { Dropped = false, AchievementsCompleted = false, HoarderID = user.ID, GameID = newGame.ID, OwnershipStatusID = 2, PriorityID = 3 });
            }

            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Game updatedGame)
        {
            var oldGenres = await context.GameGenres.Where(gg => gg.GameID == updatedGame.ID).ToListAsync();
            UpdateManyToManyRelation(oldGenres, updatedGame.Genres);

            var oldSeries = await context.GameSeries.Where(gg => gg.GameID == updatedGame.ID).ToListAsync();
            UpdateManyToManyRelation(oldSeries, updatedGame.Series);

            var oldModes = await context.GameModes.Where(gg => gg.GameID == updatedGame.ID).ToListAsync();
            UpdateManyToManyRelation(oldModes, updatedGame.Modes);

            var oldDevelopers = await context.GameDevelopers.Where(gg => gg.GameID == updatedGame.ID).ToListAsync();
            UpdateManyToManyRelation(oldDevelopers, updatedGame.Developers);

            var oldPublishers = await context.GamePublishers.Where(gg => gg.GameID == updatedGame.ID).ToListAsync();
            UpdateManyToManyRelation(oldPublishers, updatedGame.Publishers);

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

            if (game != null)
            {
                context.Games.Remove(game);
            }

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Game>> GetAllAsync()
        {
            var items = await context.Games
                .Include(g => g.Platform)
                .Include(g => g.Genres).ThenInclude(genre => genre.Genre)
                .Include(g => g.Modes).ThenInclude(m => m.Mode)
                .Include(g => g.Developers).ThenInclude(d => d.Developer)
                .Include(g => g.Publishers).ThenInclude(d => d.Publisher)
                .Include(g => g.PlayData).ThenInclude(pd => pd.Playthroughs).ThenInclude(pt => pt.PlayStatus)
                .Include(g => g.PlayData).ThenInclude(pd => pd.Priority)
                .OrderBy(g => g.Platform.Name).ThenBy(g => g.Title)
                .ToListAsync();

            return items;
        }

        public async Task<IEnumerable<Game>> GetAllAsync(int hoarderID)
        {
            var items = await context.Games
                .Include(g => g.Platform)
                .Include(g => g.Genres).ThenInclude(genre => genre.Genre)
                .Include(g => g.Modes).ThenInclude(m => m.Mode)
                .Include(g => g.Developers).ThenInclude(d => d.Developer)
                .Include(g => g.Publishers).ThenInclude(d => d.Publisher)
                .Include(g => g.PlayData.Where(pd => pd.HoarderID == hoarderID)).ThenInclude(pd => pd.Playthroughs).ThenInclude(pt => pt.PlayStatus)
                .Include(g => g.PlayData.Where(pd => pd.HoarderID == hoarderID)).ThenInclude(pd => pd.Priority)
                .OrderBy(g => g.Platform.Name).ThenBy(g => g.Title)
                .ToListAsync();

            return items;
        }

        public async Task<Game> GetDetailsAsync(int id)
        {
            var item = await context.Games
                .Include(g => g.Platform)
                .Include(g => g.Language)
                .Include(g => g.MediaType)
                .Include(g => g.Genres).ThenInclude(genre => genre.Genre)
                .Include(g => g.Modes).ThenInclude(m => m.Mode)
                .Include(g => g.Series).ThenInclude(s => s.Series)
                .Include(g => g.Developers).ThenInclude(d => d.Developer)
                .Include(g => g.Publishers).ThenInclude(p => p.Publisher)
                .Include(g => g.PlayData).ThenInclude(pd => pd.Playthroughs).ThenInclude(pt => pt.PlayStatus)
                .Include(g => g.PlayData).ThenInclude(pd => pd.Hoarder)
                .Include(g => g.PlayData).ThenInclude(pd => pd.Priority)
                .Include(g => g.PlayData).ThenInclude(pd => pd.OwnershipStatus)
                .Where(g => g.ID == id)
                .FirstOrDefaultAsync();

            return item;
        }

        public async Task<Game> GetUpdateDataAsync(int id)
        {
            var item = await context.Games
                .Include(g => g.Genres)
                .Include(g => g.Modes)
                .Include(g => g.Series)
                .Include(g => g.Developers)
                .Include(g => g.Publishers)
                .Where(g => g.ID == id)
                .FirstOrDefaultAsync();

            return item;
        }

        public async Task<IEnumerable<Game>> FindByTitleAsync(string title)
        {
            var items = await context.Games.Where(g => g.Title == title).ToListAsync(); // TODO: Add Include()s

            return items;
        }

        // TODO: Use Game as parameter instead
        public async Task<bool> CreateResultsInDuplicateEntry(string title, int platformID, int languageID, int mediaTypeID, DateTime releaseDate)
        {
            var item = await context.Games
                .Where(g =>
                    g.Title == title &&
                    g.PlatformID == platformID &&
                    g.LanguageID == languageID &&
                    g.MediaTypeID == mediaTypeID &&
                    g.ReleaseDate == releaseDate)
                .FirstOrDefaultAsync();

            if (item != null)
            {
                return true;
            }

            return false;
        }

        // TODO: Use Game as parameter instead
        public async Task<bool> UpdateResultsInDuplicateEntry(int id, string title, int platformID, int languageID, int mediaTypeID, DateTime releaseDate)
        {
            var item = await context.Games
                .Where(g =>
                    g.ID != id &&
                    g.Title == title &&
                    g.PlatformID == platformID &&
                    g.LanguageID == languageID &&
                    g.MediaTypeID == mediaTypeID &&
                    g.ReleaseDate == releaseDate)
                .FirstOrDefaultAsync();

            if (item != null)
            {
                return true;
            }

            return false;
        }
    }
}
