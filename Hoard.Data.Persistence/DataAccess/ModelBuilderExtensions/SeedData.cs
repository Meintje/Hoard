using Hoard.Data.Entities.Game;
using Microsoft.EntityFrameworkCore;
using System;

namespace Hoard.Data.Persistence.DataAccess.ModelBuilderExtensions
{
    internal static class SeedData
    {
        internal static void SeedDatabase(this ModelBuilder builder)
        {
            builder.Entity<Game>().HasData(
                new Game { ID = 1, Title = "The Legend of Heroes: Trails in the Sky FC Evolution", ReleaseDate = DateTime.Parse("2015-06-11") },
                new Game { ID = 2, Title = "Monster Hunter World", ReleaseDate = DateTime.Parse("2018-08-09") },
                new Game { ID = 3, Title = "Yoshi's Woolly World", ReleaseDate = DateTime.Parse("2015-06-26") }
                );

            builder.Entity<Player>().HasData(
                new Player { ID = 1, Name = "Meintje" },
                new Player { ID = 2, Name = "Bram" }
                );

            builder.Entity<PlayStatus>().HasData(
                new PlayStatus { ID = 1, Name = "Playing", OrdinalNumber = 1 },
                new PlayStatus { ID = 2, Name = "Finished", OrdinalNumber = 2 },
                new PlayStatus { ID = 3, Name = "Hiatus", OrdinalNumber = 3 },
                new PlayStatus { ID = 4, Name = "Dropped", OrdinalNumber = 4 }
                );
            
            builder.Entity<PlayData>().HasData(
                new PlayData { ID = 1, GameID = 1, PlayerID = 1, Dropped = false, CurrentlyPlaying = true },    // 1: Trails in the Sky, Meintje, not dropped, currently playing
                new PlayData { ID = 2, GameID = 1, PlayerID = 2, Dropped = true, CurrentlyPlaying = false },    // 2: Trails in the Sky, Bram, dropped, not currently playing
                new PlayData { ID = 3, GameID = 2, PlayerID = 1, Dropped = false, CurrentlyPlaying = false },   // 3: Monster Hunter World, Meintje, not dropped, not currently playing
                new PlayData { ID = 4, GameID = 2, PlayerID = 2, Dropped = false, CurrentlyPlaying = true },    // 4: Monster Hunter World, Bram, not dropped, currently playing
                new PlayData { ID = 5, GameID = 3, PlayerID = 1, Dropped = false, CurrentlyPlaying = true },    // 5: Yoshi's Woolly World, Meintje, not dropped, currently playing
                new PlayData { ID = 6, GameID = 3, PlayerID = 2, Dropped = true, CurrentlyPlaying = false }     // 6: Yoshi's Woolly World, Bram, dropped, not currently playing
                );

            builder.Entity<Playthrough>().HasData(
                new Playthrough { PlayDataID = 1, OrdinalNumber = 1, PlayStatusID = 1, SideContentCompleted = false, DateStart = DateTime.Today, DateEnd = DateTime.Today, PlaytimeMinutes = 3000 },
                new Playthrough { PlayDataID = 3, OrdinalNumber = 1, PlayStatusID = 3, SideContentCompleted = false, DateStart = null, DateEnd = null, PlaytimeMinutes = 30000 },
                new Playthrough { PlayDataID = 4, OrdinalNumber = 1, PlayStatusID = 1, SideContentCompleted = false, DateStart = DateTime.Today, DateEnd = DateTime.Today, PlaytimeMinutes = 29000 },
                new Playthrough { PlayDataID = 5, OrdinalNumber = 1, PlayStatusID = 2, SideContentCompleted = true, DateStart = DateTime.Today, DateEnd = DateTime.Today, PlaytimeMinutes = 1000 },
                new Playthrough { PlayDataID = 5, OrdinalNumber = 2, PlayStatusID = 1, SideContentCompleted = false, DateStart = DateTime.Today, DateEnd = DateTime.Today, PlaytimeMinutes = 500 },
                new Playthrough { PlayDataID = 6, OrdinalNumber = 1, PlayStatusID = 4, SideContentCompleted = false, DateStart = DateTime.Today, DateEnd = DateTime.Today, PlaytimeMinutes = 10 }
                );
        }
    }
}
