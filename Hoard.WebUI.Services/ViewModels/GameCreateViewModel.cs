using Hoard.Core.Constants;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hoard.WebUI.Services.ViewModels
{
    public class GameCreateViewModel
    {
        [Required(ErrorMessage = "A game needs a title.")]
        [MaxLength(EntityConstants.TitleMaximumLength, ErrorMessage = "Your title is too long.")]
        public string Title { get; set; }

        [Display(Name = "Platform")]
        [Required(ErrorMessage = "Please select a platform.")]
        public int PlatformID { get; set; }
        public SelectList PlatformSelectList { get; set; }

        [Display(Name = "Genre(s)")]
        public int[] GenreIDs { get; set; }
        public SelectList GenreSelectList { get; set; }

        [Display(Name = "Release date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "A game needs a release date.")]
        public DateTime ReleaseDate { get; set; }

        [MaxLength(EntityConstants.NotesMaximumLength, ErrorMessage = "Your description is too long.")]
        public string Description { get; set; }
    }
}
