using Hoard.Core.Entities.Base;
using Hoard.Core.Entities.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoard.Core.Entities.Wishlist
{
    public class WishlistItem : BaseEntityWithID
    {
        public int HoarderID { get; set; }
        public Hoarder Hoarder { get; set; }

        public int WishlistItemTypeID { get; set; }
        public WishlistItemType WishlistItemType { get; set; }

        public int PriorityID { get; set; }
        public Priority Priority { get; set; }

        public int LanguageID { get; set; }
        public Language Language { get; set; }

        public string Title { get; set; }
        public DateTime AddDate { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string StoreURL { get; set; }
        public string Notes { get; set; }
    }
}
