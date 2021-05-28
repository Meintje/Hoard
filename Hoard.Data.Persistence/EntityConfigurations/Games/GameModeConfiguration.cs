using Hoard.Core.Entities.Games.JoinEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hoard.Infrastructure.Persistence.EntityConfigurations.Games
{
    class GameModeConfiguration : IEntityTypeConfiguration<GameMode>
    {
        public void Configure(EntityTypeBuilder<GameMode> builder)
        {
            builder.ToTable("GameModes");

            builder.HasKey(gd => new { gd.GameID, gd.ModeID });
        }
    }
}