using Hoard.Core.Constants;
using Hoard.Core.Entities.Games;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hoard.Infrastructure.Persistence.EntityConfigurations.Games
{
    class DeveloperConfiguration : IEntityTypeConfiguration<Developer>
    {
        public void Configure(EntityTypeBuilder<Developer> builder)
        {
            builder.ToTable("Developers");

            builder.HasIndex(p => p.Name).IsUnique();

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(EntityConstants.NameMaximumLength);
        }
    }
}
