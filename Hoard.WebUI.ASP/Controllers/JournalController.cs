using Hoard.WebUI.ASP.Attributes;
using Hoard.WebUI.Services.Interfaces;
using Hoard.WebUI.Services.ViewModels.Journal.CreateUpdate;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hoard.WebUI.ASP.Controllers
{
    public class JournalController : Controller
    {
        private readonly IJournalViewService journalViewService;

        public JournalController(IJournalViewService journalViewService)
        {
            this.journalViewService = journalViewService;
        }

        [ViewLayout("Journal")]
        public async Task<IActionResult> Index()
        {
            // TODO: Get ID from ASP.NET User
            int hoarderID = 1;

            // TODO: Put page number (and size?) in Index parameters?
            int pageNumber = 1;
            int pageSize = 30;

            var viewModel = await journalViewService.GetIndexAsync(hoarderID, pageNumber, pageSize);

            return View(viewModel);
        }

        // GET: Journal/Create
        public async Task<IActionResult> Create()
        {
            // TODO: Get ID from ASP.NET User
            int hoarderID = 1;

            var viewModel = await journalViewService.GetCreateDataAsync(hoarderID);

            return View(viewModel);
        }

        // POST: Journal/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HoarderID,Title,Date,GameIDs,TagIDs,Content")] JournalCreateViewModel journalCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                if (await journalViewService.CreateResultsInDuplicateEntryAsync(journalCreateViewModel))
                {
                    ModelState.AddModelError(string.Empty, "A journal entry with the same date already exists in the database.");
                    return View(journalCreateViewModel); // TODO: Refill SelectLists
                }

                await journalViewService.CreateAsync(journalCreateViewModel);

                return RedirectToAction(nameof(Index));
            }

            return View(journalCreateViewModel); // TODO: Refill SelectLists
        }

        // GET: Journal/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guVM = await journalViewService.GetUpdateDataAsync((int)id);

            if (guVM == null)
            {
                return NotFound();
            }

            return View(guVM);
        }

        // POST: Journal/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,HoarderID,Title,Date,GameIDs,TagIDs,Content")] JournalUpdateViewModel journalUpdateViewModel)
        {
            if (id != journalUpdateViewModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (await journalViewService.UpdateResultsInDuplicateEntryAsync(journalUpdateViewModel))
                {
                    ModelState.AddModelError(string.Empty, "A journal entry with the same date already exists in the database.");
                    return View(journalUpdateViewModel); // TODO: Refill SelectLists
                }

                await journalViewService.UpdateAsync(journalUpdateViewModel);

                return RedirectToAction(nameof(Index));
            }
            return View(journalUpdateViewModel); // TODO: Refill SelectLists
        }
    }
}
