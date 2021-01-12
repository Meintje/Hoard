using Hoard.Data.Entities.Base;
using System.Collections.Generic;

namespace Hoard.Data.Entities.Game
{
    public class PlayData : BaseEntityWithID
    {
        public int GameID { get; set; }
        public virtual Game Game { get; set; }

        public int PlayerID { get; set; }
        public virtual Player Player { get; set; }

        public bool Dropped { get; set; }
        public bool CurrentlyPlaying { get; set; }

        public string PlayNotes { get; set; }
        public string GameNotes { get; set; }

        public ICollection<Playthrough> Playthroughs { get; set; }
    }
}
