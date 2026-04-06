using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FashionStoreIS.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddProductSkuIdNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ASPNETUSERS_USERID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_IMG_PROD",
                table: "ProductImages");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "ProductVariants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vouchers",
                table: "Vouchers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductImages",
                table: "ProductImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Banners",
                table: "Banners");

            migrationBuilder.DropSequence(
                name: "HiLoSequence");

            migrationBuilder.RenameTable(
                name: "Vouchers",
                newName: "VOUCHERS");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "PRODUCTS");

            migrationBuilder.RenameTable(
                name: "ProductImages",
                newName: "PRODUCTIMAGES");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "ORDERS");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "CATEGORIES");

            migrationBuilder.RenameTable(
                name: "Banners",
                newName: "BANNERS");

            migrationBuilder.RenameColumn(
                name: "MinOrderAmount",
                table: "VOUCHERS",
                newName: "MINORDERAMOUNT");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "VOUCHERS",
                newName: "ISACTIVE");

            migrationBuilder.RenameColumn(
                name: "ExpiryDate",
                table: "VOUCHERS",
                newName: "EXPIRYDATE");

            migrationBuilder.RenameColumn(
                name: "DiscountAmount",
                table: "VOUCHERS",
                newName: "DISCOUNTAMOUNT");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "VOUCHERS",
                newName: "CREATEDAT");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "VOUCHERS",
                newName: "CODE");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "VOUCHERS",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Stock",
                table: "PRODUCTS",
                newName: "STOCK");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "PRODUCTS",
                newName: "PRICE");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "PRODUCTS",
                newName: "NAME");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "PRODUCTS",
                newName: "ISACTIVE");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "PRODUCTS",
                newName: "IMAGEURL");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "PRODUCTS",
                newName: "DESCRIPTION");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "PRODUCTS",
                newName: "CREATEDAT");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "PRODUCTS",
                newName: "CATEGORYID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PRODUCTS",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_PROD_CAT",
                table: "PRODUCTS",
                newName: "IX_PRODUCTS_CATEGORYID");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "PRODUCTIMAGES",
                newName: "PRODUCTID");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "PRODUCTIMAGES",
                newName: "IMAGEURL");

            migrationBuilder.RenameColumn(
                name: "DisplayOrder",
                table: "PRODUCTIMAGES",
                newName: "DISPLAYORDER");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PRODUCTIMAGES",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_IMG_PROD",
                table: "PRODUCTIMAGES",
                newName: "IX_PRODUCTIMAGES_PRODUCTID");

            migrationBuilder.RenameColumn(
                name: "TotalAmount",
                table: "ORDERS",
                newName: "TOTALAMOUNT");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "ORDERS",
                newName: "STATUS");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "ORDERS",
                newName: "PHONE");

            migrationBuilder.RenameColumn(
                name: "CustomerName",
                table: "ORDERS",
                newName: "CUSTOMERNAME");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "ORDERS",
                newName: "CREATEDAT");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "ORDERS",
                newName: "ADDRESS");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ORDERS",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_USERID",
                table: "ORDERS",
                newName: "IX_ORDERS_USERID");

            migrationBuilder.RenameColumn(
                name: "Slug",
                table: "CATEGORIES",
                newName: "SLUG");

            migrationBuilder.RenameColumn(
                name: "ParentCategoryId",
                table: "CATEGORIES",
                newName: "PARENTCATEGORYID");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "CATEGORIES",
                newName: "NAME");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "CATEGORIES",
                newName: "ISACTIVE");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "CATEGORIES",
                newName: "IMAGEURL");

            migrationBuilder.RenameColumn(
                name: "DisplayOrder",
                table: "CATEGORIES",
                newName: "DISPLAYORDER");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "CATEGORIES",
                newName: "DESCRIPTION");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CATEGORIES",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_CAT_PARENT",
                table: "CATEGORIES",
                newName: "IX_CATEGORIES_PARENTCATEGORYID");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "BANNERS",
                newName: "TITLE");

            migrationBuilder.RenameColumn(
                name: "SubTitle",
                table: "BANNERS",
                newName: "SUBTITLE");

            migrationBuilder.RenameColumn(
                name: "Position",
                table: "BANNERS",
                newName: "POSITION");

            migrationBuilder.RenameColumn(
                name: "LinkUrl",
                table: "BANNERS",
                newName: "LINKURL");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "BANNERS",
                newName: "ISACTIVE");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "BANNERS",
                newName: "IMAGEURL");

            migrationBuilder.RenameColumn(
                name: "DisplayOrder",
                table: "BANNERS",
                newName: "DISPLAYORDER");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "BANNERS",
                newName: "CREATEDAT");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "BANNERS",
                newName: "ID");

            migrationBuilder.AlterColumn<decimal>(
                name: "MINORDERAMOUNT",
                table: "VOUCHERS",
                type: "NUMBER(12,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<bool>(
                name: "ISACTIVE",
                table: "VOUCHERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "NUMBER(1)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EXPIRYDATE",
                table: "VOUCHERS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)");

            migrationBuilder.AlterColumn<decimal>(
                name: "DISCOUNTAMOUNT",
                table: "VOUCHERS",
                type: "NUMBER(12,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATEDAT",
                table: "VOUCHERS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)");

            migrationBuilder.AlterColumn<string>(
                name: "CODE",
                table: "VOUCHERS",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "VOUCHERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<bool>(
                name: "ISDELETED",
                table: "VOUCHERS",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UPDATEDAT",
                table: "VOUCHERS",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "PRICE",
                table: "PRODUCTS",
                type: "NUMBER(12,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "PRODUCTS",
                type: "TEXT",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<bool>(
                name: "ISACTIVE",
                table: "PRODUCTS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "NUMBER(1)");

            migrationBuilder.AlterColumn<string>(
                name: "IMAGEURL",
                table: "PRODUCTS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DESCRIPTION",
                table: "PRODUCTS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATEDAT",
                table: "PRODUCTS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)");

            migrationBuilder.AlterColumn<int>(
                name: "CATEGORYID",
                table: "PRODUCTS",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "PRODUCTS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<bool>(
                name: "ISDELETED",
                table: "PRODUCTS",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SLUG",
                table: "PRODUCTS",
                type: "TEXT",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SUPPLIERID",
                table: "PRODUCTS",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UPDATEDAT",
                table: "PRODUCTS",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PRODUCTID",
                table: "PRODUCTIMAGES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<string>(
                name: "IMAGEURL",
                table: "PRODUCTIMAGES",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AlterColumn<int>(
                name: "DISPLAYORDER",
                table: "PRODUCTIMAGES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "PRODUCTIMAGES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CREATEDAT",
                table: "PRODUCTIMAGES",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "ISDELETED",
                table: "PRODUCTIMAGES",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UPDATEDAT",
                table: "PRODUCTIMAGES",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "USERID",
                table: "ORDERS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TOTALAMOUNT",
                table: "ORDERS",
                type: "NUMBER(14,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<byte>(
                name: "STATUS",
                table: "ORDERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AlterColumn<string>(
                name: "PHONE",
                table: "ORDERS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "CUSTOMERNAME",
                table: "ORDERS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATEDAT",
                table: "ORDERS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)");

            migrationBuilder.AlterColumn<string>(
                name: "ADDRESS",
                table: "ORDERS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "ORDERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "CUSTOMERID",
                table: "ORDERS",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DISCOUNTAMOUNT",
                table: "ORDERS",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "ISDELETED",
                table: "ORDERS",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "NOTE",
                table: "ORDERS",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ORDERCODE",
                table: "ORDERS",
                type: "TEXT",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte>(
                name: "PAYMENTMETHOD",
                table: "ORDERS",
                type: "INTEGER",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "PAYMENTSTATUS",
                table: "ORDERS",
                type: "INTEGER",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<int>(
                name: "POINTSEARNED",
                table: "ORDERS",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "STOREID",
                table: "ORDERS",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "SUBTOTAL",
                table: "ORDERS",
                type: "NUMBER(14,0)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "UPDATEDAT",
                table: "ORDERS",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VOUCHERID",
                table: "ORDERS",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SLUG",
                table: "CATEGORIES",
                type: "TEXT",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<int>(
                name: "PARENTCATEGORYID",
                table: "CATEGORIES",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "CATEGORIES",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<bool>(
                name: "ISACTIVE",
                table: "CATEGORIES",
                type: "INTEGER",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "NUMBER(1)");

            migrationBuilder.AlterColumn<string>(
                name: "IMAGEURL",
                table: "CATEGORIES",
                type: "TEXT",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DISPLAYORDER",
                table: "CATEGORIES",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<string>(
                name: "DESCRIPTION",
                table: "CATEGORIES",
                type: "TEXT",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "CATEGORIES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CREATEDAT",
                table: "CATEGORIES",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "ISDELETED",
                table: "CATEGORIES",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UPDATEDAT",
                table: "CATEGORIES",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TITLE",
                table: "BANNERS",
                type: "TEXT",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "SUBTITLE",
                table: "BANNERS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "POSITION",
                table: "BANNERS",
                type: "TEXT",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LINKURL",
                table: "BANNERS",
                type: "TEXT",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "ISACTIVE",
                table: "BANNERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "NUMBER(1)");

            migrationBuilder.AlterColumn<string>(
                name: "IMAGEURL",
                table: "BANNERS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DISPLAYORDER",
                table: "BANNERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATEDAT",
                table: "BANNERS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "BANNERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<bool>(
                name: "ISDELETED",
                table: "BANNERS",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UPDATEDAT",
                table: "BANNERS",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "VALUE",
                table: "ASPNETUSERTOKENS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "ASPNETUSERTOKENS",
                type: "TEXT",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LOGINPROVIDER",
                table: "ASPNETUSERTOKENS",
                type: "TEXT",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "USERID",
                table: "ASPNETUSERTOKENS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2(450)");

            migrationBuilder.AlterColumn<string>(
                name: "USERNAME",
                table: "ASPNETUSERS",
                type: "TEXT",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "TWOFACTORENABLED",
                table: "ASPNETUSERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "NUMBER(1)");

            migrationBuilder.AlterColumn<string>(
                name: "SECURITYSTAMP",
                table: "ASPNETUSERS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "PHONENUMBERCONFIRMED",
                table: "ASPNETUSERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "NUMBER(1)");

            migrationBuilder.AlterColumn<string>(
                name: "PHONENUMBER",
                table: "ASPNETUSERS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PASSWORDHASH",
                table: "ASPNETUSERS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NORMALIZEDUSERNAME",
                table: "ASPNETUSERS",
                type: "TEXT",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NORMALIZEDEMAIL",
                table: "ASPNETUSERS",
                type: "TEXT",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LOCKOUTEND",
                table: "ASPNETUSERS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "TIMESTAMP(7) WITH TIME ZONE",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "LOCKOUTENABLED",
                table: "ASPNETUSERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "NUMBER(1)");

            migrationBuilder.AlterColumn<bool>(
                name: "EMAILCONFIRMED",
                table: "ASPNETUSERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "NUMBER(1)");

            migrationBuilder.AlterColumn<string>(
                name: "EMAIL",
                table: "ASPNETUSERS",
                type: "TEXT",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CONCURRENCYSTAMP",
                table: "ASPNETUSERS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ACCESSFAILEDCOUNT",
                table: "ASPNETUSERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<string>(
                name: "ID",
                table: "ASPNETUSERS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2(450)");

            migrationBuilder.AddColumn<string>(
                name: "AVATARURL",
                table: "ASPNETUSERS",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DATEOFBIRTH",
                table: "ASPNETUSERS",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FULLNAME",
                table: "ASPNETUSERS",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GENDER",
                table: "ASPNETUSERS",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "JOINDATE",
                table: "ASPNETUSERS",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "MEMBERSHIPPOINTS",
                table: "ASPNETUSERS",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "ROLEID",
                table: "ASPNETUSERROLES",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2(450)");

            migrationBuilder.AlterColumn<string>(
                name: "USERID",
                table: "ASPNETUSERROLES",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2(450)");

            migrationBuilder.AlterColumn<string>(
                name: "USERID",
                table: "ASPNETUSERLOGINS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2(450)");

            migrationBuilder.AlterColumn<string>(
                name: "PROVIDERDISPLAYNAME",
                table: "ASPNETUSERLOGINS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PROVIDERKEY",
                table: "ASPNETUSERLOGINS",
                type: "TEXT",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LOGINPROVIDER",
                table: "ASPNETUSERLOGINS",
                type: "TEXT",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "USERID",
                table: "ASPNETUSERCLAIMS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2(450)");

            migrationBuilder.AlterColumn<string>(
                name: "CLAIMVALUE",
                table: "ASPNETUSERCLAIMS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CLAIMTYPE",
                table: "ASPNETUSERCLAIMS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "ASPNETUSERCLAIMS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<string>(
                name: "NORMALIZEDNAME",
                table: "ASPNETROLES",
                type: "TEXT",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "ASPNETROLES",
                type: "TEXT",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CONCURRENCYSTAMP",
                table: "ASPNETROLES",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ID",
                table: "ASPNETROLES",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ROLEID",
                table: "ASPNETROLECLAIMS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2(450)");

            migrationBuilder.AlterColumn<string>(
                name: "CLAIMVALUE",
                table: "ASPNETROLECLAIMS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CLAIMTYPE",
                table: "ASPNETROLECLAIMS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "ASPNETROLECLAIMS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_VOUCHERS",
                table: "VOUCHERS",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PRODUCTS",
                table: "PRODUCTS",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PRODUCTIMAGES",
                table: "PRODUCTIMAGES",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ORDERS",
                table: "ORDERS",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CATEGORIES",
                table: "CATEGORIES",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BANNERS",
                table: "BANNERS",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "CUSTOMERS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FULLNAME = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    PHONE = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    EMAIL = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    ADDRESS = table.Column<string>(type: "TEXT", nullable: true),
                    DATEOFBIRTH = table.Column<DateTime>(type: "TEXT", nullable: true),
                    TIER = table.Column<int>(type: "INTEGER", nullable: false),
                    LOYALTYPOINTS = table.Column<int>(type: "INTEGER", nullable: false),
                    USERID = table.Column<string>(type: "TEXT", nullable: true),
                    JOINDATE = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CREATEDAT = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UPDATEDAT = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ISDELETED = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMERS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CUST_USER",
                        column: x => x.USERID,
                        principalTable: "ASPNETUSERS",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PRODUCTSKUS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SKU = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    SKUCODE = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    SIZE = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    COLOR = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    COSTPRICE = table.Column<decimal>(type: "NUMBER(12,2)", nullable: false),
                    SELLINGPRICE = table.Column<decimal>(type: "NUMBER(12,2)", nullable: false),
                    PRICEOVERRIDE = table.Column<decimal>(type: "NUMBER(12,2)", nullable: true),
                    STOCK = table.Column<int>(type: "INTEGER", nullable: false, defaultValue: 0),
                    ISACTIVE = table.Column<bool>(type: "INTEGER", nullable: false),
                    PRODUCTID = table.Column<int>(type: "INTEGER", nullable: false),
                    CREATEDAT = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UPDATEDAT = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ISDELETED = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCTSKUS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SKU_PROD",
                        column: x => x.PRODUCTID,
                        principalTable: "PRODUCTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "STORES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NAME = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ADDRESS = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    PHONE = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    MANAGERNAME = table.Column<string>(type: "TEXT", nullable: false),
                    ISACTIVE = table.Column<bool>(type: "INTEGER", nullable: false),
                    CREATEDAT = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UPDATEDAT = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ISDELETED = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STORES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SUPPLIERS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NAME = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    CONTACTPERSON = table.Column<string>(type: "TEXT", nullable: true),
                    PHONE = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    EMAIL = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    ADDRESS = table.Column<string>(type: "TEXT", nullable: true),
                    LEADTIMEDAYS = table.Column<int>(type: "INTEGER", nullable: false),
                    ISACTIVE = table.Column<bool>(type: "INTEGER", nullable: false),
                    CREATEDAT = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UPDATEDAT = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ISDELETED = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUPPLIERS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LOYALTYTRANSACTIONS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    POINTS = table.Column<int>(type: "INTEGER", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "TEXT", nullable: false),
                    ORDERID = table.Column<int>(type: "INTEGER", nullable: true),
                    CUSTOMERID = table.Column<int>(type: "INTEGER", nullable: false),
                    CREATEDAT = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UPDATEDAT = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ISDELETED = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOYALTYTRANSACTIONS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LOYALTYTRANSACTIONS_ORDERS_ORDERID",
                        column: x => x.ORDERID,
                        principalTable: "ORDERS",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_LT_CUST",
                        column: x => x.CUSTOMERID,
                        principalTable: "CUSTOMERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ORDERDETAILS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    QUANTITY = table.Column<int>(type: "INTEGER", nullable: false),
                    UNITPRICE = table.Column<decimal>(type: "NUMBER(12,0)", nullable: false),
                    DISCOUNTPERCENT = table.Column<decimal>(type: "TEXT", nullable: false),
                    SUBTOTAL = table.Column<decimal>(type: "NUMBER(14,0)", nullable: false),
                    ORDERID = table.Column<int>(type: "INTEGER", nullable: false),
                    PRODUCTSKUID = table.Column<int>(type: "INTEGER", nullable: true),
                    PRODUCTID = table.Column<int>(type: "INTEGER", nullable: true),
                    CREATEDAT = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UPDATEDAT = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ISDELETED = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDERDETAILS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OD_ORD",
                        column: x => x.ORDERID,
                        principalTable: "ORDERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OD_PROD",
                        column: x => x.PRODUCTID,
                        principalTable: "PRODUCTS",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_OD_SKU",
                        column: x => x.PRODUCTSKUID,
                        principalTable: "PRODUCTSKUS",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "EMPLOYEES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FULLNAME = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    PHONE = table.Column<string>(type: "TEXT", nullable: false),
                    EMAIL = table.Column<string>(type: "TEXT", nullable: false),
                    POSITION = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    HIREDATE = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ISACTIVE = table.Column<bool>(type: "INTEGER", nullable: false),
                    USERID = table.Column<string>(type: "TEXT", nullable: true),
                    STOREID = table.Column<int>(type: "INTEGER", nullable: false),
                    CREATEDAT = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UPDATEDAT = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ISDELETED = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPLOYEES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EMP_STORE",
                        column: x => x.STOREID,
                        principalTable: "STORES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "INVENTORIES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    QUANTITYONHAND = table.Column<int>(type: "INTEGER", nullable: false),
                    REORDERPOINT = table.Column<int>(type: "INTEGER", nullable: false),
                    MAXSTOCKLEVEL = table.Column<int>(type: "INTEGER", nullable: true),
                    LASTUPDATED = table.Column<DateTime>(type: "TEXT", nullable: false),
                    STOREID = table.Column<int>(type: "INTEGER", nullable: false),
                    PRODUCTSKUID = table.Column<int>(type: "INTEGER", nullable: false),
                    CREATEDAT = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UPDATEDAT = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ISDELETED = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INVENTORIES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_INV_SKU",
                        column: x => x.PRODUCTSKUID,
                        principalTable: "PRODUCTSKUS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_INV_STORE",
                        column: x => x.STOREID,
                        principalTable: "STORES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PURCHASEORDERS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    POCODE = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    ORDERDATE = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EXPECTEDDATE = table.Column<DateTime>(type: "TEXT", nullable: true),
                    RECEIVEDDATE = table.Column<DateTime>(type: "TEXT", nullable: true),
                    STATUS = table.Column<byte>(type: "INTEGER", nullable: false),
                    TOTALCOST = table.Column<decimal>(type: "NUMBER(16,0)", nullable: false),
                    NOTE = table.Column<string>(type: "TEXT", nullable: true),
                    SUPPLIERID = table.Column<int>(type: "INTEGER", nullable: false),
                    STOREID = table.Column<int>(type: "INTEGER", nullable: false),
                    CREATEDAT = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UPDATEDAT = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ISDELETED = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PURCHASEORDERS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PO_STORE",
                        column: x => x.STOREID,
                        principalTable: "STORES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PO_SUP",
                        column: x => x.SUPPLIERID,
                        principalTable: "SUPPLIERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "STOCKADJUSTMENTS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    QUANTITYBEFORE = table.Column<int>(type: "INTEGER", nullable: false),
                    QUANTITYCHANGE = table.Column<int>(type: "INTEGER", nullable: false),
                    QUANTITYAFTER = table.Column<int>(type: "INTEGER", nullable: false),
                    REASON = table.Column<byte>(type: "INTEGER", nullable: false),
                    NOTE = table.Column<string>(type: "TEXT", nullable: true),
                    ADJUSTEDBYUSERID = table.Column<string>(type: "TEXT", nullable: true),
                    INVENTORYID = table.Column<int>(type: "INTEGER", nullable: false),
                    CREATEDAT = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UPDATEDAT = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ISDELETED = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STOCKADJUSTMENTS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SA_INV",
                        column: x => x.INVENTORYID,
                        principalTable: "INVENTORIES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PURCHASEORDERDETAILS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    QUANTITYORDERED = table.Column<int>(type: "INTEGER", nullable: false),
                    QUANTITYRECEIVED = table.Column<int>(type: "INTEGER", nullable: false),
                    UNITCOST = table.Column<decimal>(type: "NUMBER(12,0)", nullable: false),
                    SUBTOTAL = table.Column<decimal>(type: "NUMBER(14,0)", nullable: false),
                    PURCHASEORDERID = table.Column<int>(type: "INTEGER", nullable: false),
                    PRODUCTSKUID = table.Column<int>(type: "INTEGER", nullable: false),
                    CREATEDAT = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UPDATEDAT = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ISDELETED = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PURCHASEORDERDETAILS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_POD_PO",
                        column: x => x.PURCHASEORDERID,
                        principalTable: "PURCHASEORDERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_POD_SKU",
                        column: x => x.PRODUCTSKUID,
                        principalTable: "PRODUCTSKUS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VOUCHERS_CODE",
                table: "VOUCHERS",
                column: "CODE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTS_SUPPLIERID",
                table: "PRODUCTS",
                column: "SUPPLIERID");

            migrationBuilder.CreateIndex(
                name: "IX_ORDERS_CUSTOMERID",
                table: "ORDERS",
                column: "CUSTOMERID");

            migrationBuilder.CreateIndex(
                name: "IX_ORDERS_ORDERCODE",
                table: "ORDERS",
                column: "ORDERCODE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ORDERS_STOREID",
                table: "ORDERS",
                column: "STOREID");

            migrationBuilder.CreateIndex(
                name: "IX_ORDERS_VOUCHERID",
                table: "ORDERS",
                column: "VOUCHERID");

            migrationBuilder.CreateIndex(
                name: "IX_CUSTOMERS_USERID",
                table: "CUSTOMERS",
                column: "USERID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEES_STOREID",
                table: "EMPLOYEES",
                column: "STOREID");

            migrationBuilder.CreateIndex(
                name: "IX_INVENTORIES_PRODUCTSKUID",
                table: "INVENTORIES",
                column: "PRODUCTSKUID");

            migrationBuilder.CreateIndex(
                name: "IX_INVENTORIES_STOREID",
                table: "INVENTORIES",
                column: "STOREID");

            migrationBuilder.CreateIndex(
                name: "IX_LOYALTYTRANSACTIONS_CUSTOMERID",
                table: "LOYALTYTRANSACTIONS",
                column: "CUSTOMERID");

            migrationBuilder.CreateIndex(
                name: "IX_LOYALTYTRANSACTIONS_ORDERID",
                table: "LOYALTYTRANSACTIONS",
                column: "ORDERID");

            migrationBuilder.CreateIndex(
                name: "IX_ORDERDETAILS_ORDERID",
                table: "ORDERDETAILS",
                column: "ORDERID");

            migrationBuilder.CreateIndex(
                name: "IX_ORDERDETAILS_PRODUCTID",
                table: "ORDERDETAILS",
                column: "PRODUCTID");

            migrationBuilder.CreateIndex(
                name: "IX_ORDERDETAILS_PRODUCTSKUID",
                table: "ORDERDETAILS",
                column: "PRODUCTSKUID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTSKUS_PRODUCTID",
                table: "PRODUCTSKUS",
                column: "PRODUCTID");

            migrationBuilder.CreateIndex(
                name: "IX_PURCHASEORDERDETAILS_PRODUCTSKUID",
                table: "PURCHASEORDERDETAILS",
                column: "PRODUCTSKUID");

            migrationBuilder.CreateIndex(
                name: "IX_PURCHASEORDERDETAILS_PURCHASEORDERID",
                table: "PURCHASEORDERDETAILS",
                column: "PURCHASEORDERID");

            migrationBuilder.CreateIndex(
                name: "IX_PURCHASEORDERS_STOREID",
                table: "PURCHASEORDERS",
                column: "STOREID");

            migrationBuilder.CreateIndex(
                name: "IX_PURCHASEORDERS_SUPPLIERID",
                table: "PURCHASEORDERS",
                column: "SUPPLIERID");

            migrationBuilder.CreateIndex(
                name: "IX_STOCKADJUSTMENTS_INVENTORYID",
                table: "STOCKADJUSTMENTS",
                column: "INVENTORYID");

            migrationBuilder.AddForeignKey(
                name: "FK_ORDERS_VOUCHERS_VOUCHERID",
                table: "ORDERS",
                column: "VOUCHERID",
                principalTable: "VOUCHERS",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ORD_CUST",
                table: "ORDERS",
                column: "CUSTOMERID",
                principalTable: "CUSTOMERS",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ORD_STORE",
                table: "ORDERS",
                column: "STOREID",
                principalTable: "STORES",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ORD_USER",
                table: "ORDERS",
                column: "USERID",
                principalTable: "ASPNETUSERS",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUCTIMAGES_PRODUCTS_PRODUCTID",
                table: "PRODUCTIMAGES",
                column: "PRODUCTID",
                principalTable: "PRODUCTS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PROD_SUP",
                table: "PRODUCTS",
                column: "SUPPLIERID",
                principalTable: "SUPPLIERS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ORDERS_VOUCHERS_VOUCHERID",
                table: "ORDERS");

            migrationBuilder.DropForeignKey(
                name: "FK_ORD_CUST",
                table: "ORDERS");

            migrationBuilder.DropForeignKey(
                name: "FK_ORD_STORE",
                table: "ORDERS");

            migrationBuilder.DropForeignKey(
                name: "FK_ORD_USER",
                table: "ORDERS");

            migrationBuilder.DropForeignKey(
                name: "FK_PRODUCTIMAGES_PRODUCTS_PRODUCTID",
                table: "PRODUCTIMAGES");

            migrationBuilder.DropForeignKey(
                name: "FK_PROD_SUP",
                table: "PRODUCTS");

            migrationBuilder.DropTable(
                name: "EMPLOYEES");

            migrationBuilder.DropTable(
                name: "LOYALTYTRANSACTIONS");

            migrationBuilder.DropTable(
                name: "ORDERDETAILS");

            migrationBuilder.DropTable(
                name: "PURCHASEORDERDETAILS");

            migrationBuilder.DropTable(
                name: "STOCKADJUSTMENTS");

            migrationBuilder.DropTable(
                name: "CUSTOMERS");

            migrationBuilder.DropTable(
                name: "PURCHASEORDERS");

            migrationBuilder.DropTable(
                name: "INVENTORIES");

            migrationBuilder.DropTable(
                name: "SUPPLIERS");

            migrationBuilder.DropTable(
                name: "PRODUCTSKUS");

            migrationBuilder.DropTable(
                name: "STORES");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VOUCHERS",
                table: "VOUCHERS");

            migrationBuilder.DropIndex(
                name: "IX_VOUCHERS_CODE",
                table: "VOUCHERS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PRODUCTS",
                table: "PRODUCTS");

            migrationBuilder.DropIndex(
                name: "IX_PRODUCTS_SUPPLIERID",
                table: "PRODUCTS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PRODUCTIMAGES",
                table: "PRODUCTIMAGES");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ORDERS",
                table: "ORDERS");

            migrationBuilder.DropIndex(
                name: "IX_ORDERS_CUSTOMERID",
                table: "ORDERS");

            migrationBuilder.DropIndex(
                name: "IX_ORDERS_ORDERCODE",
                table: "ORDERS");

            migrationBuilder.DropIndex(
                name: "IX_ORDERS_STOREID",
                table: "ORDERS");

            migrationBuilder.DropIndex(
                name: "IX_ORDERS_VOUCHERID",
                table: "ORDERS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CATEGORIES",
                table: "CATEGORIES");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BANNERS",
                table: "BANNERS");

            migrationBuilder.DropColumn(
                name: "ISDELETED",
                table: "VOUCHERS");

            migrationBuilder.DropColumn(
                name: "UPDATEDAT",
                table: "VOUCHERS");

            migrationBuilder.DropColumn(
                name: "ISDELETED",
                table: "PRODUCTS");

            migrationBuilder.DropColumn(
                name: "SLUG",
                table: "PRODUCTS");

            migrationBuilder.DropColumn(
                name: "SUPPLIERID",
                table: "PRODUCTS");

            migrationBuilder.DropColumn(
                name: "UPDATEDAT",
                table: "PRODUCTS");

            migrationBuilder.DropColumn(
                name: "CREATEDAT",
                table: "PRODUCTIMAGES");

            migrationBuilder.DropColumn(
                name: "ISDELETED",
                table: "PRODUCTIMAGES");

            migrationBuilder.DropColumn(
                name: "UPDATEDAT",
                table: "PRODUCTIMAGES");

            migrationBuilder.DropColumn(
                name: "CUSTOMERID",
                table: "ORDERS");

            migrationBuilder.DropColumn(
                name: "DISCOUNTAMOUNT",
                table: "ORDERS");

            migrationBuilder.DropColumn(
                name: "ISDELETED",
                table: "ORDERS");

            migrationBuilder.DropColumn(
                name: "NOTE",
                table: "ORDERS");

            migrationBuilder.DropColumn(
                name: "ORDERCODE",
                table: "ORDERS");

            migrationBuilder.DropColumn(
                name: "PAYMENTMETHOD",
                table: "ORDERS");

            migrationBuilder.DropColumn(
                name: "PAYMENTSTATUS",
                table: "ORDERS");

            migrationBuilder.DropColumn(
                name: "POINTSEARNED",
                table: "ORDERS");

            migrationBuilder.DropColumn(
                name: "STOREID",
                table: "ORDERS");

            migrationBuilder.DropColumn(
                name: "SUBTOTAL",
                table: "ORDERS");

            migrationBuilder.DropColumn(
                name: "UPDATEDAT",
                table: "ORDERS");

            migrationBuilder.DropColumn(
                name: "VOUCHERID",
                table: "ORDERS");

            migrationBuilder.DropColumn(
                name: "CREATEDAT",
                table: "CATEGORIES");

            migrationBuilder.DropColumn(
                name: "ISDELETED",
                table: "CATEGORIES");

            migrationBuilder.DropColumn(
                name: "UPDATEDAT",
                table: "CATEGORIES");

            migrationBuilder.DropColumn(
                name: "ISDELETED",
                table: "BANNERS");

            migrationBuilder.DropColumn(
                name: "UPDATEDAT",
                table: "BANNERS");

            migrationBuilder.DropColumn(
                name: "AVATARURL",
                table: "ASPNETUSERS");

            migrationBuilder.DropColumn(
                name: "DATEOFBIRTH",
                table: "ASPNETUSERS");

            migrationBuilder.DropColumn(
                name: "FULLNAME",
                table: "ASPNETUSERS");

            migrationBuilder.DropColumn(
                name: "GENDER",
                table: "ASPNETUSERS");

            migrationBuilder.DropColumn(
                name: "JOINDATE",
                table: "ASPNETUSERS");

            migrationBuilder.DropColumn(
                name: "MEMBERSHIPPOINTS",
                table: "ASPNETUSERS");

            migrationBuilder.RenameTable(
                name: "VOUCHERS",
                newName: "Vouchers");

            migrationBuilder.RenameTable(
                name: "PRODUCTS",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "PRODUCTIMAGES",
                newName: "ProductImages");

            migrationBuilder.RenameTable(
                name: "ORDERS",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "CATEGORIES",
                newName: "Categories");

            migrationBuilder.RenameTable(
                name: "BANNERS",
                newName: "Banners");

            migrationBuilder.RenameColumn(
                name: "MINORDERAMOUNT",
                table: "Vouchers",
                newName: "MinOrderAmount");

            migrationBuilder.RenameColumn(
                name: "ISACTIVE",
                table: "Vouchers",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "EXPIRYDATE",
                table: "Vouchers",
                newName: "ExpiryDate");

            migrationBuilder.RenameColumn(
                name: "DISCOUNTAMOUNT",
                table: "Vouchers",
                newName: "DiscountAmount");

            migrationBuilder.RenameColumn(
                name: "CREATEDAT",
                table: "Vouchers",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "CODE",
                table: "Vouchers",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Vouchers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "STOCK",
                table: "Products",
                newName: "Stock");

            migrationBuilder.RenameColumn(
                name: "PRICE",
                table: "Products",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "NAME",
                table: "Products",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ISACTIVE",
                table: "Products",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "IMAGEURL",
                table: "Products",
                newName: "ImageUrl");

            migrationBuilder.RenameColumn(
                name: "DESCRIPTION",
                table: "Products",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "CREATEDAT",
                table: "Products",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "CATEGORYID",
                table: "Products",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Products",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_PRODUCTS_CATEGORYID",
                table: "Products",
                newName: "IX_PROD_CAT");

            migrationBuilder.RenameColumn(
                name: "PRODUCTID",
                table: "ProductImages",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "IMAGEURL",
                table: "ProductImages",
                newName: "ImageUrl");

            migrationBuilder.RenameColumn(
                name: "DISPLAYORDER",
                table: "ProductImages",
                newName: "DisplayOrder");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "ProductImages",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_PRODUCTIMAGES_PRODUCTID",
                table: "ProductImages",
                newName: "IX_IMG_PROD");

            migrationBuilder.RenameColumn(
                name: "TOTALAMOUNT",
                table: "Orders",
                newName: "TotalAmount");

            migrationBuilder.RenameColumn(
                name: "STATUS",
                table: "Orders",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "PHONE",
                table: "Orders",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "CUSTOMERNAME",
                table: "Orders",
                newName: "CustomerName");

            migrationBuilder.RenameColumn(
                name: "CREATEDAT",
                table: "Orders",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "ADDRESS",
                table: "Orders",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Orders",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_ORDERS_USERID",
                table: "Orders",
                newName: "IX_Orders_USERID");

            migrationBuilder.RenameColumn(
                name: "SLUG",
                table: "Categories",
                newName: "Slug");

            migrationBuilder.RenameColumn(
                name: "PARENTCATEGORYID",
                table: "Categories",
                newName: "ParentCategoryId");

            migrationBuilder.RenameColumn(
                name: "NAME",
                table: "Categories",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ISACTIVE",
                table: "Categories",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "IMAGEURL",
                table: "Categories",
                newName: "ImageUrl");

            migrationBuilder.RenameColumn(
                name: "DISPLAYORDER",
                table: "Categories",
                newName: "DisplayOrder");

            migrationBuilder.RenameColumn(
                name: "DESCRIPTION",
                table: "Categories",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Categories",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_CATEGORIES_PARENTCATEGORYID",
                table: "Categories",
                newName: "IX_CAT_PARENT");

            migrationBuilder.RenameColumn(
                name: "TITLE",
                table: "Banners",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "SUBTITLE",
                table: "Banners",
                newName: "SubTitle");

            migrationBuilder.RenameColumn(
                name: "POSITION",
                table: "Banners",
                newName: "Position");

            migrationBuilder.RenameColumn(
                name: "LINKURL",
                table: "Banners",
                newName: "LinkUrl");

            migrationBuilder.RenameColumn(
                name: "ISACTIVE",
                table: "Banners",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "IMAGEURL",
                table: "Banners",
                newName: "ImageUrl");

            migrationBuilder.RenameColumn(
                name: "DISPLAYORDER",
                table: "Banners",
                newName: "DisplayOrder");

            migrationBuilder.RenameColumn(
                name: "CREATEDAT",
                table: "Banners",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Banners",
                newName: "Id");

            migrationBuilder.CreateSequence(
                name: "HiLoSequence");

            migrationBuilder.AlterColumn<decimal>(
                name: "MinOrderAmount",
                table: "Vouchers",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER(12,0)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Vouchers",
                type: "NUMBER(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpiryDate",
                table: "Vouchers",
                type: "TIMESTAMP(7)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<decimal>(
                name: "DiscountAmount",
                table: "Vouchers",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER(12,0)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Vouchers",
                type: "TIMESTAMP(7)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Vouchers",
                type: "NVARCHAR2(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Vouchers",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER(12,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "NVARCHAR2(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Products",
                type: "NUMBER(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Products",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "NVARCHAR2(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Products",
                type: "TIMESTAMP(7)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Products",
                type: "NUMBER(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Products",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "ProductImages",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "ProductImages",
                type: "NVARCHAR2(2000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "DisplayOrder",
                table: "ProductImages",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ProductImages",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<string>(
                name: "USERID",
                table: "Orders",
                type: "VARCHAR2(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalAmount",
                table: "Orders",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER(14,0)");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Orders",
                type: "NVARCHAR2(2000)",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Orders",
                type: "NVARCHAR2(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CustomerName",
                table: "Orders",
                type: "NVARCHAR2(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Orders",
                type: "TIMESTAMP(7)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Orders",
                type: "NVARCHAR2(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Orders",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<string>(
                name: "Slug",
                table: "Categories",
                type: "NVARCHAR2(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ParentCategoryId",
                table: "Categories",
                type: "NUMBER(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "NVARCHAR2(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Categories",
                type: "NUMBER(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "INTEGER",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Categories",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DisplayOrder",
                table: "Categories",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Categories",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Categories",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Banners",
                type: "NVARCHAR2(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "SubTitle",
                table: "Banners",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Position",
                table: "Banners",
                type: "NVARCHAR2(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LinkUrl",
                table: "Banners",
                type: "NVARCHAR2(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Banners",
                type: "NUMBER(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Banners",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DisplayOrder",
                table: "Banners",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Banners",
                type: "TIMESTAMP(7)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Banners",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<string>(
                name: "VALUE",
                table: "ASPNETUSERTOKENS",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "ASPNETUSERTOKENS",
                type: "NVARCHAR2(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LOGINPROVIDER",
                table: "ASPNETUSERTOKENS",
                type: "NVARCHAR2(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "USERID",
                table: "ASPNETUSERTOKENS",
                type: "VARCHAR2(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "USERNAME",
                table: "ASPNETUSERS",
                type: "VARCHAR2(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "TWOFACTORENABLED",
                table: "ASPNETUSERS",
                type: "NUMBER(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "SECURITYSTAMP",
                table: "ASPNETUSERS",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "PHONENUMBERCONFIRMED",
                table: "ASPNETUSERS",
                type: "NUMBER(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "PHONENUMBER",
                table: "ASPNETUSERS",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PASSWORDHASH",
                table: "ASPNETUSERS",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NORMALIZEDUSERNAME",
                table: "ASPNETUSERS",
                type: "VARCHAR2(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NORMALIZEDEMAIL",
                table: "ASPNETUSERS",
                type: "VARCHAR2(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LOCKOUTEND",
                table: "ASPNETUSERS",
                type: "TIMESTAMP(7) WITH TIME ZONE",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "LOCKOUTENABLED",
                table: "ASPNETUSERS",
                type: "NUMBER(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<bool>(
                name: "EMAILCONFIRMED",
                table: "ASPNETUSERS",
                type: "NUMBER(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "EMAIL",
                table: "ASPNETUSERS",
                type: "VARCHAR2(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CONCURRENCYSTAMP",
                table: "ASPNETUSERS",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ACCESSFAILEDCOUNT",
                table: "ASPNETUSERS",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "ID",
                table: "ASPNETUSERS",
                type: "VARCHAR2(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "ROLEID",
                table: "ASPNETUSERROLES",
                type: "VARCHAR2(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "USERID",
                table: "ASPNETUSERROLES",
                type: "VARCHAR2(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "USERID",
                table: "ASPNETUSERLOGINS",
                type: "VARCHAR2(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "PROVIDERDISPLAYNAME",
                table: "ASPNETUSERLOGINS",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PROVIDERKEY",
                table: "ASPNETUSERLOGINS",
                type: "NVARCHAR2(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LOGINPROVIDER",
                table: "ASPNETUSERLOGINS",
                type: "NVARCHAR2(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "USERID",
                table: "ASPNETUSERCLAIMS",
                type: "VARCHAR2(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "CLAIMVALUE",
                table: "ASPNETUSERCLAIMS",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CLAIMTYPE",
                table: "ASPNETUSERCLAIMS",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "ASPNETUSERCLAIMS",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<string>(
                name: "NORMALIZEDNAME",
                table: "ASPNETROLES",
                type: "VARCHAR2(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "ASPNETROLES",
                type: "VARCHAR2(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CONCURRENCYSTAMP",
                table: "ASPNETROLES",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ID",
                table: "ASPNETROLES",
                type: "VARCHAR2(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "ROLEID",
                table: "ASPNETROLECLAIMS",
                type: "VARCHAR2(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "CLAIMVALUE",
                table: "ASPNETROLECLAIMS",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CLAIMTYPE",
                table: "ASPNETROLECLAIMS",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "ASPNETROLECLAIMS",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vouchers",
                table: "Vouchers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductImages",
                table: "ProductImages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Banners",
                table: "Banners",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ProductVariants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Color = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    PriceOverride = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: true),
                    SKU = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    Size = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Stock = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductVariants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VAR_PROD",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ProductId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ProductVariantId = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    Quantity = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ORDITEM_ORDER",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ORDITEM_PROD",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_ProductVariants_ProductVariantId",
                        column: x => x.ProductVariantId,
                        principalTable: "ProductVariants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductVariantId",
                table: "OrderItems",
                column: "ProductVariantId");

            migrationBuilder.CreateIndex(
                name: "IX_ORDITEM_ORDER",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ORDITEM_PROD",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_VAR_PROD",
                table: "ProductVariants",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_ASPNETUSERS_USERID",
                table: "Orders",
                column: "USERID",
                principalTable: "ASPNETUSERS",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_IMG_PROD",
                table: "ProductImages",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
