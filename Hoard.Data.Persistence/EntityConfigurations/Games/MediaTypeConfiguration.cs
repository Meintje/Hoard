using Hoard.Core.Constants;
using Hoard.Core.Entities.Games;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hoard.Infrastructure.Persistence.EntityConfigurations.Games
{
    class MediaTypeConfiguration : IEntityTypeConfiguration<MediaType>
    {
        public void Configure(EntityTypeBuilder<MediaType> builder)
        {
            builder.ToTable("MediaTypes");

            builder.HasIndex(p => p.Name).IsUnique();

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(EntityConstants.NameMaximumLength);
        }
    }
}
