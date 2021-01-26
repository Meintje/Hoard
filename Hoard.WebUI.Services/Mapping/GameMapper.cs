using Hoard.Core.Constants;
using Hoard.Data.Entities.Game;
using Hoard.WebUI.Services.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
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
                Platform = game.Platform.Name,
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

        internal static GameCreateViewModel ToCreateViewModel(ICollection<Platform> platformList)
        {
            var vm = new GameCreateViewModel();

            foreach(var item in platformList)
            {
                vm.PlatformSelectList.Add(new SelectListItem { Value = item.ID.ToString(), Text = item.Name });
            }

            return vm;
        }

        internal static GameUpdateViewModel ToUpdateViewModel(Game game, ICollection<Platform> platformList)
        {
            var vm = new GameUpdateViewModel
            {
                ID = game.ID,
                Title = game.Title,
                PlatformID = game.PlatformID,
                Description = game.Description,
                ReleaseDate = game.ReleaseDate
            };

            // TODO: Extract this into a separate, private helper method?
            foreach (var item in platformList)
            {
                vm.PlatformSelectList.Add(new SelectListItem { Value = item.ID.ToString(), Text = item.Name });
            }

            return vm;
        }

        internal static Game ToNewGame(GameCreateViewModel gcVM)
        {
            var game = new Game 
            { 
                Title = gcVM.Title,
                PlatformID = gcVM.PlatformID,
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
                PlatformID = guVM.PlatformID,
                ReleaseDate = guVM.ReleaseDate,
                Description = guVM.Description
            };

            return game;
        }
    }
}
