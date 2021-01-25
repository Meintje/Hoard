using Hoard.Core.Constants;
using Hoard.Data.Entities.Game;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hoard.Data.Persistence.EntityConfigurations
{
    class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.ToTable("Games");

            builder.HasAlternateKey(g => new { g.Title, g.ReleaseDate, g.PlatformID });

            builder.Property(g => g.Title)
                .IsRequired()
                .HasMaxLength(EntityConstants.TitleMaximumLength);
            builder.Property(g => g.ReleaseDate)
                .IsRequired()
                .HasColumnType("date");
            builder.Property(g => g.Description)
                .HasMaxLength(EntityConstants.NotesMaximumLength);
        }
    }
}
