namespace Hoard.Core.Entities.Games.JoinEntities
{
    public class GameMode
    {
        public int GameID { get; set; }
        public virtual Game Game { get; set; }
        public int ModeID { get; set; }
        public virtual Mode Mode { get; set; }
    }
}
