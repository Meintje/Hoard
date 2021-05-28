using Hoard.WebUI.ASP.Attributes;
using Hoard.WebUI.Services.Interfaces;
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

            // TODO: Put page number and size in Index parameters
            int pageNumber = 1;
            int pageSize = 30;

            var vm = await journalViewService.GetIndex(hoarderID, pageNumber, pageSize);

            return View(vm);
        }
    }
}
