using Hoard.Core.Entities.Journal;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hoard.Core.Interfaces.Journal
{
    public interface ITagDbService
    {
        public Task CreateAsync(Tag tag);
        public Task UpdateAsync(Tag tag);
        public Task DeleteAsync(int id);
        public Task<IEnumerable<Tag>> GetAllAsync();
        public Task<Tag> GetUpdateDataAsync(int id);
        public Task<bool> CommandResultsInDuplicateEntryAsync(Tag tag);
    }
}
