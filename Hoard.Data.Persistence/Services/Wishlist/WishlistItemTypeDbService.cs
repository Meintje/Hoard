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

        public async Task CreateAsync(WishlistItemType wishlistItemType)
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
            var wishlistItemType = await context.WishlistItemTypes.Where(wt => wt.ID == id).FirstOrDefaultAsync();

            if (wishlistItemType != null)
            {
                context.WishlistItemTypes.Remove(wishlistItemType);
            }

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<WishlistItemType>> GetAllAsync()
        {
            var wishlistItemTypes = await context.WishlistItemTypes.OrderBy(wt => wt.OrdinalNumber).ToListAsync();

            return wishlistItemTypes;
        }

        public async Task<WishlistItemType> GetUpdateDataAsync(int id)
        {
            var wishlistItemType = await context.WishlistItemTypes
                .Where(wt => wt.ID == id)
                .FirstOrDefaultAsync();

            return wishlistItemType;
        }

        public async Task<bool> CommandResultsInDuplicateEntryAsync(WishlistItemType wishlistItemType)
        {
            var duplicateWishlistItemType = await context.WishlistItemTypes
                .Where(wt =>
                    wt.ID != wishlistItemType.ID &&
                    (wt.Name == wishlistItemType.Name || wt.OrdinalNumber == wishlistItemType.OrdinalNumber))
                .FirstOrDefaultAsync();

            if (duplicateWishlistItemType != null)
            {
                return true;
            }

            return false;
        }
    }
}
