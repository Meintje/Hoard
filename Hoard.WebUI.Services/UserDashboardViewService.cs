using Hoard.Core.Entities.Game;
using Hoard.Core.Interfaces;
using Hoard.WebUI.Services.Interfaces;
using Hoard.WebUI.Services.Mapping;
using Hoard.WebUI.Services.Mapping.Helpers;
using Hoard.WebUI.Services.ViewModels.UserDashboard;
using Hoard.WebUI.Services.ViewModels.UserDashboard.InnerModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hoard.WebUI.Services
{
    public class UserDashboardViewService : IUserDashboardViewService
    {
        private readonly IPlayDataDbService playDataDbService;
        private readonly IPlaythroughDbService playthroughDbService;

        public UserDashboardViewService(IPlayDataDbService playDataDbService, IPlaythroughDbService playthroughDbService)
        {
            this.playDataDbService = playDataDbService;
            this.playthroughDbService = playthroughDbService;
        }

        public async Task<UserDashboardViewModel> GetUserDashboard(int playerID)
        {
            var recentlyStartedPlaythroughs = await playthroughDbService.GetRecentlyStartedPlaythroughs(playerID);
            var recentlyFinishedPlaythroughs = await playthroughDbService.GetRecentlyFinishedPlaythroughs(playerID);

            var recentEvents = CreateRecentEventsList(recentlyStartedPlaythroughs, recentlyFinishedPlaythroughs);

            var totalNumberOfGames = await playDataDbService.CountUserGames(playerID);
            var totalPlayTime = await playDataDbService.CountUserTotalPlaytime(playerID);

            var userDashboardVM = new UserDashboardViewModel
            {
                TotalNumberOfGames = totalNumberOfGames.ToString(),
                TotalPlaytime = PlaytimeHelper.GetLongPlaytimeString(totalPlayTime),
                RecentEvents = recentEvents
            };

            var currentPlaythroughs = await playthroughDbService.GetCurrentPlaythroughs(playerID);
            foreach (var pt in currentPlaythroughs)
            {
                userDashboardVM.CurrentGames.Add(UserDashboardMapper.ToGameViewModel(pt));
            }

            return userDashboardVM;
        }

        private List<UserDashboardEventViewModel> CreateRecentEventsList(List<Playthrough> recentlyStartedPlaythroughs, List<Playthrough> recentlyFinishedPlaythroughs)
        {
            var recentEvents = new List<UserDashboardEventViewModel>();

            foreach (var pt in recentlyStartedPlaythroughs)
            {
                recentEvents.Add(UserDashboardMapper.StartedPlaythroughToRecentEvent(pt));
            }
            foreach (var pt in recentlyFinishedPlaythroughs)
            {
                recentEvents.Add(UserDashboardMapper.FinishedPlaythroughToRecentEvent(pt));
            }

            recentEvents.Sort((a, b) => a.Date.CompareTo(b.Date));
            recentEvents.Reverse();

            if (recentEvents.Count > 15)
            {
                recentEvents.RemoveRange(15, recentEvents.Count - 15);
            }

            return recentEvents;
        }
    }
}
