using System;

namespace Hoard.Core.Entities.Game
{
    public class Playthrough
    {
        public int PlayDataID { get; set; }
        public int OrdinalNumber { get; set; }

        public int PlayStatusID { get; set; }

        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public int PlaytimeMinutes { get; set; }
        public bool SideContentCompleted { get; set; }
        public string Notes { get; set; }

        public virtual PlayStatus PlayStatus { get; set; }
        public virtual PlayData PlayData { get; set; }
    }
}
