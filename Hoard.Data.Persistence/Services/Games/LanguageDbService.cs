using Hoard.Core.Entities.Games;
using Hoard.Core.Interfaces.Games;
using Hoard.Infrastructure.Persistence.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hoard.Infrastructure.Persistence.Services.Games
{
    public class LanguageDbService : ILanguageDbService
    {
        private readonly HoardDbContext context;

        public LanguageDbService(HoardDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Language>> GetAllAsync()
        {
            var items = await context.Languages.OrderBy(p => p.Name).ToListAsync();

            return items;
        }
    }
}
