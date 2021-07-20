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

        public async Task AddAsync(OwnershipStatus ownershipStatus)
        {
            context.Add(ownershipStatus);

            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(OwnershipStatus ownershipStatus)
        {
            context.Update(ownershipStatus);

            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var ownershipStatus = await context.OwnershipStatuses.Where(os => os.ID == id).FirstOrDefaultAsync();

            if (ownershipStatus != null)
            {
                context.OwnershipStatuses.Remove(ownershipStatus);
            }

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<OwnershipStatus>> GetAllAsync()
        {
            var ownershipStatuses = await context.OwnershipStatuses.OrderBy(os => os.OrdinalNumber).ToListAsync();

            return ownershipStatuses;
        }

        public async Task<OwnershipStatus> GetUpdateDataAsync(int id)
        {
            var ownershipStatus = await context.OwnershipStatuses
                .Where(os => os.ID == id)
                .FirstOrDefaultAsync();

            return ownershipStatus;
        }

        public async Task<bool> CommandResultsInDuplicateEntryAsync(OwnershipStatus ownershipStatus)
        {
            var duplicateOwnershipStatus = await context.OwnershipStatuses
                .Where(os =>
                    os.ID != ownershipStatus.ID &&
                    (os.Name == ownershipStatus.Name || os.OrdinalNumber == ownershipStatus.OrdinalNumber))
                .FirstOrDefaultAsync();

            if (duplicateOwnershipStatus != null)
            {
                return true;
            }

            return false;
        }
    }
}
