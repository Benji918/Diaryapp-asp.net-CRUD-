using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Diaryapp.Migrations
{
    /// <inheritdoc />
    public partial class Addtestingdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DiaryModels",
                columns: new[] { "Id", "Content", "Created_at", "Title" },
                values: new object[,]
                {
                    { 1, "dfididjf", new DateTime(2024, 12, 8, 7, 50, 30, 278, DateTimeKind.Local).AddTicks(8773), "Went for a walk" },
                    { 2, "I hate Jake", new DateTime(2024, 12, 8, 7, 50, 30, 278, DateTimeKind.Local).AddTicks(9682), "I need to lock-in" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DiaryModels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DiaryModels",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
