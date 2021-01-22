using System.ComponentModel.DataAnnotations;

namespace Hoard.WebUI.Services.ViewModels
{
    public class PlaythroughDetailsViewModel
    {
        public int PlayDataID { get; set; }

        [Display(Name = "#")]
        public int OrdinalNumber { get; set; }

        [Display(Name = "Status")]
        public string PlayStatus { get; set; }

        [Display(Name = "Start date")]
        public string DateStart { get; set; }

        [Display(Name = "End date")]
        public string DateEnd { get; set; }

        public string Playtime { get; set; }

        [Display(Name = "Side content")]
        public string SideContentCompleted { get; set; }

        public string Notes { get; set; }
    }
}
