using Hoard.WebUI.Services.Converters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Hoard.WebUI.ASP.Controllers
{
    public class AdminController : Controller
    {
        private readonly IConverter htmlConverter;

        public AdminController(IConverter htmlConverter)
        {
            this.htmlConverter = htmlConverter;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ExportGameData()
        {
            var date = DateTime.Today.ToString("yyyy-MM-dd");

            var text = await htmlConverter.ConvertGameData();
            byte[] data = Encoding.UTF8.GetBytes(text);

            return File(data, MediaTypeNames.Text.Html, $"{date} Hoard GameData.html");
        }
    }
}
