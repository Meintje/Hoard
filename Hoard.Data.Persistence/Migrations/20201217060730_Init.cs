using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hoard.Data.Persistence.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.ID);
                    table.UniqueConstraint("AK_Games_Title_ReleaseDate", x => new { x.Title, x.ReleaseDate });
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PlayStatuses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrdinalNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayStatuses", x => x.ID);
                    table.UniqueConstraint("AK_PlayStatuses_Name", x => x.Name);
                    table.UniqueConstraint("AK_PlayStatuses_OrdinalNumber", x => x.OrdinalNumber);
                });

            migrationBuilder.CreateTable(
                name: "PlayerProgress",
                columns: table => new
                {
                    GameID = table.Column<int>(type: "int", nullable: false),
                    PlayerID = table.Column<int>(type: "int", nullable: false),
                    PlayStatusID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerProgress", x => new { x.GameID, x.PlayerID });
                    table.ForeignKey(
                        name: "FK_PlayerProgress_Games_GameID",
                        column: x => x.GameID,
                        principalTable: "Games",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerProgress_Players_PlayerID",
                        column: x => x.PlayerID,
                        principalTable: "Players",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerProgress_PlayStatuses_PlayStatusID",
                        column: x => x.PlayStatusID,
                        principalTable: "PlayStatuses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "ID", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2015, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Legend of Heroes: Trails in the Sky FC Evolution" },
                    { 2, new DateTime(2018, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Monster Hunter World" },
                    { 3, new DateTime(2015, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yoshi's Woolly World" }
                });

            migrationBuilder.InsertData(
                table: "PlayStatuses",
                columns: new[] { "ID", "Name", "OrdinalNumber" },
                values: new object[,]
                {
                    { 1, "Not started", 1 },
                    { 2, "Playing", 2 },
                    { 3, "Finished", 3 }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Meintje" },
                    { 2, "Bram" }
                });

            migrationBuilder.InsertData(
                table: "PlayerProgress",
                columns: new[] { "GameID", "PlayerID", "PlayStatusID" },
                values: new object[,]
                {
                    { 1, 1, 2 },
                    { 2, 1, 2 },
                    { 3, 1, 3 },
                    { 1, 2, 1 },
                    { 2, 2, 2 },
                    { 3, 2, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerProgress_PlayerID",
                table: "PlayerProgress",
                column: "PlayerID");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerProgress_PlayStatusID",
                table: "PlayerProgress",
                column: "PlayStatusID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerProgress");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "PlayStatuses");
        }
    }
}
