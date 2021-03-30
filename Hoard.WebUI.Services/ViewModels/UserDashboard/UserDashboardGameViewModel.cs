using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoard.WebUI.Services.ViewModels.UserDashboard
{
    public class UserDashboardGameViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Platform { get; set; }

        public string PlaythroughNotes { get; set; }
        public string PlaythroughURL { get; set; }
    }
}
