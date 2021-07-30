using Hoard.Core.Entities.Games;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hoard.Core.Interfaces.Games
{
    public interface IPlaythroughDbService
    {
        public Task<Playthrough> GetDetailsAsync(int playDataID, int ordinalNumber);
        public Task<Playthrough> GetUpdateDataAsync(int playDataID, int ordinalNumber);
        public Task CreateAsync(Playthrough playthrough);
        public Task UpdateAsync(Playthrough playthrough);
        public Task DeleteAsync(int playDataID, int ordinalNumber);
        public Task<IEnumerable<Playthrough>> GetUserRecentlyStartedPlaythroughsAsync(int playerID);
        public Task<IEnumerable<Playthrough>> GetUserRecentlyFinishedPlaythroughsAsync(int playerID);
        public Task<IEnumerable<Playthrough>> GetUserCurrentPlaythroughsAsync(int playerID);
    }
}
