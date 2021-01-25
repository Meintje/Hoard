using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hoard.Data.Persistence.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Platforms",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platforms", x => x.ID);
                    table.UniqueConstraint("AK_Platforms_Name", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.ID);
                    table.UniqueConstraint("AK_Players_Name", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "PlayStatuses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    OrdinalNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayStatuses", x => x.ID);
                    table.UniqueConstraint("AK_PlayStatuses_Name", x => x.Name);
                    table.UniqueConstraint("AK_PlayStatuses_OrdinalNumber", x => x.OrdinalNumber);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "date", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    PlatformID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.ID);
                    table.UniqueConstraint("AK_Games_Title_ReleaseDate_PlatformID", x => new { x.Title, x.ReleaseDate, x.PlatformID });
                    table.ForeignKey(
                        name: "FK_Games_Platforms_PlatformID",
                        column: x => x.PlatformID,
                        principalTable: "Platforms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayData",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameID = table.Column<int>(type: "int", nullable: false),
                    PlayerID = table.Column<int>(type: "int", nullable: false),
                    Dropped = table.Column<bool>(type: "bit", nullable: false),
                    CurrentlyPlaying = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayData", x => x.ID);
                    table.UniqueConstraint("AK_PlayData_GameID_PlayerID", x => new { x.GameID, x.PlayerID });
                    table.ForeignKey(
                        name: "FK_PlayData_Games_GameID",
                        column: x => x.GameID,
                        principalTable: "Games",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayData_Players_PlayerID",
                        column: x => x.PlayerID,
                        principalTable: "Players",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Playthroughs",
                columns: table => new
                {
                    PlayDataID = table.Column<int>(type: "int", nullable: false),
                    OrdinalNumber = table.Column<int>(type: "int", nullable: false),
                    PlayStatusID = table.Column<int>(type: "int", nullable: false),
                    DateStart = table.Column<DateTime>(type: "date", nullable: true),
                    DateEnd = table.Column<DateTime>(type: "date", nullable: true),
                    PlaytimeMinutes = table.Column<int>(type: "int", nullable: false),
                    SideContentCompleted = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playthroughs", x => new { x.PlayDataID, x.OrdinalNumber });
                    table.ForeignKey(
                        name: "FK_Playthroughs_PlayData_PlayDataID",
                        column: x => x.PlayDataID,
                        principalTable: "PlayData",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Playthroughs_PlayStatuses_PlayStatusID",
                        column: x => x.PlayStatusID,
                        principalTable: "PlayStatuses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Sony Playstation Vita" },
                    { 2, "Steam" },
                    { 3, "Nintendo Switch" },
                    { 4, "Nintendo 3DS" }
                });

            migrationBuilder.InsertData(
                table: "PlayStatuses",
                columns: new[] { "ID", "Name", "OrdinalNumber" },
                values: new object[,]
                {
                    { 1, "Playing", 1 },
                    { 2, "Finished", 2 },
                    { 3, "Hiatus", 3 },
                    { 4, "Dropped", 4 }
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
                table: "Games",
                columns: new[] { "ID", "Description", "PlatformID", "ReleaseDate", "Title" },
                values: new object[] { 1, null, 1, new DateTime(2015, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Legend of Heroes: Trails in the Sky FC Evolution" });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "ID", "Description", "PlatformID", "ReleaseDate", "Title" },
                values: new object[] { 2, null, 2, new DateTime(2018, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Monster Hunter World" });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "ID", "Description", "PlatformID", "ReleaseDate", "Title" },
                values: new object[] { 3, null, 3, new DateTime(2015, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yoshi's Woolly World" });

            migrationBuilder.InsertData(
                table: "PlayData",
                columns: new[] { "ID", "CurrentlyPlaying", "Dropped", "GameID", "Notes", "PlayerID" },
                values: new object[,]
                {
                    { 1, true, false, 1, null, 1 },
                    { 2, false, true, 1, null, 2 },
                    { 3, false, false, 2, null, 1 },
                    { 4, true, false, 2, null, 2 },
                    { 5, true, false, 3, null, 1 },
                    { 6, false, true, 3, null, 2 }
                });

            migrationBuilder.InsertData(
                table: "Playthroughs",
                columns: new[] { "OrdinalNumber", "PlayDataID", "DateEnd", "DateStart", "Notes", "PlayStatusID", "PlaytimeMinutes", "SideContentCompleted" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2021, 1, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 1, 25, 0, 0, 0, 0, DateTimeKind.Local), null, 1, 3000, false },
                    { 1, 3, null, null, null, 3, 30000, false },
                    { 1, 4, new DateTime(2021, 1, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 1, 25, 0, 0, 0, 0, DateTimeKind.Local), null, 1, 29000, false },
                    { 1, 5, new DateTime(2021, 1, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 1, 25, 0, 0, 0, 0, DateTimeKind.Local), null, 2, 1000, true },
                    { 2, 5, new DateTime(2021, 1, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 1, 25, 0, 0, 0, 0, DateTimeKind.Local), null, 1, 500, false },
                    { 1, 6, new DateTime(2021, 1, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 1, 25, 0, 0, 0, 0, DateTimeKind.Local), null, 4, 10, false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_PlatformID",
                table: "Games",
                column: "PlatformID");

            migrationBuilder.CreateIndex(
                name: "IX_PlayData_PlayerID",
                table: "PlayData",
                column: "PlayerID");

            migrationBuilder.CreateIndex(
                name: "IX_Playthroughs_PlayStatusID",
                table: "Playthroughs",
                column: "PlayStatusID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Playthroughs");

            migrationBuilder.DropTable(
                name: "PlayData");

            migrationBuilder.DropTable(
                name: "PlayStatuses");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Platforms");
        }
    }
}
