using Hoard.Core.Constants;
using Hoard.Core.Entities.Games;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hoard.Infrastructure.Persistence.EntityConfigurations.Games
{
    class SeriesConfiguration : IEntityTypeConfiguration<Series>
    {
        public void Configure(EntityTypeBuilder<Series> builder)
        {
            builder.ToTable("Series");

            builder.HasIndex(p => p.Name).IsUnique();

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(EntityConstants.NameMaximumLength);
        }
    }
}