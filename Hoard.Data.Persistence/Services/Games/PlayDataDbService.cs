using Hoard.Core.Entities.Games;
using Hoard.Core.Interfaces.Games;
using Hoard.Infrastructure.Persistence.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Hoard.Infrastructure.Persistence.Services.Games
{
    public class PlayDataDbService : IPlayDataDbService
    {
        private readonly HoardDbContext context;

        public PlayDataDbService(HoardDbContext context)
        {
            this.context = context;
        }

        public async Task<PlayData> GetDetailsAsync(int id)
        {
            var item = await context.PlayData
                .Include(pd => pd.Game)
                .Include(pd => pd.Hoarder)
                .Include(pd => pd.Priority)
                .Include(pd => pd.OwnershipStatus)
                .Include(pd => pd.Playthroughs.OrderBy(pt => pt.OrdinalNumber)).ThenInclude(pt => pt.PlayStatus)
                .Where(pd => pd.ID == id)
                .FirstOrDefaultAsync();

            return item;
        }

        public async Task<PlayData> GetUpdateDataAsync(int id)
        {
            var item = await context.PlayData
                .Include(pd => pd.Game)
                .Include(pd => pd.Hoarder)
                .Include(pd => pd.Playthroughs.OrderBy(pt => pt.OrdinalNumber)).ThenInclude(pt => pt.PlayStatus)
                .Where(pd => pd.ID == id)
                .FirstOrDefaultAsync();

            return item;
        }

        public async Task UpdateAsync(PlayData playData)
        {
            context.Update(playData);
            await context.SaveChangesAsync();
        }

        public async Task<int> CountUserOwnedGames(int hoarderID)
        {
            var userGames = await context.PlayData
                .Include(pd => pd.OwnershipStatus)
                .Where(pd => pd.HoarderID == hoarderID && pd.OwnershipStatus.OrdinalNumber <= 2)
                .CountAsync();

            return userGames;
        }

        public async Task<int> CountUserDroppedGames(int hoarderID)
        {
            var userGames = await context.PlayData
                .Include(pd => pd.OwnershipStatus)
                .Where(pd => pd.HoarderID == hoarderID && pd.OwnershipStatus.OrdinalNumber <= 2 && pd.Dropped)
                .CountAsync();

            return userGames;
        }

        public async Task<TimeSpan> CountUserTotalPlaytime(int hoarderID)
        {
            var totalPlaytime = new TimeSpan();

            var playData = await context.PlayData
                .Where(pd => pd.HoarderID == hoarderID)
                .Include(pd => pd.Playthroughs)
                .ToListAsync();

            foreach(var pd in playData)
            {
                totalPlaytime = totalPlaytime.Add(pd.TotalPlaytime);
            }

            return totalPlaytime;
        }

        public async Task<int> CountUserFinishedGamesByPlatform(int hoarderID, int platformID)
        {
            // Count user's PlayData set to owned/household and not dropped, belonging to a specific platform, that has finished/endless playthroughs
            int finishedGames = await context.PlayData
                .Include(pd => pd.Playthroughs).ThenInclude(pt => pt.PlayStatus)
                .Include(pd => pd.OwnershipStatus)
                .Include(pd => pd.Game)
                .Where(pd => 
                            pd.HoarderID == hoarderID &&
                            pd.Game.PlatformID == platformID &&
                            pd.OwnershipStatus.OrdinalNumber <= 2 &&
                            pd.Dropped == false &&
                            pd.Playthroughs.Any(pt => pt.PlayStatus.OrdinalNumber >= 4))
                .CountAsync();

            return finishedGames;
        }

        public async Task<int> CountUserPlayedGamesByPlatform(int hoarderID, int platformID)
        {
            // Count user's PlayData set to owned/household and not dropped, that has playing/hiatus/dropped playthroughs, belonging to a specific platform
            int playedGames = await context.PlayData
                .Include(pd => pd.Playthroughs).ThenInclude(pt => pt.PlayStatus)
                .Include(pd => pd.OwnershipStatus)
                .Include(pd => pd.Game)
                .Where(pd =>
                            pd.HoarderID == hoarderID &&
                            pd.Game.PlatformID == platformID &&
                            pd.OwnershipStatus.OrdinalNumber <= 2 &&
                            pd.Dropped == false &&
                            pd.Playthroughs.Any(pt => pt.PlayStatus.OrdinalNumber <= 3) &&
                            !pd.Playthroughs.Any(pt => pt.PlayStatus.OrdinalNumber >= 4))
                .CountAsync();

            return playedGames;
        }

        public async Task<int> CountUserUnplayedGamesByPlatform(int hoarderID, int platformID)
        {
            // TODO: Count user's PlayData set to owned/household and not dropped, that has no playthroughs, belonging to a specific platform
            int unplayedGames = await context.PlayData
                .Include(pd => pd.Playthroughs).ThenInclude(pt => pt.PlayStatus)
                .Include(pd => pd.OwnershipStatus)
                .Include(pd => pd.Game)
                .Where(pd =>
                            pd.HoarderID == hoarderID &&
                            pd.Game.PlatformID == platformID &&
                            pd.OwnershipStatus.OrdinalNumber <= 2 &&
                            pd.Dropped == false &&
                            pd.Playthroughs.Count == 0)
                .CountAsync();

            return unplayedGames;
        }

        public async Task<int> CountUserDroppedGamesByPlatform(int hoarderID, int platformID)
        {
            // Count user's PlayData set to owned/household and dropped, belonging to a specific platform
            int droppedGames = await context.PlayData
                .Include(pd => pd.OwnershipStatus)
                .Include(pd => pd.Game)
                .Where(pd =>
                            pd.HoarderID == hoarderID &&
                            pd.Game.PlatformID == platformID &&
                            pd.OwnershipStatus.OrdinalNumber <= 2 &&
                            pd.Dropped == true)
                .CountAsync();

            return droppedGames;
        }
    }
}
