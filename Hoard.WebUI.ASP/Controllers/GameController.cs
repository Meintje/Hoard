using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hoard.WebUI.Services.Interfaces;
using Hoard.WebUI.Services;
using Hoard.WebUI.Services.ViewModels;

namespace Hoard.WebUI.ASP.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameViewService _gameViewService;

        public GameController(IGameViewService gameService)
        {
            _gameViewService = gameService;
        }

        // GET: Game
        public async Task<IActionResult> Index()
        {
            return View(await _gameViewService.GetGameIndex());
        }

        // GET: Game/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameVM = await _gameViewService.GetGameDetails((int)id);

            if (gameVM == null || gameVM.ID == 0)
            {
                return NotFound();
            }

            return View(gameVM);
        }

        // GET: Game/Create
        public async Task<IActionResult> Create()
        {
            var gameVM = await _gameViewService.GetGameCreateUpdateData(null);

            return View(gameVM);
        }

        // POST: Game/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,ReleaseDate,Description")] GameCreateUpdateViewModel gcuVM)
        {
            if (ModelState.IsValid)
            {
                await _gameViewService.CreateGame(gcuVM);

                return RedirectToAction(nameof(Index));
            }

            return View(gcuVM);
        }

        // GET: Game/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = new GameCreateUpdateViewModel();
            //var game = await _context.Games.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            return View(game);
        }

        // POST: Game/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title,ReleaseDate,ID")] GameCreateUpdateViewModel game)
        {
            if (id != game.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(game);
                    //await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameExists(game.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(game);
        }

        // GET: Game/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = new GameCreateUpdateViewModel();
            //var game = await _context.Games.FirstOrDefaultAsync(m => m.ID == id);
            if (game == null || game.ID == 0)
            {
                return NotFound();
            }

            return View(game);
        }

        // POST: Game/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var game = new GameCreateUpdateViewModel();
            //var game = await _context.Games.FindAsync(id);
            //_context.Games.Remove(game);
            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GameExists(int id)
        {
            return true;
            //return _context.Games.Any(e => e.ID == id);
        }
    }
}
