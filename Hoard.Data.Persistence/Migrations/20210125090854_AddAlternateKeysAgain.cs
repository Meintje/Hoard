using Microsoft.EntityFrameworkCore.Migrations;

namespace Hoard.Data.Persistence.Migrations
{
    public partial class AddAlternateKeysAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_PlayStatuses_Name",
                table: "PlayStatuses",
                column: "Name");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Players_Name",
                table: "Players",
                column: "Name");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Games_Title_ReleaseDate",
                table: "Games",
                columns: new[] { "Title", "ReleaseDate" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_PlayStatuses_Name",
                table: "PlayStatuses");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Players_Name",
                table: "Players");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Games_Title_ReleaseDate",
                table: "Games");
        }
    }
}
