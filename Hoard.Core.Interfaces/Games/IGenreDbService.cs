using Hoard.Core.Entities.Games;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hoard.Core.Interfaces.Games
{
    public interface IGenreDbService
    {
        public Task AddAsync(Genre genre);
        public Task UpdateAsync(Genre genre);
        public Task DeleteAsync(int id);
        public Task<IEnumerable<Genre>> GetAllAsync();
        public Task<Genre> GetUpdateDataAsync(int id);
        public Task<bool> CommandResultsInDuplicateEntryAsync(Genre genre);
    }
}
