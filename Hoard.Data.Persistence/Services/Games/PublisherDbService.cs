using Hoard.Core.Entities.Games;
using Hoard.Core.Interfaces.Games;
using Hoard.Infrastructure.Persistence.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hoard.Infrastructure.Persistence.Services.Games
{
    public class PublisherDbService : IPublisherDbService
    {
        private readonly HoardDbContext context;

        public PublisherDbService(HoardDbContext context)
        {
            this.context = context;
        }

        public async Task CreateAsync(Publisher publisher)
        {
            context.Add(publisher);

            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Publisher publisher)
        {
            context.Update(publisher);

            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var publisher = await context.Publishers.Where(p => p.ID == id).FirstOrDefaultAsync();

            if (publisher != null)
            {
                context.Publishers.Remove(publisher);
            }

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Publisher>> GetAllAsync()
        {
            var publishers = await context.Publishers.OrderBy(p => p.Name).ToListAsync();

            return publishers;
        }

        public async Task<Publisher> GetUpdateDataAsync(int id)
        {
            var publisher = await context.Publishers
                .Where(p => p.ID == id)
                .FirstOrDefaultAsync();

            return publisher;
        }

        public async Task<bool> CommandResultsInDuplicateEntryAsync(Publisher publisher)
        {
            var duplicatePublisher = await context.Publishers
                .Where(p =>
                    p.ID != publisher.ID &&
                    p.Name == publisher.Name)
                .FirstOrDefaultAsync();

            if (duplicatePublisher != null)
            {
                return true;
            }

            return false;
        }
    }
}
