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
                .Include(pt => pt.PlayData).ThenInclude(pd => pd.Player)
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
    }
}
