using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;

namespace Hoard.WebUI.Services.ViewModels.Game.Playthrough
{
    public class PlaythroughCreateUpdateViewModel
    {
        public PlaythroughCreateUpdateViewModel()
        {
            PlaytimeDays = 0;
            PlaytimeHours = 0;
            PlaytimeMinutes = 0;
        }

        public int PlayDataID { get; set; }

        [Display(Name = "#")]
        [Required(ErrorMessage = "Please enter the number of this playthrough."), Range(1, 1000)]
        public int? OrdinalNumber { get; set; }

        [Display(Name = "Status")]
        [Required(ErrorMessage = "Please select the status of this playthrough.")]
        public int PlayStatusID { get; set; }
        public SelectList PlayStatusSelectList { get; set; }
        [Display(Name = "Side content completed")]
        public bool SideContentCompleted { get; set; }

        [Display(Name = "Start date")]
        [DataType(DataType.Date)]
        public DateTime? DateStart { get; set; }

        [Display(Name = "End date")]
        [DataType(DataType.Date)]
        public DateTime? DateEnd { get; set; }

        [Required(ErrorMessage = "Please enter a value of 0 or above for days played.")]
        [Display(Name = "Days")]
        [Range(0, int.MaxValue)]
        public int PlaytimeDays { get; set; }
        [Required(ErrorMessage = "Please enter a value of 0 or above for hours played.")]
        [Display(Name = "Hours")]
        [Range(0, int.MaxValue)]
        public int PlaytimeHours { get; set; }
        [Required(ErrorMessage = "Please enter a value of 0 or above for minutes played.")]
        [Display(Name = "Minutes")]
        [Range(0, int.MaxValue)]
        public int PlaytimeMinutes { get; set; }

        public string Notes { get; set; }
    }
}
