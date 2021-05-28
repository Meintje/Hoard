using Hoard.Core.Entities.Wishlist;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hoard.Core.Interfaces.Wishlist
{
    public interface IWishlistDbService
    {
        public Task AddAsync(WishlistItem item);
        public Task UpdateAsync(WishlistItem item);
        public Task DeleteAsync(int id);
        public Task<IEnumerable<WishlistItem>> GetAllAsync(int hoarderID);
        public Task<WishlistItem> GetUpdateDataAsync(int id);
        public Task<bool> CreateResultsInDuplicateEntryAsync(WishlistItem newItem);
        public Task<bool> UpdateResultsInDuplicateEntryAsync(WishlistItem newItem);
        public Task<int> CountUserWishlistItems(int hoarderID);
    }
}
