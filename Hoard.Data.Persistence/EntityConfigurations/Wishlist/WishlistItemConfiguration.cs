using Hoard.Core.Constants;
using Hoard.Core.Entities.Wishlist;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoard.Infrastructure.Persistence.EntityConfigurations.Wishlist
{
    class WishlistItemConfiguration : IEntityTypeConfiguration<WishlistItem>
    {
        public void Configure(EntityTypeBuilder<WishlistItem> builder)
        {
            builder.ToTable("WishlistItems");

            builder.HasIndex(wi => new { wi.Title, wi.HoarderID, wi.WishlistItemTypeID }).IsUnique();

            builder.Property(wi => wi.Title)
                .IsRequired()
                .HasMaxLength(EntityConstants.TitleMaximumLength);
            builder.Property(wi => wi.AddDate)
                .IsRequired()
                .HasColumnType("date");
            builder.Property(wi => wi.ReleaseDate)
                .HasColumnType("date");
            builder.Property(wi => wi.StoreURL)
                .HasMaxLength(EntityConstants.NotesMaximumLength);
            builder.Property(wi => wi.Notes)
                .HasMaxLength(EntityConstants.NotesMaximumLength);
        }
    }
}
