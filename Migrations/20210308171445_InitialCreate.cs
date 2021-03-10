using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UploadPurchaseOrder.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PurchaseOrder",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    orderNumber = table.Column<string>(type: "TEXT", nullable: true),
                    buyerName = table.Column<string>(type: "TEXT", nullable: true),
                    buyerStreetAddress = table.Column<string>(type: "TEXT", nullable: true),
                    buyerCityStateZip = table.Column<string>(type: "TEXT", nullable: true),
                    buyerPhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    vendorName = table.Column<string>(type: "TEXT", nullable: true),
                    vendorStreetAddress = table.Column<string>(type: "TEXT", nullable: true),
                    vendorCityStateZip = table.Column<string>(type: "TEXT", nullable: true),
                    vendorPhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    subtotal = table.Column<decimal>(type: "TEXT", nullable: false),
                    tax = table.Column<decimal>(type: "TEXT", nullable: false),
                    shipping = table.Column<decimal>(type: "TEXT", nullable: false),
                    fullTotal = table.Column<decimal>(type: "TEXT", nullable: false),
                    purchaseOrderPDF = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrder", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseOrder");
        }
    }
}
