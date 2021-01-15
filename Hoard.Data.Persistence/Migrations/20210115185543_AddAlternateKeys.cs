using Microsoft.EntityFrameworkCore.Migrations;

namespace Hoard.Data.Persistence.Migrations
{
    public partial class AddAlternateKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PlayData_GameID",
                table: "PlayData");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_PlayStatuses_Name",
                table: "PlayStatuses",
                column: "Name");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_PlayStatuses_OrdinalNumber",
                table: "PlayStatuses",
                column: "OrdinalNumber");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Players_Name",
                table: "Players",
                column: "Name");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_PlayData_GameID_PlayerID",
                table: "PlayData",
                columns: new[] { "GameID", "PlayerID" });

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
                name: "AK_PlayStatuses_OrdinalNumber",
                table: "PlayStatuses");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Players_Name",
                table: "Players");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_PlayData_GameID_PlayerID",
                table: "PlayData");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Games_Title_ReleaseDate",
                table: "Games");

            migrationBuilder.CreateIndex(
                name: "IX_PlayData_GameID",
                table: "PlayData",
                column: "GameID");
        }
    }
}
