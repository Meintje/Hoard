using Hoard.Data.Entities.Game;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hoard.Data.Persistence.EntityConfigurations
{
    class PlaythroughConfiguration : IEntityTypeConfiguration<Playthrough>
    {
        public void Configure(EntityTypeBuilder<Playthrough> builder)
        {
            builder.HasKey(pt => new { pt.PlayDataID, pt.OrdinalNumber });
            builder.Property(g => g.DateStart).HasColumnType("date");
            builder.Property(g => g.DateEnd).HasColumnType("date");
        }
    }
}
