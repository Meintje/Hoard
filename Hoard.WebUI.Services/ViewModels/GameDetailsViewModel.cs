using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoard.WebUI.Services.ViewModels
{
    public class GameDetailsViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string ReleaseDate { get; set; }
        public List<PlayDataViewModel> PlayData { get; set; }
    }
}
