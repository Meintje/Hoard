using Hoard.Core.Entities.Base;
using System.Collections.Generic;

namespace Hoard.Core.Entities.Games
{
    public class Platform : BaseEntityWithID
    {
        public string Name { get; set; }
        public string ShortName { get; set; }

        public int PlatformDeveloperID { get; set; }
        public PlatformDeveloper Developer { get; set; }

        public int PlatformTypeID { get; set; }
        public PlatformType Type { get; set; }

        public int OrdinalNumber { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}
