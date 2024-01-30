using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeVendas.Migrations
{
    public partial class IncludeDatesInAllClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "Clients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "Clients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Salles",
                keyColumn: "SalleId",
                keyValue: 1,
                column: "SalleDate",
                value: new DateTime(2024, 1, 29, 21, 56, 26, 536, DateTimeKind.Local).AddTicks(9230));

            migrationBuilder.UpdateData(
                table: "Salles",
                keyColumn: "SalleId",
                keyValue: 2,
                column: "SalleDate",
                value: new DateTime(2024, 1, 29, 21, 56, 26, 536, DateTimeKind.Local).AddTicks(9242));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "Categories");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.UpdateData(
                table: "Salles",
                keyColumn: "SalleId",
                keyValue: 1,
                column: "SalleDate",
                value: new DateTime(2024, 1, 20, 0, 1, 37, 847, DateTimeKind.Local).AddTicks(2171));

            migrationBuilder.UpdateData(
                table: "Salles",
                keyColumn: "SalleId",
                keyValue: 2,
                column: "SalleDate",
                value: new DateTime(2024, 1, 20, 0, 1, 37, 847, DateTimeKind.Local).AddTicks(2186));
        }
    }
}
