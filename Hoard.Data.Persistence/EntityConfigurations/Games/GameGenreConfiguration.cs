using Hoard.Core.Entities.Games.JoinEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Hoard.Infrastructure.Persistence.EntityConfigurations.Games
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
