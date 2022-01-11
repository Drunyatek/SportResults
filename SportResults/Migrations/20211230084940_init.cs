using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SportResults.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EditDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Competitions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EditDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    StatusId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Comments = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Competitions_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DisciplineType",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EditDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    StatusId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisciplineType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DisciplineType_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Discipline",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EditDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CompetitionId = table.Column<long>(type: "bigint", nullable: false),
                    StatusId = table.Column<long>(type: "bigint", nullable: false),
                    DisciplineTypeId = table.Column<long>(type: "bigint", nullable: false),
                    Result = table.Column<double>(type: "double precision", nullable: false),
                    Comments = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discipline", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Discipline_Competitions_CompetitionId",
                        column: x => x.CompetitionId,
                        principalTable: "Competitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Discipline_DisciplineType_DisciplineTypeId",
                        column: x => x.DisciplineTypeId,
                        principalTable: "DisciplineType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Discipline_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "CreateDate", "EditDate", "Name" },
                values: new object[,]
                {
                    { 1L, new DateTime(2021, 12, 30, 11, 49, 40, 219, DateTimeKind.Local).AddTicks(3819), new DateTime(2021, 12, 30, 11, 49, 40, 220, DateTimeKind.Local).AddTicks(4983), "Активно" },
                    { 2L, new DateTime(2021, 12, 30, 11, 49, 40, 220, DateTimeKind.Local).AddTicks(5977), new DateTime(2021, 12, 30, 11, 49, 40, 220, DateTimeKind.Local).AddTicks(5981), "Аннулировано" }
                });

            migrationBuilder.InsertData(
                table: "DisciplineType",
                columns: new[] { "Id", "CreateDate", "EditDate", "Name", "StatusId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2021, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Бег на 100м", 1L },
                    { 2L, new DateTime(2021, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Бег на 60м", 1L },
                    { 3L, new DateTime(2021, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Прыжок в длину", 1L },
                    { 4L, new DateTime(2021, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Тройной прыжок в длину", 1L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Competitions_StatusId",
                table: "Competitions",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Discipline_CompetitionId",
                table: "Discipline",
                column: "CompetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Discipline_DisciplineTypeId",
                table: "Discipline",
                column: "DisciplineTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Discipline_StatusId",
                table: "Discipline",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplineType_StatusId",
                table: "DisciplineType",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Discipline");

            migrationBuilder.DropTable(
                name: "Competitions");

            migrationBuilder.DropTable(
                name: "DisciplineType");

            migrationBuilder.DropTable(
                name: "Status");
        }
    }
}
