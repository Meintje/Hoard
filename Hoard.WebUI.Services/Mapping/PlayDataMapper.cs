using Hoard.Core.Entities.Game;
using Hoard.Core.Constants;
using Hoard.WebUI.Services.ViewModels;
using System;
using Hoard.WebUI.Services.Mapping.Helpers;

namespace Hoard.WebUI.Services.Mapping
{
    internal static class PlayDataMapper
    {
        internal static GamePlayDataDetailsViewModel ToGameDetailsViewModel(PlayData playData)
        {
            var pdVM = new GamePlayDataDetailsViewModel
            {
                ID = playData.ID,
                PlayerName = playData.Player.Name,
                Status = playData.Status,
                Priority = "Highest",
                Rating = "10",
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
                PlayerName = playData.Player.Name,
                Status = playData.Status,
                Priority = "Highest",
                Rating = "10",
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

        internal static PlayDataUpdateViewModel ToUpdateViewModel(PlayData playData)
        {
            var pdVM = new PlayDataUpdateViewModel
            {
                ID = playData.ID,
                GameID = playData.GameID,
                PlayerID = playData.PlayerID,
                Dropped = playData.Dropped,
                Notes = playData.Notes
            };

            return pdVM;
        }

        internal static PlayData ToPlayData(PlayDataUpdateViewModel playDataUpdateViewModel)
        {
            var playdata = new PlayData
            {
                ID = playDataUpdateViewModel.ID,
                GameID = playDataUpdateViewModel.GameID,
                PlayerID = playDataUpdateViewModel.PlayerID,
                Dropped = playDataUpdateViewModel.Dropped,
                Notes = playDataUpdateViewModel.Notes
            };

            return playdata;
        }
    }
}
