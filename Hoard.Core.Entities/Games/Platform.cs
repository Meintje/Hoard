using Hoard.Core.Entities.Base;
using System.Collections.Generic;

namespace Hoard.Core.Entities.Games
{
    public class Platform : BaseEntityWithID
    {
        public string Name { get; set; }
        public string ShortName { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}
