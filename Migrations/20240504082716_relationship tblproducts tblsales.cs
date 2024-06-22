using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POSniLeinard.Migrations
{
    /// <inheritdoc />
    public partial class relationshiptblproductstblsales : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Sales");

            migrationBuilder.CreateTable(
                name: "Tbl_SalesHeaders",
                columns: table => new
                {
                    Sales_Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedStamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_SalesHeaders", x => x.Sales_Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_SaleDetails",
                columns: table => new
                {
                    Sales_Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tbl_ProductsProduct_Id = table.Column<long>(type: "bigint", nullable: false),
                    Tbl_SalesHeaderSales_Id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_SaleDetails", x => x.Sales_Id);
                    table.ForeignKey(
                        name: "FK_Tbl_SaleDetails_Tbl_Products_Tbl_ProductsProduct_Id",
                        column: x => x.Tbl_ProductsProduct_Id,
                        principalTable: "Tbl_Products",
                        principalColumn: "Product_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_SaleDetails_Tbl_SalesHeaders_Tbl_SalesHeaderSales_Id",
                        column: x => x.Tbl_SalesHeaderSales_Id,
                        principalTable: "Tbl_SalesHeaders",
                        principalColumn: "Sales_Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_SaleDetails_Tbl_ProductsProduct_Id",
                table: "Tbl_SaleDetails",
                column: "Tbl_ProductsProduct_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_SaleDetails_Tbl_SalesHeaderSales_Id",
                table: "Tbl_SaleDetails",
                column: "Tbl_SalesHeaderSales_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_SaleDetails");

            migrationBuilder.DropTable(
                name: "Tbl_SalesHeaders");

            migrationBuilder.CreateTable(
                name: "Tbl_Sales",
                columns: table => new
                {
                    Sales_Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Sales", x => x.Sales_Id);
                });
        }
    }
}
