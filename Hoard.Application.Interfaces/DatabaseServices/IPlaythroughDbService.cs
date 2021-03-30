using Hoard.Core.Entities.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoard.Core.Interfaces
{
    public interface IPlaythroughDbService
    {
        public Task<Playthrough> GetDetailsAsync(int playDataID, int ordinalNumber);
        public Task<Playthrough> GetUpdateDataAsync(int playDataID, int ordinalNumber);
        public Task CreateAsync(Playthrough playthrough);
        public Task UpdateAsync(Playthrough playthrough);
        public Task DeleteAsync(int playDataID, int ordinalNumber);
    }
}
