using Hoard.Core.Entities.Base;

namespace Hoard.Core.Entities.Games
{
    public class Priority : BaseEntityWithID
    {
        public int OrdinalNumber { get; set; }
        public string Name { get; set; }
    }
}
