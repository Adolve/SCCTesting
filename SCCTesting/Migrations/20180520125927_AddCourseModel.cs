using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SCCTesting.Migrations
{
    public partial class AddCourseModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 80, nullable: false),
                    Name = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProfessorTermCourse",
                columns: table => new
                {
                    ProfessorId = table.Column<int>(nullable: false),
                    TermId = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessorTermCourse", x => new { x.ProfessorId, x.TermId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_ProfessorTermCourse_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfessorTermCourse_ProfessorTerm_ProfessorId_TermId",
                        columns: x => new { x.ProfessorId, x.TermId },
                        principalTable: "ProfessorTerm",
                        principalColumns: new[] { "ProfessorId", "TermId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProfessorTermCourse_CourseId",
                table: "ProfessorTermCourse",
                column: "CourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfessorTermCourse");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
