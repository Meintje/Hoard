namespace Hoard.Core.Entities.Games.JoinEntities
{
    public class GameGenre
    {
        public int GameID { get; set; }
        public virtual Game Game { get; set; }
        public int GenreID { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
