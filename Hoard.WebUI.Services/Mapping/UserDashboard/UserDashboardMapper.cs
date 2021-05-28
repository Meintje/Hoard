using Hoard.Core.Constants;
using Hoard.Core.Entities.Games;
using Hoard.Core.Entities.Journal;
using Hoard.WebUI.Services.ViewModels.UserDashboard.InnerModels;
using System;

namespace Hoard.WebUI.Services.Mapping.UserDashboard
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

        internal static UserDashboardEventViewModel JournalEntryToRecentEvent(JournalEntry journalEntry)
        {
            return new UserDashboardEventViewModel
            {
                Type = "Journal",
                Date = journalEntry.Date,
                DateString = (journalEntry.Date).ToString(EntityConstants.DateFormatString),
                Title = journalEntry.Title,
                URL = $"../Journal/Details/{journalEntry.ID}"
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
                GamePlatform = playthrough.PlayData.Game.Platform.ShortName,
                GameTitle = playthrough.PlayData.Game.Title
            };
        }
    }
}
