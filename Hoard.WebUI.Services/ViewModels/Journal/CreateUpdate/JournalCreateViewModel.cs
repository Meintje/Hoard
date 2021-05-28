using Hoard.Core.Constants;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoard.WebUI.Services.ViewModels.Journal.CreateUpdate
{
    public class JournalCreateViewModel
    {
        public int HoarderID { get; set; }

        [Required(ErrorMessage = "I know thinking up a title is hard, but please try anyway.")]
        [MaxLength(EntityConstants.TitleMaximumLength, ErrorMessage = "This title is too long.")]
        public string Title { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Select a date.")]
        public DateTime? Date { get; set; }

        [Required(ErrorMessage = "What is a journal entry without content?")]
        [MaxLength(EntityConstants.JournalMaximumLength, ErrorMessage = "You must've had a very eventful day, because this journal entry is too long.")]
        public string Content { get; set; }

        [Display(Name = "Game(s)")]
        public int[] GameIDs { get; set; }
        public SelectList GameSelectList { get; set; }

        [Display(Name = "Tag(s)")]
        public int[] TagIDs { get; set; }
        public SelectList TagSelectList { get; set; }
    }
}
