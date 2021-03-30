using Hoard.Core.Entities.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoard.Core.Interfaces
{
    public interface IPlayDataDbService
    {
        public Task<PlayData> GetDetailsAsync(int id);
        public Task<PlayData> GetUpdateDataAsync(int id);
        public Task UpdateAsync(PlayData playData);
    }
}
