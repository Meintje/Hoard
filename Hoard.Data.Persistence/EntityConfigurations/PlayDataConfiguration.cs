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

            builder.HasIndex(pd => new { pd.GameID, pd.PlayerID }).IsUnique();

            builder.Property(pd => pd.Notes)
                .HasMaxLength(EntityConstants.NotesMaximumLength);
        }
    }
}
