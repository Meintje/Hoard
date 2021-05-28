using Hoard.Core.Entities.Games;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hoard.Core.Interfaces.Games
{
    public interface ILanguageDbService
    {
        public Task<IEnumerable<Language>> GetAllAsync();
    }
}
