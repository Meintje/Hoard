using Hoard.Core.Constants;
using Hoard.Core.Entities.Games;
using Hoard.Core.Interfaces.Games;
using Hoard.WebUI.Services.ViewModels.Game.GameIndex;
using Hoard.WebUI.Services.ViewModels.Game.GameIndex.InnerModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Hoard.WebUI.ASP.MediatR
{
    // TODO: Move to Services layer
    public record GameIndexViewModelRequest(int ID) : IRequest<GameIndexViewModel>;

    public class RequestGameIndexViewModelHandler : IRequestHandler<GameIndexViewModelRequest, GameIndexViewModel>
    {
        private readonly IGameDbService gameDbService;

        public RequestGameIndexViewModelHandler(IGameDbService gameDbService)
        {
            this.gameDbService = gameDbService;
        }

        public async Task<GameIndexViewModel> Handle(GameIndexViewModelRequest request, CancellationToken cancellationToken)
        {
            var games = await gameDbService.GetAllAsync(request.ID);

            var vm = ToIndexViewModel(games);

            return vm;
        }

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
    }
}
