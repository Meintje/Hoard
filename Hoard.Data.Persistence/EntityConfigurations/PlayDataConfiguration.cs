using Hoard.Data.Entities.Game;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hoard.Data.Persistence.EntityConfigurations
{
    class PlayDataConfiguration : IEntityTypeConfiguration<PlayData>
    {
        public void Configure(EntityTypeBuilder<PlayData> builder)
        {
            builder.HasAlternateKey(pd => new { pd.GameID, pd.PlayerID });
        }
    }
}
