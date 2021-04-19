using Hoard.Core.Entities.Game;
using Hoard.Core.Interfaces;
using Hoard.WebUI.Services.Interfaces;
using Hoard.WebUI.Services.Mapping;
using Hoard.WebUI.Services.ViewModels.UserDashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

            var userDashboardVM = new UserDashboardViewModel
            {
                TotalNumberOfGames = "9999",
                TotalPlaytime = "9999 days, 99 hours, 99 minutes",
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

            if (recentEvents.Count > 5)
            {
                recentEvents.RemoveRange(5, recentEvents.Count - 5);
            }

            return recentEvents;
        }
    }
}
