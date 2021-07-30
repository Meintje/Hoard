using Hoard.Core.Entities.Games;
using Hoard.Core.Interfaces.Games;
using Hoard.WebUI.Services.Interfaces;
using Hoard.WebUI.Services.Mapping.Games;
using Hoard.WebUI.Services.ViewModels.Game.GameCreateUpdate;
using Hoard.WebUI.Services.ViewModels.Game.GameDetails;
using Hoard.WebUI.Services.ViewModels.Game.GameIndex;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Threading.Tasks;

namespace Hoard.WebUI.Services
{
    public class GameViewService : IGameViewService
    {
        private readonly IGameDbService gameDbService;
        private readonly IGenreDbService genreDbService;
        private readonly IPlatformDbService platformDbService;
        private readonly ILanguageDbService languageDbService;
        private readonly IMediaTypeDbService mediaTypeDbService;
        private readonly ISeriesDbService seriesDbService;
        private readonly IModeDbService modeDbService;
        private readonly IDeveloperDbService developerDbService;
        private readonly IPublisherDbService publisherDbService;

        public GameViewService(IGameDbService gameDbService, IGenreDbService genreDbService, IPlatformDbService platformDbService, ILanguageDbService languageDbService,
            IMediaTypeDbService mediaTypeDbService, ISeriesDbService seriesDbService, IModeDbService modeDbService, IDeveloperDbService developerDbService, IPublisherDbService publisherDbService)
        {
            this.gameDbService = gameDbService;
            this.genreDbService = genreDbService;
            this.platformDbService = platformDbService;
            this.languageDbService = languageDbService;
            this.mediaTypeDbService = mediaTypeDbService;
            this.seriesDbService = seriesDbService;
            this.modeDbService = modeDbService;
            this.developerDbService = developerDbService;
            this.publisherDbService = publisherDbService;
        }

        public async Task<GameIndexViewModel> GetGameIndexAsync(int hoarderID)
        {
            var games = await gameDbService.GetAllAsync(hoarderID);

            var vm = GameMapper.ToIndexViewModel(games);

            return vm;
        }

        public async Task<GameDetailsViewModel> GetGameDetailsAsync(int id)
        {
            var game = await gameDbService.GetDetailsAsync(id);

            if (game == null)
            {
                return null;
            }

            var vm = GameMapper.ToDetailsViewModel(game);

            return vm;
        }

        public async Task<GameCreateViewModel> GetGameCreateDataAsync()
        {
            var platformList = await platformDbService.GetAllAsync();
            var genreList = await genreDbService.GetAllAsync();
            var languageList = await languageDbService.GetAllAsync();
            var mediaTypeList = await mediaTypeDbService.GetAllAsync();
            var seriesList = await seriesDbService.GetAllAsync();
            var modeList = await modeDbService.GetAllAsync();
            var developerList = await developerDbService.GetAllAsync();
            var publisherList = await publisherDbService.GetAllAsync();

            return GameMapper.ToCreateViewModel(platformList, genreList, languageList, mediaTypeList, seriesList, modeList, developerList, publisherList);
        }

        public async Task<GameUpdateViewModel> GetGameUpdateDataAsync(int id)
        {
            var game = await gameDbService.GetUpdateDataAsync(id);

            if(game == null)
            {
                return null;
            }

            var platformList = await platformDbService.GetAllAsync();
            var genreList = await genreDbService.GetAllAsync();
            var languageList = await languageDbService.GetAllAsync();
            var mediaTypeList = await mediaTypeDbService.GetAllAsync();
            var seriesList = await seriesDbService.GetAllAsync();
            var modeList = await modeDbService.GetAllAsync();
            var developerList = await developerDbService.GetAllAsync();
            var publisherList = await publisherDbService.GetAllAsync();

            return GameMapper.ToUpdateViewModel(game, platformList, genreList, languageList, mediaTypeList, seriesList, modeList, developerList, publisherList);
        }

        public async Task CreateGameAsync(GameCreateViewModel gcVM)
        {
            var game = GameMapper.ToGame(gcVM);

            await gameDbService.CreateAsync(game);
        }

        public async Task UpdateGameAsync(GameUpdateViewModel guVM)
        {
            var game = GameMapper.ToGame(guVM);

            await gameDbService.UpdateAsync(game);
        }

        public async Task DeleteGameAsync(int id)
        {
            await gameDbService.DeleteAsync(id);
        }

        public async Task<GameCreateViewModel> FillSelectLists(GameCreateViewModel gvm)
        {
            // TODO
            var platformList = await platformDbService.GetAllAsync();
            var genreList = await genreDbService.GetAllAsync();
            var languageList = await languageDbService.GetAllAsync();
            var mediaTypeList = await mediaTypeDbService.GetAllAsync();
            var seriesList = await seriesDbService.GetAllAsync();
            var modeList = await modeDbService.GetAllAsync();
            var developerList = await developerDbService.GetAllAsync();
            var publisherList = await publisherDbService.GetAllAsync();

            gvm.PlatformSelectList = new SelectList(platformList, nameof(Platform.ID), nameof(Platform.Name));
            gvm.GenreSelectList = new SelectList(genreList, nameof(Genre.ID), nameof(Genre.Name));
            gvm.LanguageSelectList = new SelectList(languageList, nameof(Language.ID), nameof(Language.Name));
            gvm.MediaTypeSelectList = new SelectList(mediaTypeList, nameof(MediaType.ID), nameof(MediaType.Name));
            gvm.SeriesSelectList = new SelectList(seriesList, nameof(Series.ID), nameof(Series.Name));
            gvm.ModeSelectList = new SelectList(modeList, nameof(Mode.ID), nameof(Mode.Name));
            gvm.DeveloperSelectList = new SelectList(developerList, nameof(Developer.ID), nameof(Developer.Name));
            gvm.PublisherSelectList = new SelectList(publisherList, nameof(Publisher.ID), nameof(Publisher.Name));

            return gvm;
        }

        public async Task<bool> CreateResultsInDuplicateEntryAsync(GameCreateViewModel vm)
        {
            var newGame = GameMapper.ToGame(vm);

            bool resultsInDuplicateGame = await gameDbService.CommandResultsInDuplicateEntryAsync(newGame);

            return resultsInDuplicateGame;
        }

        public async Task<bool> UpdateResultsInDuplicateEntryAsync(GameUpdateViewModel vm)
        {
            var updatedGame = GameMapper.ToGame(vm);

            bool resultsInDuplicateGame = await gameDbService.CommandResultsInDuplicateEntryAsync(updatedGame);

            return resultsInDuplicateGame;
        }
    }
}
