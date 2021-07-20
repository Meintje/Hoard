using Hoard.Core.Entities.Games;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hoard.Core.Interfaces.Games
{
    public interface IDeveloperDbService
    {
        public Task AddAsync(Developer developer);
        public Task UpdateAsync(Developer developer);
        public Task DeleteAsync(int id);
        public Task<IEnumerable<Developer>> GetAllAsync();
        public Task<Developer> GetUpdateDataAsync(int id);
        public Task<bool> CommandResultsInDuplicateEntryAsync(Developer developer);
    }
}
