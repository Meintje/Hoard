namespace Hoard.Core.Entities.Journal.JoinEntities
{
    public class JournalTag
    {
        public int JournalEntryID { get; set; }
        public virtual JournalEntry JournalEntry { get; set; }

        public int TagID { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
