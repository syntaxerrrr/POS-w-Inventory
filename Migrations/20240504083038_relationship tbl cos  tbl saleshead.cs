using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POSniLeinard.Migrations
{
    /// <inheritdoc />
    public partial class relationshiptblcostblsaleshead : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Tbl_CustomersCustomer_Id",
                table: "Tbl_SalesHeaders",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_SalesHeaders_Tbl_CustomersCustomer_Id",
                table: "Tbl_SalesHeaders",
                column: "Tbl_CustomersCustomer_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_SalesHeaders_Tbl_Costumers_Tbl_CustomersCustomer_Id",
                table: "Tbl_SalesHeaders",
                column: "Tbl_CustomersCustomer_Id",
                principalTable: "Tbl_Costumers",
                principalColumn: "Customer_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_SalesHeaders_Tbl_Costumers_Tbl_CustomersCustomer_Id",
                table: "Tbl_SalesHeaders");

            migrationBuilder.DropIndex(
                name: "IX_Tbl_SalesHeaders_Tbl_CustomersCustomer_Id",
                table: "Tbl_SalesHeaders");

            migrationBuilder.DropColumn(
                name: "Tbl_CustomersCustomer_Id",
                table: "Tbl_SalesHeaders");
        }
    }
}
