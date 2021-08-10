using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hoard.Infrastructure.Persistence.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Developers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Hoarders",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hoarders", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MediaTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Modes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OwnershipStatuses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrdinalNumber = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnershipStatuses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PlatformDevelopers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    OrdinalNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatformDevelopers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PlatformTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatformTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PlayStatuses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    OrdinalNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayStatuses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Priorities",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrdinalNumber = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Priorities", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.ID);
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
                name: "WishlistItemTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrdinalNumber = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishlistItemTypes", x => x.ID);
                });

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
                name: "Platforms",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    PlatformDeveloperID = table.Column<int>(type: "int", nullable: false),
                    PlatformTypeID = table.Column<int>(type: "int", nullable: false),
                    OrdinalNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platforms", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Platforms_PlatformDevelopers_PlatformDeveloperID",
                        column: x => x.PlatformDeveloperID,
                        principalTable: "PlatformDevelopers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Platforms_PlatformTypes_PlatformTypeID",
                        column: x => x.PlatformTypeID,
                        principalTable: "PlatformTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WishlistItems",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoarderID = table.Column<int>(type: "int", nullable: false),
                    WishlistItemTypeID = table.Column<int>(type: "int", nullable: false),
                    PriorityID = table.Column<int>(type: "int", nullable: false),
                    LanguageID = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    AddDate = table.Column<DateTime>(type: "date", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "date", nullable: true),
                    StoreURL = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishlistItems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WishlistItems_Hoarders_HoarderID",
                        column: x => x.HoarderID,
                        principalTable: "Hoarders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WishlistItems_Languages_LanguageID",
                        column: x => x.LanguageID,
                        principalTable: "Languages",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WishlistItems_Priorities_PriorityID",
                        column: x => x.PriorityID,
                        principalTable: "Priorities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WishlistItems_WishlistItemTypes_WishlistItemTypeID",
                        column: x => x.WishlistItemTypeID,
                        principalTable: "WishlistItemTypes",
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

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    AlternateTitle = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "date", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    PlatformID = table.Column<int>(type: "int", nullable: false),
                    MediaTypeID = table.Column<int>(type: "int", nullable: false),
                    LanguageID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Games_Languages_LanguageID",
                        column: x => x.LanguageID,
                        principalTable: "Languages",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Games_MediaTypes_MediaTypeID",
                        column: x => x.MediaTypeID,
                        principalTable: "MediaTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Games_Platforms_PlatformID",
                        column: x => x.PlatformID,
                        principalTable: "Platforms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameDevelopers",
                columns: table => new
                {
                    GameID = table.Column<int>(type: "int", nullable: false),
                    DeveloperID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameDevelopers", x => new { x.GameID, x.DeveloperID });
                    table.ForeignKey(
                        name: "FK_GameDevelopers_Developers_DeveloperID",
                        column: x => x.DeveloperID,
                        principalTable: "Developers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameDevelopers_Games_GameID",
                        column: x => x.GameID,
                        principalTable: "Games",
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
                name: "GameModes",
                columns: table => new
                {
                    GameID = table.Column<int>(type: "int", nullable: false),
                    ModeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameModes", x => new { x.GameID, x.ModeID });
                    table.ForeignKey(
                        name: "FK_GameModes_Games_GameID",
                        column: x => x.GameID,
                        principalTable: "Games",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameModes_Modes_ModeID",
                        column: x => x.ModeID,
                        principalTable: "Modes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GamePublishers",
                columns: table => new
                {
                    GameID = table.Column<int>(type: "int", nullable: false),
                    PublisherID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePublishers", x => new { x.GameID, x.PublisherID });
                    table.ForeignKey(
                        name: "FK_GamePublishers_Games_GameID",
                        column: x => x.GameID,
                        principalTable: "Games",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamePublishers_Publishers_PublisherID",
                        column: x => x.PublisherID,
                        principalTable: "Publishers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameSeries",
                columns: table => new
                {
                    GameID = table.Column<int>(type: "int", nullable: false),
                    SeriesID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameSeries", x => new { x.GameID, x.SeriesID });
                    table.ForeignKey(
                        name: "FK_GameSeries_Games_GameID",
                        column: x => x.GameID,
                        principalTable: "Games",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameSeries_Series_SeriesID",
                        column: x => x.SeriesID,
                        principalTable: "Series",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
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
                name: "PlayData",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameID = table.Column<int>(type: "int", nullable: false),
                    HoarderID = table.Column<int>(type: "int", nullable: false),
                    OwnershipStatusID = table.Column<int>(type: "int", nullable: false),
                    PriorityID = table.Column<int>(type: "int", nullable: false),
                    Dropped = table.Column<bool>(type: "bit", nullable: false),
                    AchievementsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    Rating = table.Column<float>(type: "real", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true)
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
                        name: "FK_PlayData_Hoarders_HoarderID",
                        column: x => x.HoarderID,
                        principalTable: "Hoarders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayData_OwnershipStatuses_OwnershipStatusID",
                        column: x => x.OwnershipStatusID,
                        principalTable: "OwnershipStatuses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayData_Priorities_PriorityID",
                        column: x => x.PriorityID,
                        principalTable: "Priorities",
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
                    PlaytimeInMinutes = table.Column<int>(type: "int", nullable: false),
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
                table: "Developers",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Nihon Falcom" },
                    { 2, "CAPCOM" },
                    { 3, "Good-Feel" }
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
                table: "Hoarders",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Meintje" },
                    { 2, "Bram" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "ID", "Name", "ShortName" },
                values: new object[,]
                {
                    { 1, "English", "EN" },
                    { 2, "Japanese", "JP" }
                });

            migrationBuilder.InsertData(
                table: "MediaTypes",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Physical" },
                    { 2, "Digital" }
                });

            migrationBuilder.InsertData(
                table: "Modes",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 4, "MMO" },
                    { 3, "Competitive multiplayer" },
                    { 2, "Cooperative multiplayer" },
                    { 1, "Single-player" }
                });

            migrationBuilder.InsertData(
                table: "OwnershipStatuses",
                columns: new[] { "ID", "Name", "OrdinalNumber" },
                values: new object[,]
                {
                    { 1, "Owned", 1 },
                    { 2, "Household", 2 },
                    { 3, "Borrowed", 3 },
                    { 4, "Subscription", 4 },
                    { 5, "Formerly owned", 5 },
                    { 6, "Other", 6 }
                });

            migrationBuilder.InsertData(
                table: "PlatformDevelopers",
                columns: new[] { "ID", "Name", "OrdinalNumber" },
                values: new object[,]
                {
                    { 1, "Nintendo", 1 },
                    { 2, "Sony", 2 },
                    { 3, "Microsoft", 3 },
                    { 4, "Sega", 4 },
                    { 5, "Valve", 5 },
                    { 6, "Epic Games", 6 }
                });

            migrationBuilder.InsertData(
                table: "PlatformTypes",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 2, "Handheld" },
                    { 3, "Other" },
                    { 1, "Console" }
                });

            migrationBuilder.InsertData(
                table: "PlayStatuses",
                columns: new[] { "ID", "Name", "OrdinalNumber" },
                values: new object[,]
                {
                    { 1, "Playing", 1 },
                    { 2, "Hiatus", 2 },
                    { 3, "Dropped", 3 },
                    { 4, "Finished", 4 },
                    { 5, "Endless", 5 }
                });

            migrationBuilder.InsertData(
                table: "Priorities",
                columns: new[] { "ID", "Name", "OrdinalNumber" },
                values: new object[,]
                {
                    { 1, "Highest", 1 },
                    { 2, "High", 2 },
                    { 3, "Neutral", 3 },
                    { 4, "Low", 4 },
                    { 5, "Lowest", 5 }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 3, "Nintendo" },
                    { 1, "Nihon Falcom" },
                    { 2, "CAPCOM" }
                });

            migrationBuilder.InsertData(
                table: "Series",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 4, "Yoshi" },
                    { 3, "Monster Hunter" },
                    { 2, "The Legend of Heroes" },
                    { 1, "Trails" }
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
                table: "WishlistItemTypes",
                columns: new[] { "ID", "Name", "OrdinalNumber" },
                values: new object[,]
                {
                    { 4, "Book", 4 },
                    { 3, "DVD/Bluray", 3 },
                    { 5, "Artbook", 5 },
                    { 1, "Game", 1 },
                    { 2, "Manga", 2 },
                    { 6, "CD", 6 }
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
                table: "Platforms",
                columns: new[] { "ID", "Name", "OrdinalNumber", "PlatformDeveloperID", "PlatformTypeID", "ShortName" },
                values: new object[,]
                {
                    { 24, "Microsoft Xbox Series X|S", 4, 3, 1, "XSXS" },
                    { 6, "Sony Playstation Portable", 1, 2, 2, "PSP" },
                    { 7, "Sony Playstation Vita", 2, 2, 2, "PSVita" },
                    { 15, "Nintendo Game Boy", 1, 1, 2, "GB" },
                    { 16, "Nintendo Game Boy Color", 2, 1, 2, "GBC" },
                    { 20, "Microsoft Windows", 1, 3, 3, "PC" },
                    { 18, "Nintendo DS", 4, 1, 2, "NDS" },
                    { 19, "Nintendo 3DS", 5, 1, 2, "3DS" },
                    { 23, "Microsoft Xbox One", 3, 3, 1, "XOne" },
                    { 25, "Steam", 1, 5, 3, "Steam" },
                    { 26, "Epic Games Store", 1, 6, 3, "Epic" },
                    { 17, "Nintendo Game Boy Advance", 3, 1, 2, "GBA" },
                    { 22, "Microsoft Xbox 360", 2, 3, 1, "X360" },
                    { 13, "Nintendo Wii U", 6, 1, 1, "Wii U" },
                    { 14, "Nintendo Switch", 7, 1, 1, "Switch" },
                    { 12, "Nintendo Wii", 5, 1, 1, "Wii" },
                    { 11, "Nintendo GameCube", 4, 1, 1, "GCN" },
                    { 10, "Nintendo 64", 3, 1, 1, "N64" },
                    { 9, "Super Nintendo Entertainment System", 2, 1, 1, "SNES" },
                    { 8, "Nintendo Entertainment System", 1, 1, 1, "NES" },
                    { 5, "Sony Playstation 5", 5, 2, 1, "PS5" },
                    { 4, "Sony Playstation 4", 4, 2, 1, "PS4" },
                    { 3, "Sony Playstation 3", 3, 2, 1, "PS3" },
                    { 2, "Sony Playstation 2", 2, 2, 1, "PS2" },
                    { 1, "Sony Playstation", 1, 2, 1, "PSX" },
                    { 21, "Microsoft Xbox", 1, 3, 1, "Xbox" }
                });

            migrationBuilder.InsertData(
                table: "WishlistItems",
                columns: new[] { "ID", "AddDate", "HoarderID", "LanguageID", "Notes", "PriorityID", "ReleaseDate", "StoreURL", "Title", "WishlistItemTypeID" },
                values: new object[,]
                {
                    { 2, new DateTime(2021, 8, 9, 0, 0, 0, 0, DateTimeKind.Local), 1, 2, "Check out other works by this artist, too.", 2, new DateTime(2021, 8, 9, 0, 0, 0, 0, DateTimeKind.Local), "https://www.amazon.co.jp/", "Oresama Teacher", 2 },
                    { 1, new DateTime(2021, 8, 9, 0, 0, 0, 0, DateTimeKind.Local), 1, 1, "Maybe wait for PS7 version?", 1, new DateTime(2021, 8, 9, 0, 0, 0, 0, DateTimeKind.Local), "https://www.budgetgaming.nl/", "Persona 6 Royal", 1 },
                    { 4, new DateTime(2021, 8, 9, 0, 0, 0, 0, DateTimeKind.Local), 1, 2, "Get Limited Edition!", 1, new DateTime(2021, 8, 9, 0, 0, 0, 0, DateTimeKind.Local), "https://www.amazon.co.jp/", "Eiyuu Densetsu: Zero no Kiseki", 1 },
                    { 3, new DateTime(2021, 8, 9, 0, 0, 0, 0, DateTimeKind.Local), 1, 2, "Hide this from Bram.", 3, new DateTime(2021, 8, 9, 0, 0, 0, 0, DateTimeKind.Local), "https://www.amazon.co.jp/", "Monstergirl Factory", 5 }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "ID", "AlternateTitle", "Description", "LanguageID", "MediaTypeID", "PlatformID", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 3, null, null, 1, 1, 13, new DateTime(2015, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yoshi's Woolly World" },
                    { 2, null, null, 1, 2, 24, new DateTime(2018, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Monster Hunter World" },
                    { 1, "英雄伝説 空の軌跡 FC Evolution", null, 2, 1, 7, new DateTime(2015, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Legend of Heroes: Trails in the Sky FC Evolution" }
                });

            migrationBuilder.InsertData(
                table: "JournalTags",
                columns: new[] { "JournalEntryID", "TagID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 5 },
                    { 3, 3 },
                    { 5, 6 },
                    { 5, 7 }
                });

            migrationBuilder.InsertData(
                table: "GameDevelopers",
                columns: new[] { "DeveloperID", "GameID" },
                values: new object[,]
                {
                    { 3, 3 },
                    { 2, 2 },
                    { 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "GameGenres",
                columns: new[] { "GameID", "GenreID" },
                values: new object[,]
                {
                    { 1, 4 },
                    { 3, 3 },
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "GameModes",
                columns: new[] { "GameID", "ModeID" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 2, 2 },
                    { 1, 1 },
                    { 3, 2 },
                    { 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "GamePublishers",
                columns: new[] { "GameID", "PublisherID" },
                values: new object[,]
                {
                    { 3, 3 },
                    { 2, 2 },
                    { 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "GameSeries",
                columns: new[] { "GameID", "SeriesID" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 1, 1 },
                    { 3, 4 },
                    { 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "JournalGames",
                columns: new[] { "GameID", "JournalEntryID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 1 },
                    { 1, 5 },
                    { 3, 5 },
                    { 3, 1 },
                    { 2, 5 }
                });

            migrationBuilder.InsertData(
                table: "PlayData",
                columns: new[] { "ID", "AchievementsCompleted", "Dropped", "GameID", "HoarderID", "Notes", "OwnershipStatusID", "PriorityID", "Rating" },
                values: new object[,]
                {
                    { 4, false, false, 2, 2, null, 1, 2, null },
                    { 1, true, false, 1, 1, null, 1, 1, null },
                    { 2, false, true, 1, 2, null, 1, 5, null },
                    { 6, false, true, 3, 2, null, 1, 4, null },
                    { 5, true, false, 3, 1, null, 1, 4, null },
                    { 3, false, false, 2, 1, null, 1, 2, null }
                });

            migrationBuilder.InsertData(
                table: "Playthroughs",
                columns: new[] { "OrdinalNumber", "PlayDataID", "DateEnd", "DateStart", "Notes", "PlayStatusID", "PlaytimeInMinutes", "SideContentCompleted" },
                values: new object[,]
                {
                    { 1, 5, new DateTime(2021, 8, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 8, 9, 0, 0, 0, 0, DateTimeKind.Local), null, 2, 1000, true },
                    { 2, 5, new DateTime(2021, 8, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 8, 9, 0, 0, 0, 0, DateTimeKind.Local), null, 1, 500, false },
                    { 1, 6, new DateTime(2021, 8, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 8, 9, 0, 0, 0, 0, DateTimeKind.Local), null, 4, 10, false },
                    { 1, 3, null, null, null, 3, 30000, false },
                    { 1, 4, new DateTime(2021, 8, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 8, 9, 0, 0, 0, 0, DateTimeKind.Local), null, 1, 29000, false },
                    { 1, 1, new DateTime(2021, 8, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 8, 9, 0, 0, 0, 0, DateTimeKind.Local), null, 1, 3000, false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Developers_Name",
                table: "Developers",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GameDevelopers_DeveloperID",
                table: "GameDevelopers",
                column: "DeveloperID");

            migrationBuilder.CreateIndex(
                name: "IX_GameGenres_GenreID",
                table: "GameGenres",
                column: "GenreID");

            migrationBuilder.CreateIndex(
                name: "IX_GameModes_ModeID",
                table: "GameModes",
                column: "ModeID");

            migrationBuilder.CreateIndex(
                name: "IX_GamePublishers_PublisherID",
                table: "GamePublishers",
                column: "PublisherID");

            migrationBuilder.CreateIndex(
                name: "IX_Games_LanguageID",
                table: "Games",
                column: "LanguageID");

            migrationBuilder.CreateIndex(
                name: "IX_Games_MediaTypeID",
                table: "Games",
                column: "MediaTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Games_PlatformID",
                table: "Games",
                column: "PlatformID");

            migrationBuilder.CreateIndex(
                name: "IX_Games_Title_PlatformID_LanguageID_MediaTypeID_ReleaseDate",
                table: "Games",
                columns: new[] { "Title", "PlatformID", "LanguageID", "MediaTypeID", "ReleaseDate" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GameSeries_SeriesID",
                table: "GameSeries",
                column: "SeriesID");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_Name",
                table: "Genres",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Hoarders_Name",
                table: "Hoarders",
                column: "Name",
                unique: true);

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
                name: "IX_Languages_Name",
                table: "Languages",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Languages_ShortName",
                table: "Languages",
                column: "ShortName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MediaTypes_Name",
                table: "MediaTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Modes_Name",
                table: "Modes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OwnershipStatuses_Name",
                table: "OwnershipStatuses",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OwnershipStatuses_OrdinalNumber",
                table: "OwnershipStatuses",
                column: "OrdinalNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlatformDevelopers_Name",
                table: "PlatformDevelopers",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlatformDevelopers_OrdinalNumber",
                table: "PlatformDevelopers",
                column: "OrdinalNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Platforms_PlatformDeveloperID_PlatformTypeID_Name",
                table: "Platforms",
                columns: new[] { "PlatformDeveloperID", "PlatformTypeID", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Platforms_PlatformDeveloperID_PlatformTypeID_OrdinalNumber",
                table: "Platforms",
                columns: new[] { "PlatformDeveloperID", "PlatformTypeID", "OrdinalNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Platforms_PlatformTypeID",
                table: "Platforms",
                column: "PlatformTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Platforms_ShortName",
                table: "Platforms",
                column: "ShortName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlatformTypes_Name",
                table: "PlatformTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlayData_GameID_HoarderID",
                table: "PlayData",
                columns: new[] { "GameID", "HoarderID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlayData_HoarderID",
                table: "PlayData",
                column: "HoarderID");

            migrationBuilder.CreateIndex(
                name: "IX_PlayData_OwnershipStatusID",
                table: "PlayData",
                column: "OwnershipStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_PlayData_PriorityID",
                table: "PlayData",
                column: "PriorityID");

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

            migrationBuilder.CreateIndex(
                name: "IX_Priorities_Name",
                table: "Priorities",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Priorities_OrdinalNumber",
                table: "Priorities",
                column: "OrdinalNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Publishers_Name",
                table: "Publishers",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Series_Name",
                table: "Series",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_Name",
                table: "Tags",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WishlistItems_HoarderID",
                table: "WishlistItems",
                column: "HoarderID");

            migrationBuilder.CreateIndex(
                name: "IX_WishlistItems_LanguageID",
                table: "WishlistItems",
                column: "LanguageID");

            migrationBuilder.CreateIndex(
                name: "IX_WishlistItems_PriorityID",
                table: "WishlistItems",
                column: "PriorityID");

            migrationBuilder.CreateIndex(
                name: "IX_WishlistItems_Title_HoarderID_WishlistItemTypeID",
                table: "WishlistItems",
                columns: new[] { "Title", "HoarderID", "WishlistItemTypeID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WishlistItems_WishlistItemTypeID",
                table: "WishlistItems",
                column: "WishlistItemTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_WishlistItemTypes_Name",
                table: "WishlistItemTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WishlistItemTypes_OrdinalNumber",
                table: "WishlistItemTypes",
                column: "OrdinalNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameDevelopers");

            migrationBuilder.DropTable(
                name: "GameGenres");

            migrationBuilder.DropTable(
                name: "GameModes");

            migrationBuilder.DropTable(
                name: "GamePublishers");

            migrationBuilder.DropTable(
                name: "GameSeries");

            migrationBuilder.DropTable(
                name: "JournalGames");

            migrationBuilder.DropTable(
                name: "JournalTags");

            migrationBuilder.DropTable(
                name: "Playthroughs");

            migrationBuilder.DropTable(
                name: "WishlistItems");

            migrationBuilder.DropTable(
                name: "Developers");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Modes");

            migrationBuilder.DropTable(
                name: "Publishers");

            migrationBuilder.DropTable(
                name: "Series");

            migrationBuilder.DropTable(
                name: "JournalEntries");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "PlayData");

            migrationBuilder.DropTable(
                name: "PlayStatuses");

            migrationBuilder.DropTable(
                name: "WishlistItemTypes");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Hoarders");

            migrationBuilder.DropTable(
                name: "OwnershipStatuses");

            migrationBuilder.DropTable(
                name: "Priorities");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "MediaTypes");

            migrationBuilder.DropTable(
                name: "Platforms");

            migrationBuilder.DropTable(
                name: "PlatformDevelopers");

            migrationBuilder.DropTable(
                name: "PlatformTypes");
        }
    }
}
