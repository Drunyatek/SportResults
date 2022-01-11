using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportResults.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreateDate", "EditDate" },
                values: new object[] { new DateTime(2021, 12, 30, 11, 35, 38, 200, DateTimeKind.Local).AddTicks(5725), new DateTime(2021, 12, 30, 11, 35, 38, 201, DateTimeKind.Local).AddTicks(7318) });

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreateDate", "EditDate" },
                values: new object[] { new DateTime(2021, 12, 30, 11, 35, 38, 201, DateTimeKind.Local).AddTicks(8329), new DateTime(2021, 12, 30, 11, 35, 38, 201, DateTimeKind.Local).AddTicks(8334) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreateDate", "EditDate" },
                values: new object[] { new DateTime(2021, 12, 30, 11, 26, 5, 375, DateTimeKind.Local).AddTicks(763), new DateTime(2021, 12, 30, 11, 26, 5, 376, DateTimeKind.Local).AddTicks(2385) });

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreateDate", "EditDate" },
                values: new object[] { new DateTime(2021, 12, 30, 11, 26, 5, 376, DateTimeKind.Local).AddTicks(3391), new DateTime(2021, 12, 30, 11, 26, 5, 376, DateTimeKind.Local).AddTicks(3396) });
        }
    }
}
