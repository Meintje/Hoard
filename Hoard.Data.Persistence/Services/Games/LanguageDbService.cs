using Hoard.Core.Entities.Games;
using Hoard.Core.Interfaces.Games;
using Hoard.Infrastructure.Persistence.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hoard.Infrastructure.Persistence.Services.Games
{
    public class LanguageDbService : ILanguageDbService
    {
        private readonly HoardDbContext context;

        public LanguageDbService(HoardDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Language language)
        {
            context.Add(language);

            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Language language)
        {
            context.Update(language);

            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var language = await context.Languages.Where(l => l.ID == id).FirstOrDefaultAsync();

            if (language != null)
            {
                context.Languages.Remove(language);
            }

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Language>> GetAllAsync()
        {
            var languages = await context.Languages.OrderBy(l => l.Name).ToListAsync();

            return languages;
        }

        public async Task<Language> GetUpdateDataAsync(int id)
        {
            var language = await context.Languages
                .Where(l => l.ID == id)
                .FirstOrDefaultAsync();

            return language;
        }

        public async Task<bool> CommandResultsInDuplicateEntryAsync(Language language)
        {
            var duplicateLanguage = await context.Languages
                .Where(l =>
                    l.ID != language.ID &&
                    l.Name == language.Name)
                .FirstOrDefaultAsync();

            if (duplicateLanguage != null)
            {
                return true;
            }

            return false;
        }
    }
}
