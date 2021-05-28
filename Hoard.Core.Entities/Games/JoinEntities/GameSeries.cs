namespace Hoard.Core.Entities.Games.JoinEntities
{
    public class GameSeries
    {
        public int GameID { get; set; }
        public virtual Game Game { get; set; }
        public int SeriesID { get; set; }
        public virtual Series Series { get; set; }
    }
}
