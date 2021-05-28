using Hoard.Core.Entities.Games.JoinEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hoard.Infrastructure.Persistence.EntityConfigurations.Games
{
    class GameSeriesConfiguration : IEntityTypeConfiguration<GameSeries>
    {
        public void Configure(EntityTypeBuilder<GameSeries> builder)
        {
            builder.ToTable("GameSeries");

            builder.HasKey(gd => new { gd.GameID, gd.SeriesID });
        }
    }
}
