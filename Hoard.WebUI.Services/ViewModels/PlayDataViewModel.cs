using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hoard.WebUI.Services.ViewModels
{
    public class PlayDataViewModel
    {
        public PlayDataViewModel()
        {
            Playthroughs = new List<PlaythroughDetailsViewModel>();
        }
        
        public int GameID { get; set; }
        public int PlayerID { get; set; }
        public string Status { get; set; }
        [Display(Name = "Player name")]
        public string PlayerName { get; set; }
        public string Notes { get; set; }

        public ICollection<PlaythroughDetailsViewModel> Playthroughs { get; set; }
    }
}
