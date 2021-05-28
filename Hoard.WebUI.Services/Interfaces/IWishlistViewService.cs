using Hoard.WebUI.Services.ViewModels.Wishlist.CreateUpdate;
using Hoard.WebUI.Services.ViewModels.Wishlist.Index;
using System.Threading.Tasks;

namespace Hoard.WebUI.Services.Interfaces
{
    public interface IWishlistViewService
    {
        public Task<WishlistIndexViewModel> GetIndex(int hoarderID);
        public Task<WishlistCreateViewModel> GetCreateData(int hoarderID);
        public Task<WishlistUpdateViewModel> GetUpdateData(int id);
        public Task Create(WishlistCreateViewModel wishlistCreateViewModel);
        public Task Update(WishlistUpdateViewModel wishlistUpdateViewModel);
        public Task Delete(int id);

        public Task<bool> CreateResultsInDuplicateEntry(WishlistCreateViewModel wishlistCreateViewModel);
        public Task<bool> UpdateResultsInDuplicateEntry(WishlistUpdateViewModel wishlistUpdateViewModel);
    }
}
