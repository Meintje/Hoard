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

        public async Task<Playthrough> GetPlaythroughDetails(int pdID, int ordinalNumber)
        {
            var item = await context.Playthroughs
                .Include(pt => pt.PlayStatus)
                .Include(pt => pt.PlayData).ThenInclude(pd => pd.Player)
                .Include(pt => pt.PlayData).ThenInclude(pd => pd.Game)
                .Where(pt => pt.PlayDataID == pdID && pt.OrdinalNumber == ordinalNumber).FirstOrDefaultAsync();

            return item;
        }
    }
}
