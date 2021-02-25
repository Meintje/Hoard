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
    public class PlatformDbService : IPlatformDbService
    {
        private readonly HoardDbContext context;

        public PlatformDbService(HoardDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Platform>> GetAllAsync()
        {
            var items = await context.Platforms.ToListAsync();

            return items;
        }
    }
}
