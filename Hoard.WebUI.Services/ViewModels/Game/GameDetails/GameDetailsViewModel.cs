using Hoard.WebUI.Services.ViewModels.Game.GameDetails.InnerModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hoard.WebUI.Services.ViewModels.Game.GameDetails
{
    public class GameDetailsViewModel
    {
        public GameDetailsViewModel()
        {
            PlayData = new List<GamePlayDataDetailsViewModel>();
        }

        public int ID { get; set; }
        public string Title { get; set; }
        public string AlternateTitle { get; set; }
        public string Platform { get; set; }

        [Display(Name = "Release date")]
        public string ReleaseDate { get; set; }

        [Display(Name = "Genre(s)")]
        public string Genres { get; set; }
        [Display(Name = "Mode(s)")]
        public string Modes { get; set; }
        [Display(Name = "Series")]
        public string Series { get; set; }
        [Display(Name = "Developer(s)")]
        public string Developers { get; set; }
        [Display(Name = "Publisher(s)")]
        public string Publishers { get; set; }

        [Display(Name = "Media type")]
        public string MediaType { get; set; }
        [Display(Name = "Language")]
        public string Language { get; set; }

        public string Description { get; set; }

        [Display(Name = "Play data")]
        public ICollection<GamePlayDataDetailsViewModel> PlayData { get; set; }
    }
}
