using Hoard.Core.Entities.Games;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hoard.Core.Interfaces.Games
{
    public interface IPlayStatusDbService
    {
        public Task CreateAsync(PlayStatus playStatus);
        public Task UpdateAsync(PlayStatus playStatus);
        public Task DeleteAsync(int id);
        public Task<IEnumerable<PlayStatus>> GetAllAsync();
        public Task<PlayStatus> GetUpdateDataAsync(int id);
        public Task<bool> CommandResultsInDuplicateEntryAsync(PlayStatus playStatus);
    }
}
