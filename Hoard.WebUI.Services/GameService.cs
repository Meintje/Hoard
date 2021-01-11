using Hoard.Data.Persistence.DataAccess;
using Hoard.Data.Services;
using Hoard.Data.Services.Interfaces;
using Hoard.WebUI.Services.Interfaces;
using Hoard.WebUI.Services.Mapping;
using Hoard.WebUI.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoard.WebUI.Services
{
    public class GameService : IGameService
    {
        private readonly IGameDbService _dbService;

        public GameService(IGameDbService dbService)
        {
            _dbService = dbService;
        }

        public GameIndexViewModel GetGameIndex()
        {
            var games = _dbService.GetGames();

            var vm = GameMapper.ToIndexViewModel(games);

            return vm;
        }
    }
}
