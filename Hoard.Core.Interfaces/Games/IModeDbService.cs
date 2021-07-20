using Hoard.Core.Entities.Games;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hoard.Core.Interfaces.Games
{
    public interface IModeDbService
    {
        public Task AddAsync(Mode mode);
        public Task UpdateAsync(Mode mode);
        public Task DeleteAsync(int id);
        public Task<IEnumerable<Mode>> GetAllAsync();
        public Task<Mode> GetUpdateDataAsync(int id);
        public Task<bool> CommandResultsInDuplicateEntryAsync(Mode mode);
    }
}
