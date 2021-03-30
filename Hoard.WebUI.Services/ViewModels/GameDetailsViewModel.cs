using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hoard.WebUI.Services.ViewModels
{
    public class GameDetailsViewModel
    {
        public GameDetailsViewModel()
        {
            PlayData = new List<GamePlayDataDetailsViewModel>();
        }

        public int ID { get; set; }
        public string Title { get; set; }
        public string Platform { get; set; }

        [Display(Name = "Genre(s)")]
        public string Genres { get; set; }
        public string Description { get; set; }

        [Display(Name = "Release date")]
        public string ReleaseDate { get; set; }

        [Display(Name = "Play data")]
        public ICollection<GamePlayDataDetailsViewModel> PlayData { get; set; }
    }
}
