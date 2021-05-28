using Hoard.Core.Entities.Games;
using Hoard.Core.Entities.Journal;
using Hoard.Core.Interfaces.Games;
using Hoard.Core.Interfaces.Journal;
using Hoard.Core.Interfaces.Wishlist;
using Hoard.WebUI.Services.Interfaces;
using Hoard.WebUI.Services.Mapping.Helpers;
using Hoard.WebUI.Services.Mapping.UserDashboard;
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
        private readonly IWishlistDbService wishlistDbService;
        private readonly IJournalDbService journalDbService;

        public UserDashboardViewService(IPlayDataDbService playDataDbService, IPlaythroughDbService playthroughDbService,
            IWishlistDbService wishlistDbService, IJournalDbService journalDbService)
        {
            this.playDataDbService = playDataDbService;
            this.playthroughDbService = playthroughDbService;
            this.wishlistDbService = wishlistDbService;
            this.journalDbService = journalDbService;
        }

        public async Task<UserDashboardViewModel> GetUserDashboard(int hoarderID)
        {
            var recentlyStartedPlaythroughs = await playthroughDbService.GetRecentlyStartedPlaythroughs(hoarderID);
            var recentlyFinishedPlaythroughs = await playthroughDbService.GetRecentlyFinishedPlaythroughs(hoarderID);
            var recentJournalEntries = await journalDbService.GetRecentJournalEntriesAsync(hoarderID);

            var recentEvents = CreateRecentEventsList(recentlyStartedPlaythroughs, recentlyFinishedPlaythroughs, recentJournalEntries);

            var totalNumberOfGames = await playDataDbService.CountUserGames(hoarderID);
            var totalPlayTime = await playDataDbService.CountUserTotalPlaytime(hoarderID);
            var itemsOnWishlist = await wishlistDbService.CountUserWishlistItems(hoarderID);

            var userDashboardVM = new UserDashboardViewModel
            {
                TotalNumberOfGames = totalNumberOfGames.ToString(),
                TotalPlaytime = PlaytimeHelper.GetLongPlaytimeString(totalPlayTime),
                NumberOfWishlistItems = itemsOnWishlist.ToString(),
                RecentEvents = recentEvents
            };

            var currentPlaythroughs = await playthroughDbService.GetCurrentPlaythroughs(hoarderID);
            foreach (var pt in currentPlaythroughs)
            {
                userDashboardVM.CurrentGames.Add(UserDashboardMapper.ToGameViewModel(pt));
            }

            return userDashboardVM;
        }

        private List<UserDashboardEventViewModel> CreateRecentEventsList(IEnumerable<Playthrough> recentlyStartedPlaythroughs, IEnumerable<Playthrough> recentlyFinishedPlaythroughs,
            IEnumerable<JournalEntry> recentJournalEntries)
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
            foreach (var je in recentJournalEntries)
            {
                recentEvents.Add(UserDashboardMapper.JournalEntryToRecentEvent(je));
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
