using Hoard.Core.Entities.Games;
using Hoard.Core.Interfaces.Games;
using Hoard.Infrastructure.Persistence.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hoard.Infrastructure.Persistence.Services.Games
{
    public class GenreDbService : IGenreDbService
    {
        private readonly HoardDbContext context;

        public GenreDbService(HoardDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Genre genre)
        {
            context.Add(genre);

            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Genre genre)
        {
            context.Update(genre);

            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var genre = await context.Genres.Where(g => g.ID == id).FirstOrDefaultAsync();

            if (genre != null)
            {
                context.Genres.Remove(genre);
            }

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Genre>> GetAllAsync()
        {
            var genres = await context.Genres.OrderBy(g => g.Name).ToListAsync();

            return genres;
        }

        public async Task<Genre> GetUpdateDataAsync(int id)
        {
            var genre = await context.Genres
                .Where(g => g.ID == id)
                .FirstOrDefaultAsync();

            return genre;
        }

        public async Task<bool> CommandResultsInDuplicateEntryAsync(Genre genre)
        {
            var duplicateGenre = await context.Genres
                .Where(g =>
                    g.ID != genre.ID &&
                    g.Name == genre.Name)
                .FirstOrDefaultAsync();

            if (duplicateGenre != null)
            {
                return true;
            }

            return false;
        }
    }
}
