using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolScheduleBackend.Migrations
{
    /// <inheritdoc />
    public partial class ThirdMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cool",
                table: "cabinets");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Cool",
                table: "cabinets",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
