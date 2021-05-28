using Hoard.Core.Entities.Games.JoinEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hoard.Infrastructure.Persistence.EntityConfigurations.Games
{
    class GameDeveloperConfiguration : IEntityTypeConfiguration<GameDeveloper>
    {
        public void Configure(EntityTypeBuilder<GameDeveloper> builder)
        {
            builder.ToTable("GameDevelopers");

            builder.HasKey(gd => new { gd.GameID, gd.DeveloperID });
        }
    }
}
