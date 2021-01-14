using Hoard.Data.Entities.Game;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hoard.Data.Persistence.EntityConfigurations
{
    class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.ToTable("Games");
            builder.HasAlternateKey(g => new { g.Title, g.ReleaseDate }); // TODO: Add Platform once this entity has been added
            builder.Property(g => g.ReleaseDate).HasColumnType("date");
        }
    }
}
