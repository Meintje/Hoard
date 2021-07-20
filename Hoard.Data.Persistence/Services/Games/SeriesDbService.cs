using Hoard.Core.Entities.Games;
using Hoard.Core.Interfaces.Games;
using Hoard.Infrastructure.Persistence.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hoard.Infrastructure.Persistence.Services.Games
{
    public class SeriesDbService : ISeriesDbService
    {
        private readonly HoardDbContext context;

        public SeriesDbService(HoardDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Series series)
        {
            context.Add(series);

            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Series series)
        {
            context.Update(series);

            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var series = await context.Series.Where(s => s.ID == id).FirstOrDefaultAsync();

            if (series != null)
            {
                context.Series.Remove(series);
            }

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Series>> GetAllAsync()
        {
            var series = await context.Series.OrderBy(p => p.Name).ToListAsync();

            return series;
        }

        public async Task<Series> GetUpdateDataAsync(int id)
        {
            var series = await context.Series
                .Where(s => s.ID == id)
                .FirstOrDefaultAsync();

            return series;
        }

        public async Task<bool> CommandResultsInDuplicateEntryAsync(Series series)
        {
            var duplicateSeries = await context.Series
                .Where(s =>
                    s.ID != series.ID &&
                    s.Name == series.Name)
                .FirstOrDefaultAsync();

            if (duplicateSeries != null)
            {
                return true;
            }

            return false;
        }
    }
}
