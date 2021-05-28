using System;

namespace Hoard.Core.Entities.Games
{
    public class Playthrough
    {
        public int PlayDataID { get; set; }
        public int OrdinalNumber { get; set; }

        public int PlayStatusID { get; set; }
        public virtual PlayStatus PlayStatus { get; set; }

        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public int PlaytimeInMinutes { get; set; }
        public bool SideContentCompleted { get; set; }
        public string Notes { get; set; }

        public string Status
        {
            get
            {
                string status = PlayStatus.Name;

                if (SideContentCompleted)
                {
                    status += ", side content completed";
                }
                
                return status;
            }
        }

        public virtual PlayData PlayData { get; set; }
    }
}
