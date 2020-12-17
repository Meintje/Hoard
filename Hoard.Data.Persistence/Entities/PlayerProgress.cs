﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoard.Data.Persistence.Entities
{
    public class PlayerProgress
    {
        public int GameID { get; set; }
        public int PlayerID { get; set; }

        public virtual Game Game { get; set; }
        public virtual Player Player { get; set; }

        public int PlayStatusID { get; set; }
        public virtual PlayStatus PlayStatus { get; set; }
    }
}
