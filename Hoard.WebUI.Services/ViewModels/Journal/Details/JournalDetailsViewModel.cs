using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoard.WebUI.Services.ViewModels.Journal.Details
{
    public class JournalDetailsViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }
        public string Content { get; set; }

        public string Games { get; set; }
        public string Tags { get; set; }
    }
}
