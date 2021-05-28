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

        public async Task<IEnumerable<PlayStatus>> GetAllAsync()
        {
            var items = await context.PlayStatuses.OrderBy(ps => ps.OrdinalNumber).ToListAsync();

            return items;
        }
    }
}
