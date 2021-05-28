﻿using Hoard.Core.Entities.Games;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hoard.Core.Interfaces.Games
{
    public interface IPublisherDbService
    {
        public Task<IEnumerable<Publisher>> GetAllAsync();
    }
}
