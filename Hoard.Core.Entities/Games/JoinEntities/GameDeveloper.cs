namespace Hoard.Core.Entities.Games.JoinEntities
{
    public class GameDeveloper
    {
        public int GameID { get; set; }
        public virtual Game Game { get; set; }
        public int DeveloperID { get; set; }
        public virtual Developer Developer { get; set; }
    }
}
