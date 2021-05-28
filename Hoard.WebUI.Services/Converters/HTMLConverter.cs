using Hoard.Core.Interfaces.Games;
using System.Text;
using System.Threading.Tasks;

namespace Hoard.WebUI.Services.Converters
{
    public class HTMLConverter : IConverter
    {
        private readonly IGameDbService gameDbService;

        public HTMLConverter(IGameDbService gameDbService)
        {
            this.gameDbService = gameDbService;
        }

        public async Task<string> ConvertGameData()
        {
            var games = await gameDbService.GetAllAsync();

            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("<!DOCTYPE html>");
            stringBuilder.AppendLine("<head>");
            stringBuilder.AppendLine("<meta charset=\"UTF-8\"/>");
            stringBuilder.AppendLine("</head>");
            stringBuilder.AppendLine("<html xmlns:v=\"urn:schemas-microsoft-com:vml\" xmlns:o=\"urn:schemas-microsoft-com:office:office\" xmlns:x=\"urn:schemas-microsoft-com:office:excel\" xmlns=\"http://www.w3.org/TR/REC-html40\">");
            stringBuilder.AppendLine("    <style>");
            stringBuilder.AppendLine("        <!--");
            stringBuilder.AppendLine("        br {mso-data-placement:same-cell;}");
            stringBuilder.AppendLine("        -->");
            stringBuilder.AppendLine("    </style>");
            stringBuilder.AppendLine("    <body>");
            stringBuilder.AppendLine("        <table>");

            stringBuilder.AppendLine("           <tr>");
            stringBuilder.AppendLine($"               <th>Platform</th>");
            stringBuilder.AppendLine($"               <th>Title</th>");
            stringBuilder.AppendLine($"               <th>Release date</th>");
            stringBuilder.AppendLine($"               <th>Genre(s)</th>");
            stringBuilder.AppendLine($"               <th>Description</th>");
            stringBuilder.AppendLine("           </tr>");

            foreach (var game in games)
            {
                stringBuilder.AppendLine("           <tr>");
                stringBuilder.AppendLine($"               <td>{game.Platform.Name}</td>");
                stringBuilder.AppendLine($"               <td>{game.Title}</td>");
                stringBuilder.AppendLine($"               <td>{game.ReleaseDate:dd/MM/yyyy}</td>");
                stringBuilder.AppendLine($"               <td>{game.FullGenres}</td>");
                stringBuilder.AppendLine($"               <td>{game.Description?.Replace("\n", "<br/>")}</td>");
                stringBuilder.AppendLine("           </tr>\n");
            }

            stringBuilder.AppendLine("        </table>");
            stringBuilder.AppendLine("    </body>");
            stringBuilder.AppendLine("</html>");

            var html = stringBuilder.ToString();

            return html;
        }
    }
}
