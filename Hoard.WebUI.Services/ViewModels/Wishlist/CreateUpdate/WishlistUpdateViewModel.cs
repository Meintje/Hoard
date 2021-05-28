using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoard.WebUI.Services.ViewModels.Wishlist.CreateUpdate
{
    public class WishlistUpdateViewModel : WishlistCreateViewModel
    {
        public int ID { get; set; }
        public DateTime AddDate { get; set; }
    }
}
