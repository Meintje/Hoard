using Hoard.Core.Interfaces.Games;
using Hoard.Core.Interfaces.Journal;
using Hoard.WebUI.Services.Interfaces;
using Hoard.WebUI.Services.Mapping.Journal;
using Hoard.WebUI.Services.ViewModels.Journal.CreateUpdate;
using Hoard.WebUI.Services.ViewModels.Journal.Details;
using Hoard.WebUI.Services.ViewModels.Journal.Index;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoard.WebUI.Services.Services
{
    public class JournalViewService : IJournalViewService
    {
        private readonly IJournalDbService journalDbService;
        private readonly ITagDbService tagDbService;
        private readonly IGameDbService gameDbService;

        public JournalViewService(IJournalDbService journalDbService, ITagDbService tagDbService, IGameDbService gameDbService)
        {
            this.journalDbService = journalDbService;
            this.tagDbService = tagDbService;
            this.gameDbService = gameDbService;
        }

        public async Task<JournalIndexViewModel> GetIndexAsync(int hoarderID, int pageNumber, int pageSize)
        {
            var journalEntries = await journalDbService.GetJournalPageAsync(hoarderID, pageNumber, pageSize);

            var vm = JournalEntryMapper.ToIndexViewModel(journalEntries);

            return vm;
        }

        public async Task<JournalDetailsViewModel> GetDetailsAsync(int id)
        {
            var journalEntry = await journalDbService.GetDetailsAsync(id);

            if (journalEntry == null)
            {
                return null;
            }

            var vm = JournalEntryMapper.ToDetailsViewModel(journalEntry);

            return vm;
        }

        public async Task<JournalCreateViewModel> GetCreateDataAsync(int hoarderID)
        {
            var tagList = await tagDbService.GetAllAsync();
            var gameList = await gameDbService.GetAllAsync();

            var vm = JournalEntryMapper.ToCreateViewModel(hoarderID, tagList, gameList);

            return vm;
        }

        public async Task<JournalUpdateViewModel> GetUpdateDataAsync(int id)
        {
            var journalEntry = await journalDbService.GetUpdateDataAsync(id);

            if (journalEntry == null)
            {
                return null;
            }

            var gameList = await gameDbService.GetAllAsync();
            var tagList = await tagDbService.GetAllAsync();

            var vm = JournalEntryMapper.ToUpdateViewModel(journalEntry, gameList, tagList);

            return vm;
        }

        public async Task CreateAsync(JournalCreateViewModel journalCreateViewModel)
        {
            var newEntry = JournalEntryMapper.ToNewJournalEntry(journalCreateViewModel);

            await journalDbService.AddAsync(newEntry);
        }

        public async Task UpdateAsync(JournalUpdateViewModel journalUpdateViewModel)
        {
            var updatedEntry = JournalEntryMapper.ToExistingJournalEntry(journalUpdateViewModel);

            await journalDbService.UpdateAsync(updatedEntry);
        }

        public async Task DeleteAsync(int id)
        {
            await journalDbService.DeleteAsync(id);
        }

        public async Task<bool> CreateResultsInDuplicateEntryAsync(JournalCreateViewModel journalCreateViewModel)
        {
            var newEntry = JournalEntryMapper.ToNewJournalEntry(journalCreateViewModel);

            bool resultsInDuplicateEntry = await journalDbService.CommandResultsInDuplicateEntryAsync(newEntry);

            return resultsInDuplicateEntry;
        }

        public async Task<bool> UpdateResultsInDuplicateEntryAsync(JournalUpdateViewModel journalUpdateViewModel)
        {
            var updatedEntry = JournalEntryMapper.ToExistingJournalEntry(journalUpdateViewModel);

            bool resultsInDuplicateEntry = await journalDbService.CommandResultsInDuplicateEntryAsync(updatedEntry);

            return resultsInDuplicateEntry;
        }
    }
}
