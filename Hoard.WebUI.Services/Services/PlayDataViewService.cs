using Hoard.Core.Interfaces.Games;
using Hoard.WebUI.Services.Interfaces;
using Hoard.WebUI.Services.Mapping.Games;
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
        private readonly IOwnershipStatusDbService ownershipStatusDbService;
        private readonly IPriorityDbService priorityDbService;

        public PlayDataViewService(IPlayDataDbService playDataDbService, IPlaythroughDbService playthroughDbService, IPlayStatusDbService playStatusDbService,
            IOwnershipStatusDbService ownershipStatusDbService, IPriorityDbService priorityDbService)
        {
            this.playDataDbService = playDataDbService;
            this.playthroughDbService = playthroughDbService;
            this.playStatusDbService = playStatusDbService;
            this.ownershipStatusDbService = ownershipStatusDbService;
            this.priorityDbService = priorityDbService;
        }

        public async Task<PlayDataDetailsViewModel> GetPlayDataDetailsAsync(int id)
        {
            var playData = await playDataDbService.GetDetailsAsync(id);

            return PlayDataMapper.ToDetailsViewModel(playData);
        }

        public async Task<PlayDataUpdateViewModel> GetPlayDataUpdateDataAsync(int id)
        {
            var playData = await playDataDbService.GetUpdateDataAsync(id);

            var ownershipStatusList = await ownershipStatusDbService.GetAllAsync();
            var priorityList = await priorityDbService.GetAllAsync();

            return PlayDataMapper.ToUpdateViewModel(playData, priorityList, ownershipStatusList);
        }

        public async Task UpdatePlayDataAsync(PlayDataUpdateViewModel playDataUpdateViewModel)
        {
            var playData = PlayDataMapper.ToPlayData(playDataUpdateViewModel);

            await playDataDbService.UpdateAsync(playData);
        }

        public async Task<PlaythroughCreateUpdateViewModel> GetPlaythroughCreateDataAsync(int playDataID)
        {
            var playStatusList = await playStatusDbService.GetAllAsync();

            var playthroughCreateVM = PlaythroughMapper.ToCreateViewModel(playDataID, playStatusList);

            return playthroughCreateVM;
        }

        public async Task<PlaythroughCreateUpdateViewModel> GetPlaythroughUpdateDataAsync(int playDataID, int ordinalNumber)
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

        public async Task CreatePlaythroughAsync(PlaythroughCreateUpdateViewModel playthroughCreateViewModel)
        {
            var playthrough = PlaythroughMapper.ToPlaythrough(playthroughCreateViewModel);

            await playthroughDbService.CreateAsync(playthrough);
        }

        public async Task UpdatePlaythroughAsync(PlaythroughCreateUpdateViewModel playthroughUpdateViewModel)
        {
            var playthrough = PlaythroughMapper.ToPlaythrough(playthroughUpdateViewModel);

            await playthroughDbService.UpdateAsync(playthrough);
        }

        public async Task<PlaythroughDeleteViewModel> GetPlaythroughDeleteDataAsync(int playDataID, int ordinalNumber)
        {
            var playthrough = await playthroughDbService.GetDetailsAsync(playDataID, ordinalNumber);

            if (playthrough == null)
            {
                return null;
            }

            return PlaythroughMapper.ToDeleteViewModel(playthrough);
        }

        public async Task DeletePlaythroughAsync(PlaythroughDeleteViewModel playthroughDeleteViewModel)
        {
            await playthroughDbService.DeleteAsync(playthroughDeleteViewModel.PlayDataID, playthroughDeleteViewModel.OrdinalNumber);
        }
    }
}
