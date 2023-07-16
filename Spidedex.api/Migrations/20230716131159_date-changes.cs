using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Spidedex.api.Migrations
{
    /// <inheritdoc />
    public partial class datechanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Spiders",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateObtained",
                value: new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Spiders",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateObtained",
                value: new DateTime(2023, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Spiders",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateObtained",
                value: new DateTime(2022, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Spiders",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateObtained",
                value: new DateOnly(2021, 10, 1));

            migrationBuilder.UpdateData(
                table: "Spiders",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateObtained",
                value: new DateOnly(2023, 9, 13));

            migrationBuilder.UpdateData(
                table: "Spiders",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateObtained",
                value: new DateOnly(2022, 5, 23));
        }
    }
}
