using Hoard.Core.Interfaces;
using Hoard.WebUI.Services.Interfaces;
using Hoard.WebUI.Services.Mapping;
using Hoard.WebUI.Services.ViewModels;
using System.Threading.Tasks;

namespace Hoard.WebUI.Services
{
    public class GameViewService : IGameViewService
    {
        private readonly IGameDbService gameDbService;
        private readonly IGenreDbService genreDbService;
        private readonly IPlatformDbService platformDbService;
        private readonly IPlaythroughDbService playthroughDbService;

        public GameViewService(IGameDbService gameDbService, IGenreDbService genreDbService, IPlatformDbService platformDbService, IPlaythroughDbService playthroughDbService)
        {
            this.gameDbService = gameDbService;
            this.genreDbService = genreDbService;
            this.platformDbService = platformDbService;
            this.playthroughDbService = playthroughDbService;
        }

        public async Task<GameIndexViewModel> GetGameIndex()
        {
            var games = await gameDbService.GetAllAsync();

            var vm = GameMapper.ToIndexViewModel(games);

            return vm;
        }

        public async Task<GameDetailsViewModel> GetGameDetails(int id)
        {
            var game = await gameDbService.GetDetailsAsync(id);

            if (game == null)
            {
                return null;
            }

            var vm = GameMapper.ToDetailsViewModel(game);

            return vm;
        }

        public async Task<GameCreateViewModel> GetGameCreateData()
        {
            var platformList = await platformDbService.GetAllAsync();
            var genreList = await genreDbService.GetAllAsync();

            return GameMapper.ToCreateViewModel(platformList, genreList);
        }

        public async Task<GameUpdateViewModel> GetGameUpdateData(int id)
        {
            var game = await gameDbService.GetUpdateDataAsync(id);
            var platformList = await platformDbService.GetAllAsync();
            var genreList = await genreDbService.GetAllAsync();

            return GameMapper.ToUpdateViewModel(game, platformList, genreList);
        }

        public async Task CreateGame(GameCreateViewModel gcVM)
        {
            var game = GameMapper.ToNewGame(gcVM);

            await gameDbService.AddAsync(game);
        }

        public async Task UpdateGame(GameUpdateViewModel guVM)
        {
            var game = GameMapper.ToExistingGame(guVM);

            await gameDbService.UpdateAsync(game);
        }

        public async Task DeleteGame(int id)
        {
            await gameDbService.DeleteAsync(id);
        }

        public async Task<PlaythroughCreateUpdateViewModel> GetPlaythroughCreateData()
        {
            return new PlaythroughCreateUpdateViewModel();
        }

        public async Task<PlaythroughCreateUpdateViewModel> GetPlaythroughUpdateData(int pdID, int ordinalNumber)
        {
            var pt = await playthroughDbService.GetPlaythroughDetails(pdID, ordinalNumber);

            if (pt == null)
            {
                return null;
            }

            var ptcuVM = PlaythroughMapper.ToCreateUpdateViewModel(pt);

            return ptcuVM;
        }
    }
}
