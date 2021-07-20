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
        private readonly IPlatformDbService platformDbService;

        public UserDashboardViewService(IPlayDataDbService playDataDbService, IPlaythroughDbService playthroughDbService,
            IWishlistDbService wishlistDbService, IJournalDbService journalDbService, IPlatformDbService platformDbService)
        {
            this.playDataDbService = playDataDbService;
            this.playthroughDbService = playthroughDbService;
            this.wishlistDbService = wishlistDbService;
            this.journalDbService = journalDbService;
            this.platformDbService = platformDbService;
        }

        public async Task<UserDashboardViewModel> GetUserDashboard(int hoarderID)
        {
            // TODO: Split into separate methods for each section of the dashboard?

            var recentlyStartedPlaythroughs = await playthroughDbService.GetUserRecentlyStartedPlaythroughs(hoarderID);
            var recentlyFinishedPlaythroughs = await playthroughDbService.GetUserRecentlyFinishedPlaythroughs(hoarderID);
            var recentJournalEntries = await journalDbService.GetRecentJournalEntriesAsync(hoarderID);

            var recentEvents = CreateRecentEventsList(recentlyStartedPlaythroughs, recentlyFinishedPlaythroughs, recentJournalEntries);

            var totalPlayTime = await playDataDbService.CountUserTotalPlaytime(hoarderID);
            var numberOfOwnedGames = await playDataDbService.CountUserOwnedGames(hoarderID);
            var numberOfDroppedGames = await playDataDbService.CountUserDroppedGames(hoarderID);
            var numberOfWishlistItems = await wishlistDbService.CountUserWishlistItems(hoarderID);

            var userDashboardVM = new UserDashboardViewModel
            {
                TotalPlaytime = PlaytimeHelper.GetLongPlaytimeString(totalPlayTime),
                NumberOfOwnedGames = numberOfOwnedGames.ToString(),
                NumberOfDroppedGames = numberOfDroppedGames.ToString(),
                NumberOfWishlistItems = numberOfWishlistItems.ToString(),
                RecentEvents = recentEvents
            };

            var currentPlaythroughs = await playthroughDbService.GetUserCurrentPlaythroughs(hoarderID);
            foreach (var pt in currentPlaythroughs)
            {
                userDashboardVM.CurrentGames.Add(UserDashboardMapper.ToGameViewModel(pt));
            }

            int finishedGamesTotal = 0;
            int playedGamesTotal = 0;
            int unplayedGamesTotal = 0;
            int droppedGamesTotal = 0;

            var platforms = await platformDbService.GetAllAsync();
            foreach (var platform in platforms)
            {
                int platformID = platform.ID;
                var platformStatisticsVM = UserDashboardMapper.ToPlatformStatisticsViewModel(platform);

                int finishedGames = await playDataDbService.CountUserFinishedGamesByPlatform(hoarderID, platformID);
                int playedGames = await playDataDbService.CountUserPlayedGamesByPlatform(hoarderID, platformID);
                int unplayedGames = await playDataDbService.CountUserUnplayedGamesByPlatform(hoarderID, platformID);
                int droppedGames = await playDataDbService.CountUserDroppedGamesByPlatform(hoarderID, platformID);

                int totalGames = finishedGames + playedGames + unplayedGames + droppedGames;

                if (totalGames > 0)
                {
                    int finishedGamesPercentage = CalculatePercentage(totalGames, finishedGames);
                    int playedGamesPercentage = CalculatePercentage(totalGames, playedGames);
                    int unplayedGamesPercentage = CalculatePercentage(totalGames, unplayedGames);
                    int droppedGamesPercentage = CalculatePercentage(totalGames, droppedGames);

                    platformStatisticsVM.TotalGamesOwned = totalGames.ToString();
                    platformStatisticsVM.FinishedGames = finishedGames.ToString();
                    platformStatisticsVM.FinishedGamesPercentage = finishedGamesPercentage;
                    platformStatisticsVM.PlayedGames = playedGames.ToString();
                    platformStatisticsVM.PlayedGamesPercentage = playedGamesPercentage;
                    platformStatisticsVM.UnplayedGames = unplayedGames.ToString();
                    platformStatisticsVM.UnplayedGamesPercentage = unplayedGamesPercentage;
                    platformStatisticsVM.DroppedGames = droppedGames.ToString();
                    platformStatisticsVM.DroppedGamesPercentage = droppedGamesPercentage;

                    userDashboardVM.PlatformStatistics.Add(platformStatisticsVM);

                    finishedGamesTotal += finishedGames;
                    playedGamesTotal += playedGames;
                    unplayedGamesTotal += unplayedGames;
                    droppedGamesTotal += droppedGames;
                }
            }

            int totalFinishedGamesPercentage = CalculatePercentage(numberOfOwnedGames, finishedGamesTotal);
            int totalPlayedGamesPercentage = CalculatePercentage(numberOfOwnedGames, playedGamesTotal);
            int totalUnplayedGamesPercentage = CalculatePercentage(numberOfOwnedGames, unplayedGamesTotal);
            int totalDroppedGamesPercentage = CalculatePercentage(numberOfOwnedGames, droppedGamesTotal);

            userDashboardVM.TotalGamesFinished = finishedGamesTotal.ToString();
            userDashboardVM.TotalGamesFinishedPercentage = totalFinishedGamesPercentage;
            userDashboardVM.TotalGamesPlayed = playedGamesTotal.ToString();
            userDashboardVM.TotalGamesPlayedPercentage = totalPlayedGamesPercentage;
            userDashboardVM.TotalGamesUnplayed = unplayedGamesTotal.ToString();
            userDashboardVM.TotalGamesUnplayedPercentage = totalUnplayedGamesPercentage;
            userDashboardVM.TotalGamesDropped = droppedGamesTotal.ToString();
            userDashboardVM.TotalGamesDroppedPercentage = totalDroppedGamesPercentage;

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

        private int CalculatePercentage(int total, int part)
        {
            if (part > 0)
            {
                return (int)System.Math.Ceiling((double)100 / ((double)total / (double)part));
            }

            return 0;
        }
    }
}
