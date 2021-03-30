using Hoard.Core.Entities.Game;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hoard.Core.Interfaces
{
    public interface IPlatformDbService
    {
        public Task<IEnumerable<Platform>> GetAllAsync();
    }
}
