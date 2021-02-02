using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hoard.Data.Persistence.Migrations
{
    public partial class AlternateKeysToIndexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "AK_Platforms_Name",
                table: "Platforms");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Games_Title_ReleaseDate_PlatformID",
                table: "Games");

            migrationBuilder.UpdateData(
                table: "Playthroughs",
                keyColumns: new[] { "OrdinalNumber", "PlayDataID" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "DateEnd", "DateStart" },
                values: new object[] { new DateTime(2021, 1, 26, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 1, 26, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Playthroughs",
                keyColumns: new[] { "OrdinalNumber", "PlayDataID" },
                keyValues: new object[] { 1, 4 },
                columns: new[] { "DateEnd", "DateStart" },
                values: new object[] { new DateTime(2021, 1, 26, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 1, 26, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Playthroughs",
                keyColumns: new[] { "OrdinalNumber", "PlayDataID" },
                keyValues: new object[] { 1, 5 },
                columns: new[] { "DateEnd", "DateStart" },
                values: new object[] { new DateTime(2021, 1, 26, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 1, 26, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Playthroughs",
                keyColumns: new[] { "OrdinalNumber", "PlayDataID" },
                keyValues: new object[] { 2, 5 },
                columns: new[] { "DateEnd", "DateStart" },
                values: new object[] { new DateTime(2021, 1, 26, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 1, 26, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Playthroughs",
                keyColumns: new[] { "OrdinalNumber", "PlayDataID" },
                keyValues: new object[] { 1, 6 },
                columns: new[] { "DateEnd", "DateStart" },
                values: new object[] { new DateTime(2021, 1, 26, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 1, 26, 0, 0, 0, 0, DateTimeKind.Local) });

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
                name: "IX_Players_Name",
                table: "Players",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlayData_GameID_PlayerID",
                table: "PlayData",
                columns: new[] { "GameID", "PlayerID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Platforms_Name",
                table: "Platforms",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Games_Title_ReleaseDate_PlatformID",
                table: "Games",
                columns: new[] { "Title", "ReleaseDate", "PlatformID" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PlayStatuses_Name",
                table: "PlayStatuses");

            migrationBuilder.DropIndex(
                name: "IX_PlayStatuses_OrdinalNumber",
                table: "PlayStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Players_Name",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_PlayData_GameID_PlayerID",
                table: "PlayData");

            migrationBuilder.DropIndex(
                name: "IX_Platforms_Name",
                table: "Platforms");

            migrationBuilder.DropIndex(
                name: "IX_Games_Title_ReleaseDate_PlatformID",
                table: "Games");

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
                name: "AK_Platforms_Name",
                table: "Platforms",
                column: "Name");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Games_Title_ReleaseDate_PlatformID",
                table: "Games",
                columns: new[] { "Title", "ReleaseDate", "PlatformID" });

            migrationBuilder.UpdateData(
                table: "Playthroughs",
                keyColumns: new[] { "OrdinalNumber", "PlayDataID" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "DateEnd", "DateStart" },
                values: new object[] { new DateTime(2021, 1, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 1, 25, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Playthroughs",
                keyColumns: new[] { "OrdinalNumber", "PlayDataID" },
                keyValues: new object[] { 1, 4 },
                columns: new[] { "DateEnd", "DateStart" },
                values: new object[] { new DateTime(2021, 1, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 1, 25, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Playthroughs",
                keyColumns: new[] { "OrdinalNumber", "PlayDataID" },
                keyValues: new object[] { 1, 5 },
                columns: new[] { "DateEnd", "DateStart" },
                values: new object[] { new DateTime(2021, 1, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 1, 25, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Playthroughs",
                keyColumns: new[] { "OrdinalNumber", "PlayDataID" },
                keyValues: new object[] { 2, 5 },
                columns: new[] { "DateEnd", "DateStart" },
                values: new object[] { new DateTime(2021, 1, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 1, 25, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Playthroughs",
                keyColumns: new[] { "OrdinalNumber", "PlayDataID" },
                keyValues: new object[] { 1, 6 },
                columns: new[] { "DateEnd", "DateStart" },
                values: new object[] { new DateTime(2021, 1, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 1, 25, 0, 0, 0, 0, DateTimeKind.Local) });
        }
    }
}
