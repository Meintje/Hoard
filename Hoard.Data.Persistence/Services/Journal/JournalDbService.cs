using Hoard.Core.Entities.Journal;
using Hoard.Core.Interfaces.Journal;
using Hoard.Infrastructure.Persistence.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoard.Infrastructure.Persistence.Services.Journal
{
    public class JournalDbService : IJournalDbService
    {
        private readonly HoardDbContext context;

        public JournalDbService(HoardDbContext context)
        {
            this.context = context;
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

        private void UpdateManyToManyRelation<T>(IEnumerable<T> oldItems, IEnumerable<T> newItems) where T : class
        {
            context.RemoveRange(oldItems);
            context.AddRange(newItems);
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
            var items = await context.JournalEntries
                .Where(j => j.HoarderID == hoarderID)
                .Include(j => j.Tags).ThenInclude(jt => jt.Tag)
                .Include(j => j.Games).ThenInclude(jg => jg.Game)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return items;
        }

        public async Task<IEnumerable<JournalEntry>> GetRecentJournalEntriesAsync(int hoarderID)
        {
            var items = await context.JournalEntries
                .Where(j => j.HoarderID == hoarderID)
                .Include(j => j.Tags).ThenInclude(jt => jt.Tag)
                .Include(j => j.Games).ThenInclude(jg => jg.Game)
                .OrderByDescending(j => j.Date)
                .Take(15)
                .ToListAsync();

            return items;
        }


        public async Task<JournalEntry> GetDetailsAsync(int id)
        {
            var item = await context.JournalEntries
                .Where(j => j.ID == id)
                .Include(j => j.Tags).ThenInclude(jt => jt.Tag)
                .Include(j => j.Games).ThenInclude(jg => jg.Game).ThenInclude(g => g.Platform)
                .FirstOrDefaultAsync();

            return item;
        }

        public async Task<JournalEntry> GetUpdateDataAsync(int id)
        {
            var item = await context.JournalEntries
                .Where(j => j.ID == id)
                .Include(j => j.Tags)
                .Include(j => j.Games)
                .FirstOrDefaultAsync();

            return item;
        }

        public async Task<bool> CommandResultsInDuplicateEntry(JournalEntry journalEntry)
        {
            var item = await context.JournalEntries
                .Where(j =>
                    j.ID != journalEntry.ID &&
                    j.Date == journalEntry.Date &&
                    j.HoarderID == journalEntry.HoarderID)
                .FirstOrDefaultAsync();

            if (item != null)
            {
                return true;
            }

            return false;
        }
    }
}
