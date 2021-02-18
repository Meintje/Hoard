using Hoard.Core.Entities.Base;
using System;
using System.Collections.Generic;

namespace Hoard.Core.Entities.Game
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
