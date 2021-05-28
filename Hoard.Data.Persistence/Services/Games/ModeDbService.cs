using Hoard.Core.Entities.Games;
using Hoard.Core.Interfaces.Games;
using Hoard.Infrastructure.Persistence.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hoard.Infrastructure.Persistence.Services.Games
{
    public class ModeDbService : IModeDbService
    {
        private readonly HoardDbContext context;

        public ModeDbService(HoardDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Mode>> GetAllAsync()
        {
            var items = await context.Modes.OrderBy(p => p.Name).ToListAsync();

            return items;
        }
    }
}
