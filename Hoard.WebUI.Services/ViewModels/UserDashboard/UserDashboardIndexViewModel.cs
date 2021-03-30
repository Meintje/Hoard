using Hoard.WebUI.Services.ViewModels.UserDashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoard.WebUI.Services.ViewModels.Index
{
    public class UserDashboardIndexViewModel
    {
        public ICollection<UserDashboardGameViewModel> CurrentGames { get; set; }
        public ICollection<UserDashboardEventViewModel> RecentEvents { get; set; }
        public ICollection<UserDashboardConsoleStatisticsViewModel> ConsoleStatistics { get; set; }

        public string TotalPlaytime { get; set; }
        public string TotalNumberOfGames { get; set; }
    }
}
