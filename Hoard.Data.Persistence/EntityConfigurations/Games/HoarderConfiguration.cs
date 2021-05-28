using Hoard.Core.Constants;
using Hoard.Core.Entities.Games;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hoard.Infrastructure.Persistence.EntityConfigurations.Games
{
    class HoarderConfiguration : IEntityTypeConfiguration<Hoarder>
    {
        public void Configure(EntityTypeBuilder<Hoarder> builder)
        {
            builder.ToTable("Hoarders");

            builder.HasIndex(p => p.Name).IsUnique();

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(EntityConstants.NameMaximumLength);
        }
    }
}
