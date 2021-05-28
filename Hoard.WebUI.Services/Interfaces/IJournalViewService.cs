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
        public Task<JournalIndexViewModel> GetIndex(int hoarderID, int pageNumber, int pageSize);
        public Task<JournalDetailsViewModel> GetDetails(int id);
        public Task<JournalCreateViewModel> GetCreateData(int hoarderID);
        public Task<JournalUpdateViewModel> GetUpdateData(int id);
        public Task Create(JournalCreateViewModel journalCreateViewModel);
        public Task Update(JournalUpdateViewModel journalUpdateViewModel);
        public Task Delete(int id);

        public Task<bool> CreateResultsInDuplicateEntry(JournalCreateViewModel journalCreateViewModel);
        public Task<bool> UpdateResultsInDuplicateEntry(JournalUpdateViewModel journalUpdateViewModel);
    }
}
