using Hoard.Data.Services.Interfaces;
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
            var game = await _dbService.GetGameByID(id);

            if (game == null)
            {
                return null;
            }

            var vm = GameMapper.ToDetailsViewModel(game);

            return vm;
        }

        public async Task<GameCreateViewModel> GetGameCreateData()
        {
            return GameMapper.ToCreateViewModel();
        }

        public async Task<GameUpdateViewModel> GetGameUpdateData(int id)
        {
            var game = await _dbService.GetGameByID(id);

            return GameMapper.ToUpdateViewModel(game);
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

        public async Task<PlaythroughCreateUpdateViewModel> GetPlaythroughCreateUpdateData(int? pdID, int? ordinalNumber)
        {
            if (pdID == null || ordinalNumber == null)
            {
                return new PlaythroughCreateUpdateViewModel();
            }
            else
            {
                var pt = await _dbService.GetPlaythroughByID((int)pdID, (int)ordinalNumber);

                if (pt == null)
                {
                    return null;
                }

                var ptcuVM = PlaythroughMapper.ToCreateUpdateViewModel(pt);

                return ptcuVM;
            }
        }
    }
}
