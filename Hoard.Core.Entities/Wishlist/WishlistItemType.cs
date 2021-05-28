using Hoard.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoard.Core.Entities.Wishlist
{
    public class WishlistItemType : BaseEntityWithID
    {
        public int OrdinalNumber { get; set; }
        public string Name { get; set; }
    }
}
