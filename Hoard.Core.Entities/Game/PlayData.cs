using Hoard.Core.Entities.Base;
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

        public virtual ICollection<Playthrough> Playthroughs { get; set; }
    }
}
