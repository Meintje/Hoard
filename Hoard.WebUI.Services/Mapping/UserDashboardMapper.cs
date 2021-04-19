using Hoard.Core.Constants;
using Hoard.Core.Entities.Game;
using Hoard.WebUI.Services.ViewModels.UserDashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoard.WebUI.Services.Mapping
{
    internal static class UserDashboardMapper
    {
        internal static UserDashboardEventViewModel StartedPlaythroughToRecentEvent(Playthrough playthrough)
        {
            return new UserDashboardEventViewModel
            {
                Type = "Started",
                Date = (DateTime)playthrough.DateStart,
                DateString = ((DateTime)playthrough.DateStart).ToString(EntityConstants.DateFormatString),
                Title = playthrough.PlayData.Game.Title,
                URL = $"../PlayData/Details/{playthrough.PlayData.ID}"
            };
        }

        internal static UserDashboardEventViewModel FinishedPlaythroughToRecentEvent(Playthrough playthrough)
        {
            return new UserDashboardEventViewModel
            {
                Type = "Finished",
                Date = (DateTime)playthrough.DateEnd,
                DateString = ((DateTime)playthrough.DateEnd).ToString(EntityConstants.DateFormatString),
                Title = playthrough.PlayData.Game.Title,
                URL = $"../PlayData/Details/{playthrough.PlayData.ID}"
            };
        }

        internal static UserDashboardGameViewModel ToGameViewModel(Playthrough playthrough)
        {
            return new UserDashboardGameViewModel
            {
                PlayDataID = playthrough.PlayDataID,
                OrdinalNumber = playthrough.OrdinalNumber,
                PlaythroughNotes = playthrough.Notes,
                GameID = playthrough.PlayData.GameID,
                GamePlatform = playthrough.PlayData.Game.Platform.Name,
                GameTitle = playthrough.PlayData.Game.Title
            };
        }
    }
}
