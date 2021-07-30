using Hoard.Core.Entities.Games;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hoard.Core.Interfaces.Games
{
    public interface IPlatformDbService
    {
        public Task CreateAsync(Platform platform);
        public Task UpdateAsync(Platform platform);
        public Task DeleteAsync(int id);
        public Task<IEnumerable<Platform>> GetAllAsync();
        public Task<Platform> GetUpdateDataAsync(int id);
        public Task<bool> CommandResultsInDuplicateEntryAsync(Platform platform);
    }
}
