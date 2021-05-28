using Hoard.Core.Constants;
using Hoard.Core.Entities.Wishlist;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hoard.Infrastructure.Persistence.EntityConfigurations.Wishlist
{
    class WishlistItemTypeConfiguration : IEntityTypeConfiguration<WishlistItemType>
    {
        public void Configure(EntityTypeBuilder<WishlistItemType> builder)
        {
            builder.ToTable("WishlistItemTypes");

            builder.HasIndex(wt => wt.Name).IsUnique();
            builder.HasIndex(wt => wt.OrdinalNumber).IsUnique();

            builder.Property(wt => wt.Name)
                .IsRequired()
                .HasMaxLength(EntityConstants.NameMaximumLength);
            builder.Property(wt => wt.OrdinalNumber)
                .IsRequired();
        }
    }
}
