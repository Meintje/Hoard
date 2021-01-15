using Hoard.Core.Constants;
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
                ReleaseDate = game.ReleaseDate.ToString(EntityConstants.DateFormatString)
            };

            return vm;
        }

        internal static GameIndexViewModel ToIndexViewModel(ICollection<Game> games)
        {
            var vm = new GameIndexViewModel();

            foreach(var g in games)
            {
                vm.Games.Add(ToIndexItemViewModel(g));
            }

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

        internal static GameCreateUpdateViewModel ToCreateViewModel()
        {
            var vm = new GameCreateUpdateViewModel();

            return vm;
        }

        internal static GameCreateUpdateViewModel ToUpdateViewModel()
        {
            var vm = new GameCreateUpdateViewModel();

            return vm;
        }

        internal static Game ToNewEntity(GameCreateUpdateViewModel gcuVM)
        {
            var game = new Game 
            { 
                Title = gcuVM.Title,
                ReleaseDate = gcuVM.ReleaseDate,
                Description = gcuVM.Description
            };

            return game;
        }

        internal static Game ToExistingEntity(GameCreateUpdateViewModel gcuVM)
        {
            var game = new Game();

            return game;
        }
    }
}
