using System.Collections.Generic;
using Hoard.WebUI.Services.ViewModels.UserDashboard.InnerModels;

namespace Hoard.WebUI.Services.ViewModels.UserDashboard
{
    public class UserDashboardViewModel
    {
        public UserDashboardViewModel()
        {
            CurrentGames = new List<UserDashboardGameViewModel>();
            RecentEvents = new List<UserDashboardEventViewModel>();
            PlatformStatistics = new List<UserDashboardPlatformStatisticsViewModel>();
        }

        public ICollection<UserDashboardGameViewModel> CurrentGames { get; set; }
        public ICollection<UserDashboardEventViewModel> RecentEvents { get; set; }
        public ICollection<UserDashboardPlatformStatisticsViewModel> PlatformStatistics { get; set; }

        public string TotalPlaytime { get; set; }
        public string NumberOfOwnedGames { get; set; }
        public string NumberOfSoldGames { get; set; }
        public string NumberOfDroppedGames { get; set; }
        public string NumberOfWishlistItems { get; set; }

        public string TotalGamesFinished { get; set; }
        public int TotalGamesFinishedPercentage { get; set; }
        public string TotalGamesPlayed { get; set; }
        public int TotalGamesPlayedPercentage { get; set; }
        public string TotalGamesUnplayed { get; set; }
        public int TotalGamesUnplayedPercentage { get; set; }
        public string TotalGamesDropped { get; set; }
        public int TotalGamesDroppedPercentage { get; set; }
    }
}
