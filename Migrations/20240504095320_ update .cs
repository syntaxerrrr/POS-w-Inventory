using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POSniLeinard.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Tbl_SalesHeaders",
                newName: "Transaction_Name");

            migrationBuilder.AddColumn<string>(
                name: "Customer_Name",
                table: "Tbl_SalesHeaders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Product_Name",
                table: "Tbl_SalesHeaders",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Customer_Name",
                table: "Tbl_SalesHeaders");

            migrationBuilder.DropColumn(
                name: "Product_Name",
                table: "Tbl_SalesHeaders");

            migrationBuilder.RenameColumn(
                name: "Transaction_Name",
                table: "Tbl_SalesHeaders",
                newName: "Name");
        }
    }
}
