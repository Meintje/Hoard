using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hoard.Data.Persistence.Migrations
{
    public partial class SmallModelChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "GameNotes",
                table: "PlayData");

            migrationBuilder.DropColumn(
                name: "PlayNotes",
                table: "PlayData");

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Playthroughs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PlayStatuses",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Players",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "PlayData",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Games",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Games",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2048)",
                oldMaxLength: 2048,
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Playthroughs");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "PlayData");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PlayStatuses",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(70)",
                oldMaxLength: 70);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Players",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(70)",
                oldMaxLength: 70);

            migrationBuilder.AddColumn<string>(
                name: "GameNotes",
                table: "PlayData",
                type: "nvarchar(2048)",
                maxLength: 2048,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlayNotes",
                table: "PlayData",
                type: "nvarchar(2048)",
                maxLength: 2048,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Games",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Games",
                type: "nvarchar(2048)",
                maxLength: 2048,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000,
                oldNullable: true);

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
        }
    }
}
