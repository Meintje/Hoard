using Hoard.Infrastructure.Persistence.DataAccess.ModelBuilderExtensions;
using Hoard.Core.Entities.Games;
using Hoard.Core.Entities.Games.JoinEntities;
using Microsoft.EntityFrameworkCore;
using Hoard.Core.Entities.Wishlist;
using Hoard.Core.Entities.Journal;
using Hoard.Core.Entities.Journal.JoinEntities;

namespace Hoard.Infrastructure.Persistence.DataAccess
{
    public class HoardDbContext : DbContext
    {
        public HoardDbContext(DbContextOptions<HoardDbContext> options) : base(options)
        {
            
        }

        #region Games
        public DbSet<Hoarder> Hoarders { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<PlayData> PlayData { get; set; }
        public DbSet<Playthrough> Playthroughs { get; set; }
        public DbSet<PlayStatus> PlayStatuses { get; set; }
        public DbSet<Platform> Platforms { get; set; }
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Applies entity configurations (found in EntityConfigurations folder).
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HoardDbContext).Assembly);

            #region Games
            modelBuilder.SeedHoarders();
            modelBuilder.SeedPlatforms();
            modelBuilder.SeedLanguages();
            modelBuilder.SeedMediaTypes();
            modelBuilder.SeedGenres();
            modelBuilder.SeedDevelopers();
            modelBuilder.SeedPublishers();
            modelBuilder.SeedModes();
            modelBuilder.SeedSeries();
            modelBuilder.SeedGames();
            modelBuilder.SeedGameGenres();
            modelBuilder.SeedGameDevelopers();
            modelBuilder.SeedGamePublishers();
            modelBuilder.SeedGameModes();
            modelBuilder.SeedGameSeries();
            modelBuilder.SeedPlayStatuses();
            modelBuilder.SeedOwnershipStatuses();
            modelBuilder.SeedPriorities();
            modelBuilder.SeedPlayData();
            modelBuilder.SeedPlaythroughs();
            #endregion

            #region Wishlist
            modelBuilder.SeedWishlistItemTypes();
            modelBuilder.SeedWishlistItems();
            #endregion

            #region Journal
            modelBuilder.SeedTags();
            modelBuilder.SeedJournalEntries();
            modelBuilder.SeedJournalTags();
            modelBuilder.SeedJournalGames();
            #endregion
        }
    }
}
