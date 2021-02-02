using Hoard.Data.Entities.Base;
using System;
using System.Collections.Generic;

namespace Hoard.Data.Entities.Game
{
    public class Game : BaseEntityWithID
    {
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }

        public int PlatformID { get; set; }

        public virtual Platform Platform { get; set; }

        public virtual ICollection<GameGenre> Genres { get; set; }
        public virtual ICollection<PlayData> PlayData { get; set; }
    }
}
