using Hoard.Data.Entities.Game;
using Hoard.WebUI.Services.ViewModels;

namespace Hoard.WebUI.Services.Mapping
{
    internal static class PlayDataMapper
    {
        internal static PlayDataViewModel ToViewModel(PlayData playData)
        {
            var pdVM = new PlayDataViewModel
            {
                GameID = playData.GameID,
                PlayerID = playData.PlayerID,
                PlayerName = playData.Player.Name,
            };

            if (playData.Dropped)
            {
                pdVM.Status = "Dropped";
            }
            else if (playData.CurrentlyPlaying)
            {
                pdVM.Status = "Playing";
            }
            else
            {
                pdVM.Status = "Play status logic goes here";
            }

            if (playData.Playthroughs != null && playData.Playthroughs.Count != 0)
            {
                foreach (var pt in playData.Playthroughs)
                {
                    var ptVM = PlaythroughMapper.ToDetailsViewModel(pt);

                    pdVM.Playthroughs.Add(ptVM);
                }
            }

            return pdVM;
        }
    }
}
