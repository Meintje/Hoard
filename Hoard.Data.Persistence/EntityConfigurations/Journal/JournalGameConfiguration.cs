using Hoard.Core.Entities.Journal.JoinEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hoard.Infrastructure.Persistence.EntityConfigurations.Journal
{
    class JournalGameConfiguration : IEntityTypeConfiguration<JournalGame>
    {
        public void Configure(EntityTypeBuilder<JournalGame> builder)
        {
            builder.ToTable("JournalGames");

            builder.HasKey(jg => new { jg.JournalEntryID, jg.GameID });
        }
    }
}
