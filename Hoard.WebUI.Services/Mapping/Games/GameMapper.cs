using Hoard.Core.Constants;
using Hoard.Core.Entities.Games;
using Hoard.Core.Entities.Games.JoinEntities;
using Hoard.WebUI.Services.ViewModels.Game.GameCreateUpdate;
using Hoard.WebUI.Services.ViewModels.Game.GameDetails;
using Hoard.WebUI.Services.ViewModels.Game.GameIndex;
using Hoard.WebUI.Services.ViewModels.Game.GameIndex.InnerModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hoard.WebUI.Services.Mapping.Games
{
    internal static class GameMapper
    {
        internal static GameIndexViewModel ToIndexViewModel(IEnumerable<Game> games)
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
                Platform = game.Platform.ShortName,
                Title = game.Title,
                ReleaseDate = game.ReleaseDate.ToString(EntityConstants.DateFormatString),
                Genres = game.FullGenres,
                Developers = game.FullDevelopers,
                Publishers = game.FullPublishers,
                Modes = game.FullModes,
                Status = game.PlayData?.FirstOrDefault()?.Status,
                Priority = game.PlayData?.FirstOrDefault()?.Priority.Name
            };

            return vm;
        }

        internal static GameDetailsViewModel ToDetailsViewModel(Game game)
        {
            var vm = new GameDetailsViewModel
            {
                ID = game.ID,
                Title = game.Title,
                AlternateTitle = game.AlternateTitle,
                Platform = game.Platform.Name,
                ReleaseDate = game.ReleaseDate.ToString(EntityConstants.DateFormatString),
                Genres = game.FullGenres,
                Modes = game.FullModes,
                Series = game.FullSeries,
                Developers = game.FullDevelopers,
                Publishers = game.FullPublishers,
                MediaType = game.MediaType.Name,
                Language = game.Language.Name,
                Description = game.Description
            };

            if (game.PlayData != null && game.PlayData.Count > 0)
            {
                foreach (var pd in game.PlayData)
                {
                    var pdVM = PlayDataMapper.ToGameDetailsViewModel(pd);

                    vm.PlayData.Add(pdVM);
                }
            }

            return vm;
        }

        internal static GameCreateViewModel ToCreateViewModel(IEnumerable<Platform> platformList, IEnumerable<Genre> genreList, IEnumerable<Language> languageList, 
            IEnumerable<MediaType> mediaTypeList, IEnumerable<Series> seriesList, IEnumerable<Mode> modeList, IEnumerable<Developer> developerList, IEnumerable<Publisher> publisherList)
        {
            var vm = new GameCreateViewModel();

            vm.PlatformSelectList = new SelectList(platformList, nameof(Platform.ID), nameof(Platform.Name));
            vm.GenreSelectList = new SelectList(genreList, nameof(Genre.ID), nameof(Genre.Name));
            vm.LanguageSelectList = new SelectList(languageList, nameof(Language.ID), nameof(Language.Name));
            vm.MediaTypeSelectList = new SelectList(mediaTypeList, nameof(MediaType.ID), nameof(MediaType.Name));
            vm.SeriesSelectList = new SelectList(seriesList, nameof(Series.ID), nameof(Series.Name));
            vm.ModeSelectList = new SelectList(modeList, nameof(Mode.ID), nameof(Mode.Name));
            vm.DeveloperSelectList = new SelectList(developerList, nameof(Developer.ID), nameof(Developer.Name));
            vm.PublisherSelectList = new SelectList(publisherList, nameof(Publisher.ID), nameof(Publisher.Name));

            return vm;
        }

        internal static GameUpdateViewModel ToUpdateViewModel(Game game, IEnumerable<Platform> platformList, IEnumerable<Genre> genreList, IEnumerable<Language> languageList, 
            IEnumerable<MediaType> mediaTypeList, IEnumerable<Series> seriesList, IEnumerable<Mode> modeList, IEnumerable<Developer> developerList, IEnumerable<Publisher> publisherList)
        {
            var vm = new GameUpdateViewModel
            {
                ID = game.ID,
                Title = game.Title,
                AlternateTitle = game.AlternateTitle,
                ReleaseDate = game.ReleaseDate,
                Description = game.Description,
                PlatformID = game.PlatformID,
                LanguageID = game.LanguageID,
                MediaTypeID = game.MediaTypeID
            };

            // TODO: Add better way to create the arrays of selected IDs. (Make a helper method that uses BaseEntity)
            if (game.Genres != null && game.Genres.Count > 0)
            {
                var selectedGenres = new List<int>();
                foreach (var genre in game.Genres)
                {
                    selectedGenres.Add(genre.GenreID);
                }
                vm.GenreIDs = selectedGenres.ToArray();
            }

            if (game.Series != null && game.Series.Count > 0)
            {
                var selectedSeries = new List<int>();
                foreach (var series in game.Series)
                {
                    selectedSeries.Add(series.SeriesID);
                }
                vm.SeriesIDs = selectedSeries.ToArray();
            }

            if (game.Modes != null && game.Modes.Count > 0)
            {
                var selectedModes = new List<int>();
                foreach (var mode in game.Modes)
                {
                    selectedModes.Add(mode.ModeID);
                }
                vm.ModeIDs = selectedModes.ToArray();
            }

            if (game.Developers != null && game.Developers.Count > 0)
            {
                var selectedDevelopers = new List<int>();
                foreach (var developer in game.Developers)
                {
                    selectedDevelopers.Add(developer.DeveloperID);
                }
                vm.DeveloperIDs = selectedDevelopers.ToArray();
            }

            if (game.Publishers != null && game.Publishers.Count > 0)
            {
                var selectedPublishers = new List<int>();
                foreach (var publisher in game.Publishers)
                {
                    selectedPublishers.Add(publisher.PublisherID);
                }
                vm.PublisherIDs = selectedPublishers.ToArray();
            }

            vm.PlatformSelectList = new SelectList(platformList, nameof(Platform.ID), nameof(Platform.Name));
            vm.GenreSelectList = new SelectList(genreList, nameof(Genre.ID), nameof(Genre.Name));
            vm.LanguageSelectList = new SelectList(languageList, nameof(Language.ID), nameof(Language.Name));
            vm.MediaTypeSelectList = new SelectList(mediaTypeList, nameof(MediaType.ID), nameof(MediaType.Name));
            vm.SeriesSelectList = new SelectList(seriesList, nameof(Series.ID), nameof(Series.Name));
            vm.ModeSelectList = new SelectList(modeList, nameof(Mode.ID), nameof(Mode.Name));
            vm.DeveloperSelectList = new SelectList(developerList, nameof(Developer.ID), nameof(Developer.Name));
            vm.PublisherSelectList = new SelectList(publisherList, nameof(Publisher.ID), nameof(Publisher.Name));

            return vm;
        }

        internal static Game ToNewGame(GameCreateViewModel gcVM)
        {
            var game = new Game
            {
                Title = gcVM.Title,
                AlternateTitle = gcVM.AlternateTitle,
                PlatformID = gcVM.PlatformID,
                MediaTypeID = gcVM.MediaTypeID,
                LanguageID = gcVM.LanguageID,
                ReleaseDate = (DateTime)gcVM.ReleaseDate,
                Description = gcVM.Description,
                Genres = new List<GameGenre>(),
                Modes = new List<GameMode>(),
                Series = new List<GameSeries>(),
                Developers = new List<GameDeveloper>(),
                Publishers = new List<GamePublisher>(),
            };

            if (gcVM.GenreIDs != null && gcVM.GenreIDs.Length > 0)
            {
                foreach (var genreID in gcVM.GenreIDs)
                {
                    game.Genres.Add(new GameGenre { GenreID = genreID });
                }
            }

            if (gcVM.ModeIDs != null && gcVM.ModeIDs.Length > 0)
            {
                foreach (var modeID in gcVM.ModeIDs)
                {
                    game.Modes.Add(new GameMode { ModeID = modeID });
                }
            }

            if (gcVM.SeriesIDs != null && gcVM.SeriesIDs.Length > 0)
            {
                foreach (var seriesID in gcVM.SeriesIDs)
                {
                    game.Series.Add(new GameSeries { SeriesID = seriesID });
                }
            }

            if (gcVM.DeveloperIDs != null && gcVM.DeveloperIDs.Length > 0)
            {
                foreach (var developerID in gcVM.DeveloperIDs)
                {
                    game.Developers.Add(new GameDeveloper { DeveloperID = developerID });
                }
            }

            if (gcVM.PublisherIDs != null && gcVM.PublisherIDs.Length > 0)
            {
                foreach (var publisherID in gcVM.PublisherIDs)
                {
                    game.Publishers.Add(new GamePublisher { PublisherID = publisherID });
                }
            }

            return game;
        }

        internal static Game ToExistingGame(GameUpdateViewModel guVM)
        {
            var game = ToNewGame(guVM);
            game.ID = guVM.ID;

            return game;
        }
    }
}
