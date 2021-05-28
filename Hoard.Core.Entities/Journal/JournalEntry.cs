using Hoard.Core.Entities.Base;
using Hoard.Core.Entities.Games;
using Hoard.Core.Entities.Journal.JoinEntities;
using System;
using System.Collections.Generic;

namespace Hoard.Core.Entities.Journal
{
    public class JournalEntry : BaseEntityWithID
    {
        public int HoarderID { get; set; }
        public virtual Hoarder Hoarder { get; set; }

        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }

        public string FullGames
        {
            get
            {
                string fullGames = "";

                if (Games != null && Games.Count > 0)
                {
                    foreach (var g in Games)
                    {
                        fullGames += $"{g.Game.Title}, ";
                    }
                    fullGames = fullGames.Substring(0, fullGames.Length - 2);
                }

                return fullGames;
            }
        }

        public string FullTags
        {
            get
            {
                string fullTags = "";

                if (Tags != null && Tags.Count > 0)
                {
                    foreach (var t in Tags)
                    {
                        fullTags += $"{t.Tag.Name}, ";
                    }
                    fullTags = fullTags.Substring(0, fullTags.Length - 2);
                }

                return fullTags;
            }
        }

        public virtual ICollection<JournalTag> Tags { get; set; }
        public virtual ICollection<JournalGame> Games { get; set; }
    }
}
