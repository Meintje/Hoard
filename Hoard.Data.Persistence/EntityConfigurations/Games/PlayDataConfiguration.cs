using Hoard.Core.Constants;
using Hoard.Core.Entities.Games;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hoard.Infrastructure.Persistence.EntityConfigurations.Games
{
    class PlayDataConfiguration : IEntityTypeConfiguration<PlayData>
    {
        public void Configure(EntityTypeBuilder<PlayData> builder)
        {
            builder.ToTable("PlayData");

            builder.HasIndex(pd => new { pd.GameID, pd.HoarderID }).IsUnique();

            builder.Property(pd => pd.Notes)
                .HasMaxLength(EntityConstants.NotesMaximumLength);

            builder.Ignore(pd => pd.Status);
        }
    }
}
