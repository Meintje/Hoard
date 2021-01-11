using Hoard.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoard.Data.Entities.Game
{
    public class Game : BaseEntity
    {
        public string Title { get; set; }

        public virtual ICollection<PlayData> PlayData { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}
