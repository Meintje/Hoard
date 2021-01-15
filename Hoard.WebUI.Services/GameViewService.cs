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

        public async Task<GameCreateUpdateViewModel> GetGameCreateUpdateData(int? id)
        {
            if (id == null)
            {
                return GameMapper.ToCreateViewModel();
            }
            else
            {
                var game = await _dbService.GetGameByID((int)id);

                return GameMapper.ToCreateViewModel();
            }
        }

        public async Task CreateGame(GameCreateUpdateViewModel gcuVM)
        {
            var game = GameMapper.ToNewEntity(gcuVM);
            
            await _dbService.CreateGame(game);
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
