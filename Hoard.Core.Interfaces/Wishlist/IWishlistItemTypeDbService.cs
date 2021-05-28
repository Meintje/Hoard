using Hoard.Core.Entities.Wishlist;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hoard.Core.Interfaces.Wishlist
{
    public interface IWishlistItemTypeDbService
    {
        public Task AddAsync(WishlistItemType item);
        public Task UpdateAsync(WishlistItemType item);
        public Task DeleteAsync(int id);
        public Task<IEnumerable<WishlistItemType>> GetAllAsync();
        public Task<WishlistItemType> GetUpdateDataAsync(int id);
        public Task<bool> CreateResultsInDuplicateEntryAsync(WishlistItemType newItem);
        public Task<bool> UpdateResultsInDuplicateEntryAsync(WishlistItemType newItem);
    }
}
