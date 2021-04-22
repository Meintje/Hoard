using Hoard.WebUI.Services.ViewModels.Game.GameIndex.InnerModels;
using System.Collections.Generic;

namespace Hoard.WebUI.Services.ViewModels.Game.GameIndex
{
    public class GameIndexViewModel
    {
        public GameIndexViewModel()
        {
            Games = new List<GameIndexItemViewModel>();
        }

        public ICollection<GameIndexItemViewModel> Games { get; set; }
    }
}
