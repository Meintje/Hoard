using Hoard.WebUI.Services.ViewModels.Wishlist.CreateUpdate;
using Hoard.WebUI.Services.ViewModels.Wishlist.Index;
using System.Threading.Tasks;

namespace Hoard.WebUI.Services.Interfaces
{
    public interface IWishlistViewService
    {
        public Task<WishlistIndexViewModel> GetIndexAsync(int hoarderID);
        public Task<WishlistCreateViewModel> GetCreateDataAsync(int hoarderID);
        public Task<WishlistUpdateViewModel> GetUpdateDataAsync(int id);
        public Task CreateAsync(WishlistCreateViewModel wishlistCreateViewModel);
        public Task UpdateAsync(WishlistUpdateViewModel wishlistUpdateViewModel);
        public Task DeleteAsync(int id);

        public Task<bool> CreateResultsInDuplicateEntryAsync(WishlistCreateViewModel wishlistCreateViewModel);
        public Task<bool> UpdateResultsInDuplicateEntryAsync(WishlistUpdateViewModel wishlistUpdateViewModel);
    }
}
