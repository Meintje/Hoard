using Hoard.Core.Entities.Games;
using Hoard.Core.Entities.Games.JoinEntities;
using Hoard.Core.Entities.Journal;
using Hoard.Core.Entities.Journal.JoinEntities;
using Hoard.Core.Entities.Wishlist;
using Microsoft.EntityFrameworkCore;
using System;

namespace Hoard.Infrastructure.Persistence.DataAccess.ModelBuilderExtensions
{
    internal static class SeedData
    {
        #region Games
        internal static void SeedHoarders(this ModelBuilder builder)
        {
            builder.Entity<Hoarder>().HasData(
                new Hoarder { ID = 1, Name = "Meintje" },
                new Hoarder { ID = 2, Name = "Bram" });
        }

        internal static void SeedPlatforms(this ModelBuilder builder)
        {
            builder.Entity<Platform>().HasData(
               new Platform { ID = 1, Name = "Sony Playstation", ShortName = "PSX" },
               new Platform { ID = 2, Name = "Sony Playstation 2", ShortName = "PS2" },
               new Platform { ID = 3, Name = "Sony Playstation 3", ShortName = "PS3" },
               new Platform { ID = 4, Name = "Sony Playstation 4", ShortName = "PS4" },
               new Platform { ID = 5, Name = "Sony Playstation 5", ShortName = "PS5" },
               new Platform { ID = 6, Name = "Sony Playstation Portable", ShortName = "PSP" },
               new Platform { ID = 7, Name = "Sony Playstation Vita", ShortName = "PSVita" },
               new Platform { ID = 8, Name = "Nintendo Entertainment System", ShortName = "NES" },
               new Platform { ID = 9, Name = "Super Nintendo Entertainment System", ShortName = "SNES" },
               new Platform { ID = 10, Name = "Nintendo 64", ShortName = "N64" },
               new Platform { ID = 11, Name = "Nintendo GameCube", ShortName = "GCN" },
               new Platform { ID = 12, Name = "Nintendo Wii", ShortName = "Wii" },
               new Platform { ID = 13, Name = "Nintendo Wii U", ShortName = "Wii U" },
               new Platform { ID = 14, Name = "Nintendo Switch", ShortName = "Switch" },
               new Platform { ID = 15, Name = "Nintendo Game Boy", ShortName = "GB" },
               new Platform { ID = 16, Name = "Nintendo Game Boy Color", ShortName = "GBC" },
               new Platform { ID = 17, Name = "Nintendo Game Boy Advance", ShortName = "GBA" },
               new Platform { ID = 18, Name = "Nintendo DS", ShortName = "DS" },
               new Platform { ID = 19, Name = "Nintendo 3DS", ShortName = "3DS" },
               new Platform { ID = 20, Name = "Microsoft Xbox", ShortName = "Xbox" },
               new Platform { ID = 21, Name = "Microsoft Xbox 360", ShortName = "X360" },
               new Platform { ID = 22, Name = "Microsoft Xbox One", ShortName = "XOne" },
               new Platform { ID = 23, Name = "Microsoft Xbox Series X|S", ShortName = "XSXS" },
               new Platform { ID = 24, Name = "Steam", ShortName = "Steam" });
        }

        internal static void SeedGenres(this ModelBuilder builder)
        {
            builder.Entity<Genre>().HasData(
               new Genre { ID = 1, Name = "Turn-based RPG" },
               new Genre { ID = 2, Name = "Action RPG" },
               new Genre { ID = 3, Name = "Platform" },
               new Genre { ID = 4, Name = "Visual novel" });
        }

        internal static void SeedDevelopers(this ModelBuilder builder)
        {
            builder.Entity<Developer>().HasData(
               new Developer { ID = 1, Name = "Nihon Falcom" },
               new Developer { ID = 2, Name = "CAPCOM" },
               new Developer { ID = 3, Name = "Good-Feel" });
        }

