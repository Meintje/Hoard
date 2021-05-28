using Hoard.WebUI.ASP.Attributes;
using Hoard.WebUI.ASP.Models;
using Hoard.WebUI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Hoard.WebUI.ASP.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserDashboardViewService _userDashboardViewService;

        public HomeController(IUserDashboardViewService userDashboardViewService)
        {
            _userDashboardViewService = userDashboardViewService;
        }

        [ViewLayout("Index")]
        public async Task<IActionResult> Index()
        {
            // TODO: Redirect to Welcome if user is not logged in

            return View(await _userDashboardViewService.GetUserDashboard(1));
        }

        public IActionResult Welcome()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
