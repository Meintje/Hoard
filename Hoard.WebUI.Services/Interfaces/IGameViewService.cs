using Hoard.WebUI.Services.ViewModels.Game.GameCreateUpdate;
using Hoard.WebUI.Services.ViewModels.Game.GameDetails;
using Hoard.WebUI.Services.ViewModels.Game.GameIndex;
using System.Threading.Tasks;

namespace Hoard.WebUI.Services.Interfaces
{
    public interface IGameViewService
    {
        public Task<GameIndexViewModel> GetGameIndex();
        public Task<GameDetailsViewModel> GetGameDetails(int id);
        public Task<GameCreateViewModel> GetGameCreateData();
        public Task<GameUpdateViewModel> GetGameUpdateData(int id);
        public Task CreateGame(GameCreateViewModel gameCreateViewModel);
        public Task UpdateGame(GameUpdateViewModel gameUpdateViewModel);
        public Task DeleteGame(int id);
        public Task<bool> CreateResultsInDuplicateEntry(GameCreateViewModel gameCreateViewModel);
        public Task<bool> UpdateResultsInDuplicateEntry(GameUpdateViewModel gameUpdateViewModel);
    }
}
