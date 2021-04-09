using Hoard.Core.Entities.Base;
using System;
using System.Collections.Generic;

namespace Hoard.Core.Entities.Game
{
    public class PlayData : BaseEntityWithID
    {
        public int GameID { get; set; }
        public virtual Game Game { get; set; }

        public int PlayerID { get; set; }
        public virtual Player Player { get; set; }

        public bool Dropped { get; set; }

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
                    int currentStatusNumber = 99;

                    foreach (var playthrough in Playthroughs)
                    {
                        if (playthrough.PlayStatus.OrdinalNumber < currentStatusNumber)
                        {
                            currentStatusNumber = playthrough.PlayStatus.OrdinalNumber;
                            status = playthrough.PlayStatus.Name;
                        }
                    }
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
                        totalPlaytimeInMinutes += playthrough.PlaytimeMinutes;
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
