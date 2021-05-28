using Hoard.Core.Entities.Base;
using System;
using System.Collections.Generic;

namespace Hoard.Core.Entities.Games
{
    public class PlayData : BaseEntityWithID
    {
        public int GameID { get; set; }
        public virtual Game Game { get; set; }

        public int HoarderID { get; set; }
        public virtual Hoarder Hoarder { get; set; }

        public int OwnershipStatusID { get; set; }
        public virtual OwnershipStatus OwnershipStatus { get; set; }

        public int PriorityID { get; set; }
        public virtual Priority Priority { get; set; }

        public bool Dropped { get; set; }
        public bool AchievementsCompleted { get; set; }
        public float? Rating { get; set; }
        public string Notes { get; set; }

        public string Status 
        { 
            get
            {
                string status = "Unknown";

                if (Dropped)
                {
                    status = "Dropped";
                }
                else if (Playthroughs == null || Playthroughs.Count == 0)
                {
                    status = "Unplayed";
                }
                else
                {
                    int lowestStatusNumber = 99;

                    foreach (var playthrough in Playthroughs)
                    {
                        if (playthrough.PlayStatus.OrdinalNumber < lowestStatusNumber)
                        {
                            lowestStatusNumber = playthrough.PlayStatus.OrdinalNumber;
                            status = playthrough.PlayStatus.Name;
                        }
                    }
                }

                if (AchievementsCompleted)
                {
                    status += ", achievements completed";
                }

                return status;
            }
        }

        public TimeSpan TotalPlaytime 
        { 
            get
            {
                int totalPlaytimeInMinutes = 0;

                if (Playthroughs != null && Playthroughs.Count != 0)
                {
                    foreach (var playthrough in Playthroughs)
                    {
                        totalPlaytimeInMinutes += playthrough.PlaytimeInMinutes;
                    }
                }

                return new TimeSpan(0, totalPlaytimeInMinutes, 0);
            }
        }

        public DateTime? FirstPlayed 
        {
            get
            {
                DateTime? firstPlayed = null;

                if (Playthroughs != null && Playthroughs.Count != 0)
                {
                    foreach (var playthrough in Playthroughs)
                    {
                        if (firstPlayed == null)
                        {
                            firstPlayed = playthrough.DateStart;
                        }
                        else if (firstPlayed > playthrough.DateStart)
                        {
                            firstPlayed = playthrough.DateStart;
                        }
                    }
                }

                return firstPlayed;
            }
        }

        public DateTime? LastPlayed 
        { 
            get
            {
                DateTime? lastPlayed = null;

                if (Playthroughs != null && Playthroughs.Count != 0)
                {
                    foreach (var playthrough in Playthroughs)
                    {
                        if (lastPlayed == null)
                        {
                            lastPlayed = playthrough.DateEnd;
                        }
                        else if (lastPlayed < playthrough.DateEnd)
                        {
                            lastPlayed = playthrough.DateEnd;
                        }
                    }
                }

                return lastPlayed;
            }
        }

        public virtual ICollection<Playthrough> Playthroughs { get; set; }
    }
}
