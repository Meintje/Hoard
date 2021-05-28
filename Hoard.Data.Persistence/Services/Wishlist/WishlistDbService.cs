using Hoard.Core.Entities.Wishlist;
using Hoard.Core.Interfaces.Wishlist;
using Hoard.Infrastructure.Persistence.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hoard.Infrastructure.Persistence.Services.Wishlist
{
    public class WishlistDbService : IWishlistDbService
    {
        private readonly HoardDbContext context;

        public WishlistDbService(HoardDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(WishlistItem item)
        {
            context.Add(item);

            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(WishlistItem item)
        {
            context.Update(item);

            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var wishlistItem = await context.WishlistItems.Where(wi => wi.ID == id).FirstOrDefaultAsync();

            if (wishlistItem != null)
            {
                context.WishlistItems.Remove(wishlistItem);
            }

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<WishlistItem>> GetAllAsync(int hoarderID)
        {
            var items = await context.WishlistItems
                .Include(wi => wi.WishlistItemType)
                .Include(wi => wi.Priority)
                .Include(wi => wi.Language)
                .Where(wi => wi.HoarderID == hoarderID)
                .OrderBy(wi => wi.WishlistItemType.OrdinalNumber)
                .ThenBy(wi => wi.Priority.OrdinalNumber)
                .ToListAsync();

            return items;
        }

        public async Task<WishlistItem> GetUpdateDataAsync(int id)
        {
            var item = await context.WishlistItems
                .Include(wi => wi.WishlistItemType)
                .Include(wi => wi.Priority)
                .Include(wi => wi.Language)
                .Where(wi => wi.ID == id)
                .FirstOrDefaultAsync();

            return item;
        }

        public async Task<bool> CreateResultsInDuplicateEntryAsync(WishlistItem newItem)
        {
            var item = await context.WishlistItems
                .Where(wi =>
                wi.Title == newItem.Title &&
                wi.WishlistItemTypeID == newItem.WishlistItemTypeID &&
                wi.HoarderID == newItem.HoarderID)
                .FirstOrDefaultAsync();

            if (item != null)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> UpdateResultsInDuplicateEntryAsync(WishlistItem newItem)
        {
            var item = await context.WishlistItems
                .Where(wi =>
                wi.ID != newItem.ID &&
                wi.Title == newItem.Title &&
                wi.WishlistItemTypeID == newItem.WishlistItemTypeID &&
                wi.HoarderID == newItem.HoarderID)
                .FirstOrDefaultAsync();

            if (item != null)
            {
                return true;
            }

            return false;
        }

        public async Task<int> CountUserWishlistItems(int hoarderID)
        {
            var count = await context.WishlistItems
                .Where(w => w.HoarderID == hoarderID)
                .CountAsync();

            return count;
        }
    }
}
