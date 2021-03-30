using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoard.WebUI.Services.ViewModels.UserDashboard
{
    public class UserDashboardConsoleStatisticsViewModel
    {
        public string ConsoleName { get; set; }
        public string TotalGames { get; set; }
        public string PlayedGames { get; set; }
        public string FinishedGames { get; set; }
    }
}
