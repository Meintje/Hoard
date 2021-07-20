using Hoard.Core.Entities.Games;
using Hoard.Core.Interfaces.Games;
using Hoard.Infrastructure.Persistence.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hoard.Infrastructure.Persistence.Services.Games
{
    public class DeveloperDbService : IDeveloperDbService
    {
        private readonly HoardDbContext context;

        public DeveloperDbService(HoardDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Developer developer)
        {
            context.Add(developer);

            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Developer developer)
        {
            context.Update(developer);

            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var developer = await context.Developers.Where(d => d.ID == id).FirstOrDefaultAsync();

            if (developer != null)
            {
                context.Developers.Remove(developer);
            }

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Developer>> GetAllAsync()
        {
            var developers = await context.Developers.OrderBy(p => p.Name).ToListAsync();

            return developers;
        }

        public async Task<Developer> GetUpdateDataAsync(int id)
        {
            var developer = await context.Developers
                .Where(d => d.ID == id)
                .FirstOrDefaultAsync();

            return developer;
        }

        public async Task<bool> CommandResultsInDuplicateEntryAsync(Developer developer)
        {
            var duplicateDeveloper = await context.Developers
                .Where(d =>
                    d.ID != developer.ID &&
                    d.Name == developer.Name)
                .FirstOrDefaultAsync();

            if (duplicateDeveloper != null)
            {
                return true;
            }

            return false;
        }
    }
}
