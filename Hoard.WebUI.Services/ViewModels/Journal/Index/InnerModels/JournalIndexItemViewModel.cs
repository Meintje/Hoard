using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoard.WebUI.Services.ViewModels.Journal.Index.InnerModels
{
    public class JournalIndexItemViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }
        public string Content { get; set; }

        public string Games { get; set; }
        public string Tags { get; set; }
    }
}
