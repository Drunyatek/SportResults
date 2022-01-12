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
                name: "status",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    createdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    editdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_status", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "competitions",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    createdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    editdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    statusid = table.Column<long>(type: "bigint", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    comments = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_competitions", x => x.id);
                    table.ForeignKey(
                        name: "FK_competitions_status_statusid",
                        column: x => x.statusid,
                        principalTable: "status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "disciplinetype",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    createdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    editdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    statusid = table.Column<long>(type: "bigint", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_disciplinetype", x => x.id);
                    table.ForeignKey(
                        name: "FK_disciplinetype_status_statusid",
                        column: x => x.statusid,
                        principalTable: "status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "discipline",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    createdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    editdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    competitionid = table.Column<long>(type: "bigint", nullable: false),
                    statusid = table.Column<long>(type: "bigint", nullable: false),
                    disciplinetypeid = table.Column<long>(type: "bigint", nullable: false),
                    result = table.Column<double>(type: "double precision", nullable: false),
                    comments = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_discipline", x => x.id);
                    table.ForeignKey(
                        name: "FK_discipline_competitions_competitionid",
                        column: x => x.competitionid,
                        principalTable: "competitions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_discipline_disciplinetype_disciplinetypeid",
                        column: x => x.disciplinetypeid,
                        principalTable: "disciplinetype",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_discipline_status_statusid",
                        column: x => x.statusid,
                        principalTable: "status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "status",
                columns: new[] { "id", "createdate", "editdate", "name" },
                values: new object[,]
                {
                    { 1L, new DateTime(2021, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Активно" },
                    { 2L, new DateTime(2021, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Аннулировано" }
                });

            migrationBuilder.InsertData(
                table: "disciplinetype",
                columns: new[] { "id", "createdate", "editdate", "name", "statusid" },
                values: new object[,]
                {
                    { 1L, new DateTime(2021, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Бег на 100м", 1L },
                    { 2L, new DateTime(2021, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Бег на 60м", 1L },
                    { 3L, new DateTime(2021, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Прыжок в длину", 1L },
                    { 4L, new DateTime(2021, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Тройной прыжок в длину", 1L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_competitions_statusid",
                table: "competitions",
                column: "statusid");

            migrationBuilder.CreateIndex(
                name: "IX_discipline_competitionid",
                table: "discipline",
                column: "competitionid");

            migrationBuilder.CreateIndex(
                name: "IX_discipline_disciplinetypeid",
                table: "discipline",
                column: "disciplinetypeid");

            migrationBuilder.CreateIndex(
                name: "IX_discipline_statusid",
                table: "discipline",
                column: "statusid");

            migrationBuilder.CreateIndex(
                name: "IX_disciplinetype_statusid",
                table: "disciplinetype",
                column: "statusid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "discipline");

            migrationBuilder.DropTable(
                name: "competitions");

            migrationBuilder.DropTable(
                name: "disciplinetype");

            migrationBuilder.DropTable(
                name: "status");
        }
    }
}