        internal static void SeedPublishers(this ModelBuilder builder)
        {
            builder.Entity<Publisher>().HasData(
               new Publisher { ID = 1, Name = "Nihon Falcom" },
               new Publisher { ID = 2, Name = "CAPCOM" },
               new Publisher { ID = 3, Name = "Nintendo" });
        }

        internal static void SeedSeries(this ModelBuilder builder)
        {
            builder.Entity<Series>().HasData(
               new Series { ID = 1, Name = "Trails" },
               new Series { ID = 2, Name = "The Legend of Heroes" },
               new Series { ID = 3, Name = "Monster Hunter" },
               new Series { ID = 4, Name = "Yoshi" });
        }

        internal static void SeedModes(this ModelBuilder builder)
        {
            builder.Entity<Mode>().HasData(
               new Mode { ID = 1, Name = "Single-player" },
               new Mode { ID = 2, Name = "Cooperative multiplayer" },
               new Mode { ID = 3, Name = "Competitive multiplayer" },
               new Mode { ID = 4, Name = "MMO" });
        }

        internal static void SeedLanguages(this ModelBuilder builder)
        {
            builder.Entity<Language>().HasData(
               new Language { ID = 1, Name = "English", ShortName = "EN" },
               new Language { ID = 2, Name = "Japanese", ShortName = "JP" });
        }

        internal static void SeedMediaTypes(this ModelBuilder builder)
        {
            builder.Entity<MediaType>().HasData(
               new MediaType { ID = 1, Name = "Physical" },
               new MediaType { ID = 2, Name = "Digital" });
        }

        internal static void SeedGames(this ModelBuilder builder)
        {
            builder.Entity<Game>().HasData(
                new Game { ID = 1, Title = "The Legend of Heroes: Trails in the Sky FC Evolution", AlternateTitle = "英雄伝説 空の軌跡 FC Evolution", ReleaseDate = DateTime.Parse("2015-06-11"), PlatformID = 7, LanguageID = 2, MediaTypeID = 1 },
                new Game { ID = 2, Title = "Monster Hunter World", ReleaseDate = DateTime.Parse("2018-08-09"), PlatformID = 24, LanguageID = 1, MediaTypeID = 2 },
                new Game { ID = 3, Title = "Yoshi's Woolly World", ReleaseDate = DateTime.Parse("2015-06-26"), PlatformID = 13, LanguageID = 1, MediaTypeID = 1 });
        }

        internal static void SeedGameGenres(this ModelBuilder builder)
        {
            builder.Entity<GameGenre>().HasData(
                new GameGenre { GameID = 1, GenreID = 1 },
                new GameGenre { GameID = 1, GenreID = 4 },
                new GameGenre { GameID = 2, GenreID = 2 },
                new GameGenre { GameID = 3, GenreID = 3 });
        }

        internal static void SeedGameDevelopers(this ModelBuilder builder)
        {
            builder.Entity<GameDeveloper>().HasData(
                new GameDeveloper { GameID = 1, DeveloperID = 1 },
                new GameDeveloper { GameID = 2, DeveloperID = 2 },
                new GameDeveloper { GameID = 3, DeveloperID = 3 });
        }

        internal static void SeedGamePublishers(this ModelBuilder builder)
        {
            builder.Entity<GamePublisher>().HasData(
                new GamePublisher { GameID = 1, PublisherID = 1 },
                new GamePublisher { GameID = 2, PublisherID = 2 },
                new GamePublisher { GameID = 3, PublisherID = 3 });
        }

        internal static void SeedGameSeries(this ModelBuilder builder)
        {
            builder.Entity<GameSeries>().HasData(
                new GameSeries { GameID = 1, SeriesID = 1 },
                new GameSeries { GameID = 1, SeriesID = 2 },
                new GameSeries { GameID = 2, SeriesID = 3 },
                new GameSeries { GameID = 3, SeriesID = 4 });
        }

