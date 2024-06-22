using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POSniLeinard.Migrations
{
    /// <inheritdoc />
    public partial class initialcname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Costumer_Id",
                table: "Tbl_Costumers",
                newName: "Customer_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Customer_Id",
                table: "Tbl_Costumers",
                newName: "Costumer_Id");
        }
    }
}
