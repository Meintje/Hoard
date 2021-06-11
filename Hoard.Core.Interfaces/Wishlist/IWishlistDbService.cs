using Hoard.Core.Entities.Wishlist;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hoard.Core.Interfaces.Wishlist
{
    public interface IWishlistDbService
    {
        public Task AddAsync(WishlistItem wishlistItem);
        public Task UpdateAsync(WishlistItem wishlistItem);
        public Task DeleteAsync(int id);
        public Task<IEnumerable<WishlistItem>> GetAllAsync(int hoarderID);
        public Task<WishlistItem> GetUpdateDataAsync(int id);
        public Task<bool> CommandResultsInDuplicateEntryAsync(WishlistItem wishlistItem);
        public Task<int> CountUserWishlistItems(int hoarderID);
    }
}
