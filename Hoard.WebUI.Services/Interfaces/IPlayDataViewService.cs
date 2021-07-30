using Hoard.WebUI.Services.ViewModels.Game.PlayDataDetails;
using Hoard.WebUI.Services.ViewModels.Game.PlayDataUpdate;
using Hoard.WebUI.Services.ViewModels.Game.Playthrough;
using System.Threading.Tasks;

namespace Hoard.WebUI.Services.Interfaces
{
    public interface IPlayDataViewService
    {
        public Task<PlayDataDetailsViewModel> GetPlayDataDetailsAsync(int id);
        public Task<PlayDataUpdateViewModel> GetPlayDataUpdateDataAsync(int id);
        public Task UpdatePlayDataAsync(PlayDataUpdateViewModel playDataUpdateViewModel);

        public Task<PlaythroughCreateUpdateViewModel> GetPlaythroughCreateDataAsync(int playDataID);
        public Task<PlaythroughCreateUpdateViewModel> GetPlaythroughUpdateDataAsync(int playDataID, int ordinalNumber);
        public Task CreatePlaythroughAsync(PlaythroughCreateUpdateViewModel playthroughCreateViewModel);
        public Task UpdatePlaythroughAsync(PlaythroughCreateUpdateViewModel playthroughUpdateViewModel);
        public Task<PlaythroughDeleteViewModel> GetPlaythroughDeleteDataAsync(int playDataID, int ordinalNumber);
        public Task DeletePlaythroughAsync(PlaythroughDeleteViewModel playthroughDeleteViewModel);
    }
}
