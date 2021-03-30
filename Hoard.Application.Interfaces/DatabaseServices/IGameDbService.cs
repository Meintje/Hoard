using Hoard.Core.Entities.Game;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hoard.Core.Interfaces
{
    public interface IGameDbService
    {
        public Task AddAsync(Game game);
        public Task UpdateAsync(Game game);
        public Task DeleteAsync(int id);
        public Task<IEnumerable<Game>> GetAllAsync();
        public Task<Game> GetDetailsAsync(int id);
        public Task<Game> GetUpdateDataAsync(int id);
        public Task<IEnumerable<Game>> FindByTitleAsync(string title);
        public Task<bool> CreateResultsInDuplicateEntry(string title, int platformID, DateTime releaseDate); // TODO: Add languageID
        public Task<bool> UpdateResultsInDuplicateEntry(int id, string title, int platformID, DateTime releaseDate); // TODO: Add languageID

    }
}
