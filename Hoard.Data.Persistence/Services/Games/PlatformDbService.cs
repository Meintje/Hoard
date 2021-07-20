﻿using Hoard.Core.Entities.Games;
using Hoard.Core.Interfaces.Games;
using Hoard.Infrastructure.Persistence.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hoard.Infrastructure.Persistence.Services.Games
{
    public class PlatformDbService : IPlatformDbService
    {
        private readonly HoardDbContext context;

        public PlatformDbService(HoardDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Platform platform)
        {
            context.Add(platform);

            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Platform platform)
        {
            context.Update(platform);

            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var platform = await context.Platforms.Where(p => p.ID == id).FirstOrDefaultAsync();

            if (platform != null)
            {
                context.Platforms.Remove(platform);
            }

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Platform>> GetAllAsync()
        {
            var platforms = await context.Platforms.OrderBy(p => p.Name).ToListAsync();

            return platforms;
        }

        public async Task<Platform> GetUpdateDataAsync(int id)
        {
            var platform = await context.Platforms
                .Where(p => p.ID == id)
                .FirstOrDefaultAsync();

            return platform;
        }

        public async Task<bool> CommandResultsInDuplicateEntryAsync(Platform platform)
        {
            var duplicatePlatform = await context.Platforms
                .Where(p =>
                    p.ID != platform.ID &&
                    p.Name == platform.Name)
                .FirstOrDefaultAsync();

            if (duplicatePlatform != null)
            {
                return true;
            }

            return false;
        }
    }
}
