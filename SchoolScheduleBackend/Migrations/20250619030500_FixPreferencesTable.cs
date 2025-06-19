using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolScheduleBackend.Migrations
{
    /// <inheritdoc />
    public partial class FixPreferencesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Удаляем колонку EmployeeId
            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "preferences");

            // Добавляем колонку UserId
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "preferences",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            // Добавляем внешний ключ из preferences.UserId в users.Id
            migrationBuilder.AddForeignKey(
                name: "FK_preferences_users_UserId",
                table: "preferences",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade); // или Restrict/SetNull по бизнес-логике
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Удаляем внешний ключ
            migrationBuilder.DropForeignKey(
                name: "FK_preferences_users_UserId",
                table: "preferences");

            // Удаляем колонку UserId
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "preferences");

            // Восстанавливаем колонку EmployeeId
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "preferences",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            // Можно добавить внешний ключ для EmployeeId, если он был (опционально)
        }

    }
}
