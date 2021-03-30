using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hoard.Infrastructure.Persistence.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.ID);
                });

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
                    table.ForeignKey(
                        name: "FK_Games_Platforms_PlatformID",
                        column: x => x.PlatformID,
                        principalTable: "Platforms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameGenres",
                columns: table => new
                {
                    GameID = table.Column<int>(type: "int", nullable: false),
                    GenreID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameGenres", x => new { x.GameID, x.GenreID });
                    table.ForeignKey(
                        name: "FK_GameGenres_Games_GameID",
                        column: x => x.GameID,
                        principalTable: "Games",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameGenres_Genres_GenreID",
                        column: x => x.GenreID,
                        principalTable: "Genres",
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
                    Notes = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayData", x => x.ID);
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
                table: "Genres",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Turn-based RPG" },
                    { 2, "Action RPG" },
                    { 3, "Platform" },
                    { 4, "Visual novel" }
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
                    { 2, "Hiatus", 2 },
                    { 3, "Finished", 3 },
                    { 4, "Dropped", 4 },
                    { 5, "Endless", 5 }
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
                table: "GameGenres",
                columns: new[] { "GameID", "GenreID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 4 },
                    { 2, 2 },
                    { 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "PlayData",
                columns: new[] { "ID", "Dropped", "GameID", "Notes", "PlayerID" },
                values: new object[,]
                {
                    { 1, false, 1, null, 1 },
                    { 2, true, 1, null, 2 },
                    { 3, false, 2, null, 1 },
                    { 4, false, 2, null, 2 },
                    { 5, false, 3, null, 1 },
                    { 6, true, 3, null, 2 }
                });

            migrationBuilder.InsertData(
                table: "Playthroughs",
                columns: new[] { "OrdinalNumber", "PlayDataID", "DateEnd", "DateStart", "Notes", "PlayStatusID", "PlaytimeMinutes", "SideContentCompleted" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2021, 3, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 3, 29, 0, 0, 0, 0, DateTimeKind.Local), null, 1, 3000, false },
                    { 1, 3, null, null, null, 3, 30000, false },
                    { 1, 4, new DateTime(2021, 3, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 3, 29, 0, 0, 0, 0, DateTimeKind.Local), null, 1, 29000, false },
                    { 1, 5, new DateTime(2021, 3, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 3, 29, 0, 0, 0, 0, DateTimeKind.Local), null, 2, 1000, true },
                    { 2, 5, new DateTime(2021, 3, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 3, 29, 0, 0, 0, 0, DateTimeKind.Local), null, 1, 500, false },
                    { 1, 6, new DateTime(2021, 3, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 3, 29, 0, 0, 0, 0, DateTimeKind.Local), null, 4, 10, false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameGenres_GenreID",
                table: "GameGenres",
                column: "GenreID");

            migrationBuilder.CreateIndex(
                name: "IX_Games_PlatformID",
                table: "Games",
                column: "PlatformID");

            migrationBuilder.CreateIndex(
                name: "IX_Games_Title_PlatformID_ReleaseDate",
                table: "Games",
                columns: new[] { "Title", "PlatformID", "ReleaseDate" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Genres_Name",
                table: "Genres",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Platforms_Name",
                table: "Platforms",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlayData_GameID_PlayerID",
                table: "PlayData",
                columns: new[] { "GameID", "PlayerID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlayData_PlayerID",
                table: "PlayData",
                column: "PlayerID");

            migrationBuilder.CreateIndex(
                name: "IX_Players_Name",
                table: "Players",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlayStatuses_Name",
                table: "PlayStatuses",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlayStatuses_OrdinalNumber",
                table: "PlayStatuses",
                column: "OrdinalNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Playthroughs_PlayStatusID",
                table: "Playthroughs",
                column: "PlayStatusID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameGenres");

            migrationBuilder.DropTable(
                name: "Playthroughs");

            migrationBuilder.DropTable(
                name: "Genres");

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
