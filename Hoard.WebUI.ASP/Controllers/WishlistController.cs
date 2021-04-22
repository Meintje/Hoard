using Hoard.WebUI.ASP.Attributes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hoard.WebUI.ASP.Controllers
{
    public class WishlistController : Controller
    {
        [ViewLayout("Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
