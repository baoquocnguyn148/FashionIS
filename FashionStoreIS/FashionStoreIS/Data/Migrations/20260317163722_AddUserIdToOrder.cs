using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FashionStoreIS.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUserIdToOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "PriceOverride",
                table: "ProductVariants",
                type: "DECIMAL(18, 2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AddColumn<string>(
                name: "USERID",
                table: "Orders",
                type: "VARCHAR2(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_USERID",
                table: "Orders",
                column: "USERID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_ASPNETUSERS_USERID",
                table: "Orders",
                column: "USERID",
                principalTable: "ASPNETUSERS",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ASPNETUSERS_USERID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_USERID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "USERID",
                table: "Orders");

            migrationBuilder.AlterColumn<decimal>(
                name: "PriceOverride",
                table: "ProductVariants",
                type: "DECIMAL(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");
        }
    }
}
