using Hoard.Core.Entities.Games;
using Hoard.Core.Entities.Games.JoinEntities;
using Hoard.Core.Entities.Journal;
using Hoard.Core.Entities.Journal.JoinEntities;
using Hoard.Core.Entities.Wishlist;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoard.Infrastructure.DataSeeding
{
    internal class DataSeedingContext : DbContext
    {
        #region Games
        public DbSet<Hoarder> Hoarders { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<PlayData> PlayData { get; set; }
        public DbSet<Playthrough> Playthroughs { get; set; }
        public DbSet<PlayStatus> PlayStatuses { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<PlatformDeveloper> PlatformDevelopers { get; set; }
        public DbSet<PlatformType> PlatformTypes { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<GameGenre> GameGenres { get; set; }
        public DbSet<Mode> Modes { get; set; }
        public DbSet<GameMode> GameModes { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<GameSeries> GameSeries { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<GameDeveloper> GameDevelopers { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<GamePublisher> GamePublishers { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<MediaType> MediaTypes { get; set; }
        public DbSet<OwnershipStatus> OwnershipStatuses { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        #endregion

        #region Wishlist
        public DbSet<WishlistItem> WishlistItems { get; set; }
        public DbSet<WishlistItemType> WishlistItemTypes { get; set; }
        #endregion

        #region Journal
        public DbSet<JournalEntry> JournalEntries { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<JournalGame> JournalGames { get; set; }
        public DbSet<JournalTag> JournalTags { get; set; }
        #endregion


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = @"Server=(localdb)\\mssqllocaldb;Database=HoardMainDb;Trusted_Connection=True;MultipleActiveResultSets=true";

            optionsBuilder.UseSqlServer(connectionString).EnableSensitiveDataLogging();
        }
    }
}
