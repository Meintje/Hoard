using Hoard.Core.Constants;
using Hoard.Core.Entities.Game;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hoard.Data.Persistence.EntityConfigurations
{
    class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("Genres");

            builder.HasIndex(g => g.Name).IsUnique();

            builder.Property(g => g.Name)
                .HasMaxLength(EntityConstants.NameMaximumLength);
        }
    }
}
