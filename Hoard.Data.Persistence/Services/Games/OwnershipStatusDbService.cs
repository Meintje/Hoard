using Hoard.Core.Entities.Games;
using Hoard.Core.Interfaces.Games;
using Hoard.Infrastructure.Persistence.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hoard.Infrastructure.Persistence.Services.Games
{
    public class OwnershipStatusDbService : IOwnershipStatusDbService
    {
        private readonly HoardDbContext context;

        public OwnershipStatusDbService(HoardDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<OwnershipStatus>> GetAllAsync()
        {
            var items = await context.OwnershipStatuses.OrderBy(o => o.OrdinalNumber).ToListAsync();

            return items;
        }
    }
}
