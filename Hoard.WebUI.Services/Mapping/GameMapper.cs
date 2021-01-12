using Hoard.Data.Entities.Game;
using Hoard.WebUI.Services.ViewModels;
using System.Collections.Generic;

namespace Hoard.WebUI.Services.Mapping
{
    internal static class GameMapper
    {
        internal static GameIndexItemViewModel ToIndexItemViewModel(Game game)
        {
            GameIndexItemViewModel vm = new GameIndexItemViewModel
            {
                ID = game.ID,
                Title = game.Title,
                ReleaseDate = game.ReleaseDate.ToString("dd/MM/yyyy")
            };

            return vm;
        }

        internal static GameIndexViewModel ToIndexViewModel(List<Game> games)
        {
            var vm = new GameIndexViewModel
            {
                Games = new List<GameIndexItemViewModel>()
            };

            foreach(var g in games)
            {
                vm.Games.Add(ToIndexItemViewModel(g));
            }

            return vm;
        }
    }
}
