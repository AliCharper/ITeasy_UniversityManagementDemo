using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExternalStudents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UniverSity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalStudents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InCampusStudents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    YearsOfStudy = table.Column<int>(type: "int", nullable: false),
                    InitialTuitionFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MinimumScholarShipGiven = table.Column<bool>(type: "bit", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InCampusStudents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsNew = table.Column<bool>(type: "bit", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LessonInCampusStudent",
                columns: table => new
                {
                    AttendedLessonsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentsThatAttendedId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonInCampusStudent", x => new { x.AttendedLessonsId, x.StudentsThatAttendedId });
                    table.ForeignKey(
                        name: "FK_LessonInCampusStudent_InCampusStudents_StudentsThatAttendedId",
                        column: x => x.StudentsThatAttendedId,
                        principalTable: "InCampusStudents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LessonInCampusStudent_Lessons_AttendedLessonsId",
                        column: x => x.AttendedLessonsId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ExternalStudents",
                columns: new[] { "Id", "FirstName", "LastName", "UniverSity" },
                values: new object[] { new Guid("72f2f5fe-e50c-4966-8420-d50258aefdcb"), "Mohammad", "Jafary", "IT for Idiots, Inc" });

            migrationBuilder.InsertData(
                table: "InCampusStudents",
                columns: new[] { "Id", "FirstName", "InitialTuitionFee", "LastName", "Level", "MinimumScholarShipGiven", "YearsOfStudy" },
                values: new object[,]
                {
                    { new Guid("72f2f5fe-e50c-4966-8420-d50258aefdcb"), "Ali", 200000m, "Kolahdoozan", 2, false, 6 },
                    { new Guid("f484ad8f-78fd-46d1-9f87-bbb1e676e37f"), "Arash", 150000m, "Layazi", 1, true, 4 }
                });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "IsNew", "Title" },
                values: new object[,]
                {
                    { new Guid("1fd115cf-f44c-4982-86bc-a8fe2e4ff83e"), false, "Respecting Your Classmates" },
                    { new Guid("37e03ca7-c730-4351-834c-b66f280cdb01"), false, "University Introduction" },
                    { new Guid("844e14ce-c055-49e9-9610-855669c9859b"), false, "Dealing with Clients 101" },
                    { new Guid("cbf6db3b-c4ee-46aa-9457-5fa8aefef33a"), false, "Management 101" },
                    { new Guid("d6e0e4b7-9365-4332-9b29-bb7bf09664a6"), false, "Headache with Python - Advanced" }
                });

            migrationBuilder.InsertData(
                table: "LessonInCampusStudent",
                columns: new[] { "AttendedLessonsId", "StudentsThatAttendedId" },
                values: new object[,]
                {
                    { new Guid("1fd115cf-f44c-4982-86bc-a8fe2e4ff83e"), new Guid("72f2f5fe-e50c-4966-8420-d50258aefdcb") },
                    { new Guid("1fd115cf-f44c-4982-86bc-a8fe2e4ff83e"), new Guid("f484ad8f-78fd-46d1-9f87-bbb1e676e37f") },
                    { new Guid("37e03ca7-c730-4351-834c-b66f280cdb01"), new Guid("72f2f5fe-e50c-4966-8420-d50258aefdcb") },
                    { new Guid("37e03ca7-c730-4351-834c-b66f280cdb01"), new Guid("f484ad8f-78fd-46d1-9f87-bbb1e676e37f") },
                    { new Guid("844e14ce-c055-49e9-9610-855669c9859b"), new Guid("f484ad8f-78fd-46d1-9f87-bbb1e676e37f") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LessonInCampusStudent_StudentsThatAttendedId",
                table: "LessonInCampusStudent",
                column: "StudentsThatAttendedId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExternalStudents");

            migrationBuilder.DropTable(
                name: "LessonInCampusStudent");

            migrationBuilder.DropTable(
                name: "InCampusStudents");

            migrationBuilder.DropTable(
                name: "Lessons");
        }
    }
}
