using Hoard.Core.Constants;
using Hoard.Core.Entities.Games;
using Hoard.Core.Entities.Journal;
using Hoard.Core.Entities.Journal.JoinEntities;
using Hoard.WebUI.Services.ViewModels.Journal.CreateUpdate;
using Hoard.WebUI.Services.ViewModels.Journal.Details;
using Hoard.WebUI.Services.ViewModels.Journal.Index;
using Hoard.WebUI.Services.ViewModels.Journal.Index.InnerModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoard.WebUI.Services.Mapping.Journal
{
    internal static class JournalEntryMapper
    {
        internal static JournalIndexViewModel ToIndexViewModel(IEnumerable<JournalEntry> journalEntries)
        {
            var vm = new JournalIndexViewModel();

            foreach (var journalEntry in journalEntries)
            {
                vm.JournalEntries.Add(JournalEntryMapper.ToIndexItemViewModel(journalEntry));
            }

            return vm;
        }

        internal static JournalIndexItemViewModel ToIndexItemViewModel(JournalEntry journalEntry)
        {
            var vm = new JournalIndexItemViewModel
            {
                ID = journalEntry.ID,
                Title = journalEntry.Title,
                Date = journalEntry.Date.ToString(EntityConstants.DateFormatString),
                Content = journalEntry.Content,
                Games = journalEntry.FullGames,
                Tags = journalEntry.FullTags
            };

            return vm;
        }

        internal static JournalDetailsViewModel ToDetailsViewModel(JournalEntry journalEntry)
        {
            var vm = new JournalDetailsViewModel();

            return vm;
        }

        internal static JournalCreateViewModel ToCreateViewModel(IEnumerable<Tag> tagList, IEnumerable<Game> gameList)
        {
            var vm = new JournalCreateViewModel();

            vm.GameSelectList = new SelectList(gameList, nameof(Game.ID), nameof(Game.Title));
            vm.TagSelectList = new SelectList(tagList, nameof(Tag.ID), nameof(Tag.Name));

            return vm;
        }

        internal static JournalUpdateViewModel ToUpdateViewModel(JournalEntry journalEntry, IEnumerable<Game> gameList, IEnumerable<Tag> tagList)
        {
            if ( journalEntry == null )
            {
                return null;
            }

            var vm = new JournalUpdateViewModel
            {
                ID = journalEntry.ID,
                HoarderID = journalEntry.HoarderID,
                Title = journalEntry.Title,
                Date = journalEntry.Date,
                Content = journalEntry.Content
            };

            if (journalEntry.Games != null && journalEntry.Games.Count > 0)
            {
                var selectedGames = new List<int>();
                foreach (var game in journalEntry.Games)
                {
                    selectedGames.Add(game.GameID);
                }
                vm.GameIDs = selectedGames.ToArray();
            }

            if (journalEntry.Tags != null && journalEntry.Tags.Count > 0)
            {
                var selectedTags = new List<int>();
                foreach (var tag in journalEntry.Tags)
                {
                    selectedTags.Add(tag.TagID);
                }
                vm.TagIDs = selectedTags.ToArray();
            }

            vm.GameSelectList = new SelectList(gameList, nameof(Game.ID), nameof(Game.Title));
            vm.TagSelectList = new SelectList(tagList, nameof(Tag.ID), nameof(Tag.Name));

            return vm;
        }

        internal static JournalEntry ToNewJournalEntry(JournalCreateViewModel journalVM)
        {
            var journalEntry = new JournalEntry
            {
                HoarderID = journalVM.HoarderID,
                Title = journalVM.Title,
                Date = (DateTime)journalVM.Date,
                Content = journalVM.Content,
                Games = new List<JournalGame>(),
                Tags = new List<JournalTag>()
            };

            if (journalVM.GameIDs != null && journalVM.GameIDs.Length > 0)
            {
                foreach (var gameID in journalVM.GameIDs)
                {
                    journalEntry.Games.Add(new JournalGame { GameID = gameID });
                }
            }

            if (journalVM.TagIDs != null && journalVM.TagIDs.Length > 0)
            {
                foreach (var tagID in journalVM.TagIDs)
                {
                    journalEntry.Tags.Add(new JournalTag { TagID = tagID });
                }
            }

            return journalEntry;
        }

        internal static JournalEntry ToExistingJournalEntry(JournalUpdateViewModel journalVM)
        {
            var journalEntry = ToNewJournalEntry(journalVM);
            journalEntry.ID = journalVM.ID;

            return journalEntry;
        }
    }
}
