using Hoard.Core.Entities.Base;
using System.Collections.Generic;

namespace Hoard.Core.Entities.Games
{
    public class Hoarder : BaseEntityWithID
    {
        public string Name { get; set; }

        public virtual ICollection<PlayData> GameProgress { get; set; }
    }
}
