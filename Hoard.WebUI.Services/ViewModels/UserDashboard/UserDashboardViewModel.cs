using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoard.WebUI.Services.ViewModels.UserDashboard
{
    public class UserDashboardViewModel
    {
        public UserDashboardViewModel()
        {
            CurrentGames = new List<UserDashboardGameViewModel>();
            RecentEvents = new List<UserDashboardEventViewModel>();
            ConsoleStatistics = new List<UserDashboardConsoleStatisticsViewModel>();
        }

        public ICollection<UserDashboardGameViewModel> CurrentGames { get; set; }
        public ICollection<UserDashboardEventViewModel> RecentEvents { get; set; }
        public ICollection<UserDashboardConsoleStatisticsViewModel> ConsoleStatistics { get; set; }

        public string TotalPlaytime { get; set; }
        public string TotalNumberOfGames { get; set; }
    }
}
