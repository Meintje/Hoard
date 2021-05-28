using Hoard.Core.Entities.Games;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hoard.Infrastructure.Persistence.EntityConfigurations.Games
{
    class PlaythroughConfiguration : IEntityTypeConfiguration<Playthrough>
    {
        public void Configure(EntityTypeBuilder<Playthrough> builder)
        {
            builder.ToTable("Playthroughs");

            builder.HasKey(pt => new { pt.PlayDataID, pt.OrdinalNumber });

            builder.Property(g => g.DateStart)
                .HasColumnType("date");
            builder.Property(g => g.DateEnd)
                .HasColumnType("date");
        }
    }
}
