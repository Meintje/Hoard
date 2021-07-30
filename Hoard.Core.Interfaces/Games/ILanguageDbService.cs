using Hoard.Core.Entities.Games;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hoard.Core.Interfaces.Games
{
    public interface ILanguageDbService
    {
        public Task CreateAsync(Language language);
        public Task UpdateAsync(Language language);
        public Task DeleteAsync(int id);
        public Task<IEnumerable<Language>> GetAllAsync();
        public Task<Language> GetUpdateDataAsync(int id);
        public Task<bool> CommandResultsInDuplicateEntryAsync(Language language);
    }
}
