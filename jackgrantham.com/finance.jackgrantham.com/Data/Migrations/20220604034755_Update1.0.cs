using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace finance.jackgrantham.com.Data.Migrations
{
    public partial class Update10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Items");
        }
    }
}