        internal static void SeedGameModes(this ModelBuilder builder)
        {
            builder.Entity<GameMode>().HasData(
                new GameMode { GameID = 1, ModeID = 1 },
                new GameMode { GameID = 2, ModeID = 1 },
                new GameMode { GameID = 2, ModeID = 2 },
                new GameMode { GameID = 3, ModeID = 1 },
                new GameMode { GameID = 3, ModeID = 2 });
        }

        internal static void SeedPlayStatuses(this ModelBuilder builder)
        {
            builder.Entity<PlayStatus>().HasData(
                new PlayStatus { ID = 1, Name = "Playing", OrdinalNumber = 1 },
                new PlayStatus { ID = 2, Name = "Hiatus", OrdinalNumber = 2 },
                new PlayStatus { ID = 3, Name = "Finished", OrdinalNumber = 3 },
                new PlayStatus { ID = 4, Name = "Dropped", OrdinalNumber = 4 },
                new PlayStatus { ID = 5, Name = "Endless", OrdinalNumber = 5 });
        }

        internal static void SeedOwnershipStatuses(this ModelBuilder builder)
        {
            builder.Entity<OwnershipStatus>().HasData(
                new OwnershipStatus { ID = 1, OrdinalNumber = 1, Name = "Owned" },
                new OwnershipStatus { ID = 2, OrdinalNumber = 2, Name = "Household" },
                new OwnershipStatus { ID = 3, OrdinalNumber = 3, Name = "Borrowed" },
                new OwnershipStatus { ID = 4, OrdinalNumber = 4, Name = "Subscription" },
                new OwnershipStatus { ID = 5, OrdinalNumber = 5, Name = "Formerly owned" },
                new OwnershipStatus { ID = 6, OrdinalNumber = 6, Name = "Other" });
        }

        internal static void SeedPriorities(this ModelBuilder builder)
        {
            builder.Entity<Priority>().HasData(
                new Priority { ID = 1, Name = "Highest", OrdinalNumber = 1 },
                new Priority { ID = 2, Name = "High", OrdinalNumber = 2 },
                new Priority { ID = 3, Name = "Neutral", OrdinalNumber = 3 },
                new Priority { ID = 4, Name = "Low", OrdinalNumber = 4 },
                new Priority { ID = 5, Name = "Lowest", OrdinalNumber = 5 });
        }

        internal static void SeedPlayData(this ModelBuilder builder)
        {
            builder.Entity<PlayData>().HasData(
                new PlayData { ID = 1, GameID = 1, HoarderID = 1, Dropped = false, AchievementsCompleted = true, OwnershipStatusID = 1, PriorityID = 1 },       // 1: Trails in the Sky, Meintje
                new PlayData { ID = 2, GameID = 1, HoarderID = 2, Dropped = true, AchievementsCompleted = false, OwnershipStatusID = 1, PriorityID = 5 },       // 2: Trails in the Sky, Bram
                new PlayData { ID = 3, GameID = 2, HoarderID = 1, Dropped = false, AchievementsCompleted = false, OwnershipStatusID = 1, PriorityID = 2 },      // 3: Monster Hunter World, Meintje
                new PlayData { ID = 4, GameID = 2, HoarderID = 2, Dropped = false, AchievementsCompleted = false, OwnershipStatusID = 1, PriorityID = 2 },      // 4: Monster Hunter World, Bram
                new PlayData { ID = 5, GameID = 3, HoarderID = 1, Dropped = false, AchievementsCompleted = true, OwnershipStatusID = 1, PriorityID = 4 },       // 5: Yoshi's Woolly World, Meintje
                new PlayData { ID = 6, GameID = 3, HoarderID = 2, Dropped = true, AchievementsCompleted = false, OwnershipStatusID = 1, PriorityID = 4 });      // 6: Yoshi's Woolly World, Bram
        }

