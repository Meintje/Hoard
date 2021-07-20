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

        public async Task AddAsync(WishlistItem wishlistItem)
        {
            context.Add(wishlistItem);

            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(WishlistItem wishlistItem)
        {
            context.Update(wishlistItem);

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
            var wishlistItems = await context.WishlistItems
                .Include(wi => wi.WishlistItemType)
                .Include(wi => wi.Priority)
                .Include(wi => wi.Language)
                .Where(wi => wi.HoarderID == hoarderID)
                .OrderBy(wi => wi.WishlistItemType.OrdinalNumber)
                .ThenBy(wi => wi.Priority.OrdinalNumber)
                .ThenBy(wi => wi.Title)
                .ToListAsync();

            return wishlistItems;
        }

        public async Task<WishlistItem> GetUpdateDataAsync(int id)
        {
            var wishlistItem = await context.WishlistItems
                .Include(wi => wi.WishlistItemType)
                .Include(wi => wi.Priority)
                .Include(wi => wi.Language)
                .Where(wi => wi.ID == id)
                .FirstOrDefaultAsync();

            return wishlistItem;
        }

        public async Task<bool> CommandResultsInDuplicateEntryAsync(WishlistItem wishlistItem)
        {
            var duplicateWishlistItem = await context.WishlistItems
                .Where(wi =>
                wi.ID != wishlistItem.ID &&
                wi.Title == wishlistItem.Title &&
                wi.WishlistItemTypeID == wishlistItem.WishlistItemTypeID &&
                wi.HoarderID == wishlistItem.HoarderID)
                .FirstOrDefaultAsync();

            if (duplicateWishlistItem != null)
            {
                return true;
            }

            return false;
        }

        public async Task<int> CountUserWishlistItems(int hoarderID)
        {
            var wishlistItems = await context.WishlistItems
                .Where(wi => wi.HoarderID == hoarderID)
                .CountAsync();

            return wishlistItems;
        }
    }
}
