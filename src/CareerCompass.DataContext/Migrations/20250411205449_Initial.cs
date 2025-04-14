using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CareerCompass.DataContext.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FieldOfStudy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Goal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SchoolYears",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Grades_Algebra = table.Column<short>(type: "smallint", nullable: true),
                    Grades_Art = table.Column<short>(type: "smallint", nullable: true),
                    Grades_Biology = table.Column<short>(type: "smallint", nullable: true),
                    Grades_Business = table.Column<short>(type: "smallint", nullable: true),
                    Grades_Chemistry = table.Column<short>(type: "smallint", nullable: true),
                    Grades_English = table.Column<short>(type: "smallint", nullable: true),
                    Grades_French = table.Column<short>(type: "smallint", nullable: true),
                    Grades_Geography = table.Column<short>(type: "smallint", nullable: true),
                    Grades_German = table.Column<short>(type: "smallint", nullable: true),
                    Grades_History = table.Column<short>(type: "smallint", nullable: true),
                    Grades_Informatics = table.Column<short>(type: "smallint", nullable: true),
                    Grades_LinearAlgebra = table.Column<short>(type: "smallint", nullable: true),
                    Grades_Mathematics = table.Column<short>(type: "smallint", nullable: true),
                    Grades_MusicEducation = table.Column<short>(type: "smallint", nullable: true),
                    Grades_Physics = table.Column<short>(type: "smallint", nullable: true),
                    Grades_ProgrammingLanguages = table.Column<short>(type: "smallint", nullable: true),
                    Grades_Psychology = table.Column<short>(type: "smallint", nullable: true),
                    Grades_Sociology = table.Column<short>(type: "smallint", nullable: true),
                    Grades_Sport = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolYears", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchoolYears_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SchoolYears_UserId",
                table: "SchoolYears",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SchoolYears");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
