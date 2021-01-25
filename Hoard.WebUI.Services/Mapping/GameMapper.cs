using Hoard.Core.Constants;
using Hoard.Data.Entities.Game;
using Hoard.WebUI.Services.ViewModels;
using System.Collections.Generic;

namespace Hoard.WebUI.Services.Mapping
{
    internal static class GameMapper
    {
        internal static GameIndexViewModel ToIndexViewModel(ICollection<Game> games)
        {
            var vm = new GameIndexViewModel();

            foreach(var g in games)
            {
                vm.Games.Add(ToIndexItemViewModel(g));
            }

            return vm;
        }

        internal static GameIndexItemViewModel ToIndexItemViewModel(Game game)
        {
            GameIndexItemViewModel vm = new GameIndexItemViewModel
            {
                ID = game.ID,
                Title = game.Title,
                ReleaseDate = game.ReleaseDate.ToString(EntityConstants.DateFormatString)
            };

            return vm;
        }

        internal static GameDetailsViewModel ToDetailsViewModel(Game game)
        {
            var vm = new GameDetailsViewModel
            {
                ID = game.ID,
                Title = game.Title,
                Description = game.Description,
                ReleaseDate = game.ReleaseDate.ToString(EntityConstants.DateFormatString)
            };

            if (game.PlayData != null && game.PlayData.Count != 0)
            {
                foreach (var pd in game.PlayData)
                {
                    var pdVM = PlayDataMapper.ToViewModel(pd);

                    vm.PlayData.Add(pdVM);
                }
            }

            return vm;
        }

        internal static GameCreateViewModel ToCreateViewModel()
        {
            var vm = new GameCreateViewModel();

            return vm;
        }

        internal static GameUpdateViewModel ToUpdateViewModel(Game game)
        {
            var vm = new GameUpdateViewModel
            {
                ID = game.ID,
                Title = game.Title,
                Description = game.Description,
                ReleaseDate = game.ReleaseDate
            };

            return vm;
        }

        internal static Game ToNewGame(GameCreateViewModel gcVM)
        {
            var game = new Game 
            { 
                Title = gcVM.Title,
                ReleaseDate = gcVM.ReleaseDate,
                Description = gcVM.Description
            };

            return game;
        }

        internal static Game ToExistingGame(GameUpdateViewModel guVM)
        {
            var game = new Game
            {
                ID = guVM.ID,
                Title = guVM.Title,
                ReleaseDate = guVM.ReleaseDate,
                Description = guVM.Description
            };

            return game;
        }
    }
}
