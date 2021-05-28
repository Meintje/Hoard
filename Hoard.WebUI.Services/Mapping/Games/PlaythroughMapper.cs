using Hoard.Core.Entities.Games;
using Hoard.Core.Constants;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Hoard.WebUI.Services.Mapping.Helpers;
using Hoard.WebUI.Services.ViewModels.Game.Playthrough;
using Hoard.WebUI.Services.ViewModels.Game.GameDetails.InnerModels;
using Hoard.WebUI.Services.ViewModels.Game.PlayDataDetails.InnerModels;

namespace Hoard.WebUI.Services.Mapping.Games
{
    internal static class PlaythroughMapper
    {
        internal static GamePlaythroughDetailsViewModel ToGameDetailsViewModel(Playthrough playthrough)
        {
            var playtime = new TimeSpan(0, playthrough.PlaytimeInMinutes, 0);

            var ptVM = new GamePlaythroughDetailsViewModel
            {
                PlayDataID = playthrough.PlayDataID,
                OrdinalNumber = playthrough.OrdinalNumber,
                Status = playthrough.Status,
                Playtime = PlaytimeHelper.GetShortPlaytimeString(playtime),
                PlayDates = PlayDatesHelper.GetPlayDatesString(playthrough.DateStart, playthrough.DateEnd),
                Notes = playthrough.Notes
            };

            return ptVM;
        }

        internal static PlayDataPlaythroughDetailsViewModel ToPlayDataDetailsViewModel(Playthrough playthrough)
        {
            var playtime = new TimeSpan(0, playthrough.PlaytimeInMinutes, 0);

            var ptVM = new PlayDataPlaythroughDetailsViewModel
            {
                PlayDataID = playthrough.PlayDataID,
                OrdinalNumber = playthrough.OrdinalNumber,
                Status = playthrough.Status,
                Playtime = PlaytimeHelper.GetLongPlaytimeString(playtime),
                DateStart = playthrough.DateStart == null ? "Unknown" : ((DateTime)playthrough.DateStart).ToString(EntityConstants.DateFormatString),
                DateEnd = playthrough.DateEnd == null ? "Unknown" : ((DateTime)playthrough.DateEnd).ToString(EntityConstants.DateFormatString),
                Notes = playthrough.Notes
            };

            return ptVM;
        }

        internal static PlaythroughCreateUpdateViewModel ToCreateViewModel(int playDataID, IEnumerable<PlayStatus> playStatusList)
        {
            var playthroughCreateViewModel = new PlaythroughCreateUpdateViewModel
            {
                PlayDataID = playDataID
            };

            playthroughCreateViewModel.PlayStatusSelectList = new SelectList(playStatusList, nameof(PlayStatus.ID), nameof(PlayStatus.Name));

            return playthroughCreateViewModel;
        }

        internal static PlaythroughCreateUpdateViewModel ToUpdateViewModel(Playthrough playthrough, IEnumerable<PlayStatus> playStatusList)
        {
            var playtime = new TimeSpan(0, playthrough.PlaytimeInMinutes, 0);

            var playthroughUpdateViewModel = new PlaythroughCreateUpdateViewModel
            {
                PlayDataID = playthrough.PlayDataID,
                OrdinalNumber = playthrough.OrdinalNumber,
                PlayStatusID = playthrough.PlayStatusID,
                DateStart = playthrough.DateStart,
                DateEnd = playthrough.DateEnd,
                PlaytimeDays = playtime.Days,
                PlaytimeHours = playtime.Hours,
                PlaytimeMinutes = playtime.Minutes,
                SideContentCompleted = playthrough.SideContentCompleted,
                Notes = playthrough.Notes
            };

            playthroughUpdateViewModel.PlayStatusSelectList = new SelectList(playStatusList, nameof(PlayStatus.ID), nameof(PlayStatus.Name));

            return playthroughUpdateViewModel;
        }

        internal static PlaythroughDeleteViewModel ToDeleteViewModel(Playthrough playthrough)
        {
            var playthroughDeleteViewModel = new PlaythroughDeleteViewModel
            {
                PlayDataID = playthrough.PlayDataID,
                OrdinalNumber = playthrough.OrdinalNumber
            };

            return playthroughDeleteViewModel;
        }

        internal static Playthrough ToPlaythrough(PlaythroughCreateUpdateViewModel playthroughCreateUpdateViewModel)
        {
            var playtime = new TimeSpan(playthroughCreateUpdateViewModel.PlaytimeDays, playthroughCreateUpdateViewModel.PlaytimeHours, playthroughCreateUpdateViewModel.PlaytimeMinutes, 0);

            var playthrough = new Playthrough
            {
                PlayDataID = playthroughCreateUpdateViewModel.PlayDataID,
                OrdinalNumber = (int)playthroughCreateUpdateViewModel.OrdinalNumber,
                PlayStatusID = playthroughCreateUpdateViewModel.PlayStatusID,
                DateStart = playthroughCreateUpdateViewModel.DateStart,
                DateEnd = playthroughCreateUpdateViewModel.DateEnd,
                PlaytimeInMinutes = (int)playtime.TotalMinutes,
                SideContentCompleted = playthroughCreateUpdateViewModel.SideContentCompleted,
                Notes = playthroughCreateUpdateViewModel.Notes
            };

            return playthrough;
        }
    }
}
