using Hoard.Core.Entities.Journal;
using Hoard.Core.Interfaces.Journal;
using Hoard.Infrastructure.Persistence.DataAccess;
using Hoard.Infrastructure.Persistence.Services.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoard.Infrastructure.Persistence.Services.Journal
{
    public class JournalDbService : BaseDbService, IJournalDbService
    {
        public JournalDbService(HoardDbContext context) : base(context)
        {
        }

        public async Task AddAsync(JournalEntry journalEntry)
        {
            context.Add(journalEntry);

            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(JournalEntry journalEntry)
        {
            var oldGames = await context.JournalGames.Where(jg => jg.JournalEntryID == journalEntry.ID).ToListAsync();
            UpdateManyToManyRelation(oldGames, journalEntry.Games);

            var oldTags = await context.JournalTags.Where(jt => jt.JournalEntryID == journalEntry.ID).ToListAsync();
            UpdateManyToManyRelation(oldTags, journalEntry.Tags);

            context.Update(journalEntry);

            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var journalEntry = await context.JournalEntries.Where(j => j.ID == id).FirstOrDefaultAsync();

            if (journalEntry != null)
            {
                context.JournalEntries.Remove(journalEntry);
            }

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<JournalEntry>> GetJournalPageAsync(int hoarderID, int pageNumber, int pageSize)
        {
            var journalEntries = await context.JournalEntries
                .Where(j => j.HoarderID == hoarderID)
                .Include(j => j.Tags).ThenInclude(jt => jt.Tag)
                .Include(j => j.Games).ThenInclude(jg => jg.Game)
                .OrderByDescending(j => j.Date)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return journalEntries;
        }

        public async Task<IEnumerable<JournalEntry>> GetRecentJournalEntriesAsync(int hoarderID)
        {
            var journalEntries = await context.JournalEntries
                .Where(j => j.HoarderID == hoarderID)
                .Include(j => j.Tags).ThenInclude(jt => jt.Tag)
                .Include(j => j.Games).ThenInclude(jg => jg.Game)
                .OrderByDescending(j => j.Date)
                .Take(15)
                .ToListAsync();

            return journalEntries;
        }


        public async Task<JournalEntry> GetDetailsAsync(int id)
        {
            var journalEntry = await context.JournalEntries
                .Where(j => j.ID == id)
                .Include(j => j.Tags).ThenInclude(jt => jt.Tag)
                .Include(j => j.Games).ThenInclude(jg => jg.Game).ThenInclude(g => g.Platform)
                .FirstOrDefaultAsync();

            return journalEntry;
        }

        public async Task<JournalEntry> GetUpdateDataAsync(int id)
        {
            var journalEntry = await context.JournalEntries
                .Where(j => j.ID == id)
                .Include(j => j.Tags)
                .Include(j => j.Games)
                .FirstOrDefaultAsync();

            return journalEntry;
        }

        public async Task<bool> CommandResultsInDuplicateEntry(JournalEntry journalEntry)
        {
            var duplicateJournalEntry = await context.JournalEntries
                .Where(j =>
                    j.ID != journalEntry.ID &&
                    j.Date == journalEntry.Date &&
                    j.HoarderID == journalEntry.HoarderID)
                .FirstOrDefaultAsync();

            if (duplicateJournalEntry != null)
            {
                return true;
            }

            return false;
        }
    }
}
