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
    }
}
