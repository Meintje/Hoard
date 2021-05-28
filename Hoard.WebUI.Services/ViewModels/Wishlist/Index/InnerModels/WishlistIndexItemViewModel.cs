using System.ComponentModel.DataAnnotations;

namespace Hoard.WebUI.Services.ViewModels.Wishlist.Index.InnerModels
{
    public class WishlistIndexItemViewModel
    {
        public int ID { get; set; }
        [Display(Name = "Type")]
        public string ItemType { get; set; }
        public string Title { get; set; }
        [Display(Name = "Added")]
        public string AddDate { get; set; }
        [Display(Name = "Release")]
        public string ReleaseDate { get; set; }
        public string Priority { get; set; }
        public string Notes { get; set; }
        public string URL { get; set; }
        public string Language { get; set; }
    }
}
