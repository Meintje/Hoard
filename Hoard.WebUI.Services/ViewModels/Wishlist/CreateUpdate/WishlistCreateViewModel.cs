using Hoard.Core.Constants;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoard.WebUI.Services.ViewModels.Wishlist.CreateUpdate
{
    public class WishlistCreateViewModel
    {
        public string Title { get; set; }

        public int HoarderID { get; set; }

        [Display(Name = "Type")]
        [Required(ErrorMessage = "Please select a type.")]
        public int WishlistItemTypeID { get; set; }
        public SelectList WishlistItemTypeSelectList { get; set; }

        [Display(Name = "Priority")]
        [Required(ErrorMessage = "Please select a priority.")]
        public int PriorityID { get; set; }
        public SelectList PrioritySelectList { get; set; }

        [Display(Name = "Language")]
        [Required(ErrorMessage = "Please select a language.")]
        public int LanguageID { get; set; }
        public SelectList LanguageSelectList { get; set; }

        [MaxLength(EntityConstants.NotesMaximumLength, ErrorMessage = "Your URL is too long.")]
        public string StoreURL { get; set; }

        [Display(Name = "Release date")]
        [DataType(DataType.Date)]
        public DateTime? ReleaseDate { get; set; }

        [MaxLength(EntityConstants.NotesMaximumLength, ErrorMessage = "Your notes are too long.")]
        public string Notes { get; set; }
    }
}
