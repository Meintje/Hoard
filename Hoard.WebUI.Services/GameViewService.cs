﻿using Hoard.Core.Interfaces;
using Hoard.WebUI.Services.Interfaces;
using Hoard.WebUI.Services.Mapping;
using Hoard.WebUI.Services.ViewModels;
using System.Threading.Tasks;

namespace Hoard.WebUI.Services
{
    public class GameViewService : IGameViewService
    {
        private readonly IGameDbService _dbService;

        public GameViewService(IGameDbService dbService)
        {
            _dbService = dbService;
        }

        public async Task<GameIndexViewModel> GetGameIndex()
        {
            var games = await _dbService.GetAllGames();

            var vm = GameMapper.ToIndexViewModel(games);

            return vm;
        }

        public async Task<GameDetailsViewModel> GetGameDetails(int id)
        {
            var game = await _dbService.GetGameDetails(id);

            if (game == null)
            {
                return null;
            }

            var vm = GameMapper.ToDetailsViewModel(game);

            return vm;
        }

        public async Task<GameCreateViewModel> GetGameCreateData()
        {
            var platformList = await _dbService.GetAllPlatforms();
            var genreList = await _dbService.GetAllGenres();

            return GameMapper.ToCreateViewModel(platformList, genreList);
        }

        public async Task<GameUpdateViewModel> GetGameUpdateData(int id)
        {
            var game = await _dbService.GetGameUpdateData(id);
            var platformList = await _dbService.GetAllPlatforms();
            var genreList = await _dbService.GetAllGenres();

            return GameMapper.ToUpdateViewModel(game, platformList, genreList);
        }

        public async Task CreateGame(GameCreateViewModel gcVM)
        {
            var game = GameMapper.ToNewGame(gcVM);

            await _dbService.CreateGame(game);
        }

        public async Task UpdateGame(GameUpdateViewModel guVM)
        {
            var game = GameMapper.ToExistingGame(guVM);

            await _dbService.UpdateGame(game);
        }

        public async Task DeleteGame(int id)
        {
            await _dbService.DeleteGame(id);
        }

        public async Task<PlaythroughCreateUpdateViewModel> GetPlaythroughCreateData()
        {
            return new PlaythroughCreateUpdateViewModel();
        }

        public async Task<PlaythroughCreateUpdateViewModel> GetPlaythroughUpdateData(int pdID, int ordinalNumber)
        {
            var pt = await _dbService.GetPlaythroughDetails(pdID, ordinalNumber);

            if (pt == null)
            {
                return null;
            }

            var ptcuVM = PlaythroughMapper.ToCreateUpdateViewModel(pt);

            return ptcuVM;
        }
    }
}
