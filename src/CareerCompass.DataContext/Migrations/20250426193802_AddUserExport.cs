using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CareerCompass.DataContext.Migrations
{
    /// <inheritdoc />
    public partial class AddUserExport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserExports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Why = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalaryRange = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EducationPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alternatives = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserExports", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserExports");
        }
    }
}
