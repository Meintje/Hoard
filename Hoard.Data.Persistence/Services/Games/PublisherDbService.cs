using Hoard.Core.Entities.Games;
using Hoard.Core.Interfaces.Games;
using Hoard.Infrastructure.Persistence.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hoard.Infrastructure.Persistence.Services.Games
{
    public class PublisherDbService : IPublisherDbService
    {
        private readonly HoardDbContext context;

        public PublisherDbService(HoardDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Publisher>> GetAllAsync()
        {
            var items = await context.Publishers.OrderBy(p => p.Name).ToListAsync();

            return items;
        }
    }
}
