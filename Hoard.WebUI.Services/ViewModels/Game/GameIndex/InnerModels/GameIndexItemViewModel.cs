using System.ComponentModel.DataAnnotations;

namespace Hoard.WebUI.Services.ViewModels.Game.GameIndex.InnerModels
{
    public class GameIndexItemViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }

        [Display(Name = "Release")]
        [DataType(DataType.Date)]
        public string ReleaseDate { get; set; }

        [Display(Name = "Genre(s)")]
        public string Genres { get; set; }

        public string Platform { get; set; }
    }
}
