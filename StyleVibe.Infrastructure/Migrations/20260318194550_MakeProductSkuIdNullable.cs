using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StyleVibe.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MakeProductSkuIdNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_ProductSkus_ProductSkuId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrderDetails_ProductSkus_ProductSkuId",
                table: "PurchaseOrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrderDetails_ProductSkus_ProductSkuId1",
                table: "PurchaseOrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrderDetails_PurchaseOrders_PurchaseOrderId",
                table: "PurchaseOrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseOrderDetails_ProductSkuId1",
                table: "PurchaseOrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_StoreId_ProductSkuId",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "ProductSkuId1",
                table: "PurchaseOrderDetails");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Suppliers",
                type: "NUMBER(1)",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "BOOLEAN",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Suppliers",
                type: "NUMBER(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "BOOLEAN");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Suppliers",
                type: "TIMESTAMP(7)",
                nullable: false,
                defaultValueSql: "SYS_EXTRACT_UTC(SYSTIMESTAMP)",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)",
                oldDefaultValueSql: "GETUTCDATE()");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Stores",
                type: "NUMBER(1)",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "BOOLEAN",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Stores",
                type: "NUMBER(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "BOOLEAN");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Stores",
                type: "TIMESTAMP(7)",
                nullable: false,
                defaultValueSql: "SYS_EXTRACT_UTC(SYSTIMESTAMP)",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)",
                oldDefaultValueSql: "GETUTCDATE()");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "StockAdjustments",
                type: "NUMBER(1)",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "BOOLEAN",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "StockAdjustments",
                type: "TIMESTAMP(7)",
                nullable: false,
                defaultValueSql: "SYS_EXTRACT_UTC(SYSTIMESTAMP)",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)",
                oldDefaultValueSql: "GETUTCDATE()");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalCost",
                table: "PurchaseOrders",
                type: "decimal(12,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(16,0)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "PurchaseOrders",
                type: "NUMBER(1)",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "BOOLEAN",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "PurchaseOrders",
                type: "TIMESTAMP(7)",
                nullable: false,
                defaultValueSql: "SYS_EXTRACT_UTC(SYSTIMESTAMP)",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)",
                oldDefaultValueSql: "GETUTCDATE()");

            migrationBuilder.AlterColumn<decimal>(
                name: "Subtotal",
                table: "PurchaseOrderDetails",
                type: "decimal(12,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(14,0)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "PurchaseOrderDetails",
                type: "NUMBER(1)",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "BOOLEAN",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "PurchaseOrderDetails",
                type: "TIMESTAMP(7)",
                nullable: false,
                defaultValueSql: "SYS_EXTRACT_UTC(SYSTIMESTAMP)",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)",
                oldDefaultValueSql: "GETUTCDATE()");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "ProductSkus",
                type: "NUMBER(1)",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "BOOLEAN",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "ProductSkus",
                type: "NUMBER(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "BOOLEAN");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ProductSkus",
                type: "TIMESTAMP(7)",
                nullable: false,
                defaultValueSql: "SYS_EXTRACT_UTC(SYSTIMESTAMP)",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)",
                oldDefaultValueSql: "GETUTCDATE()");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Products",
                type: "NUMBER(1)",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "BOOLEAN",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Products",
                type: "NUMBER(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "BOOLEAN");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Products",
                type: "TIMESTAMP(7)",
                nullable: false,
                defaultValueSql: "SYS_EXTRACT_UTC(SYSTIMESTAMP)",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)",
                oldDefaultValueSql: "GETUTCDATE()");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalAmount",
                table: "Orders",
                type: "decimal(12,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(14,0)");

            migrationBuilder.AlterColumn<decimal>(
                name: "SubTotal",
                table: "Orders",
                type: "decimal(12,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(14,0)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Orders",
                type: "NUMBER(1)",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "BOOLEAN",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<decimal>(
                name: "DiscountAmount",
                table: "Orders",
                type: "decimal(12,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(14,0)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Orders",
                type: "TIMESTAMP(7)",
                nullable: false,
                defaultValueSql: "SYS_EXTRACT_UTC(SYSTIMESTAMP)",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)",
                oldDefaultValueSql: "GETUTCDATE()");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Orders",
                type: "NVARCHAR2(2000)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "Orders",
                type: "NVARCHAR2(2000)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Orders",
                type: "NVARCHAR2(2000)",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Subtotal",
                table: "OrderDetails",
                type: "decimal(12,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(14,0)");

            migrationBuilder.AlterColumn<int>(
                name: "ProductSkuId",
                table: "OrderDetails",
                type: "NUMBER(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "OrderDetails",
                type: "NUMBER(1)",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "BOOLEAN",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<decimal>(
                name: "DiscountPercent",
                table: "OrderDetails",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "OrderDetails",
                type: "TIMESTAMP(7)",
                nullable: false,
                defaultValueSql: "SYS_EXTRACT_UTC(SYSTIMESTAMP)",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)",
                oldDefaultValueSql: "GETUTCDATE()");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "LoyaltyTransactions",
                type: "NUMBER(1)",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "BOOLEAN",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "LoyaltyTransactions",
                type: "NVARCHAR2(2000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "LoyaltyTransactions",
                type: "TIMESTAMP(7)",
                nullable: false,
                defaultValueSql: "SYS_EXTRACT_UTC(SYSTIMESTAMP)",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)",
                oldDefaultValueSql: "GETUTCDATE()");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Inventories",
                type: "NUMBER(1)",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "BOOLEAN",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Inventories",
                type: "TIMESTAMP(7)",
                nullable: false,
                defaultValueSql: "SYS_EXTRACT_UTC(SYSTIMESTAMP)",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)",
                oldDefaultValueSql: "GETUTCDATE()");

            migrationBuilder.AlterColumn<string>(
                name: "Position",
                table: "Employees",
                type: "NVARCHAR2(2000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Employees",
                type: "NUMBER(1)",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "BOOLEAN",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Employees",
                type: "NUMBER(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "BOOLEAN");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Employees",
                type: "TIMESTAMP(7)",
                nullable: false,
                defaultValueSql: "SYS_EXTRACT_UTC(SYSTIMESTAMP)",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)",
                oldDefaultValueSql: "GETUTCDATE()");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Customers",
                type: "NUMBER(1)",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "BOOLEAN",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Customers",
                type: "TIMESTAMP(7)",
                nullable: false,
                defaultValueSql: "SYS_EXTRACT_UTC(SYSTIMESTAMP)",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)",
                oldDefaultValueSql: "GETUTCDATE()");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Categories",
                type: "NUMBER(1)",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "BOOLEAN",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Categories",
                type: "TIMESTAMP(7)",
                nullable: false,
                defaultValueSql: "SYS_EXTRACT_UTC(SYSTIMESTAMP)",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)",
                oldDefaultValueSql: "GETUTCDATE()");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    UserName = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    RoleId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ClaimValue = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    UserId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ClaimValue = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    UserId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    RoleId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    Value = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_StoreId",
                table: "Inventories",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "\"NormalizedName\" IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "\"NormalizedUserName\" IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_ProductSkus_ProductSkuId",
                table: "OrderDetails",
                column: "ProductSkuId",
                principalTable: "ProductSkus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrderDetails_ProductSkus_ProductSkuId",
                table: "PurchaseOrderDetails",
                column: "ProductSkuId",
                principalTable: "ProductSkus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrderDetails_PurchaseOrders_PurchaseOrderId",
                table: "PurchaseOrderDetails",
                column: "PurchaseOrderId",
                principalTable: "PurchaseOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_ProductSkus_ProductSkuId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrderDetails_ProductSkus_ProductSkuId",
                table: "PurchaseOrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrderDetails_PurchaseOrders_PurchaseOrderId",
                table: "PurchaseOrderDetails");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_StoreId",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Orders");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Suppliers",
                type: "BOOLEAN",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "NUMBER(1)",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Suppliers",
                type: "BOOLEAN",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "NUMBER(1)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Suppliers",
                type: "TIMESTAMP(7)",
                nullable: false,
                defaultValueSql: "GETUTCDATE()",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)",
                oldDefaultValueSql: "SYS_EXTRACT_UTC(SYSTIMESTAMP)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Stores",
                type: "BOOLEAN",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "NUMBER(1)",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Stores",
                type: "BOOLEAN",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "NUMBER(1)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Stores",
                type: "TIMESTAMP(7)",
                nullable: false,
                defaultValueSql: "GETUTCDATE()",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)",
                oldDefaultValueSql: "SYS_EXTRACT_UTC(SYSTIMESTAMP)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "StockAdjustments",
                type: "BOOLEAN",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "NUMBER(1)",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "StockAdjustments",
                type: "TIMESTAMP(7)",
                nullable: false,
                defaultValueSql: "GETUTCDATE()",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)",
                oldDefaultValueSql: "SYS_EXTRACT_UTC(SYSTIMESTAMP)");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalCost",
                table: "PurchaseOrders",
                type: "decimal(16,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,0)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "PurchaseOrders",
                type: "BOOLEAN",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "NUMBER(1)",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "PurchaseOrders",
                type: "TIMESTAMP(7)",
                nullable: false,
                defaultValueSql: "GETUTCDATE()",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)",
                oldDefaultValueSql: "SYS_EXTRACT_UTC(SYSTIMESTAMP)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Subtotal",
                table: "PurchaseOrderDetails",
                type: "decimal(14,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,0)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "PurchaseOrderDetails",
                type: "BOOLEAN",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "NUMBER(1)",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "PurchaseOrderDetails",
                type: "TIMESTAMP(7)",
                nullable: false,
                defaultValueSql: "GETUTCDATE()",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)",
                oldDefaultValueSql: "SYS_EXTRACT_UTC(SYSTIMESTAMP)");

            migrationBuilder.AddColumn<int>(
                name: "ProductSkuId1",
                table: "PurchaseOrderDetails",
                type: "NUMBER(10)",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "ProductSkus",
                type: "BOOLEAN",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "NUMBER(1)",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "ProductSkus",
                type: "BOOLEAN",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "NUMBER(1)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ProductSkus",
                type: "TIMESTAMP(7)",
                nullable: false,
                defaultValueSql: "GETUTCDATE()",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)",
                oldDefaultValueSql: "SYS_EXTRACT_UTC(SYSTIMESTAMP)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Products",
                type: "BOOLEAN",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "NUMBER(1)",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Products",
                type: "BOOLEAN",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "NUMBER(1)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Products",
                type: "TIMESTAMP(7)",
                nullable: false,
                defaultValueSql: "GETUTCDATE()",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)",
                oldDefaultValueSql: "SYS_EXTRACT_UTC(SYSTIMESTAMP)");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalAmount",
                table: "Orders",
                type: "decimal(14,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,0)");

            migrationBuilder.AlterColumn<decimal>(
                name: "SubTotal",
                table: "Orders",
                type: "decimal(14,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,0)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Orders",
                type: "BOOLEAN",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "NUMBER(1)",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<decimal>(
                name: "DiscountAmount",
                table: "Orders",
                type: "decimal(14,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,0)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Orders",
                type: "TIMESTAMP(7)",
                nullable: false,
                defaultValueSql: "GETUTCDATE()",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)",
                oldDefaultValueSql: "SYS_EXTRACT_UTC(SYSTIMESTAMP)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Subtotal",
                table: "OrderDetails",
                type: "decimal(14,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,0)");

            migrationBuilder.AlterColumn<int>(
                name: "ProductSkuId",
                table: "OrderDetails",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "OrderDetails",
                type: "BOOLEAN",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "NUMBER(1)",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<decimal>(
                name: "DiscountPercent",
                table: "OrderDetails",
                type: "decimal(5,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "OrderDetails",
                type: "TIMESTAMP(7)",
                nullable: false,
                defaultValueSql: "GETUTCDATE()",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)",
                oldDefaultValueSql: "SYS_EXTRACT_UTC(SYSTIMESTAMP)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "LoyaltyTransactions",
                type: "BOOLEAN",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "NUMBER(1)",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "LoyaltyTransactions",
                type: "NVARCHAR2(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "LoyaltyTransactions",
                type: "TIMESTAMP(7)",
                nullable: false,
                defaultValueSql: "GETUTCDATE()",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)",
                oldDefaultValueSql: "SYS_EXTRACT_UTC(SYSTIMESTAMP)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Inventories",
                type: "BOOLEAN",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "NUMBER(1)",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Inventories",
                type: "TIMESTAMP(7)",
                nullable: false,
                defaultValueSql: "GETUTCDATE()",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)",
                oldDefaultValueSql: "SYS_EXTRACT_UTC(SYSTIMESTAMP)");

            migrationBuilder.AlterColumn<string>(
                name: "Position",
                table: "Employees",
                type: "NVARCHAR2(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Employees",
                type: "BOOLEAN",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "NUMBER(1)",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Employees",
                type: "BOOLEAN",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "NUMBER(1)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Employees",
                type: "TIMESTAMP(7)",
                nullable: false,
                defaultValueSql: "GETUTCDATE()",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)",
                oldDefaultValueSql: "SYS_EXTRACT_UTC(SYSTIMESTAMP)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Customers",
                type: "BOOLEAN",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "NUMBER(1)",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Customers",
                type: "TIMESTAMP(7)",
                nullable: false,
                defaultValueSql: "GETUTCDATE()",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)",
                oldDefaultValueSql: "SYS_EXTRACT_UTC(SYSTIMESTAMP)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Categories",
                type: "BOOLEAN",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "NUMBER(1)",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Categories",
                type: "TIMESTAMP(7)",
                nullable: false,
                defaultValueSql: "GETUTCDATE()",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)",
                oldDefaultValueSql: "SYS_EXTRACT_UTC(SYSTIMESTAMP)");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderDetails_ProductSkuId1",
                table: "PurchaseOrderDetails",
                column: "ProductSkuId1");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_StoreId_ProductSkuId",
                table: "Inventories",
                columns: new[] { "StoreId", "ProductSkuId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_ProductSkus_ProductSkuId",
                table: "OrderDetails",
                column: "ProductSkuId",
                principalTable: "ProductSkus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrderDetails_ProductSkus_ProductSkuId",
                table: "PurchaseOrderDetails",
                column: "ProductSkuId",
                principalTable: "ProductSkus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrderDetails_ProductSkus_ProductSkuId1",
                table: "PurchaseOrderDetails",
                column: "ProductSkuId1",
                principalTable: "ProductSkus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrderDetails_PurchaseOrders_PurchaseOrderId",
                table: "PurchaseOrderDetails",
                column: "PurchaseOrderId",
                principalTable: "PurchaseOrders",
                principalColumn: "Id");
        }
    }
}
