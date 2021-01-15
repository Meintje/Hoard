using Hoard.Core.Constants;
using Hoard.Data.Entities.Game;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hoard.Data.Persistence.EntityConfigurations
{
    class PlayDataConfiguration : IEntityTypeConfiguration<PlayData>
    {
        public void Configure(EntityTypeBuilder<PlayData> builder)
        {
            builder.ToTable("PlayData");

            builder.HasAlternateKey(pd => new { pd.GameID, pd.PlayerID });

            builder.Property(pd => pd.PlayNotes)
                .HasMaxLength(EntityConstants.NotesMaximumLength);
            builder.Property(pd => pd.GameNotes)
                .HasMaxLength(EntityConstants.NotesMaximumLength);
        }
    }
}
