using Hoard.Data.Persistence.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoard.Data.Persistence.Entities
{
    public class PlayStatus : BaseEntity
    {
        public string Name { get; set; }
        public int OrdinalNumber { get; set; }
    }
}
