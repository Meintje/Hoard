using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hoard.WebUI.Services.ViewModels.Game.GameDetails.InnerModels
{
    public class GamePlayDataDetailsViewModel
    {
        public GamePlayDataDetailsViewModel()
        {
            Playthroughs = new List<GamePlaythroughDetailsViewModel>();
        }

        public int ID { get; set; }
        public string PlayerName { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public string Rating { get; set; }
        [Display(Name = "Total playtime")]
        public string TotalPlaytime { get; set; }
        public string Notes { get; set; }

        public ICollection<GamePlaythroughDetailsViewModel> Playthroughs { get; set; }
    }
}
