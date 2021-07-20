using Hoard.Core.Entities.Games;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hoard.Core.Interfaces.Games
{
    public interface IMediaTypeDbService
    {
        public Task AddAsync(MediaType mediaType);
        public Task UpdateAsync(MediaType mediaType);
        public Task DeleteAsync(int id);
        public Task<IEnumerable<MediaType>> GetAllAsync();
        public Task<MediaType> GetUpdateDataAsync(int id);
        public Task<bool> CommandResultsInDuplicateEntryAsync(MediaType mediaType);
    }
}
