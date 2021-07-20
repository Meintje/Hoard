using Hoard.Core.Entities.Games;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hoard.Core.Interfaces.Games
{
    public interface IOwnershipStatusDbService
    {
        public Task AddAsync(OwnershipStatus ownershipStatus);
        public Task UpdateAsync(OwnershipStatus ownershipStatus);
        public Task DeleteAsync(int id);
        public Task<IEnumerable<OwnershipStatus>> GetAllAsync();
        public Task<OwnershipStatus> GetUpdateDataAsync(int id);
        public Task<bool> CommandResultsInDuplicateEntryAsync(OwnershipStatus ownershipStatus);
    }
}
