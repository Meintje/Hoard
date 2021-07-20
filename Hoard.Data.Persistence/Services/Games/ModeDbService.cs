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

        public async Task AddAsync(Mode mode)
        {
            context.Add(mode);

            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Mode mode)
        {
            context.Update(mode);

            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var mode = await context.Modes.Where(m => m.ID == id).FirstOrDefaultAsync();

            if (mode != null)
            {
                context.Modes.Remove(mode);
            }

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Mode>> GetAllAsync()
        {
            var modes = await context.Modes.OrderBy(p => p.Name).ToListAsync();

            return modes;
        }

        public async Task<Mode> GetUpdateDataAsync(int id)
        {
            var mode = await context.Modes
                .Where(m => m.ID == id)
                .FirstOrDefaultAsync();

            return mode;
        }

        public async Task<bool> CommandResultsInDuplicateEntryAsync(Mode mode)
        {
            var duplicateMode = await context.Modes
                .Where(m =>
                    m.ID != mode.ID &&
                    m.Name == mode.Name)
                .FirstOrDefaultAsync();

            if (duplicateMode != null)
            {
                return true;
            }

            return false;
        }
    }
}
