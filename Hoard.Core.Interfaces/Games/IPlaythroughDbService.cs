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
        public Task<IEnumerable<Playthrough>> GetRecentlyStartedPlaythroughs(int playerID);
        public Task<IEnumerable<Playthrough>> GetRecentlyFinishedPlaythroughs(int playerID);
        public Task<IEnumerable<Playthrough>> GetCurrentPlaythroughs(int playerID);
    }
}
