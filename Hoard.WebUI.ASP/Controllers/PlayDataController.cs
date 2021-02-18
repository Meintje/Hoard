using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hoard.Core.Entities.Game;
using Hoard.Data.Persistence.DataAccess;

namespace Hoard.WebUI.ASP.Controllers
{
    public class PlayDataController : Controller
    {
        private readonly HoardDbContext _context;

        public PlayDataController(HoardDbContext context)
        {
            _context = context;
        }

        // GET: PlayData/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playData = await _context.PlayData
                .Include(p => p.Game)
                .Include(p => p.Player)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (playData == null)
            {
                return NotFound();
            }

            return View(playData);
        }

        // GET: PlayData/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playData = await _context.PlayData.FindAsync(id);
            if (playData == null)
            {
                return NotFound();
            }
            ViewData["GameID"] = new SelectList(_context.Games, "ID", "Title", playData.GameID);
            ViewData["PlayerID"] = new SelectList(_context.Players, "ID", "Name", playData.PlayerID);
            return View(playData);
        }

        // POST: PlayData/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GameID,PlayerID,Dropped,CurrentlyPlaying,Notes,ID")] PlayData playData)
        {
            if (id != playData.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(playData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlayDataExists(playData.ID))
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
            ViewData["GameID"] = new SelectList(_context.Games, "ID", "Title", playData.GameID);
            ViewData["PlayerID"] = new SelectList(_context.Players, "ID", "Name", playData.PlayerID);
            return View(playData);
        }

        // GET: PlayData/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playData = await _context.PlayData
                .Include(p => p.Game)
                .Include(p => p.Player)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (playData == null)
            {
                return NotFound();
            }

            return View(playData);
        }

        // POST: PlayData/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var playData = await _context.PlayData.FindAsync(id);
            _context.PlayData.Remove(playData);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlayDataExists(int id)
        {
            return _context.PlayData.Any(e => e.ID == id);
        }
    }
}
