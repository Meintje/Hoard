using Hoard.Data.Entities.Game;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoard.Data.Persistence.DataAccess.ModelBuilderExtensions
{
    internal static class SeedData
    {
        internal static void SeedDatabase(this ModelBuilder builder)
        {
            builder.Entity<Game>().HasData(
                new Game { ID = 1, Title = "The Legend of Heroes: Trails in the Sky FC Evolution", ReleaseDate = DateTime.Parse("2015-06-11") },
                new Game { ID = 2, Title = "Monster Hunter World", ReleaseDate = DateTime.Parse("2018-08-09") },
                new Game { ID = 3, Title = "Yoshi's Woolly World", ReleaseDate = DateTime.Parse("2015-06-26") });

            builder.Entity<Player>().HasData(
                new Player { ID = 1, Name = "Meintje" },
                new Player { ID = 2, Name = "Bram" });

            builder.Entity<PlayStatus>().HasData(
                new PlayStatus { ID = 1, Name = "Not started", OrdinalNumber = 1 },
                new PlayStatus { ID = 2, Name = "Playing", OrdinalNumber = 2 },
                new PlayStatus { ID = 3, Name = "Finished", OrdinalNumber = 3 });

            builder.Entity<PlayData>().HasData(
                new PlayData { GameID = 1, PlayerID = 1, PlayStatusID = 2 },
                new PlayData { GameID = 1, PlayerID = 2, PlayStatusID = 1 },
                new PlayData { GameID = 2, PlayerID = 1, PlayStatusID = 2 },
                new PlayData { GameID = 2, PlayerID = 2, PlayStatusID = 2 },
                new PlayData { GameID = 3, PlayerID = 1, PlayStatusID = 3 },
                new PlayData { GameID = 3, PlayerID = 2, PlayStatusID = 3 }
                );
        }
    }
}
