using Hoard.Core.Constants;
using Hoard.Core.Entities.Games;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hoard.Infrastructure.Persistence.EntityConfigurations.Games
{
    class PlatformDeveloperConfiguration : IEntityTypeConfiguration<PlatformDeveloper>
    {
        public void Configure(EntityTypeBuilder<PlatformDeveloper> builder)
        {
            builder.ToTable("PlatformDevelopers");

            builder.HasIndex(p => p.Name).IsUnique();
            builder.HasIndex(p => p.OrdinalNumber).IsUnique();

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(EntityConstants.NameMaximumLength);
        }
    }
}
