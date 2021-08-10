using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Display(Name = "Game(s)")]
        public string Games { get; set; }
        [Display(Name = "Tag(s)")]
        public string Tags { get; set; }
    }
}
