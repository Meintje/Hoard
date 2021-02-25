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
        public Task<Playthrough> GetPlaythroughDetails(int pdID, int ordinalNumber);
    }
}
