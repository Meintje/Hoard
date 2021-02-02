using Hoard.Core.Constants;
using Hoard.Data.Entities.Game;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Hoard.Data.Persistence.EntityConfigurations
{
    class GameGenreConfiguration : IEntityTypeConfiguration<GameGenre>
    {
        public void Configure(EntityTypeBuilder<GameGenre> builder)
        {
            builder.ToTable("GameGenres");

            builder.HasKey(gg => new { gg.GameID, gg.GenreID });
        }
    }
}
