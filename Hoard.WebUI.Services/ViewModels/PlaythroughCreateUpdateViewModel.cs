using System;
using System.ComponentModel.DataAnnotations;

namespace Hoard.WebUI.Services.ViewModels
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
        public int OrdinalNumber { get; set; }

        public int PlayStatusID { get; set; }

        public string Player { get; set; }
        public string Game { get; set; }

        [Display(Name = "Start date")]
        [DataType(DataType.Date)]
        public DateTime? DateStart { get; set; }

        [Display(Name = "End date")]
        [DataType(DataType.Date)]
        public DateTime? DateEnd { get; set; }

        [Required(ErrorMessage = "Please enter a value of 0 or above for days played.")]
        [Display(Name = "day(s),")]
        [Range(0, int.MaxValue)]
        public int PlaytimeDays { get; set; }
        [Required(ErrorMessage = "Please enter a value of 0 or above for hours played.")]
        [Display(Name = "hour(s),")]
        [Range(0, int.MaxValue)]
        public int PlaytimeHours { get; set; }
        [Required(ErrorMessage = "Please enter a value of 0 or above for minutes played.")]
        [Display(Name = "minute(s)")]
        [Range(0, int.MaxValue)]
        public int PlaytimeMinutes { get; set; }

        public bool SideContentCompleted { get; set; }

        public string Notes { get; set; }
    }
}
