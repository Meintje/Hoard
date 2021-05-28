using Hoard.Core.Constants;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hoard.WebUI.Services.ViewModels.Game.GameCreateUpdate
{
    public class GameCreateViewModel
    {
        [Required(ErrorMessage = "A game needs a title.")]
        [MaxLength(EntityConstants.TitleMaximumLength, ErrorMessage = "This title is too long.")]
        public string Title { get; set; }

        [Display(Name = "Alternate title")]
        [MaxLength(EntityConstants.TitleMaximumLength, ErrorMessage = "This alternate title is too long.")]
        public string AlternateTitle { get; set; }

        [Display(Name = "Platform")]
        [Required(ErrorMessage = "Please select a platform.")]
        public int PlatformID { get; set; }
        public SelectList PlatformSelectList { get; set; }

        [Display(Name = "Language")]
        [Required(ErrorMessage = "Please select a language.")]
        public int LanguageID { get; set; }
        public SelectList LanguageSelectList { get; set; }

        [Display(Name = "Media type")]
        [Required(ErrorMessage = "Please select a media type.")]
        public int MediaTypeID { get; set; }
        public SelectList MediaTypeSelectList { get; set; }

        [Display(Name = "Genre(s)")]
        public int[] GenreIDs { get; set; }
        public SelectList GenreSelectList { get; set; }

        [Display(Name = "Series")]
        public int[] SeriesIDs { get; set; }
        public SelectList SeriesSelectList { get; set; }

        [Display(Name = "Mode(s)")]
        public int[] ModeIDs { get; set; }
        public SelectList ModeSelectList { get; set; }

        [Display(Name = "Developer(s)")]
        public int[] DeveloperIDs { get; set; }
        public SelectList DeveloperSelectList { get; set; }

        [Display(Name = "Publisher(s)")]
        public int[] PublisherIDs { get; set; }
        public SelectList PublisherSelectList { get; set; }

        [Display(Name = "Release date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "A game needs a release date.")]
        public DateTime? ReleaseDate { get; set; }

        [MaxLength(EntityConstants.NotesMaximumLength, ErrorMessage = "Your description is too long.")]
        public string Description { get; set; }
    }
}
