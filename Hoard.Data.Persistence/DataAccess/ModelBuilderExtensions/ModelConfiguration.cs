using Hoard.Data.Entities.Game;
using Microsoft.EntityFrameworkCore;

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

            #region PlayData
            builder.Entity<PlayData>()
                .HasAlternateKey(pd => new { pd.GameID, pd.PlayerID });
            #endregion


            #region Game
            builder.Entity<Game>()
                .HasAlternateKey(g => new { g.Title, g.ReleaseDate });
            builder.Entity<Game>()
                .Property(g => g.ReleaseDate)
                .HasColumnType("date");
            #endregion

            #region PlayStatus
            builder.Entity<PlayStatus>()
                .HasAlternateKey(ps => ps.Name);
            builder.Entity<PlayStatus>()
                .HasAlternateKey(ps => ps.OrdinalNumber);
            #endregion

            #region Playthrough
            builder.Entity<Playthrough>()
                .HasKey(pt => new { pt.PlayDataID, pt.OrdinalNumber });
            builder.Entity<Playthrough>()
                .Property(g => g.DateStart)
                .HasColumnType("date");
            builder.Entity<Playthrough>()
                .Property(g => g.DateEnd)
                .HasColumnType("date");
            #endregion
        }
    }
}
