using Hoard.Core.Entities.Base;

namespace Hoard.Core.Entities.Games
{
    public class PlayStatus : BaseEntityWithID
    {
        public string Name { get; set; }
        public int OrdinalNumber { get; set; }
    }
}
