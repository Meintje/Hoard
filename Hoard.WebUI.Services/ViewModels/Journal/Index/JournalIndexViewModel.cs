using Hoard.WebUI.Services.ViewModels.Journal.Index.InnerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoard.WebUI.Services.ViewModels.Journal.Index
{
    public class JournalIndexViewModel
    {
        public JournalIndexViewModel()
        {
            JournalEntries = new List<JournalIndexItemViewModel>();
        }

        public ICollection<JournalIndexItemViewModel> JournalEntries { get; set; }
    }
}
