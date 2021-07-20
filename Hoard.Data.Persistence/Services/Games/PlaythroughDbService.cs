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
            var playthrough = await context.Playthroughs
                .Include(pt => pt.PlayStatus)
                .Include(pt => pt.PlayData).ThenInclude(pd => pd.Hoarder)
                .Include(pt => pt.PlayData).ThenInclude(pd => pd.Game)
                .Where(pt => pt.PlayDataID == playDataID && pt.OrdinalNumber == ordinalNumber).FirstOrDefaultAsync();

            return playthrough;
        }

        public async Task<Playthrough> GetUpdateDataAsync(int playDataID, int ordinalNumber)
        {
            var playthrough = await context.Playthroughs
                .Include(pt => pt.PlayStatus)
                .Where(pt => pt.PlayDataID == playDataID && pt.OrdinalNumber == ordinalNumber).FirstOrDefaultAsync();

            return playthrough;
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
            var playthrough = await context.Playthroughs
                .Where(pt => pt.PlayDataID == playDataID && pt.OrdinalNumber == ordinalNumber).FirstOrDefaultAsync();

            if (playthrough != null)
            {
                context.Remove(playthrough);
            }

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Playthrough>> GetUserRecentlyStartedPlaythroughs(int hoarderID)
        {
            var recentlyStartedPlaythroughs = await context.Playthroughs
                .Where(pt => pt.PlayData.HoarderID == hoarderID && pt.DateStart != null)
                .OrderByDescending(pt => pt.DateStart)
                .Include(pt => pt.PlayData).ThenInclude(pd => pd.Game)
                .Take(15)
                .ToListAsync();

            return recentlyStartedPlaythroughs;
        }

        public async Task<IEnumerable<Playthrough>> GetUserRecentlyFinishedPlaythroughs(int hoarderID)
        {
            var recentlyFinishedPlaythroughs = await context.Playthroughs
                .Where(pt => pt.PlayData.HoarderID == hoarderID && pt.DateEnd != null)
                .OrderByDescending(pt => pt.DateEnd)
                .Include(pt => pt.PlayData).ThenInclude(pd => pd.Game)
                .Take(15)
                .ToListAsync();

            return recentlyFinishedPlaythroughs;
        }

        public async Task<IEnumerable<Playthrough>> GetUserCurrentPlaythroughs(int hoarderID)
        {
            var currentPlaythroughs = await context.Playthroughs
                .Where(pt => pt.PlayData.HoarderID == hoarderID && pt.PlayStatus.OrdinalNumber == 1)
                .Include(pt => pt.PlayData).ThenInclude(pd => pd.Game).ThenInclude(g => g.Platform)
                .ToListAsync();

            return currentPlaythroughs;
        }
    }
}
