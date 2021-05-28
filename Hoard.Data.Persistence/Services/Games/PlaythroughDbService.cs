using Hoard.Core.Entities.Games;
using Hoard.Core.Interfaces.Games;
using Hoard.Infrastructure.Persistence.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hoard.Infrastructure.Persistence.Services.Games
{
    public class PlaythroughDbService : IPlaythroughDbService
    {
        private readonly HoardDbContext context;

        public PlaythroughDbService(HoardDbContext context)
        {
            this.context = context;
        }
        
        public async Task<Playthrough> GetDetailsAsync(int playDataID, int ordinalNumber)
        {
            var item = await context.Playthroughs
                .Include(pt => pt.PlayStatus)
                .Include(pt => pt.PlayData).ThenInclude(pd => pd.Hoarder)
                .Include(pt => pt.PlayData).ThenInclude(pd => pd.Game)
                .Where(pt => pt.PlayDataID == playDataID && pt.OrdinalNumber == ordinalNumber).FirstOrDefaultAsync();

            return item;
        }

        public async Task<Playthrough> GetUpdateDataAsync(int playDataID, int ordinalNumber)
        {
            var item = await context.Playthroughs
                .Include(pt => pt.PlayStatus)
                .Where(pt => pt.PlayDataID == playDataID && pt.OrdinalNumber == ordinalNumber).FirstOrDefaultAsync();

            return item;
        }

        public async Task CreateAsync(Playthrough playthrough)
        {
            context.Add(playthrough);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Playthrough playthrough)
        {
            context.Update(playthrough);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int playDataID, int ordinalNumber)
        {
            var item = await context.Playthroughs
                .Where(pt => pt.PlayDataID == playDataID && pt.OrdinalNumber == ordinalNumber).FirstOrDefaultAsync();

            context.Remove(item);

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Playthrough>> GetRecentlyStartedPlaythroughs(int userID)
        {
            var items = await context.Playthroughs
                .Where(pt => pt.PlayData.HoarderID == userID && pt.DateStart != null)
                .OrderByDescending(pt => pt.DateStart)
                .Include(pt => pt.PlayData).ThenInclude(pd => pd.Game)
                .Take(15)
                .ToListAsync();

            return items;
        }

        public async Task<IEnumerable<Playthrough>> GetRecentlyFinishedPlaythroughs(int userID)
        {
            var items = await context.Playthroughs
                .Where(pt => pt.PlayData.HoarderID == userID && pt.DateEnd != null)
                .OrderByDescending(pt => pt.DateEnd)
                .Include(pt => pt.PlayData).ThenInclude(pd => pd.Game)
                .Take(15)
                .ToListAsync();

            return items;
        }

        public async Task<IEnumerable<Playthrough>> GetCurrentPlaythroughs(int userID)
        {
            var items = await context.Playthroughs
                .Where(pt => pt.PlayData.HoarderID == userID && pt.PlayStatus.OrdinalNumber == 1)
                .Include(pt => pt.PlayData).ThenInclude(pd => pd.Game).ThenInclude(g => g.Platform)
                .ToListAsync();

            return items;
        }
    }
}
