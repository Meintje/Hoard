using Hoard.Core.Entities.Game;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hoard.Core.Interfaces
{
    public interface IGenreDbService
    {
        public Task<IEnumerable<Genre>> GetAllAsync();
    }
}
