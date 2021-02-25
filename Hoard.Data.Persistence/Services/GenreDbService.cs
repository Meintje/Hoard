using Hoard.Core.Entities.Game;
using Hoard.Core.Interfaces;
using Hoard.Data.Persistence.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoard.Infrastructure.Persistence.Services
{
    public class GenreDbService : IGenreDbService
    {
        private readonly HoardDbContext context;

        public GenreDbService(HoardDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Genre>> GetAllAsync()
        {
            var items = await context.Genres.ToListAsync();

            return items;
        }
    }
}
