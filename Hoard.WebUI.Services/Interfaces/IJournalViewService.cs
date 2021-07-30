using Hoard.WebUI.Services.ViewModels.Journal.CreateUpdate;
using Hoard.WebUI.Services.ViewModels.Journal.Details;
using Hoard.WebUI.Services.ViewModels.Journal.Index;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoard.WebUI.Services.Interfaces
{
    public interface IJournalViewService
    {
        public Task<JournalIndexViewModel> GetIndexAsync(int hoarderID, int pageNumber, int pageSize);
        public Task<JournalDetailsViewModel> GetDetailsAsync(int id);
        public Task<JournalCreateViewModel> GetCreateDataAsync(int hoarderID);
        public Task<JournalUpdateViewModel> GetUpdateDataAsync(int id);
        public Task CreateAsync(JournalCreateViewModel journalCreateViewModel);
        public Task UpdateAsync(JournalUpdateViewModel journalUpdateViewModel);
        public Task DeleteAsync(int id);

        public Task<bool> CreateResultsInDuplicateEntryAsync(JournalCreateViewModel journalCreateViewModel);
        public Task<bool> UpdateResultsInDuplicateEntryAsync(JournalUpdateViewModel journalUpdateViewModel);
    }
}
