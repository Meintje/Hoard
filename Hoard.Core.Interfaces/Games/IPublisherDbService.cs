using Hoard.Core.Entities.Games;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hoard.Core.Interfaces.Games
{
    public interface IPublisherDbService
    {
        public Task CreateAsync(Publisher publisher);
        public Task UpdateAsync(Publisher publisher);
        public Task DeleteAsync(int id);
        public Task<IEnumerable<Publisher>> GetAllAsync();
        public Task<Publisher> GetUpdateDataAsync(int id);
        public Task<bool> CommandResultsInDuplicateEntryAsync(Publisher publisher);
    }
}
