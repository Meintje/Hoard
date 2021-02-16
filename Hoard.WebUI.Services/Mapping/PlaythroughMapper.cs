using Hoard.Data.Entities.Game;
using Hoard.Core.Constants;
using Hoard.WebUI.Services.ViewModels;
using System;

namespace Hoard.WebUI.Services.Mapping
{
    internal static class PlaythroughMapper
    {
        internal static PlaythroughDetailsViewModel ToDetailsViewModel(Playthrough playthrough)
        {
            var ptVM = new PlaythroughDetailsViewModel 
            {
                PlayDataID = playthrough.PlayDataID,
                OrdinalNumber = playthrough.OrdinalNumber,
                DateStart = playthrough.DateStart == null ? "Unknown" : ((DateTime)playthrough.DateStart).ToString(EntityConstants.DateFormatString),
                DateEnd = playthrough.DateEnd == null ? "Unknown" : ((DateTime)playthrough.DateEnd).ToString(EntityConstants.DateFormatString),
                PlayStatus = playthrough.PlayStatus.Name,
                SideContentCompleted = playthrough.SideContentCompleted? "Side content completed" : "Side content not completed",
                Notes = playthrough.Notes
            };

            var playtime = new TimeSpan(0, playthrough.PlaytimeMinutes, 0);
            ptVM.Playtime = $"{playtime.Days} day(s), {playtime.Hours} hour(s), {playtime.Minutes} minute(s)";

            return ptVM;
        }

        internal static PlaythroughCreateUpdateViewModel ToCreateUpdateViewModel(Playthrough playthrough)
        {
            var ptVM = new PlaythroughCreateUpdateViewModel
            {
                
            };

            return ptVM;
        }
    }
}
