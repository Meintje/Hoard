using System.ComponentModel.DataAnnotations;

namespace Hoard.WebUI.Services.ViewModels.Game.PlayDataDetails.InnerModels
{
    public class PlayDataPlaythroughDetailsViewModel
    {
        public int PlayDataID { get; set; }

        [Display(Name = "#")]
        public int OrdinalNumber { get; set; }

        public string Status { get; set; }

        [Display(Name = "Start date")]
        public string DateStart { get; set; }
        [Display(Name = "End date")]
        public string DateEnd { get; set; }
        public string Playtime { get; set; }

        public string Notes { get; set; }
    }
}
