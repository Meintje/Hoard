using Hoard.Core.Entities.Games;
using Hoard.Core.Interfaces.Games;
using Hoard.Infrastructure.Persistence.DataAccess;
using Hoard.Infrastructure.Persistence.Services.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hoard.Infrastructure.Persistence.Services.Games
{
    public class GameDbService : BaseDbService, IGameDbService
    {
        public GameDbService(HoardDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Game game)
        {
            context.Add(game);

            game.PlayData = new List<PlayData>();
            foreach (var user in context.Hoarders.OrderBy(p => p.ID))
            {
                game.PlayData.Add(new PlayData { Dropped = false, AchievementsCompleted = false, HoarderID = user.ID, GameID = game.ID, OwnershipStatusID = 2, PriorityID = 3 });
            }

            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Game game)
        {
            var oldGenres = await context.GameGenres.Where(gg => gg.GameID == game.ID).ToListAsync();
            UpdateManyToManyRelation(oldGenres, game.Genres);

            var oldSeries = await context.GameSeries.Where(gg => gg.GameID == game.ID).ToListAsync();
            UpdateManyToManyRelation(oldSeries, game.Series);

            var oldModes = await context.GameModes.Where(gg => gg.GameID == game.ID).ToListAsync();
            UpdateManyToManyRelation(oldModes, game.Modes);

            var oldDevelopers = await context.GameDevelopers.Where(gg => gg.GameID == game.ID).ToListAsync();
            UpdateManyToManyRelation(oldDevelopers, game.Developers);

            var oldPublishers = await context.GamePublishers.Where(gg => gg.GameID == game.ID).ToListAsync();
            UpdateManyToManyRelation(oldPublishers, game.Publishers);

            context.Update(game);

            await context.SaveChangesAsync();
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

        public async Task<bool> CommandResultsInDuplicateEntry(Game game)
        {
            var item = await context.Games
                .Where(g =>
                    g.ID != game.ID &&
                    g.Title == game.Title &&
                    g.PlatformID == game.PlatformID &&
                    g.LanguageID == game.LanguageID &&
                    g.MediaTypeID == game.MediaTypeID &&
                    g.ReleaseDate == game.ReleaseDate)
                .FirstOrDefaultAsync();

            if (item != null)
            {
                return true;
            }

            return false;
        }
    }
}
