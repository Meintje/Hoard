using Hoard.Core.Entities.Games;
using Hoard.Core.Interfaces.Games;
using Hoard.Infrastructure.Persistence.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hoard.Infrastructure.Persistence.Services.Games
{
    public class MediaTypeDbService : IMediaTypeDbService
    {
        private readonly HoardDbContext context;

        public MediaTypeDbService(HoardDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(MediaType mediaType)
        {
            context.Add(mediaType);

            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(MediaType mediaType)
        {
            context.Update(mediaType);

            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var mediaType = await context.MediaTypes.Where(mt => mt.ID == id).FirstOrDefaultAsync();

            if (mediaType != null)
            {
                context.MediaTypes.Remove(mediaType);
            }

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<MediaType>> GetAllAsync()
        {
            var mediaTypes = await context.MediaTypes.OrderByDescending(mt => mt.Name).ToListAsync();

            return mediaTypes;
        }

        public async Task<MediaType> GetUpdateDataAsync(int id)
        {
            var mediaType = await context.MediaTypes
                .Where(mt => mt.ID == id)
                .FirstOrDefaultAsync();

            return mediaType;
        }

        public async Task<bool> CommandResultsInDuplicateEntryAsync(MediaType mediaType)
        {
            var duplicateMediaType = await context.MediaTypes
                .Where(mt =>
                    mt.ID != mediaType.ID &&
                    mt.Name == mediaType.Name)
                .FirstOrDefaultAsync();

            if (duplicateMediaType != null)
            {
                return true;
            }

            return false;
        }
    }
}
