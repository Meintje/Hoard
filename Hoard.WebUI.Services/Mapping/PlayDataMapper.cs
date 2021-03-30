using Hoard.Core.Entities.Game;
using Hoard.Core.Constants;
using Hoard.WebUI.Services.ViewModels;
using System;

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
                Status = DetermineStatus(playData),
                Priority = "Highest",
                Rating = "10",
                TotalPlaytime = DetermineTotalPlaytime(playData),
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
                Status = DetermineStatus(playData),
                Priority = "Highest",
                Rating = "10",
                TotalPlaytime = DetermineTotalPlaytime(playData),
                FirstPlayed = DetermineFirstPlayedDate(playData),
                LastPlayed = DetermineLastPlayedDate(playData),
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

        private static string DetermineStatus(PlayData playData)
        {
            string status = "Unknown";

            if (playData.Dropped)
            {
                status = "Dropped";
            }
            else if (playData.Playthroughs == null || playData.Playthroughs.Count == 0)
            {
                status = "Unplayed";
            }
            else
            {
                int currentStatusNumber = 99;

                foreach (var playthrough in playData.Playthroughs)
                {
                    if (playthrough.PlayStatus.OrdinalNumber < currentStatusNumber)
                    {
                        currentStatusNumber = playthrough.PlayStatus.OrdinalNumber;
                        status = playthrough.PlayStatus.Name;
                    }
                }
            }

            return status;
        }

        private static string DetermineTotalPlaytime(PlayData playData)
        {
            int totalPlaytimeMinutes = 0;
            string totalPlaytimeString = "";

            if (playData.Playthroughs != null && playData.Playthroughs.Count != 0)
            {
                foreach (var playthrough in playData.Playthroughs)
                {
                    totalPlaytimeMinutes += playthrough.PlaytimeMinutes;
                }
            }

            var totalPlaytime = new TimeSpan(0, totalPlaytimeMinutes, 0);

            if (totalPlaytime.Days != 0)
            {
                totalPlaytimeString += $"{totalPlaytime.Days} day(s), ";
            }
            totalPlaytimeString += $"{totalPlaytime.Hours} hour(s), ";
            totalPlaytimeString += $"{totalPlaytime.Minutes} minute(s)";

            return totalPlaytimeString;
        }

        private static string DetermineFirstPlayedDate(PlayData playData)
        {
            string firstPlayed = "Unknown";
            DateTime? earliestDate = null;
            
            if (playData.Playthroughs != null && playData.Playthroughs.Count != 0)
            {
                foreach (var playthrough in playData.Playthroughs)
                {
                    if (earliestDate == null)
                    {
                        earliestDate = playthrough.DateStart;
                    }
                    else if (earliestDate > playthrough.DateStart)
                    {
                        earliestDate = playthrough.DateStart;
                    }
                }
            }

            if (earliestDate != null)
            {
                firstPlayed = ((DateTime)earliestDate).ToString(EntityConstants.DateFormatString);
            }

            return firstPlayed;
        }

        private static string DetermineLastPlayedDate(PlayData playData)
        {
            string lastPlayed = "Unknown";
            DateTime? latestDate = null;

            if (playData.Playthroughs != null && playData.Playthroughs.Count != 0)
            {
                foreach (var playthrough in playData.Playthroughs)
                {
                    if (latestDate == null)
                    {
                        latestDate = playthrough.DateEnd;
                    }
                    else if (latestDate < playthrough.DateEnd)
                    {
                        latestDate = playthrough.DateEnd;
                    }
                }
            }

            if (latestDate != null)
            {
                lastPlayed = ((DateTime)latestDate).ToString(EntityConstants.DateFormatString);
            }

            return lastPlayed;
        }
    }
}
