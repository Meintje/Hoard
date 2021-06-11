using Hoard.Core.Entities.Games;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hoard.Core.Interfaces.Games
{
    public interface IGameDbService
    {
        public Task AddAsync(Game game);
        public Task UpdateAsync(Game game);
        public Task DeleteAsync(int id);
        public Task<IEnumerable<Game>> GetAllAsync();
        public Task<IEnumerable<Game>> GetAllAsync(int hoarderID);
        public Task<Game> GetDetailsAsync(int id);
        public Task<Game> GetUpdateDataAsync(int id);
        public Task<IEnumerable<Game>> FindByTitleAsync(string title);
        public Task<bool> CommandResultsInDuplicateEntry(Game game);
    }
}
