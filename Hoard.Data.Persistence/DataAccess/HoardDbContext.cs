using Hoard.Data.Persistence.DataAccess.ModelBuilderExtensions;
using Hoard.Data.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoard.Data.Persistence.DataAccess
{
    public class HoardDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerProgress> PlayerProgress { get; set; }
        public DbSet<PlayStatus> PlayStatuses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=HoardMainDb;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ConfigureEntities();
            modelBuilder.SeedDatabase();
        }
    }
}
