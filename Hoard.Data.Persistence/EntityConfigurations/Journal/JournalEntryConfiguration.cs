using Hoard.Core.Constants;
using Hoard.Core.Entities.Journal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hoard.Infrastructure.Persistence.EntityConfigurations.Journal
{
    class JournalEntryConfiguration : IEntityTypeConfiguration<JournalEntry>
    {
        public void Configure(EntityTypeBuilder<JournalEntry> builder)
        {
            builder.ToTable("JournalEntries");

            builder.HasIndex(j => new { j.HoarderID, j.Date }).IsUnique();

            builder.Property(j => j.Title)
                .IsRequired()
                .HasMaxLength(EntityConstants.TitleMaximumLength);
            builder.Property(j => j.Date)
                .IsRequired()
                .HasColumnType("date");
            builder.Property(j => j.Content)
                .IsRequired()
                .HasMaxLength(EntityConstants.JournalMaximumLength);

            builder.Ignore(j => j.FullGames);
            builder.Ignore(j => j.FullTags);
        }
    }
}
