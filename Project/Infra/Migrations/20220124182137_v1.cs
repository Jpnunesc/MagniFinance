using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remuneration = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdCourse = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_Course_IdCourse",
                        column: x => x.IdCourse,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Staus = table.Column<bool>(type: "bit", nullable: false),
                    Average = table.Column<decimal>(type: "decimal(18,2)", maxLength: 10, nullable: false),
                    IdCourse = table.Column<int>(type: "int", nullable: false),
                    TeacherEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subject_Course_IdCourse",
                        column: x => x.IdCourse,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subject_Teacher_TeacherEntityId",
                        column: x => x.TeacherEntityId,
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Grade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FistGrade = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SecondGrade = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ThirdGrade = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Fourthgrade = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    StudentEntityId = table.Column<int>(type: "int", nullable: true),
                    SubjectEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grade_Student_StudentEntityId",
                        column: x => x.StudentEntityId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Grade_Subject_SubjectEntityId",
                        column: x => x.SubjectEntityId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "Id", "Name", "Status" },
                values: new object[] { 1, "Information systems", true });

            migrationBuilder.InsertData(
                table: "Teacher",
                columns: new[] { "Id", "BirthDate", "Name", "Remuneration", "Status" },
                values: new object[] { 1, new DateTime(1994, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "João Paulo Costa", 20000m, true });

            migrationBuilder.InsertData(
                table: "Teacher",
                columns: new[] { "Id", "BirthDate", "Name", "Remuneration", "Status" },
                values: new object[] { 2, new DateTime(1993, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paulo Henrique", 25000m, true });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "BirthDate", "IdCourse", "Name", "Status" },
                values: new object[] { 1, new DateTime(1998, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Pedro Luciano", true });

            migrationBuilder.InsertData(
                table: "Subject",
                columns: new[] { "Id", "Average", "IdCourse", "Name", "Staus", "TeacherEntityId" },
                values: new object[,]
                {
                    { 1, 8m, 1, "Eng. Software", true, 1 },
                    { 2, 8m, 1, "Mathematics", true, 1 },
                    { 3, 8m, 1, "Architecture", true, 1 },
                    { 4, 8m, 1, "Banco de dados", true, 2 }
                });

            migrationBuilder.InsertData(
                table: "Grade",
                columns: new[] { "Id", "FistGrade", "Fourthgrade", "SecondGrade", "StudentEntityId", "SubjectEntityId", "ThirdGrade" },
                values: new object[] { 1, 7m, 9m, 8m, 1, 1, 9m });

            migrationBuilder.CreateIndex(
                name: "IX_Grade_StudentEntityId",
                table: "Grade",
                column: "StudentEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Grade_SubjectEntityId",
                table: "Grade",
                column: "SubjectEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_IdCourse",
                table: "Student",
                column: "IdCourse");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_IdCourse",
                table: "Subject",
                column: "IdCourse");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_TeacherEntityId",
                table: "Subject",
                column: "TeacherEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grade");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Teacher");
        }
    }
}
