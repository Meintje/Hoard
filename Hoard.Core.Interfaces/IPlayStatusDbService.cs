using Hoard.Core.Entities.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoard.Core.Interfaces
{
    public interface IPlayStatusDbService
    {
        public Task<IEnumerable<PlayStatus>> GetAllAsync();
    }
}
