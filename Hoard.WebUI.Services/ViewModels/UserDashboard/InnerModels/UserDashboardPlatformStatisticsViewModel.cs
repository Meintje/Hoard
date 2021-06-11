namespace Hoard.WebUI.Services.ViewModels.UserDashboard.InnerModels
{
    public class UserDashboardPlatformStatisticsViewModel
    {
        public int PlatformID { get; set; }
        public string PlatformName { get; set; }
        public string TotalGamesOwned { get; set; }

        public string FinishedGames { get; set; }
        public int FinishedGamesPercentage { get; set; }
        public string PlayedGames { get; set; }
        public int PlayedGamesPercentage { get; set; }
        public string UnplayedGames { get; set; }
        public int UnplayedGamesPercentage { get; set; }
        public string DroppedGames { get; set; }
        public int DroppedGamesPercentage { get; set; }
    }
}
