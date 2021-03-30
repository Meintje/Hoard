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
    public class PlayStatusDbService : IPlayStatusDbService
    {
        private readonly HoardDbContext context;

        public PlayStatusDbService(HoardDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<PlayStatus>> GetAllAsync()
        {
            var items = await context.PlayStatuses.ToListAsync();

            return items;
        }
    }
}
