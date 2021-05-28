using Hoard.Core.Interfaces.Games;
using Hoard.Core.Interfaces.Wishlist;
using Hoard.WebUI.Services.Interfaces;
using Hoard.WebUI.Services.Mapping.Wishlist;
using Hoard.WebUI.Services.ViewModels.Wishlist.CreateUpdate;
using Hoard.WebUI.Services.ViewModels.Wishlist.Index;
using System.Threading.Tasks;

namespace Hoard.WebUI.Services.Services
{
    public class WishlistViewService : IWishlistViewService
    {
        private readonly IWishlistDbService wishlistDbService;
        private readonly IWishlistItemTypeDbService wishlistItemTypeDbService;
        private readonly IPriorityDbService priorityDbService;
        private readonly ILanguageDbService languageDbService;

        public WishlistViewService(IWishlistDbService wishlistDbService, IWishlistItemTypeDbService wishlistItemTypeDbService, IPriorityDbService priorityDbService, ILanguageDbService languageDbService)
        {
            this.wishlistDbService = wishlistDbService;
            this.wishlistItemTypeDbService = wishlistItemTypeDbService;
            this.priorityDbService = priorityDbService;
            this.languageDbService = languageDbService;
        }

        public async Task<WishlistIndexViewModel> GetIndex(int hoarderID)
        {
            var wishlistItems = await wishlistDbService.GetAllAsync(hoarderID);
            
            var vm = WishlistMapper.ToIndexViewModel(wishlistItems);

            return vm;
        }

        public async Task<WishlistCreateViewModel> GetCreateData(int hoarderID)
        {
            var itemTypeList = await wishlistItemTypeDbService.GetAllAsync();
            var priorityList = await priorityDbService.GetAllAsync();
            var languageList = await languageDbService.GetAllAsync();

            return WishlistMapper.ToCreateViewModel(hoarderID, itemTypeList, priorityList, languageList);
        }

        public async Task<WishlistUpdateViewModel> GetUpdateData(int id)
        {
            var item = await wishlistDbService.GetUpdateDataAsync(id);

            var itemTypeList = await wishlistItemTypeDbService.GetAllAsync();
            var priorityList = await priorityDbService.GetAllAsync();
            var languageList = await languageDbService.GetAllAsync();

            return WishlistMapper.ToUpdateViewModel(item, itemTypeList, priorityList, languageList);

        }

        public async Task Create(WishlistCreateViewModel wishlistCreateViewModel)
        {
            var newItem = WishlistMapper.ToNewWishlistItem(wishlistCreateViewModel);

            await wishlistDbService.AddAsync(newItem);
        }

        public async Task Update(WishlistUpdateViewModel wishlistUpdateViewModel)
        {
            var updatedItem = WishlistMapper.ToExistingWishlistItem(wishlistUpdateViewModel);

            await wishlistDbService.UpdateAsync(updatedItem);
        }

        public async Task Delete(int id)
        {
            await wishlistDbService.DeleteAsync(id);
        }

        public async Task<bool> CreateResultsInDuplicateEntry(WishlistCreateViewModel wishlistCreateViewModel)
        {
            var newItem =  WishlistMapper.ToNewWishlistItem(wishlistCreateViewModel);

            return await wishlistDbService.CreateResultsInDuplicateEntryAsync(newItem);
        }

        public async Task<bool> UpdateResultsInDuplicateEntry(WishlistUpdateViewModel wishlistUpdateViewModel)
        {
            var updatedItem = WishlistMapper.ToExistingWishlistItem(wishlistUpdateViewModel);

            return await wishlistDbService.UpdateResultsInDuplicateEntryAsync(updatedItem);
        }
    }
}
