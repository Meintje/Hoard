using Hoard.Core.Constants;
using Hoard.Data.Entities.Game;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hoard.Data.Persistence.EntityConfigurations
{
    class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.ToTable("Players");

            builder.HasAlternateKey(p => p.Name);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(EntityConstants.NameMaximumLength);
        }
    }
}
