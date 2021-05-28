using Hoard.Core.Entities.Games;
using Hoard.Core.Constants;
using System;
using Hoard.WebUI.Services.Mapping.Helpers;
using Hoard.WebUI.Services.ViewModels.Game.PlayDataUpdate;
using Hoard.WebUI.Services.ViewModels.Game.PlayDataDetails;
using Hoard.WebUI.Services.ViewModels.Game.GameDetails.InnerModels;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hoard.WebUI.Services.Mapping.Games
{
    internal static class PlayDataMapper
    {
        internal static GamePlayDataDetailsViewModel ToGameDetailsViewModel(PlayData playData)
        {
            var pdVM = new GamePlayDataDetailsViewModel
            {
                ID = playData.ID,
                PlayerName = playData.Hoarder.Name,
                Status = playData.Status,
                Priority = playData.Priority.Name,
                Rating = playData.Rating == null ? "" : playData.Rating.ToString(),
                TotalPlaytime = PlaytimeHelper.GetLongPlaytimeString(playData.TotalPlaytime),
                Notes = playData.Notes
            };

            if (playData.Playthroughs != null && playData.Playthroughs.Count != 0)
            {
                foreach (var pt in playData.Playthroughs)
                {
                    var ptVM = PlaythroughMapper.ToGameDetailsViewModel(pt);

                    pdVM.Playthroughs.Add(ptVM);
                }
            }

            return pdVM;
        }

        internal static PlayDataDetailsViewModel ToDetailsViewModel(PlayData playData)
        {
            var pdVM = new PlayDataDetailsViewModel
            {
                ID = playData.ID,
                GameID = playData.GameID,
                GameTitle = playData.Game.Title,
                PlayerName = playData.Hoarder.Name,
                Status = playData.Status,
                Priority = playData.Priority.Name,
                Rating = playData.Rating == null? "" : playData.Rating.ToString(),
                OwnershipStatus = playData.OwnershipStatus.Name,
                TotalPlaytime = PlaytimeHelper.GetLongPlaytimeString(playData.TotalPlaytime),
                FirstPlayed = playData.FirstPlayed == null? "Unknown" : ((DateTime)playData.FirstPlayed).ToString(EntityConstants.DateFormatString),
                LastPlayed = playData.LastPlayed == null? "Unknown" : ((DateTime)playData.LastPlayed).ToString(EntityConstants.DateFormatString),
                Notes = playData.Notes
            };

            if (playData.Playthroughs != null && playData.Playthroughs.Count != 0)
            {
                foreach (var pt in playData.Playthroughs)
                {
                    var ptVM = PlaythroughMapper.ToPlayDataDetailsViewModel(pt);

                    pdVM.Playthroughs.Add(ptVM);
                }
            }

            return pdVM;
        }

        internal static PlayDataUpdateViewModel ToUpdateViewModel(PlayData playData, IEnumerable<Priority> priorityList, IEnumerable<OwnershipStatus> ownershipStatusList)
        {
            var vm = new PlayDataUpdateViewModel
            {
                ID = playData.ID,
                GameID = playData.GameID,
                HoarderID = playData.HoarderID,
                PriorityID = playData.PriorityID,
                OwnershipStatusID = playData.OwnershipStatusID,
                Dropped = playData.Dropped,
                AchievementsCompleted = playData.AchievementsCompleted,
                Rating = playData.Rating,
                Notes = playData.Notes
            };

            vm.OwnershipStatusSelectList = new SelectList(ownershipStatusList, nameof(OwnershipStatus.ID), nameof(OwnershipStatus.Name));
            vm.PrioritySelectList = new SelectList(priorityList, nameof(Priority.ID), nameof(Priority.Name));

            return vm;
        }

        internal static PlayData ToPlayData(PlayDataUpdateViewModel playDataUpdateViewModel)
        {
            var playdata = new PlayData
            {
                ID = playDataUpdateViewModel.ID,
                GameID = playDataUpdateViewModel.GameID,
                HoarderID = playDataUpdateViewModel.HoarderID,
                PriorityID = playDataUpdateViewModel.PriorityID,
                OwnershipStatusID = playDataUpdateViewModel.OwnershipStatusID,
                Dropped = playDataUpdateViewModel.Dropped,
                AchievementsCompleted = playDataUpdateViewModel.AchievementsCompleted,
                Rating = playDataUpdateViewModel.Rating,
                Notes = playDataUpdateViewModel.Notes
            };

            return playdata;
        }
    }
}
