using Hoard.Core.Constants;
using System;
using System.ComponentModel.DataAnnotations;

namespace Hoard.WebUI.Services.ViewModels
{
    public class GameCreateViewModel
    {
        [Required(ErrorMessage = "A game needs a title.")]
        [MaxLength(EntityConstants.TitleMaximumLength, ErrorMessage = "Your title is too long.")]
        public string Title { get; set; }

        [Display(Name = "Release date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "A game needs a release date.")]
        public DateTime ReleaseDate { get; set; }

        [MaxLength(EntityConstants.NotesMaximumLength, ErrorMessage = "Your description is too long.")]
        public string Description { get; set; }
    }
}
