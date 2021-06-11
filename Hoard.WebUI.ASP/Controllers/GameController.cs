using System;
using MediatR;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hoard.WebUI.Services.Interfaces;
using Hoard.WebUI.ASP.Attributes;
using Hoard.WebUI.Services.ViewModels.Game.GameCreateUpdate;
using Hoard.WebUI.ASP.MediatR;

namespace Hoard.WebUI.ASP.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameViewService gameViewService;
        private readonly IMediator mediator;

        public GameController(IGameViewService gameService, IMediator mediator)
        {
            gameViewService = gameService;
            this.mediator = mediator;
        }

        // GET: Game
        [ViewLayout("Index")]
        public async Task<IActionResult> Index()
        {
            // TODO: Get HoarderID from ASP User
            int hoarderID = 1;

            var vm = await mediator.Send(new GameIndexViewModelRequest(hoarderID));

            //var vm = await gameViewService.GetGameIndex(hoarderID);

            return View(vm);
        }

        // GET: Game/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameVM = await gameViewService.GetGameDetails((int)id);

            if (gameVM == null || gameVM.ID == 0)
            {
                //throw new Exception();
                return NotFound();
            }

            return View(gameVM);
        }

        // POST: Game/Details/5
        [HttpPost, ActionName("Details")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await gameViewService.DeleteGame(id);

            return RedirectToAction(nameof(Index));
        }

        // GET: Game/Create
        public async Task<IActionResult> Create()
        {
            var gcVM = await gameViewService.GetGameCreateData();

            return View(gcVM);
        }

        // POST: Game/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,AlternateTitle,PlatformID,LanguageID,MediaTypeID,GenreIDs,SeriesIDs,ModeIDs,DeveloperIDs,PublisherIDs,ReleaseDate,Description")]
                                                GameCreateViewModel gameCreateViewModel)
        {
            // TODO: Implement MediatR
            if (ModelState.IsValid)
            {
                if (await gameViewService.CreateResultsInDuplicateEntry(gameCreateViewModel))
                {
                    ModelState.AddModelError(string.Empty, "A game with the same title, platform, release date and language already exists in the database.");
                    return View(gameCreateViewModel); // TODO: Refill SelectLists
                }

                await gameViewService.CreateGame(gameCreateViewModel);

                return RedirectToAction(nameof(Index));
            }

            return View(gameCreateViewModel); // TODO: Refill SelectLists
        }

        // GET: Game/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guVM = await gameViewService.GetGameUpdateData((int)id);

            if (guVM == null)
            {
                return NotFound();
            }

            return View(guVM);
        }

        // POST: Game/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,AlternateTitle,PlatformID,LanguageID,MediaTypeID,GenreIDs,SeriesIDs,ModeIDs,DeveloperIDs,PublisherIDs,ReleaseDate,Description")]
                                              GameUpdateViewModel gameUpdateViewModel)
        {
            if (id != gameUpdateViewModel.ID)
            {
                return NotFound();
            }

            // TODO: Implement MediatR
            if (ModelState.IsValid)
            {
                if (await gameViewService.UpdateResultsInDuplicateEntry(gameUpdateViewModel))
                {
                    ModelState.AddModelError(string.Empty, "A game with the same title, platform, release date and language already exists in the database.");
                    return View(gameUpdateViewModel); // TODO: Refill SelectLists
                }

                await gameViewService.UpdateGame(gameUpdateViewModel);

                return RedirectToAction(nameof(Details), new { id = id });
            }
            return View(gameUpdateViewModel); // TODO: Refill SelectLists
        }
    }
}
