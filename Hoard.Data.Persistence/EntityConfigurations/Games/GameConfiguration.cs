using Hoard.Core.Constants;
using Hoard.Core.Entities.Games;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hoard.Infrastructure.Persistence.EntityConfigurations.Games
{
    class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.ToTable("Games");

            builder.HasIndex(g => new { g.Title, g.PlatformID, g.LanguageID, g.MediaTypeID, g.ReleaseDate }).IsUnique();

            builder.Property(g => g.Title)
                .IsRequired()
                .HasMaxLength(EntityConstants.TitleMaximumLength);
            builder.Property(g => g.AlternateTitle)
                .HasMaxLength(EntityConstants.TitleMaximumLength);
            builder.Property(g => g.ReleaseDate)
                .IsRequired()
                .HasColumnType("date");
            builder.Property(g => g.Description)
                .HasMaxLength(EntityConstants.NotesMaximumLength);

            builder.Ignore(g => g.FullGenres);
            builder.Ignore(g => g.FullModes);
            builder.Ignore(g => g.FullSeries);
            builder.Ignore(g => g.FullDevelopers);
            builder.Ignore(g => g.FullPublishers);
        }
    }
}
