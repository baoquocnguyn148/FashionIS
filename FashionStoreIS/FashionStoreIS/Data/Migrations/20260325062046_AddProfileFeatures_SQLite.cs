using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FashionStoreIS.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddProfileFeatures_SQLite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "USERADDRESSES",
                type: "VARCHAR2(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderId1",
                table: "RETURNREQUESTS",
                type: "NUMBER(10)",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "DISCOUNTAMOUNT",
                table: "ORDERS",
                type: "DECIMAL(18, 2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "DISCOUNTPERCENT",
                table: "ORDERDETAILS",
                type: "DECIMAL(18, 2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)",
                oldDefaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "NOTIFICATIONS",
                type: "VARCHAR2(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_USERADDRESSES_ApplicationUserId",
                table: "USERADDRESSES",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RETURNREQUESTS_OrderId1",
                table: "RETURNREQUESTS",
                column: "OrderId1");

            migrationBuilder.CreateIndex(
                name: "IX_NOTIFICATIONS_ApplicationUserId",
                table: "NOTIFICATIONS",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_NOTIFICATIONS_ASPNETUSERS_ApplicationUserId",
                table: "NOTIFICATIONS",
                column: "ApplicationUserId",
                principalTable: "ASPNETUSERS",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_RETURNREQUESTS_ORDERS_OrderId1",
                table: "RETURNREQUESTS",
                column: "OrderId1",
                principalTable: "ORDERS",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_USERADDRESSES_ASPNETUSERS_ApplicationUserId",
                table: "USERADDRESSES",
                column: "ApplicationUserId",
                principalTable: "ASPNETUSERS",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NOTIFICATIONS_ASPNETUSERS_ApplicationUserId",
                table: "NOTIFICATIONS");

            migrationBuilder.DropForeignKey(
                name: "FK_RETURNREQUESTS_ORDERS_OrderId1",
                table: "RETURNREQUESTS");

            migrationBuilder.DropForeignKey(
                name: "FK_USERADDRESSES_ASPNETUSERS_ApplicationUserId",
                table: "USERADDRESSES");

            migrationBuilder.DropIndex(
                name: "IX_USERADDRESSES_ApplicationUserId",
                table: "USERADDRESSES");

            migrationBuilder.DropIndex(
                name: "IX_RETURNREQUESTS_OrderId1",
                table: "RETURNREQUESTS");

            migrationBuilder.DropIndex(
                name: "IX_NOTIFICATIONS_ApplicationUserId",
                table: "NOTIFICATIONS");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "USERADDRESSES");

            migrationBuilder.DropColumn(
                name: "OrderId1",
                table: "RETURNREQUESTS");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "NOTIFICATIONS");

            migrationBuilder.AlterColumn<decimal>(
                name: "DISCOUNTAMOUNT",
                table: "ORDERS",
                type: "DECIMAL(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "DISCOUNTPERCENT",
                table: "ORDERDETAILS",
                type: "DECIMAL(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldDefaultValue: 0m);
        }
    }
}
