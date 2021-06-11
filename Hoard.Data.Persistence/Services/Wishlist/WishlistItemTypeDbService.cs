using Hoard.Core.Entities.Wishlist;
using Hoard.Core.Interfaces.Wishlist;
using Hoard.Infrastructure.Persistence.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hoard.Infrastructure.Persistence.Services.Wishlist
{
    public class WishlistItemTypeDbService : IWishlistItemTypeDbService
    {
        private readonly HoardDbContext context;

        public WishlistItemTypeDbService(HoardDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(WishlistItemType wishlistItemType)
        {
            context.Add(wishlistItemType);

            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(WishlistItemType wishlistItemType)
        {
            context.Update(wishlistItemType);

            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var item = await context.WishlistItemTypes.Where(wt => wt.ID == id).FirstOrDefaultAsync();

            if (item != null)
            {
                context.WishlistItemTypes.Remove(item);
            }

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<WishlistItemType>> GetAllAsync()
        {
            var items = await context.WishlistItemTypes.ToListAsync();

            return items;
        }

        public async Task<WishlistItemType> GetUpdateDataAsync(int id)
        {
            var item = await context.WishlistItemTypes
                .Where(wt => wt.ID == id)
                .FirstOrDefaultAsync();

            return item;
        }

        public async Task<bool> CommandResultsInDuplicateEntryAsync(WishlistItemType wishlistItemType)
        {
            var item = await context.WishlistItemTypes
                .Where(wi =>
                    wi.ID != wi.ID &&
                    (wi.Name == wishlistItemType.Name || wi.OrdinalNumber == wishlistItemType.OrdinalNumber))
                .FirstOrDefaultAsync();

            if (item != null)
            {
                return true;
            }

            return false;
        }
    }
}
