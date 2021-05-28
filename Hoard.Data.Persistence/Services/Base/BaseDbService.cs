using Hoard.Infrastructure.Persistence.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoard.Infrastructure.Persistence.Services.Base
{
    public abstract class BaseDbService
    {
        protected readonly HoardDbContext context;

        public BaseDbService(HoardDbContext context)
        {
            this.context = context;
        }

        protected void UpdateManyToManyRelation<T>(IEnumerable<T> oldItems, IEnumerable<T> newItems) where T : class
        {
            context.RemoveRange(oldItems);
            context.AddRange(newItems);
        }
    }
}
