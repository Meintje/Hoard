using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hoard.WebUI.Services.ViewModels
{
    public class GameDetailsViewModel
    {
        public GameDetailsViewModel()
        {
            PlayData = new List<PlayDataViewModel>();
        }

        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        [Display(Name = "Release date")]
        public string ReleaseDate { get; set; }

        [Display(Name = "Play data")]
        public ICollection<PlayDataViewModel> PlayData { get; set; }
    }
}
