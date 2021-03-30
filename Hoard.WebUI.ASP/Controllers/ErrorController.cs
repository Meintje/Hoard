using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hoard.WebUI.ASP.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/404")]
        public IActionResult Error404()
        {
            return View("Error404");
        }

        [Route("error/{code:int}")]
        public IActionResult Error(int code)
        {
            return View();
        }
    }
}
