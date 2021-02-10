using Microsoft.EntityFrameworkCore.Migrations;

namespace DelegationBook.Migrations
{
    public partial class IsDriver : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDriver",
                table: "Employees",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDriver",
                table: "Employees");
        }
    }
}
