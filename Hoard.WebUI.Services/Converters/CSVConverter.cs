using Hoard.Core.Interfaces.Games;
using System.Text;
using System.Threading.Tasks;

namespace Hoard.WebUI.Services.Converters
{
    public class CSVConverter : IConverter
    {
        private readonly IGameDbService gameDbService;

        public CSVConverter(IGameDbService gameDbService)
        {
            this.gameDbService = gameDbService;
        }

        public async Task<string> ConvertGameData()
        {
            var games = await gameDbService.GetAllAsync();

            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("Platform;;Title;;ReleaseDate;;Genres;;Description");

            foreach (var game in games)
            {
                stringBuilder.AppendLine($"{game.Platform.Name};;{game.Title};;{game.ReleaseDate:dd/MM/yyyy};;{game.FullGenres};;{game.Description?.Replace("\r\n\n", "[nn]").Replace("\r\n", "[n]")}");
            }

            var csv = stringBuilder.ToString();

            return csv;
        }
    }
}
