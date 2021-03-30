using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoard.WebUI.Services.ViewModels
{
    public class PlayDataUpdateViewModel
    {
        public int ID { get; set; }
        public int GameID { get; set; }
        public int PlayerID { get; set; }

        public bool Dropped { get; set; }
        public string Notes { get; set; }
    }
}
