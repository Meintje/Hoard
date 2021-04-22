using Hoard.Core.Interfaces;
using Hoard.WebUI.Services.Interfaces;
using Hoard.WebUI.Services.Mapping;
using Hoard.WebUI.Services.ViewModels.Game.PlayDataDetails;
using Hoard.WebUI.Services.ViewModels.Game.PlayDataUpdate;
using Hoard.WebUI.Services.ViewModels.Game.Playthrough;
using System.Threading.Tasks;

namespace Hoard.WebUI.Services
{
    public class PlayDataViewService : IPlayDataViewService
    {
        private readonly IPlayDataDbService playDataDbService;
        private readonly IPlaythroughDbService playthroughDbService;
        private readonly IPlayStatusDbService playStatusDbService;

        public PlayDataViewService(IPlayDataDbService playDataDbService, IPlaythroughDbService playthroughDbService, IPlayStatusDbService playStatusDbService)
        {
            this.playDataDbService = playDataDbService;
            this.playthroughDbService = playthroughDbService;
            this.playStatusDbService = playStatusDbService;
        }

        public async Task<PlayDataDetailsViewModel> GetPlayDataDetails(int id)
        {
            var playData = await playDataDbService.GetDetailsAsync(id);

            return PlayDataMapper.ToDetailsViewModel(playData);
        }

        public async Task<PlayDataUpdateViewModel> GetPlayDataUpdateData(int id)
        {
            var playData = await playDataDbService.GetUpdateDataAsync(id);

            return PlayDataMapper.ToUpdateViewModel(playData);
        }

        public async Task UpdatePlayData(PlayDataUpdateViewModel playDataUpdateViewModel)
        {
            var playData = PlayDataMapper.ToPlayData(playDataUpdateViewModel);

            await playDataDbService.UpdateAsync(playData);
        }

        public async Task<PlaythroughCreateUpdateViewModel> GetPlaythroughCreateData(int playDataID)
        {
            var playStatusList = await playStatusDbService.GetAllAsync();

            var playthroughCreateVM = PlaythroughMapper.ToCreateViewModel(playDataID, playStatusList);

            return playthroughCreateVM;
        }

        public async Task<PlaythroughCreateUpdateViewModel> GetPlaythroughUpdateData(int playDataID, int ordinalNumber)
        {
            var playthrough = await playthroughDbService.GetUpdateDataAsync(playDataID, ordinalNumber);

            if (playthrough == null)
            {
                return null;
            }

            var playStatusList = await playStatusDbService.GetAllAsync();

            var playthroughUpdateVM = PlaythroughMapper.ToUpdateViewModel(playthrough, playStatusList);

            return playthroughUpdateVM;
        }

        public async Task CreatePlaythrough(PlaythroughCreateUpdateViewModel playthroughCreateViewModel)
        {
            var playthrough = PlaythroughMapper.ToPlaythrough(playthroughCreateViewModel);

            await playthroughDbService.CreateAsync(playthrough);
        }

        public async Task UpdatePlaythrough(PlaythroughCreateUpdateViewModel playthroughUpdateViewModel)
        {
            var playthrough = PlaythroughMapper.ToPlaythrough(playthroughUpdateViewModel);

            await playthroughDbService.UpdateAsync(playthrough);
        }

        public async Task<PlaythroughDeleteViewModel> GetPlaythroughDeleteData(int playDataID, int ordinalNumber)
        {
            var playthrough = await playthroughDbService.GetDetailsAsync(playDataID, ordinalNumber);

            if (playthrough == null)
            {
                return null;
            }

            return PlaythroughMapper.ToDeleteViewModel(playthrough);
        }

        public async Task DeletePlaythrough(PlaythroughDeleteViewModel playthroughDeleteViewModel)
        {
            await playthroughDbService.DeleteAsync(playthroughDeleteViewModel.PlayDataID, playthroughDeleteViewModel.OrdinalNumber);
        }
    }
}
