using Hoard.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoard.Data.Entities.Game
{
    public class Player : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<PlayData> GameProgress { get; set; }
    }
}
