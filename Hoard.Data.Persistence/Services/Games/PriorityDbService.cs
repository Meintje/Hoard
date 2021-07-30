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

        public async Task CreateAsync(Priority priority)
        {
            context.Add(priority);

            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Priority priority)
        {
            context.Update(priority);

            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var priority = await context.Priorities.Where(p => p.ID == id).FirstOrDefaultAsync();

            if (priority != null)
            {
                context.Priorities.Remove(priority);
            }

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Priority>> GetAllAsync()
        {
            var priorities = await context.Priorities.OrderBy(p => p.OrdinalNumber).ToListAsync();

            return priorities;
        }

        public async Task<Priority> GetUpdateDataAsync(int id)
        {
            var priority = await context.Priorities
                .Where(p => p.ID == id)
                .FirstOrDefaultAsync();

            return priority;
        }

        public async Task<bool> CommandResultsInDuplicateEntryAsync(Priority priority)
        {
            var duplicatePriority = await context.Priorities
                .Where(p =>
                    p.ID != priority.ID &&
                    (p.Name == priority.Name || p.OrdinalNumber == priority.OrdinalNumber))
                .FirstOrDefaultAsync();

            if (duplicatePriority != null)
            {
                return true;
            }

            return false;
        }
    }
}
