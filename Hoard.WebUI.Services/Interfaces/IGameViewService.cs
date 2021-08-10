using Hoard.WebUI.Services.ViewModels.Game.GameCreateUpdate;
using Hoard.WebUI.Services.ViewModels.Game.GameDetails;
using Hoard.WebUI.Services.ViewModels.Game.GameIndex;
using System.Threading.Tasks;

namespace Hoard.WebUI.Services.Interfaces
{
    public interface IGameViewService
    {
        public Task<GameIndexViewModel> GetGameIndexAsync(int hoarderID);
        public Task<GameDetailsViewModel> GetGameDetailsAsync(int id);
        public Task<GameCreateViewModel> GetGameCreateDataAsync();
        public Task<GameUpdateViewModel> GetGameUpdateDataAsync(int id);
        public Task CreateGameAsync(GameCreateViewModel gameCreateViewModel);
        public Task UpdateGameAsync(GameUpdateViewModel gameUpdateViewModel);
        public Task DeleteGameAsync(int id);
        public Task<bool> CreateResultsInDuplicateEntryAsync(GameCreateViewModel gameCreateViewModel);
        public Task<bool> UpdateResultsInDuplicateEntryAsync(GameUpdateViewModel gameUpdateViewModel);
        public Task<GameCreateViewModel> FillSelectLists(GameCreateViewModel gvm);
    }
}
