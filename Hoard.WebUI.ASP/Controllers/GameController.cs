﻿using System;
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
            var gcVM = await _gameViewService.GetGameCreateData();

            return View(gcVM);
        }

        // POST: Game/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,ReleaseDate,Description")] GameCreateViewModel gcVM)
        {
            if (ModelState.IsValid)
            {
                await _gameViewService.CreateGame(gcVM);

                return RedirectToAction(nameof(Index));
            }

            return View(gcVM);
        }

        // GET: Game/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guVM = await _gameViewService.GetGameUpdateData((int)id);
           
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
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,ReleaseDate,Description")] GameUpdateViewModel guVM)
        {
            if (id != guVM.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _gameViewService.UpdateGame(guVM);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameExists(guVM.ID))
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
            return View(guVM);
        }

        // GET: Game/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = new GameDetailsViewModel();
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
            var game = new GameCreateViewModel();
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
