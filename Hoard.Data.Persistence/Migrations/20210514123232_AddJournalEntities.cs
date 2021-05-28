using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hoard.Infrastructure.Persistence.Migrations
{
    public partial class AddJournalEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JournalEntries",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoarderID = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", maxLength: 8000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JournalEntries", x => x.ID);
                    table.ForeignKey(
                        name: "FK_JournalEntries_Hoarders_HoarderID",
                        column: x => x.HoarderID,
                        principalTable: "Hoarders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "JournalGames",
                columns: table => new
                {
                    JournalEntryID = table.Column<int>(type: "int", nullable: false),
                    GameID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JournalGames", x => new { x.JournalEntryID, x.GameID });
                    table.ForeignKey(
                        name: "FK_JournalGames_Games_GameID",
                        column: x => x.GameID,
                        principalTable: "Games",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JournalGames_JournalEntries_JournalEntryID",
                        column: x => x.JournalEntryID,
                        principalTable: "JournalEntries",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JournalTags",
                columns: table => new
                {
                    JournalEntryID = table.Column<int>(type: "int", nullable: false),
                    TagID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JournalTags", x => new { x.JournalEntryID, x.TagID });
                    table.ForeignKey(
                        name: "FK_JournalTags_JournalEntries_JournalEntryID",
                        column: x => x.JournalEntryID,
                        principalTable: "JournalEntries",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JournalTags_Tags_TagID",
                        column: x => x.TagID,
                        principalTable: "Tags",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "JournalEntries",
                columns: new[] { "ID", "Content", "Date", "HoarderID", "Title" },
                values: new object[,]
                {
                    { 1, "It was turtles all the way down.", new DateTime(2021, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Once upon a time" },
                    { 2, "Owari.", new DateTime(2021, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Mukashi mukashi" },
                    { 3, "En ze leefden nog lang en gelukkig.", new DateTime(2021, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Er was eens" },
                    { 4, "Kan ik niet. Te laat!", new DateTime(2021, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Vlieg!" },
                    { 5, "Insert cat ipsum here.", new DateTime(2021, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Ambiguous frog" },
                    { 6, "Kitty scratches couch bad kitty. Good morning sunshine. Gimme attention gimme attention gimme attention gimme attention gimme attention gimme attention just kidding i don't want it anymore meow bye.", new DateTime(2021, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Frantic apple" },
                    { 7, "Scratch the furniture groom yourself 4 hours - checked, have your beauty sleep 18 hours - checked, be fabulous for the rest of the day - checked, or pet my belly, you know you want to; seize the hand and shred it!", new DateTime(2021, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Da-da-da-DAAAAAA" },
                    { 8, "I like frogs and 0 gravity love or humans,humans, humans oh how much they love us felines we are the center of attention they feed, they clean yet if it fits, i sits, so the door is opening!", new DateTime(2021, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Something interesting" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Finished a game" },
                    { 2, "Started a game" },
                    { 3, "Multiplayer chaos" },
                    { 4, "Big haul" },
                    { 5, "Analog day" },
                    { 6, "Sleepy day" },
                    { 7, "Special event" },
                    { 8, "Family/friends" }
                });

            migrationBuilder.InsertData(
                table: "JournalGames",
                columns: new[] { "GameID", "JournalEntryID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 5 },
                    { 2, 5 },
                    { 3, 5 }
                });

            migrationBuilder.InsertData(
                table: "JournalTags",
                columns: new[] { "JournalEntryID", "TagID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 3, 3 },
                    { 2, 5 },
                    { 5, 6 },
                    { 5, 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntries_HoarderID_Date",
                table: "JournalEntries",
                columns: new[] { "HoarderID", "Date" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JournalGames_GameID",
                table: "JournalGames",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_JournalTags_TagID",
                table: "JournalTags",
                column: "TagID");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_Name",
                table: "Tags",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JournalGames");

            migrationBuilder.DropTable(
                name: "JournalTags");

            migrationBuilder.DropTable(
                name: "JournalEntries");

            migrationBuilder.DropTable(
                name: "Tags");
        }
    }
}
