using Microsoft.EntityFrameworkCore.Migrations;

namespace HR.Repository.Migrations
{
    public partial class migForBranchModify : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Branches",
                newName: "PhoneNo");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Branches",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Branches",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Branches");

            migrationBuilder.RenameColumn(
                name: "PhoneNo",
                table: "Branches",
                newName: "Description");
        }
    }
}
