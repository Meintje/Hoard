namespace Hoard.Core.Entities.Game
{
    public class GameGenre
    {
        public int GameID { get; set; }
        public Game Game { get; set; }
        public int GenreID { get; set; }
        public Genre Genre { get; set; }
    }
}