        internal static void SeedPlaythroughs(this ModelBuilder builder)
        {
            builder.Entity<Playthrough>().HasData(
                new Playthrough { PlayDataID = 1, OrdinalNumber = 1, PlayStatusID = 1, SideContentCompleted = false, DateStart = DateTime.Today, DateEnd = DateTime.Today, PlaytimeInMinutes = 3000 },
                new Playthrough { PlayDataID = 3, OrdinalNumber = 1, PlayStatusID = 3, SideContentCompleted = false, DateStart = null, DateEnd = null, PlaytimeInMinutes = 30000 },
                new Playthrough { PlayDataID = 4, OrdinalNumber = 1, PlayStatusID = 1, SideContentCompleted = false, DateStart = DateTime.Today, DateEnd = DateTime.Today, PlaytimeInMinutes = 29000 },
                new Playthrough { PlayDataID = 5, OrdinalNumber = 1, PlayStatusID = 2, SideContentCompleted = true, DateStart = DateTime.Today, DateEnd = DateTime.Today, PlaytimeInMinutes = 1000 },
                new Playthrough { PlayDataID = 5, OrdinalNumber = 2, PlayStatusID = 1, SideContentCompleted = false, DateStart = DateTime.Today, DateEnd = DateTime.Today, PlaytimeInMinutes = 500 },
                new Playthrough { PlayDataID = 6, OrdinalNumber = 1, PlayStatusID = 4, SideContentCompleted = false, DateStart = DateTime.Today, DateEnd = DateTime.Today, PlaytimeInMinutes = 10 });
        }
        #endregion

        #region Wishlist
        internal static void SeedWishlistItemTypes(this ModelBuilder builder)
        {
            builder.Entity<WishlistItemType>().HasData(
                new WishlistItemType { ID = 1, Name = "Game", OrdinalNumber = 1 },
                new WishlistItemType { ID = 2, Name = "Manga", OrdinalNumber = 2 },
                new WishlistItemType { ID = 3, Name = "DVD/Bluray", OrdinalNumber = 3 },
                new WishlistItemType { ID = 4, Name = "Book", OrdinalNumber = 4 },
                new WishlistItemType { ID = 5, Name = "Artbook", OrdinalNumber = 5 },
                new WishlistItemType { ID = 6, Name = "CD", OrdinalNumber = 6 }
                );
        }

        internal static void SeedWishlistItems(this ModelBuilder builder)
        {
            builder.Entity<WishlistItem>().HasData(
                new WishlistItem { ID = 1, HoarderID = 1, WishlistItemTypeID = 1, PriorityID = 1, LanguageID = 1, AddDate = DateTime.Today, ReleaseDate = DateTime.Today, 
                    Title = "Persona 6 Royal", StoreURL = "https://www.budgetgaming.nl/", Notes = "Maybe wait for PS7 version?" },
                new WishlistItem { ID = 2, HoarderID = 1, WishlistItemTypeID = 2, PriorityID = 2, LanguageID = 2, AddDate = DateTime.Today, ReleaseDate = DateTime.Today, 
                    Title = "Oresama Teacher", StoreURL = "https://www.amazon.co.jp/", Notes = "Check out other works by this artist, too." },
                new WishlistItem { ID = 3, HoarderID = 1, WishlistItemTypeID = 5, PriorityID = 3, LanguageID = 2, AddDate = DateTime.Today, ReleaseDate = DateTime.Today, 
                    Title = "Monstergirl Factory", StoreURL = "https://www.amazon.co.jp/", Notes = "Hide this from Bram." },
                new WishlistItem { ID = 4, HoarderID = 1, WishlistItemTypeID = 1, PriorityID = 1, LanguageID = 2, AddDate = DateTime.Today, ReleaseDate = DateTime.Today, 
                    Title = "Eiyuu Densetsu: Zero no Kiseki", StoreURL = "https://www.amazon.co.jp/", Notes = "Get Limited Edition!" }
                );
        }
        #endregion

