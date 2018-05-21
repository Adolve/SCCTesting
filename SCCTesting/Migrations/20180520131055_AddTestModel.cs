using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SCCTesting.Migrations
{
    public partial class AddTestModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Comment = table.Column<string>(maxLength: 255, nullable: true),
                    CourseId = table.Column<int>(nullable: false),
                    Number = table.Column<string>(maxLength: 10, nullable: false),
                    Password = table.Column<string>(maxLength: 20, nullable: false),
                    ProfessorId = table.Column<int>(nullable: false),
                    TermId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tests_ProfessorTermCourse_ProfessorId_TermId_CourseId",
                        columns: x => new { x.ProfessorId, x.TermId, x.CourseId },
                        principalTable: "ProfessorTermCourse",
                        principalColumns: new[] { "ProfessorId", "TermId", "CourseId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tests_ProfessorId_TermId_CourseId",
                table: "Tests",
                columns: new[] { "ProfessorId", "TermId", "CourseId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tests");
        }
    }
}
