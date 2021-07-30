using Hoard.Core.Entities.Games;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hoard.Core.Interfaces.Games
{
    public interface IPriorityDbService
    {
        public Task CreateAsync(Priority priority);
        public Task UpdateAsync(Priority priority);
        public Task DeleteAsync(int id);
        public Task<IEnumerable<Priority>> GetAllAsync();
        public Task<Priority> GetUpdateDataAsync(int id);
        public Task<bool> CommandResultsInDuplicateEntryAsync(Priority priority);
    }
}
