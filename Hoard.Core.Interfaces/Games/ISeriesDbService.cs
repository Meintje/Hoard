using Hoard.Core.Entities.Games;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hoard.Core.Interfaces.Games
{
    public interface ISeriesDbService
    {
        public Task AddAsync(Series series);
        public Task UpdateAsync(Series series);
        public Task DeleteAsync(int id);
        public Task<IEnumerable<Series>> GetAllAsync();
        public Task<Series> GetUpdateDataAsync(int id);
        public Task<bool> CommandResultsInDuplicateEntryAsync(Series series);
    }
}
