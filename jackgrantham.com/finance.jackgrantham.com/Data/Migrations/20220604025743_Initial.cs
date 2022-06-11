using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace finance.jackgrantham.com.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfficialName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvailableBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CurrentBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Limit = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ISOCurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedDatetime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Mask = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subtype = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VerificationStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstitutionID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccessToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ISOCurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimaryCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondaryCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StoreNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Payee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Payer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ByOrderOf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentProcessor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountOwner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Pending = table.Column<bool>(type: "bit", nullable: true),
                    MerchantName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CheckNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentChannel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Transactions");
        }
    }
}
