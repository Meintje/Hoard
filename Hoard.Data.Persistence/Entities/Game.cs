using Hoard.Data.Persistence.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoard.Data.Persistence.Entities
{
    public class Game : BaseEntity
    {
        public string Title { get; set; }

        public virtual ICollection<PlayerProgress> PlayerProgress { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}
