using Hoard.Core.Entities.Games;

namespace Hoard.Core.Entities.Journal.JoinEntities
{
    public class JournalGame
    {
        public int JournalEntryID { get; set; }
        public virtual JournalEntry JournalEntry { get; set; }

        public int GameID { get; set; }
        public virtual Game Game { get; set; }
    }
}
