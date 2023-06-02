using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Spidedex.api.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Spiders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateObtained = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Species = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Size = table.Column<string>(type: "TEXT", nullable: false),
                    Diet = table.Column<string>(type: "TEXT", nullable: false),
                    UserInfo = table.Column<string>(type: "TEXT", nullable: false),
                    Temperament = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spiders", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Spiders",
                columns: new[] { "Id", "DateObtained", "Description", "Diet", "Name", "Size", "Species", "Temperament", "UserInfo" },
                values: new object[,]
                {
                    { 1, new DateOnly(2021, 10, 1), "A cool spooder", "Crickets", "Charlotte", "3 inches", "Argiope aurantia", 4, "test123@gmail.com" },
                    { 2, new DateOnly(2023, 9, 13), "My spooder", "Locusts", "Luna", "4 inches", "Tliltocatl vagans", 0, "test123@gmail.com" },
                    { 3, new DateOnly(2022, 5, 23), "Ouch it hurts", "Crickets", "Pokey", "5 inches", "Poecilotheria regalis", 2, "test123@gmail.com" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Spiders");
        }
    }
}
