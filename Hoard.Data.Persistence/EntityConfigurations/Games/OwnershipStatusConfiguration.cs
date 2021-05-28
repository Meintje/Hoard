using Hoard.Core.Constants;
using Hoard.Core.Entities.Games;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hoard.Infrastructure.Persistence.EntityConfigurations.Games
{
    class OwnershipStatusConfiguration : IEntityTypeConfiguration<OwnershipStatus>
    {
        public void Configure(EntityTypeBuilder<OwnershipStatus> builder)
        {
            builder.ToTable("OwnershipStatuses");

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
