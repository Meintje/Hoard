using Hoard.Core.Entities.Games;
using Hoard.Core.Interfaces.Games;
using Hoard.Infrastructure.Persistence.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hoard.Infrastructure.Persistence.Services.Games
{
    public class PlayStatusDbService : IPlayStatusDbService
    {
        private readonly HoardDbContext context;

        public PlayStatusDbService(HoardDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(PlayStatus playStatus)
        {
            context.Add(playStatus);

            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(PlayStatus playStatus)
        {
            context.Update(playStatus);

            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var playStatus = await context.PlayStatuses.Where(ps => ps.ID == id).FirstOrDefaultAsync();

            if (playStatus != null)
            {
                context.PlayStatuses.Remove(playStatus);
            }

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PlayStatus>> GetAllAsync()
        {
            var playStatuses = await context.PlayStatuses.OrderBy(ps => ps.OrdinalNumber).ToListAsync();

            return playStatuses;
        }
        public async Task<PlayStatus> GetUpdateDataAsync(int id)
        {
            var playStatus = await context.PlayStatuses
                .Where(ps => ps.ID == id)
                .FirstOrDefaultAsync();

            return playStatus;
        }

        public async Task<bool> CommandResultsInDuplicateEntryAsync(PlayStatus playStatus)
        {
            var duplicatePlayStatus = await context.PlayStatuses
                .Where(ps =>
                    ps.ID != playStatus.ID &&
                    (ps.Name == playStatus.Name || ps.OrdinalNumber == playStatus.OrdinalNumber))
                .FirstOrDefaultAsync();

            if (duplicatePlayStatus != null)
            {
                return true;
            }

            return false;
        }
    }
}
