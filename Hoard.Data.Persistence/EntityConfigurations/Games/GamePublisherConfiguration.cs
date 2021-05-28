using Hoard.Core.Entities.Games.JoinEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hoard.Infrastructure.Persistence.EntityConfigurations.Games
{
    class GamePublisherConfiguration : IEntityTypeConfiguration<GamePublisher>
    {
        public void Configure(EntityTypeBuilder<GamePublisher> builder)
        {
            builder.ToTable("GamePublishers");

            builder.HasKey(gd => new { gd.GameID, gd.PublisherID });
        }
    }
}
