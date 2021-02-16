using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hoard.WebUI.Services.ViewModels
{
    public class GameIndexViewModel
    {
        public GameIndexViewModel()
        {
            Games = new List<GameIndexItemViewModel>();
        }

        public ICollection<GameIndexItemViewModel> Games { get; set; }
    }

    public class GameIndexItemViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }

        [Display(Name = "Release date")]
        [DataType(DataType.Date)]
        public string ReleaseDate { get; set; }

        [Display(Name = "Genre(s)")]
        public string Genres { get; set; }

        public string Platform { get; set; }
    }
}
