using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hoard.Data.Persistence.Migrations
{
    public partial class ColumnConfiguration : Migration
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
                name: "AK_PlayData_GameID_PlayerID",
                table: "PlayData");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Games_Title_ReleaseDate",
                table: "Games");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PlayStatuses",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Players",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PlayNotes",
                table: "PlayData",
                type: "nvarchar(2048)",
                maxLength: 2048,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GameNotes",
                table: "PlayData",
                type: "nvarchar(2048)",
                maxLength: 2048,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Games",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Games",
                type: "nvarchar(2048)",
                maxLength: 2048,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Playthroughs",
                keyColumns: new[] { "OrdinalNumber", "PlayDataID" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "DateEnd", "DateStart" },
                values: new object[] { new DateTime(2021, 1, 15, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 1, 15, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Playthroughs",
                keyColumns: new[] { "OrdinalNumber", "PlayDataID" },
                keyValues: new object[] { 1, 4 },
                columns: new[] { "DateEnd", "DateStart" },
                values: new object[] { new DateTime(2021, 1, 15, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 1, 15, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Playthroughs",
                keyColumns: new[] { "OrdinalNumber", "PlayDataID" },
                keyValues: new object[] { 1, 5 },
                columns: new[] { "DateEnd", "DateStart" },
                values: new object[] { new DateTime(2021, 1, 15, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 1, 15, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Playthroughs",
                keyColumns: new[] { "OrdinalNumber", "PlayDataID" },
                keyValues: new object[] { 2, 5 },
                columns: new[] { "DateEnd", "DateStart" },
                values: new object[] { new DateTime(2021, 1, 15, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 1, 15, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Playthroughs",
                keyColumns: new[] { "OrdinalNumber", "PlayDataID" },
                keyValues: new object[] { 1, 6 },
                columns: new[] { "DateEnd", "DateStart" },
                values: new object[] { new DateTime(2021, 1, 15, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 1, 15, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.CreateIndex(
                name: "IX_PlayData_GameID",
                table: "PlayData",
                column: "GameID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PlayData_GameID",
                table: "PlayData");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PlayStatuses",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Players",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<string>(
                name: "PlayNotes",
                table: "PlayData",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2048)",
                oldMaxLength: 2048,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GameNotes",
                table: "PlayData",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2048)",
                oldMaxLength: 2048,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Games",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Games",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2048)",
                oldMaxLength: 2048,
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_PlayStatuses_Name",
                table: "PlayStatuses",
                column: "Name");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_PlayStatuses_OrdinalNumber",
                table: "PlayStatuses",
                column: "OrdinalNumber");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_PlayData_GameID_PlayerID",
                table: "PlayData",
                columns: new[] { "GameID", "PlayerID" });

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Games_Title_ReleaseDate",
                table: "Games",
                columns: new[] { "Title", "ReleaseDate" });

            migrationBuilder.UpdateData(
                table: "Playthroughs",
                keyColumns: new[] { "OrdinalNumber", "PlayDataID" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "DateEnd", "DateStart" },
                values: new object[] { new DateTime(2021, 1, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 1, 12, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Playthroughs",
                keyColumns: new[] { "OrdinalNumber", "PlayDataID" },
                keyValues: new object[] { 1, 4 },
                columns: new[] { "DateEnd", "DateStart" },
                values: new object[] { new DateTime(2021, 1, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 1, 12, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Playthroughs",
                keyColumns: new[] { "OrdinalNumber", "PlayDataID" },
                keyValues: new object[] { 1, 5 },
                columns: new[] { "DateEnd", "DateStart" },
                values: new object[] { new DateTime(2021, 1, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 1, 12, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Playthroughs",
                keyColumns: new[] { "OrdinalNumber", "PlayDataID" },
                keyValues: new object[] { 2, 5 },
                columns: new[] { "DateEnd", "DateStart" },
                values: new object[] { new DateTime(2021, 1, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 1, 12, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Playthroughs",
                keyColumns: new[] { "OrdinalNumber", "PlayDataID" },
                keyValues: new object[] { 1, 6 },
                columns: new[] { "DateEnd", "DateStart" },
                values: new object[] { new DateTime(2021, 1, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 1, 12, 0, 0, 0, 0, DateTimeKind.Local) });
        }
    }
}
