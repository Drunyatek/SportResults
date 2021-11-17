using Microsoft.EntityFrameworkCore.Migrations;

namespace SportResults.Migrations
{
    public partial class some_foreign_keys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_DisciplineType_StatusId",
                table: "DisciplineType",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Discipline_DisciplineTypeId",
                table: "Discipline",
                column: "DisciplineTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Discipline_StatusId",
                table: "Discipline",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Competitions_StatusId",
                table: "Competitions",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Competitions_Status_StatusId",
                table: "Competitions",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Discipline_DisciplineType_DisciplineTypeId",
                table: "Discipline",
                column: "DisciplineTypeId",
                principalTable: "DisciplineType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Discipline_Status_StatusId",
                table: "Discipline",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DisciplineType_Status_StatusId",
                table: "DisciplineType",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competitions_Status_StatusId",
                table: "Competitions");

            migrationBuilder.DropForeignKey(
                name: "FK_Discipline_DisciplineType_DisciplineTypeId",
                table: "Discipline");

            migrationBuilder.DropForeignKey(
                name: "FK_Discipline_Status_StatusId",
                table: "Discipline");

            migrationBuilder.DropForeignKey(
                name: "FK_DisciplineType_Status_StatusId",
                table: "DisciplineType");

            migrationBuilder.DropIndex(
                name: "IX_DisciplineType_StatusId",
                table: "DisciplineType");

            migrationBuilder.DropIndex(
                name: "IX_Discipline_DisciplineTypeId",
                table: "Discipline");

            migrationBuilder.DropIndex(
                name: "IX_Discipline_StatusId",
                table: "Discipline");

            migrationBuilder.DropIndex(
                name: "IX_Competitions_StatusId",
                table: "Competitions");
        }
    }
}
