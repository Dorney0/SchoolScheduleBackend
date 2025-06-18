using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolScheduleBackend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_schedules_cabinets_CabinetId",
                table: "schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_schedules_classes_ClassId",
                table: "schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_schedules_employees_EmployeeId",
                table: "schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_schedules_subjects_SubjectId",
                table: "schedules");

            migrationBuilder.AddForeignKey(
                name: "FK_schedules_cabinets_CabinetId",
                table: "schedules",
                column: "CabinetId",
                principalTable: "cabinets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_schedules_classes_ClassId",
                table: "schedules",
                column: "ClassId",
                principalTable: "classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_schedules_employees_EmployeeId",
                table: "schedules",
                column: "EmployeeId",
                principalTable: "employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_schedules_subjects_SubjectId",
                table: "schedules",
                column: "SubjectId",
                principalTable: "subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_schedules_cabinets_CabinetId",
                table: "schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_schedules_classes_ClassId",
                table: "schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_schedules_employees_EmployeeId",
                table: "schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_schedules_subjects_SubjectId",
                table: "schedules");

            migrationBuilder.AddForeignKey(
                name: "FK_schedules_cabinets_CabinetId",
                table: "schedules",
                column: "CabinetId",
                principalTable: "cabinets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_schedules_classes_ClassId",
                table: "schedules",
                column: "ClassId",
                principalTable: "classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_schedules_employees_EmployeeId",
                table: "schedules",
                column: "EmployeeId",
                principalTable: "employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_schedules_subjects_SubjectId",
                table: "schedules",
                column: "SubjectId",
                principalTable: "subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
