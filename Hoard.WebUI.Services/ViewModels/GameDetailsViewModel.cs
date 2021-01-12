using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hoard.WebUI.Services.ViewModels
{
    public class GameDetailsViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }

        [Display(Name = "Release date")]
        [DataType(DataType.Date)]
        public string ReleaseDate { get; set; }
        public List<PlayDataViewModel> PlayData { get; set; }
    }
}
