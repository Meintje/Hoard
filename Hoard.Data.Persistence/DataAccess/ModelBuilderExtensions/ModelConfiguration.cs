using Hoard.Data.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoard.Data.Persistence.DataAccess.ModelBuilderExtensions
{
    internal static class ModelConfiguration
    {
        internal static void ConfigureEntities(this ModelBuilder builder)
        {
            #region Table names
            builder.Entity<Game>().ToTable("Games");
            builder.Entity<Player>().ToTable("Players");
            builder.Entity<PlayStatus>().ToTable("PlayStatuses");
            #endregion

            builder.Entity<PlayerProgress>()
                .HasKey(pp => new { pp.GameID, pp.PlayerID });

            builder.Entity<Game>()
                .HasAlternateKey(g => new { g.Title, g.ReleaseDate });
            builder.Entity<Game>()
                .Property(g => g.ReleaseDate)
                .HasColumnType("date");

            builder.Entity<PlayStatus>()
                .HasAlternateKey(ps => ps.Name);
            builder.Entity<PlayStatus>()
                .HasAlternateKey(ps => ps.OrdinalNumber);
        }
    }
}
