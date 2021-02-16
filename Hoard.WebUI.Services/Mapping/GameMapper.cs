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

            foreach (var g in games)
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
                Platform = game.Platform.Name,
                ReleaseDate = game.ReleaseDate.ToString(EntityConstants.DateFormatString)
            };

            if (game.Genres != null && game.Genres.Count > 0)
            {
                foreach (var gg in game.Genres)
                {
                    vm.Genres += $"{gg.Genre.Name}, ";
                }
                vm.Genres = vm.Genres.Substring(0, vm.Genres.Length - 2);
            }

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

            if (game.Genres != null && game.Genres.Count > 0)
            {
                foreach (var gg in game.Genres)
                {
                    vm.Genres += $"{gg.Genre.Name}, ";
                }
                vm.Genres = vm.Genres.Substring(0, vm.Genres.Length - 2);
            }

            if (game.PlayData != null && game.PlayData.Count > 0)
            {
                foreach (var pd in game.PlayData)
                {
                    var pdVM = PlayDataMapper.ToViewModel(pd);

                    vm.PlayData.Add(pdVM);
                }
            }

            return vm;
        }

        internal static GameCreateViewModel ToCreateViewModel(ICollection<Platform> platformList, ICollection<Genre> genreList)
        {
            var vm = new GameCreateViewModel();

            vm.PlatformSelectList = new SelectList(platformList, nameof(Platform.ID), nameof(Platform.Name));
            vm.GenreSelectList = new SelectList(genreList, nameof(Genre.ID), nameof(Genre.Name));

            return vm;
        }

        internal static GameUpdateViewModel ToUpdateViewModel(Game game, ICollection<Platform> platformList, ICollection<Genre> genreList)
        {
            var vm = new GameUpdateViewModel
            {
                ID = game.ID,
                Title = game.Title,
                ReleaseDate = game.ReleaseDate,
                Description = game.Description,
                PlatformID = game.PlatformID
            };

            // TODO: Add better way to create the array of selected IDs.
            if (game.Genres != null && game.Genres.Count > 0)
            {
                var SelectedGenres = new List<int>();
                foreach (var genre in game.Genres)
                {
                    SelectedGenres.Add(genre.GenreID);
                }
                vm.GenreIDs = SelectedGenres.ToArray();
            }

            vm.PlatformSelectList = new SelectList(platformList, nameof(Platform.ID), nameof(Platform.Name));
            vm.GenreSelectList = new SelectList(genreList, nameof(Genre.ID), nameof(Genre.Name));

            return vm;
        }

        internal static Game ToNewGame(GameCreateViewModel gcVM)
        {
            var game = new Game
            {
                Title = gcVM.Title,
                PlatformID = gcVM.PlatformID,
                ReleaseDate = gcVM.ReleaseDate,
                Description = gcVM.Description,
                Genres = new List<GameGenre>()
            };

            if (gcVM.GenreIDs != null && gcVM.GenreIDs.Length > 0)
            {
                foreach (var item in gcVM.GenreIDs)
                {
                    game.Genres.Add(new GameGenre { GenreID = item });
                }
            }

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
                Description = guVM.Description,
                Genres = new List<GameGenre>()
            };

            if (guVM.GenreIDs != null && guVM.GenreIDs.Length > 0)
            {
                foreach (var item in guVM.GenreIDs)
                {
                    game.Genres.Add(new GameGenre { GameID = guVM.ID, GenreID = item });
                }
            }

            return game;
        }
    }
}
