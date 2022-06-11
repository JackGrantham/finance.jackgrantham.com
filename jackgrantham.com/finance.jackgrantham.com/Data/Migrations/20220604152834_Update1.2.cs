using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace finance.jackgrantham.com.Data.Migrations
{
    public partial class Update12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Items",
                newName: "EstablishedDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EstablishedDate",
                table: "Items",
                newName: "CreatedDate");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
