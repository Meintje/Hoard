﻿using Hoard.Core.Entities.Games;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hoard.Core.Interfaces.Games
{
    public interface IPriorityDbService
    {
        public Task<IEnumerable<Priority>> GetAllAsync();
    }
}
