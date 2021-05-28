using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Hoard.WebUI.Services.ViewModels.Game.PlayDataUpdate
{
    public class PlayDataUpdateViewModel
    {
        public int ID { get; set; }
        public int GameID { get; set; }
        public int HoarderID { get; set; }

        [Display(Name = "Priority")]
        [Required(ErrorMessage = "Please select a priority.")]
        public int PriorityID { get; set; }
        public SelectList PrioritySelectList { get; set; }

        [Display(Name = "Ownership status")]
        [Required(ErrorMessage = "Please select a status.")]
        public int OwnershipStatusID { get; set; }
        public SelectList OwnershipStatusSelectList { get; set; }

        public bool Dropped { get; set; }
        [Display(Name = "Achievements completed")]
        public bool AchievementsCompleted { get; set; }

        [Range(0, 10, ErrorMessage = "Please input a number between 0 and 10.")]
        public float? Rating { get; set; }

        public string Notes { get; set; }
    }
}
