using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoard.WebUI.Services.ViewModels
{
    public class GameIndexViewModel
    {
        public List<GameIndexItemViewModel> Games { get; set; }
    }

    public class GameIndexItemViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }

        [Display(Name = "Release date")]
        [DataType(DataType.Date)]
        public string ReleaseDate { get; set; }
    }
}
