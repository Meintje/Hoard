using Hoard.WebUI.ASP.Attributes;
using Hoard.WebUI.Services.Interfaces;
using Hoard.WebUI.Services.ViewModels.Wishlist.CreateUpdate;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hoard.WebUI.ASP.Controllers
{
    public class WishlistController : Controller
    {
        private readonly IWishlistViewService wishlistViewService;

        public WishlistController(IWishlistViewService wishlistViewService)
        {
            this.wishlistViewService = wishlistViewService;
        }

        // GET: Wishlist
        [ViewLayout("Index")]
        public async Task<IActionResult> Index(int? id)
        {
            int hoarderID;
            
            if (id == null)
            {
                // TODO: Get HoarderID from ASP User
                hoarderID = 1;
            }
            else
            {
                hoarderID = (int)id;
            }

            var vm = await wishlistViewService.GetIndexAsync(hoarderID);

            return View(vm);
        }

        // GET: Wishlist/Create
        public async Task<IActionResult> Create()
        {
            // TODO: Get HoarderID from ASP User
            int hoarderID = 1;

            var gcVM = await wishlistViewService.GetCreateDataAsync(hoarderID);

            return View(gcVM);
        }

        // POST: Wishlist/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,HoarderID,WishlistItemTypeID,PriorityID,LanguageID,ReleaseDate,StoreURL,Notes")] WishlistCreateViewModel wishlistCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                if (await wishlistViewService.CreateResultsInDuplicateEntryAsync(wishlistCreateViewModel))
                {
                    ModelState.AddModelError(string.Empty, "A wishlist entry with the same owner, title and type already exists in the database.");
                    return View(wishlistCreateViewModel); // TODO: Refill SelectLists
                }

                await wishlistViewService.CreateAsync(wishlistCreateViewModel);

                return RedirectToAction(nameof(Index));
            }

            return View(wishlistCreateViewModel); // TODO: Refill SelectLists
        }

        // GET: Wishlist/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guVM = await wishlistViewService.GetUpdateDataAsync((int)id);

            if (guVM == null)
            {
                return NotFound();
            }

            return View(guVM);
        }

        // POST: Wishlist/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,HoarderID,WishlistItemTypeID,PriorityID,LanguageID,Title,AddDate,ReleaseDate,StoreURL,Notes")] WishlistUpdateViewModel wishlistUpdateViewModel)
        {
            if (id != wishlistUpdateViewModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (await wishlistViewService.UpdateResultsInDuplicateEntryAsync(wishlistUpdateViewModel))
                {
                    ModelState.AddModelError(string.Empty, "A wishlist entry with the same owner, title and type already exists in the database.");
                    return View(wishlistUpdateViewModel); // TODO: Refill SelectLists
                }

                await wishlistViewService.UpdateAsync(wishlistUpdateViewModel);

                return RedirectToAction(nameof(Index));
            }
            return View(wishlistUpdateViewModel); // TODO: Refill SelectLists
        }
    }
}
