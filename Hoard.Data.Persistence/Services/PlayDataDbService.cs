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
                .Include(pd => pd.Player)
                .Include(pd => pd.Playthroughs).ThenInclude(pt => pt.PlayStatus)
                .Where(pd => pd.ID == id)
                .FirstOrDefaultAsync();

            return item;
        }

        public async Task<PlayData> GetUpdateDataAsync(int id)
        {
            var item = await context.PlayData
                .Include(pd => pd.Game)
                .Include(pd => pd.Player)
                .Include(pd => pd.Playthroughs).ThenInclude(pt => pt.PlayStatus)
                .Where(pd => pd.ID == id)
                .FirstOrDefaultAsync();

            return item;
        }

        public async Task UpdateAsync(PlayData playData)
        {
            context.Update(playData);
            await context.SaveChangesAsync();
        }
    }
}
