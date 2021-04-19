using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoard.WebUI.Services.ViewModels.UserDashboard
{
    public class UserDashboardGameViewModel
    {
        public int PlayDataID { get; set; }
        public int OrdinalNumber { get; set; }
        public string PlaythroughNotes { get; set; }

        public int GameID { get; set; }
        public string GameTitle { get; set; }
        public string GamePlatform { get; set; }
    }
}
