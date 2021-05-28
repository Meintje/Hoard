using Hoard.Core.Entities.Games;
using Hoard.Core.Interfaces.Games;
using Hoard.Infrastructure.Persistence.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hoard.Infrastructure.Persistence.Services.Games
{
    public class PriorityDbService : IPriorityDbService
    {
        private readonly HoardDbContext context;

        public PriorityDbService(HoardDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Priority>> GetAllAsync()
        {
            var items = await context.Priorities.OrderBy(p => p.OrdinalNumber).ToListAsync();

            return items;
        }
    }
}
