using Hoard.Data.Persistence.DataAccess.ModelBuilderExtensions;
using Hoard.Data.Entities.Game;
using Microsoft.EntityFrameworkCore;

namespace Hoard.Data.Persistence.DataAccess
{
    public class HoardDbContext : DbContext
    {
        public HoardDbContext(DbContextOptions<HoardDbContext> options) : base(options)
        {
            
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayData> PlayData { get; set; }
        public DbSet<Playthrough> Playthroughs { get; set; }
        public DbSet<PlayStatus> PlayStatuses { get; set; }
        public DbSet<Platform> Platforms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Applies entity configurations found in EntityConfigurations folder.
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HoardDbContext).Assembly);

            modelBuilder.SeedDatabase();
        }
    }
}
