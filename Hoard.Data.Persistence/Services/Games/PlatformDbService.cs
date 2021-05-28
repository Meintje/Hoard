using Hoard.Core.Entities.Games;
using Hoard.Core.Interfaces.Games;
using Hoard.Infrastructure.Persistence.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hoard.Infrastructure.Persistence.Services.Games
{
    public class PlatformDbService : IPlatformDbService
    {
        private readonly HoardDbContext context;

        public PlatformDbService(HoardDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Platform>> GetAllAsync()
        {
            var items = await context.Platforms.OrderBy(p => p.Name).ToListAsync();

            return items;
        }
    }
}
