using Hoard.Data.Entities.Base;
using System.Collections.Generic;

namespace Hoard.Data.Entities.Game
{
    public class Player : BaseEntityWithID
    {
        public string Name { get; set; }

        public virtual ICollection<PlayData> GameProgress { get; set; }
    }
}
