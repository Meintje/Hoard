using Hoard.WebUI.Services.ViewModels.Wishlist.Index.InnerModels;
using System.Collections.Generic;

namespace Hoard.WebUI.Services.ViewModels.Wishlist.Index
{
    public class WishlistIndexViewModel
    {
        public WishlistIndexViewModel()
        {
            Items = new List<WishlistIndexItemViewModel>();
        }

        public ICollection<WishlistIndexItemViewModel> Items { get; set; }
    }
}
