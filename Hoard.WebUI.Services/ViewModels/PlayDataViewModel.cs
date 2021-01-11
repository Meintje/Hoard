using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoard.WebUI.Services.ViewModels
{
    public class PlayDataViewModel
    {
        public int GameID { get; set; }
        public int PlayerID { get; set; }
        public string Status { get; set; }
        public string PlayerName { get; set; }
    }
}
