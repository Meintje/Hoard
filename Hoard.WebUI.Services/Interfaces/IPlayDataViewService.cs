using Hoard.WebUI.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoard.WebUI.Services.Interfaces
{
    public interface IPlayDataViewService
    {
        public Task<PlayDataDetailsViewModel> GetPlayDataDetails(int id);
        public Task<PlayDataUpdateViewModel> GetPlayDataUpdateData(int id);
        public Task UpdatePlayData(PlayDataUpdateViewModel playDataUpdateViewModel);

        public Task<PlaythroughCreateUpdateViewModel> GetPlaythroughCreateData(int playDataID);
        public Task<PlaythroughCreateUpdateViewModel> GetPlaythroughUpdateData(int playDataID, int ordinalNumber);
        public Task CreatePlaythrough(PlaythroughCreateUpdateViewModel playthroughCreateViewModel);
        public Task UpdatePlaythrough(PlaythroughCreateUpdateViewModel playthroughUpdateViewModel);
        public Task<PlaythroughDeleteViewModel> GetPlaythroughDeleteData(int playDataID, int ordinalNumber);
        public Task DeletePlaythrough(PlaythroughDeleteViewModel playthroughDeleteViewModel);
    }
}
