using Hoard.Core.Constants;
using Hoard.Data.Entities.Game;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hoard.Data.Persistence.EntityConfigurations
{
    class PlayStatusConfiguration : IEntityTypeConfiguration<PlayStatus>
    {
        public void Configure(EntityTypeBuilder<PlayStatus> builder)
        {
            builder.ToTable("PlayStatuses");

            builder.HasIndex(ps => ps.Name).IsUnique();
            builder.HasIndex(ps => ps.OrdinalNumber).IsUnique();

            builder.Property(ps => ps.Name)
                .IsRequired()
                .HasMaxLength(EntityConstants.NameMaximumLength);
            builder.Property(ps => ps.OrdinalNumber)
                .IsRequired();
        }
    }
}
