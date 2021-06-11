using Hoard.Core.Entities.Journal;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hoard.Core.Interfaces.Journal
{
    public interface IJournalDbService
    {
        public Task AddAsync(JournalEntry journalEntry);
        public Task UpdateAsync(JournalEntry journalEntry);
        public Task DeleteAsync(int id);
        public Task<IEnumerable<JournalEntry>> GetJournalPageAsync(int hoarderID, int pageNumber, int pageSize);
        public Task<IEnumerable<JournalEntry>> GetRecentJournalEntriesAsync(int hoarderID);
        public Task<JournalEntry> GetDetailsAsync(int id);
        public Task<JournalEntry> GetUpdateDataAsync(int id);
        public Task<bool> CommandResultsInDuplicateEntry(JournalEntry journalEntry);
    }
}
