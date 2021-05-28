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

        public async Task<int> CountUserGames(int userID)
        {
            var userGames = await context.PlayData
                .Include(pd => pd.OwnershipStatus)
                .Where(pd => pd.HoarderID == userID && pd.OwnershipStatus.OrdinalNumber <= 2)
                .CountAsync();

            return userGames;
        }

        public async Task<TimeSpan> CountUserTotalPlaytime(int userID)
        {
            var totalPlaytime = new TimeSpan();

            var playData = await context.PlayData
                .Where(pd => pd.HoarderID == userID)
                .Include(pd => pd.Playthroughs)
                .ToListAsync();

            foreach(var pd in playData)
            {
                totalPlaytime = totalPlaytime.Add(pd.TotalPlaytime);
            }

            return totalPlaytime;
        }
    }
}
