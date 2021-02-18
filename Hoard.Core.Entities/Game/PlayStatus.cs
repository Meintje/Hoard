using Hoard.Core.Entities.Base;

namespace Hoard.Core.Entities.Game
{
    public class PlayStatus : BaseEntityWithID
    {
        public string Name { get; set; }
        public int OrdinalNumber { get; set; }
    }
}