        #region Journal
        internal static void SeedJournalEntries(this ModelBuilder builder)
        {
            builder.Entity<JournalEntry>().HasData(
                new JournalEntry { ID = 1, HoarderID = 1, Title = "Once upon a time", Date = DateTime.Parse("2021-05-14"), Content = "It was turtles all the way down." },
                new JournalEntry { ID = 2, HoarderID = 1, Title = "Mukashi mukashi", Date = DateTime.Parse("2021-05-15"), Content = "Owari." },
                new JournalEntry { ID = 3, HoarderID = 1, Title = "Er was eens", Date = DateTime.Parse("2021-05-16"), Content = "En ze leefden nog lang en gelukkig." },
                new JournalEntry { ID = 4, HoarderID = 1, Title = "Vlieg!", Date = DateTime.Parse("2021-05-17"), Content = "Kan ik niet. Te laat!" },
                new JournalEntry { ID = 5, HoarderID = 2, Title = "Ambiguous frog", Date = DateTime.Parse("2021-05-14"), Content = "Insert cat ipsum here." },
                new JournalEntry { ID = 6, HoarderID = 2, Title = "Frantic apple", Date = DateTime.Parse("2021-05-15"), Content = "Kitty scratches couch bad kitty. Good morning sunshine. Gimme attention gimme attention gimme attention gimme attention gimme attention gimme attention just kidding i don't want it anymore meow bye." },
                new JournalEntry { ID = 7, HoarderID = 2, Title = "Da-da-da-DAAAAAA", Date = DateTime.Parse("2021-05-16"), Content = "Scratch the furniture groom yourself 4 hours - checked, have your beauty sleep 18 hours - checked, be fabulous for the rest of the day - checked, or pet my belly, you know you want to; seize the hand and shred it!" },
                new JournalEntry { ID = 8, HoarderID = 2, Title = "Something interesting", Date = DateTime.Parse("2021-05-17"), Content = "I like frogs and 0 gravity love or humans,humans, humans oh how much they love us felines we are the center of attention they feed, they clean yet if it fits, i sits, so the door is opening!" });
        }

        internal static void SeedTags(this ModelBuilder builder)
        {
            builder.Entity<Tag>().HasData(
                new Tag { ID = 1, Name = "Finished a game" },
                new Tag { ID = 2, Name = "Started a game" },
                new Tag { ID = 3, Name = "Multiplayer chaos" },
                new Tag { ID = 4, Name = "Big haul" },
                new Tag { ID = 5, Name = "Analog day" },
                new Tag { ID = 6, Name = "Sleepy day" },
                new Tag { ID = 7, Name = "Special event" },
                new Tag { ID = 8, Name = "Family/friends" });
        }

        internal static void SeedJournalTags(this ModelBuilder builder)
        {
            builder.Entity<JournalTag>().HasData(
                new JournalTag { JournalEntryID = 1, TagID = 1 },
                new JournalTag { JournalEntryID = 1, TagID = 2 },
                new JournalTag { JournalEntryID = 2, TagID = 5 },
                new JournalTag { JournalEntryID = 5, TagID = 6 },
                new JournalTag { JournalEntryID = 5, TagID = 7 },
                new JournalTag { JournalEntryID = 3, TagID = 3 });
        }

        internal static void SeedJournalGames(this ModelBuilder builder)
        {
            builder.Entity<JournalGame>().HasData(
                new JournalGame { JournalEntryID = 1, GameID = 1 },
                new JournalGame { JournalEntryID = 1, GameID = 2 },
                new JournalGame { JournalEntryID = 1, GameID = 3 },
                new JournalGame { JournalEntryID = 2, GameID = 1 },
                new JournalGame { JournalEntryID = 5, GameID = 1 },
                new JournalGame { JournalEntryID = 5, GameID = 2 },
                new JournalGame { JournalEntryID = 5, GameID = 3 },
                new JournalGame { JournalEntryID = 3, GameID = 1 });
        }
        #endregion
    }
}
