using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hoard.Core.Entities.Games;
using Hoard.WebUI.Services.ViewModels;
using Hoard.WebUI.Services.Interfaces;
using Hoard.WebUI.Services.ViewModels.Game.Playthrough;
using Hoard.WebUI.Services.ViewModels.Game.PlayDataUpdate;

namespace Hoard.WebUI.ASP.Controllers
{
    public class PlayDataController : Controller
    {
        private readonly IPlayDataViewService playDataViewService;

        public PlayDataController(IPlayDataViewService playDataViewService)
        {
            this.playDataViewService = playDataViewService;
        }

        // GET: PlayData/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playDataViewModel = await playDataViewService.GetPlayDataDetailsAsync((int)id);
            if (playDataViewModel == null)
            {
                return NotFound();
            }

            return View(playDataViewModel);
        }

        // GET: PlayData/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playDataViewModel = await playDataViewService.GetPlayDataUpdateDataAsync((int)id);
            if (playDataViewModel == null)
            {
                return NotFound();
            }

            return PartialView("_PlayDataUpdateModalPartial", playDataViewModel);
        }

        // POST: PlayData/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("ID,GameID,HoarderID,PriorityID,OwnershipStatusID,Dropped,AchievementsCompleted,Rating,Notes")] PlayDataUpdateViewModel playDataUpdateViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await playDataViewService.UpdatePlayDataAsync(playDataUpdateViewModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlayDataExists(playDataUpdateViewModel.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Details), new { id = playDataUpdateViewModel.ID });
            }

            return RedirectToAction(nameof(Details), new { id = playDataUpdateViewModel.ID });
        }

        public async Task<IActionResult> CreatePlaythrough(int playDataId)
        {
            var playthroughCreateViewModel = await playDataViewService.GetPlaythroughCreateDataAsync(playDataId);

            return PartialView("_PlaythroughCreateModalPartial", playthroughCreateViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePlaythrough([Bind("PlayDataID,OrdinalNumber,PlayStatusID,DateStart,DateEnd,PlaytimeDays,PlaytimeHours,PlaytimeMinutes,SideContentCompleted,Notes")] PlaythroughCreateUpdateViewModel playthroughCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                await playDataViewService.CreatePlaythroughAsync(playthroughCreateViewModel);

                return RedirectToAction(nameof(Details), new { id = playthroughCreateViewModel.PlayDataID });
            }

            // TODO: If this point is reached, something went wrong while saving data. Redirect to related PlayData and show error message.
            // Or reload the form and input data into the modal
            return PartialView("_PlaythroughCreateModalPartial", playthroughCreateViewModel);
        }

        public async Task<IActionResult> EditPlaythrough(int playDataId, int ordinalNumber)
        {
            var playthroughUpdateViewModel = await playDataViewService.GetPlaythroughUpdateDataAsync(playDataId, ordinalNumber);

            return PartialView("_PlaythroughUpdateModalPartial", playthroughUpdateViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPlaythrough(int playDataId, int ordinalNumber, [Bind("PlayDataID, OrdinalNumber, PlayStatusID, DateStart, DateEnd, PlaytimeDays, PlaytimeHours, PlaytimeMinutes, SideContentCompleted, Notes")] PlaythroughCreateUpdateViewModel playthroughUpdateViewModel)
        {
            if ((playDataId != playthroughUpdateViewModel.PlayDataID) ||
                (ordinalNumber != playthroughUpdateViewModel.OrdinalNumber))
            {
                return NotFound();
            }
            
            if (ModelState.IsValid)
            {
                await playDataViewService.UpdatePlaythroughAsync(playthroughUpdateViewModel);

                return RedirectToAction(nameof(Details), new { id = playthroughUpdateViewModel.PlayDataID });
            }

            // TODO: If this point is reached, something went wrong while saving data. Redirect to related PlayData and show error message.
            // Or reload the form and input data into the modal
            return RedirectToAction(nameof(Details), new { id = playthroughUpdateViewModel.PlayDataID });
        }

        public async Task<IActionResult> DeletePlaythrough(int? playDataID, int? ordinalNumber)
        {
            if (playDataID == null || ordinalNumber == null)
            {
                return NotFound();
            }

            var playthroughDeleteViewModel = await playDataViewService.GetPlaythroughDeleteDataAsync((int)playDataID, (int)ordinalNumber);
            if (playthroughDeleteViewModel == null)
            {
                return NotFound();
            }

            return PartialView("_PlaythroughDeleteModalPartial", playthroughDeleteViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePlaythrough(PlaythroughDeleteViewModel playthroughDetailsViewModel)
        {
            await playDataViewService.DeletePlaythroughAsync(playthroughDetailsViewModel);
            
            // TODO: If the data couldn't be deleted, show error message in related PlayData page

            return RedirectToAction(nameof(Details), new { id = playthroughDetailsViewModel.PlayDataID } );
        }

        private bool PlayDataExists(int id)
        {
            return true;
        }
    }
}
