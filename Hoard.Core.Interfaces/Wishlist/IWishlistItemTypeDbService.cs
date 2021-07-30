using Hoard.Core.Entities.Wishlist;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hoard.Core.Interfaces.Wishlist
{
    public interface IWishlistItemTypeDbService
    {
        public Task CreateAsync(WishlistItemType wishlistItemType);
        public Task UpdateAsync(WishlistItemType wishlistItemType);
        public Task DeleteAsync(int id);
        public Task<IEnumerable<WishlistItemType>> GetAllAsync();
        public Task<WishlistItemType> GetUpdateDataAsync(int id);
        public Task<bool> CommandResultsInDuplicateEntryAsync(WishlistItemType wishlistItemType);
    }
}
