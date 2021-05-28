using Hoard.Core.Constants;
using Hoard.Core.Entities.Games;
using Hoard.Core.Entities.Wishlist;
using Hoard.WebUI.Services.ViewModels.Wishlist.CreateUpdate;
using Hoard.WebUI.Services.ViewModels.Wishlist.Index;
using Hoard.WebUI.Services.ViewModels.Wishlist.Index.InnerModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoard.WebUI.Services.Mapping.Wishlist
{
    internal static class WishlistMapper
    {
        internal static WishlistIndexViewModel ToIndexViewModel(IEnumerable<WishlistItem> wishlistItems)
        {
            var vm = new WishlistIndexViewModel();

            foreach (var item in wishlistItems)
            {
                vm.Items.Add(ToIndexItemViewModel(item));
            }

            return vm;
        }

        internal static WishlistIndexItemViewModel ToIndexItemViewModel(WishlistItem item)
        {
            // TODO: If URL is empty, map URL to Google search of Title?
            var vm = new WishlistIndexItemViewModel
            {
                ID = item.ID,
                ItemType = item.WishlistItemType.Name,
                Title = item.Title,
                AddDate = item.AddDate.ToString(EntityConstants.DateFormatString),
                ReleaseDate = item.ReleaseDate == null ? "Unknown" : ((DateTime)item.ReleaseDate).ToString(EntityConstants.DateFormatString),
                Priority = item.Priority.Name,
                Notes = item.Notes,
                URL = item.StoreURL,
                Language = item.Language.ShortName
            };

            return vm;
        }

        internal static WishlistCreateViewModel ToCreateViewModel(int hoarderID, IEnumerable<WishlistItemType> typeList, IEnumerable<Priority> priorityList, IEnumerable<Language> languageList)
        {
            var vm = new WishlistCreateViewModel
            {
                HoarderID = hoarderID
            };

            vm.WishlistItemTypeSelectList = new SelectList(typeList, nameof(WishlistItemType.ID), nameof(WishlistItemType.Name));
            vm.PrioritySelectList = new SelectList(priorityList, nameof(Priority.ID), nameof(Priority.Name));
            vm.LanguageSelectList = new SelectList(languageList, nameof(Language.ID), nameof(Language.Name));

            return vm;
        }

        internal static WishlistUpdateViewModel ToUpdateViewModel(WishlistItem wishlistItem, IEnumerable<WishlistItemType> typeList, IEnumerable<Priority> priorityList, IEnumerable<Language> languageList)
        {
            if ( wishlistItem == null )
            {
                return null;
            }

            var vm = new WishlistUpdateViewModel
            {
                ID = wishlistItem.ID,
                HoarderID = wishlistItem.HoarderID,
                Title = wishlistItem.Title,
                WishlistItemTypeID = wishlistItem.WishlistItemTypeID,
                PriorityID = wishlistItem.PriorityID,
                LanguageID = wishlistItem.LanguageID,
                StoreURL = wishlistItem.StoreURL,
                AddDate = wishlistItem.AddDate,
                ReleaseDate = wishlistItem.ReleaseDate,
                Notes = wishlistItem.Notes
            };

            vm.WishlistItemTypeSelectList = new SelectList(typeList, nameof(WishlistItemType.ID), nameof(WishlistItemType.Name));
            vm.PrioritySelectList = new SelectList(priorityList, nameof(Priority.ID), nameof(Priority.Name));
            vm.LanguageSelectList = new SelectList(languageList, nameof(Language.ID), nameof(Language.Name));

            return vm;
        }

        internal static WishlistItem ToNewWishlistItem(WishlistCreateViewModel wcVM)
        {
            var wishlistItem = new WishlistItem
            {
                HoarderID = wcVM.HoarderID,
                WishlistItemTypeID = wcVM.WishlistItemTypeID,
                PriorityID = wcVM.PriorityID,
                LanguageID = wcVM.LanguageID,
                Title = wcVM.Title,
                AddDate = DateTime.Today,
                ReleaseDate = wcVM.ReleaseDate,
                StoreURL = wcVM.StoreURL,
                Notes = wcVM.Notes
            };

            return wishlistItem;
        }

        internal static WishlistItem ToExistingWishlistItem(WishlistUpdateViewModel wuVM)
        {
            var wishlistItem = ToNewWishlistItem(wuVM);

            wishlistItem.ID = wuVM.ID;
            wishlistItem.AddDate = wuVM.AddDate;

            return wishlistItem;
        }
    }
}
