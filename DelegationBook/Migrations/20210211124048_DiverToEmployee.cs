using Microsoft.EntityFrameworkCore.Migrations;

namespace DelegationBook.Migrations
{
    public partial class DiverToEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Employees_DriverEmployeeId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_DriverEmployeeId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DriverEmployeeId",
                table: "Cars");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DriverEmployeeId",
                table: "Cars",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_DriverEmployeeId",
                table: "Cars",
                column: "DriverEmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Employees_DriverEmployeeId",
                table: "Cars",
                column: "DriverEmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
