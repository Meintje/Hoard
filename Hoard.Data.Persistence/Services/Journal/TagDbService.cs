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
    public class TagDbService : ITagDbService
    {
        private readonly HoardDbContext context;

        public TagDbService(HoardDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Tag tag)
        {
            context.Add(tag);

            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Tag tag)
        {
            context.Update(tag);

            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var tag = await context.Tags.Where(g => g.ID == id).FirstOrDefaultAsync();

            if (tag != null)
            {
                context.Tags.Remove(tag);
            }

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            var items = await context.Tags.ToListAsync();

            return items;
        }

        public async Task<Tag> GetUpdateDataAsync(int id)
        {
            var item = await context.Tags
                .Where(t => t.ID == id)
                .FirstOrDefaultAsync();

            return item;
        }

        public async Task<bool> CommandResultsInDuplicateEntryAsync(Tag tag)
        {
            var item = await context.Tags
                .Where(t =>
                    t.ID != tag.ID &&
                    t.Name == tag.Name)
                .FirstOrDefaultAsync();

            if (item != null)
            {
                return true;
            }

            return false;
        }
    }
}
