using Hoard.Data.Entities.Base;

namespace Hoard.Data.Entities.Game
{
    public class PlayStatus : BaseEntityWithID
    {
        public string Name { get; set; }
        public int OrdinalNumber { get; set; }
    }
}
