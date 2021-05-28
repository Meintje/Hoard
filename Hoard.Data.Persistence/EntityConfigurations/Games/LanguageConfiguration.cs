using Hoard.Core.Constants;
using Hoard.Core.Entities.Games;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hoard.Infrastructure.Persistence.EntityConfigurations.Games
{
    class LanguageConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.ToTable("Languages");

            builder.HasIndex(p => p.Name).IsUnique();
            builder.HasIndex(p => p.ShortName).IsUnique();

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(EntityConstants.NameMaximumLength);
            builder.Property(p => p.ShortName)
                .IsRequired()
                .HasMaxLength(EntityConstants.NameMaximumLength);
        }
    }
}