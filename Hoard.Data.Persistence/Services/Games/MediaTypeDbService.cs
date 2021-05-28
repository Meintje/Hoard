using Hoard.Core.Entities.Games;
using Hoard.Core.Interfaces.Games;
using Hoard.Infrastructure.Persistence.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hoard.Infrastructure.Persistence.Services.Games
{
    public class MediaTypeDbService : IMediaTypeDbService
    {
        private readonly HoardDbContext context;

        public MediaTypeDbService(HoardDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<MediaType>> GetAllAsync()
        {
            var items = await context.MediaTypes.OrderBy(p => p.Name).ToListAsync();

            return items;
        }
    }
}
