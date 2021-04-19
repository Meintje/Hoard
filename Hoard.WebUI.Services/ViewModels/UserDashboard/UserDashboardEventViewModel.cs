using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoard.WebUI.Services.ViewModels.UserDashboard
{
    public class UserDashboardEventViewModel
    {
        public DateTime Date { get; set; }
        public string DateString { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string URL { get; set; }
    }
}
