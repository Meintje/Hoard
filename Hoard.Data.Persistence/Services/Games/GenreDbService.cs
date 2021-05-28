using Hoard.Core.Entities.Games;
using Hoard.Core.Interfaces.Games;
using Hoard.Infrastructure.Persistence.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hoard.Infrastructure.Persistence.Services.Games
{
    public class GenreDbService : IGenreDbService
    {
        private readonly HoardDbContext context;

        public GenreDbService(HoardDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Genre>> GetAllAsync()
        {
            var items = await context.Genres.OrderBy(g => g.Name).ToListAsync();

            return items;
        }
    }
}
