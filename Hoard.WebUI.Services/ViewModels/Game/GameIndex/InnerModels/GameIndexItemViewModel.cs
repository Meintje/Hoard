using System.ComponentModel.DataAnnotations;

namespace Hoard.WebUI.Services.ViewModels.Game.GameIndex.InnerModels
{
    public class GameIndexItemViewModel
    {
        public int ID { get; set; }
        public string Platform { get; set; }
        public string Title { get; set; }

        [Display(Name = "Release")]
        public string ReleaseDate { get; set; }

        [Display(Name = "Genre(s)")]
        public string Genres { get; set; }
        [Display(Name = "Developer(s)")]
        public string Developers { get; set; }
        [Display(Name = "Publisher(s)")]
        public string Publishers { get; set; }
        [Display(Name = "Mode(s)")]
        public string Modes { get; set; }

        public string Status { get; set; }
        public string Priority { get; set; }
    }
}
