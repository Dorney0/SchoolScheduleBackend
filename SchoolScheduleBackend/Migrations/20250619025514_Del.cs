using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolScheduleBackend.Migrations
{
    /// <inheritdoc />
    public partial class Del : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Удаляем внешний ключ, если он есть
            migrationBuilder.DropForeignKey(
                name: "FK_preferences_employees_EmployeeId", // Имя внешнего ключа, может отличаться
                table: "preferences");

            // Удаляем индекс по колонке EmployeeId, если он есть
            migrationBuilder.DropIndex(
                name: "IX_preferences_EmployeeId", // Имя индекса, может отличаться
                table: "preferences");

            // Удаляем колонку EmployeeId
            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "preferences");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Добавляем колонку обратно
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "preferences",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            // Создаём индекс
            migrationBuilder.CreateIndex(
                name: "IX_preferences_EmployeeId",
                table: "preferences",
                column: "EmployeeId");

            // Восстанавливаем внешний ключ
            migrationBuilder.AddForeignKey(
                name: "FK_preferences_employees_EmployeeId",
                table: "preferences",
                column: "EmployeeId",
                principalTable: "employees", // Имя таблицы с которой связь
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

    }
}
