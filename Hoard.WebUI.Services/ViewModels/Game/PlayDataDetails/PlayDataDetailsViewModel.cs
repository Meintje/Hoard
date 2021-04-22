using Hoard.WebUI.Services.ViewModels.Game.PlayDataDetails.InnerModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hoard.WebUI.Services.ViewModels.Game.PlayDataDetails
{
    public class PlayDataDetailsViewModel
    {
        public PlayDataDetailsViewModel()
        {
            Playthroughs = new List<PlayDataPlaythroughDetailsViewModel>();
        }

        public int ID { get; set; }
        public int GameID { get; set; }

        public string GameTitle { get; set; }
        public string PlayerName { get; set; }

        public string Status { get; set; }
        public string Priority { get; set; }
        public string Rating { get; set; }

        [Display(Name = "Total playtime")]
        public string TotalPlaytime { get; set; }
        [Display(Name = "First played")]
        public string FirstPlayed { get; set; }
        [Display(Name = "Last played")]
        public string LastPlayed { get; set; }

        public string Notes { get; set; }

        public ICollection<PlayDataPlaythroughDetailsViewModel> Playthroughs { get; set; }
    }
}
