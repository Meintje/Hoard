namespace Hoard.Core.Entities.Games.JoinEntities
{
    public class GamePublisher
    {
        public int GameID { get; set; }
        public virtual Game Game { get; set; }
        public int PublisherID { get; set; }
        public virtual Publisher Publisher { get; set; }
    }
}
