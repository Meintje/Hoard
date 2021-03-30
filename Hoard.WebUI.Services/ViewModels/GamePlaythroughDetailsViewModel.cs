using System.ComponentModel.DataAnnotations;

namespace Hoard.WebUI.Services.ViewModels
{
    public class GamePlaythroughDetailsViewModel
    {
        public int PlayDataID { get; set; }
        [Display(Name = "#")]
        public int OrdinalNumber { get; set; }

        public string Status { get; set; }
        public string PlayDates { get; set; }
        public string Playtime { get; set; }

        public string Notes { get; set; }
    }
}
