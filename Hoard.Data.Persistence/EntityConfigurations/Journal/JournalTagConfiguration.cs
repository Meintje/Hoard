using Hoard.Core.Entities.Journal.JoinEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hoard.Infrastructure.Persistence.EntityConfigurations.Journal
{
    class JournalTagConfiguration : IEntityTypeConfiguration<JournalTag>
    {
        public void Configure(EntityTypeBuilder<JournalTag> builder)
        {
            builder.ToTable("JournalTags");

            builder.HasKey(jt => new { jt.JournalEntryID, jt.TagID });
        }
    }
}
