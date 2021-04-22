using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Hoard.WebUI.Services.ViewModels.Game.PlayDataUpdate
{
    public class PlayDataUpdateViewModel
    {
        public int ID { get; set; }
        public int GameID { get; set; }
        public int PlayerID { get; set; }

        public int PriorityID { get; set; }
        public SelectList PrioritySelectList { get; set; }
        public int OwnershipStatusID { get; set; }
        public SelectList OwnershipStatusSelectList { get; set; }

        public int? Rating { get; set; }

        public bool Dropped { get; set; }
        [Display(Name = "Achievements completed")]
        public bool AchievementsCompleted { get; set; }

        public string Notes { get; set; }
    }
}
