using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FashionStoreIS.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCampaignTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_CUSTOMERS_USERID",
                table: "CUSTOMERS");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "ASPNETUSERS");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "ASPNETROLES");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "USERADDRESSES");

            migrationBuilder.DropColumn(
                name: "OrderId1",
                table: "RETURNREQUESTS");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "NOTIFICATIONS");

            if (!migrationBuilder.IsSqlite())
            {
                migrationBuilder.DropSequence(
                    name: "HILOSEQUENCE");
            }

            migrationBuilder.AlterColumn<int>(
                name: "USEDCOUNT",
                table: "VOUCHERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATEDAT",
                table: "VOUCHERS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "MINORDERAMOUNT",
                table: "VOUCHERS",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "NUMBER(12,0)");

            migrationBuilder.AlterColumn<int>(
                name: "MAXUSAGECOUNT",
                table: "VOUCHERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<bool>(
                name: "ISDELETED",
                table: "VOUCHERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "NUMBER(1)");

            migrationBuilder.AlterColumn<bool>(
                name: "ISACTIVE",
                table: "VOUCHERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "BOOLEAN");

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
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "NUMBER(12,0)");

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

            migrationBuilder.AlterColumn<string>(
                name: "USERID",
                table: "USERADDRESSES",
                type: "TEXT",
                maxLength: 450,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2(450)",
                oldMaxLength: 450);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATEDAT",
                table: "USERADDRESSES",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PHONENUMBER",
                table: "USERADDRESSES",
                type: "TEXT",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<bool>(
                name: "ISDELETED",
                table: "USERADDRESSES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "NUMBER(1)");

            migrationBuilder.AlterColumn<bool>(
                name: "ISDEFAULT",
                table: "USERADDRESSES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "BOOLEAN");

            migrationBuilder.AlterColumn<string>(
                name: "FULLNAME",
                table: "USERADDRESSES",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATEDAT",
                table: "USERADDRESSES",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)");

            migrationBuilder.AlterColumn<string>(
                name: "ADDRESSLINE",
                table: "USERADDRESSES",
                type: "TEXT",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "USERADDRESSES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATEDAT",
                table: "SUPPLIERS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PHONE",
                table: "SUPPLIERS",
                type: "TEXT",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "SUPPLIERS",
                type: "TEXT",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<int>(
                name: "LEADTIMEDAYS",
                table: "SUPPLIERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<bool>(
                name: "ISDELETED",
                table: "SUPPLIERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "NUMBER(1)");

            migrationBuilder.AlterColumn<bool>(
                name: "ISACTIVE",
                table: "SUPPLIERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "BOOLEAN");

            migrationBuilder.AlterColumn<string>(
                name: "EMAIL",
                table: "SUPPLIERS",
                type: "TEXT",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATEDAT",
                table: "SUPPLIERS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)");

            migrationBuilder.AlterColumn<string>(
                name: "CONTACTPERSON",
                table: "SUPPLIERS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ADDRESS",
                table: "SUPPLIERS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "SUPPLIERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATEDAT",
                table: "STORES",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PHONE",
                table: "STORES",
                type: "TEXT",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "STORES",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "MANAGERNAME",
                table: "STORES",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AlterColumn<bool>(
                name: "ISDELETED",
                table: "STORES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "NUMBER(1)");

            migrationBuilder.AlterColumn<bool>(
                name: "ISACTIVE",
                table: "STORES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "BOOLEAN");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATEDAT",
                table: "STORES",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)");

            migrationBuilder.AlterColumn<string>(
                name: "ADDRESS",
                table: "STORES",
                type: "TEXT",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "STORES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATEDAT",
                table: "STOCKADJUSTMENTS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "REASON",
                table: "STOCKADJUSTMENTS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "NUMBER(3)");

            migrationBuilder.AlterColumn<int>(
                name: "QUANTITYCHANGE",
                table: "STOCKADJUSTMENTS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<int>(
                name: "QUANTITYBEFORE",
                table: "STOCKADJUSTMENTS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<int>(
                name: "QUANTITYAFTER",
                table: "STOCKADJUSTMENTS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<string>(
                name: "NOTE",
                table: "STOCKADJUSTMENTS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "ISDELETED",
                table: "STOCKADJUSTMENTS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "NUMBER(1)");

            migrationBuilder.AlterColumn<int>(
                name: "INVENTORYID",
                table: "STOCKADJUSTMENTS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATEDAT",
                table: "STOCKADJUSTMENTS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)");

            migrationBuilder.AlterColumn<string>(
                name: "ADJUSTEDBYUSERID",
                table: "STOCKADJUSTMENTS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "STOCKADJUSTMENTS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATEDAT",
                table: "RETURNREQUESTS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "STATUS",
                table: "RETURNREQUESTS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "NUMBER(3)");

            migrationBuilder.AlterColumn<decimal>(
                name: "REFUNDAMOUNT",
                table: "RETURNREQUESTS",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "NUMBER(12,0)");

            migrationBuilder.AlterColumn<string>(
                name: "REASON",
                table: "RETURNREQUESTS",
                type: "TEXT",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<int>(
                name: "ORDERID",
                table: "RETURNREQUESTS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<bool>(
                name: "ISDELETED",
                table: "RETURNREQUESTS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "NUMBER(1)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATEDAT",
                table: "RETURNREQUESTS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "RETURNREQUESTS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "ADMINNOTE",
                table: "RETURNREQUESTS",
                type: "TEXT",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PROCESSEDAT",
                table: "RETURNREQUESTS",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATEDAT",
                table: "PURCHASEORDERS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TOTALCOST",
                table: "PURCHASEORDERS",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "NUMBER(16,0)");

            migrationBuilder.AlterColumn<int>(
                name: "SUPPLIERID",
                table: "PURCHASEORDERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<int>(
                name: "STOREID",
                table: "PURCHASEORDERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<byte>(
                name: "STATUS",
                table: "PURCHASEORDERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "NUMBER(3)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RECEIVEDDATE",
                table: "PURCHASEORDERS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "POCODE",
                table: "PURCHASEORDERS",
                type: "TEXT",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ORDERDATE",
                table: "PURCHASEORDERS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)");

            migrationBuilder.AlterColumn<string>(
                name: "NOTE",
                table: "PURCHASEORDERS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "ISDELETED",
                table: "PURCHASEORDERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "NUMBER(1)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EXPECTEDDATE",
                table: "PURCHASEORDERS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATEDAT",
                table: "PURCHASEORDERS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "PURCHASEORDERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATEDAT",
                table: "PURCHASEORDERDETAILS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "UNITCOST",
                table: "PURCHASEORDERDETAILS",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "NUMBER(12,0)");

            migrationBuilder.AlterColumn<decimal>(
                name: "SUBTOTAL",
                table: "PURCHASEORDERDETAILS",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "NUMBER(14,0)");

            migrationBuilder.AlterColumn<int>(
                name: "QUANTITYRECEIVED",
                table: "PURCHASEORDERDETAILS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<int>(
                name: "QUANTITYORDERED",
                table: "PURCHASEORDERDETAILS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<int>(
                name: "PURCHASEORDERID",
                table: "PURCHASEORDERDETAILS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<int>(
                name: "PRODUCTSKUID",
                table: "PURCHASEORDERDETAILS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<bool>(
                name: "ISDELETED",
                table: "PURCHASEORDERDETAILS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "NUMBER(1)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATEDAT",
                table: "PURCHASEORDERDETAILS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "PURCHASEORDERDETAILS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATEDAT",
                table: "PRODUCTSKUS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "STOCK",
                table: "PRODUCTSKUS",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "SKUCODE",
                table: "PRODUCTSKUS",
                type: "TEXT",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "SKU",
                table: "PRODUCTSKUS",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "SIZE",
                table: "PRODUCTSKUS",
                type: "TEXT",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<int>(
                name: "PRODUCTID",
                table: "PRODUCTSKUS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<bool>(
                name: "ISDELETED",
                table: "PRODUCTSKUS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "NUMBER(1)");

            migrationBuilder.AlterColumn<bool>(
                name: "ISACTIVE",
                table: "PRODUCTSKUS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "BOOLEAN");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATEDAT",
                table: "PRODUCTSKUS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)");

            migrationBuilder.AlterColumn<string>(
                name: "COLOR",
                table: "PRODUCTSKUS",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "PRODUCTSKUS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATEDAT",
                table: "PRODUCTS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SUPPLIERID",
                table: "PRODUCTS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<string>(
                name: "SLUG",
                table: "PRODUCTS",
                type: "TEXT",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "PRODUCTS",
                type: "TEXT",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<bool>(
                name: "ISDELETED",
                table: "PRODUCTS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "NUMBER(1)");

            migrationBuilder.AlterColumn<bool>(
                name: "ISACTIVE",
                table: "PRODUCTS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "BOOLEAN");

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
                oldType: "NVARCHAR2(2000)",
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATEDAT",
                table: "PRODUCTIMAGES",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PRODUCTID",
                table: "PRODUCTIMAGES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<bool>(
                name: "ISDELETED",
                table: "PRODUCTIMAGES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "NUMBER(1)");

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

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATEDAT",
                table: "PRODUCTIMAGES",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "PRODUCTIMAGES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "VOUCHERID",
                table: "ORDERS",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "USERID",
                table: "ORDERS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATEDAT",
                table: "ORDERS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TOTALAMOUNT",
                table: "ORDERS",
                type: "NUMBER(14,0)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(long),
                oldType: "NUMBER(14,0)",
                oldDefaultValue: 0L);

            migrationBuilder.AlterColumn<decimal>(
                name: "SUBTOTAL",
                table: "ORDERS",
                type: "NUMBER(14,0)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(long),
                oldType: "NUMBER(14,0)",
                oldDefaultValue: 0L);

            migrationBuilder.AlterColumn<int>(
                name: "STOREID",
                table: "ORDERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<byte>(
                name: "STATUS",
                table: "ORDERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "NUMBER(3)");

            migrationBuilder.AlterColumn<int>(
                name: "POINTSEARNED",
                table: "ORDERS",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "PHONE",
                table: "ORDERS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "PAYMENTSTATUS",
                table: "ORDERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "NUMBER(3)");

            migrationBuilder.AlterColumn<byte>(
                name: "PAYMENTMETHOD",
                table: "ORDERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "NUMBER(3)");

            migrationBuilder.AlterColumn<string>(
                name: "ORDERCODE",
                table: "ORDERS",
                type: "TEXT",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "NOTE",
                table: "ORDERS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "ISDELETED",
                table: "ORDERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "NUMBER(1)");

            migrationBuilder.AlterColumn<decimal>(
                name: "DISCOUNTAMOUNT",
                table: "ORDERS",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "CUSTOMERNAME",
                table: "ORDERS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CUSTOMERID",
                table: "ORDERS",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)",
                oldNullable: true);

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
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "ORDERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATEDAT",
                table: "ORDERDETAILS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "QUANTITY",
                table: "ORDERDETAILS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<int>(
                name: "PRODUCTSKUID",
                table: "ORDERDETAILS",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PRODUCTID",
                table: "ORDERDETAILS",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ORDERID",
                table: "ORDERDETAILS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<bool>(
                name: "ISDELETED",
                table: "ORDERDETAILS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "NUMBER(1)");

            migrationBuilder.AlterColumn<decimal>(
                name: "DISCOUNTPERCENT",
                table: "ORDERDETAILS",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATEDAT",
                table: "ORDERDETAILS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "ORDERDETAILS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<string>(
                name: "USERID",
                table: "NOTIFICATIONS",
                type: "TEXT",
                maxLength: 450,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2(450)",
                oldMaxLength: 450);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATEDAT",
                table: "NOTIFICATIONS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TITLE",
                table: "NOTIFICATIONS",
                type: "TEXT",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "MESSAGE",
                table: "NOTIFICATIONS",
                type: "TEXT",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<bool>(
                name: "ISREAD",
                table: "NOTIFICATIONS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "BOOLEAN");

            migrationBuilder.AlterColumn<bool>(
                name: "ISDELETED",
                table: "NOTIFICATIONS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "NUMBER(1)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATEDAT",
                table: "NOTIFICATIONS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)");

            migrationBuilder.AlterColumn<string>(
                name: "ACTIONURL",
                table: "NOTIFICATIONS",
                type: "TEXT",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "NOTIFICATIONS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATEDAT",
                table: "LOYALTYTRANSACTIONS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "POINTS",
                table: "LOYALTYTRANSACTIONS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<int>(
                name: "ORDERID",
                table: "LOYALTYTRANSACTIONS",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "ISDELETED",
                table: "LOYALTYTRANSACTIONS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "NUMBER(1)");

            migrationBuilder.AlterColumn<string>(
                name: "DESCRIPTION",
                table: "LOYALTYTRANSACTIONS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AlterColumn<int>(
                name: "CUSTOMERID",
                table: "LOYALTYTRANSACTIONS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATEDAT",
                table: "LOYALTYTRANSACTIONS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "LOYALTYTRANSACTIONS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATEDAT",
                table: "INVENTORIES",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "STOREID",
                table: "INVENTORIES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<int>(
                name: "REORDERPOINT",
                table: "INVENTORIES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<int>(
                name: "QUANTITYONHAND",
                table: "INVENTORIES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<int>(
                name: "PRODUCTSKUID",
                table: "INVENTORIES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<int>(
                name: "MAXSTOCKLEVEL",
                table: "INVENTORIES",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LASTUPDATED",
                table: "INVENTORIES",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)");

            migrationBuilder.AlterColumn<bool>(
                name: "ISDELETED",
                table: "INVENTORIES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "NUMBER(1)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATEDAT",
                table: "INVENTORIES",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "INVENTORIES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<string>(
                name: "USERID",
                table: "EMPLOYEES",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATEDAT",
                table: "EMPLOYEES",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "STOREID",
                table: "EMPLOYEES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<string>(
                name: "POSITION",
                table: "EMPLOYEES",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "PHONE",
                table: "EMPLOYEES",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AlterColumn<bool>(
                name: "ISDELETED",
                table: "EMPLOYEES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "NUMBER(1)");

            migrationBuilder.AlterColumn<bool>(
                name: "ISACTIVE",
                table: "EMPLOYEES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "BOOLEAN");

            migrationBuilder.AlterColumn<DateTime>(
                name: "HIREDATE",
                table: "EMPLOYEES",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)");

            migrationBuilder.AlterColumn<string>(
                name: "FULLNAME",
                table: "EMPLOYEES",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "EMAIL",
                table: "EMPLOYEES",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATEDAT",
                table: "EMPLOYEES",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "EMPLOYEES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<string>(
                name: "USERID",
                table: "CUSTOMERS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATEDAT",
                table: "CUSTOMERS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TIER",
                table: "CUSTOMERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<string>(
                name: "PHONE",
                table: "CUSTOMERS",
                type: "TEXT",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<int>(
                name: "LOYALTYPOINTS",
                table: "CUSTOMERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "JOINDATE",
                table: "CUSTOMERS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)");

            migrationBuilder.AlterColumn<bool>(
                name: "ISDELETED",
                table: "CUSTOMERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "NUMBER(1)");

            migrationBuilder.AlterColumn<string>(
                name: "FULLNAME",
                table: "CUSTOMERS",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "EMAIL",
                table: "CUSTOMERS",
                type: "TEXT",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DATEOFBIRTH",
                table: "CUSTOMERS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATEDAT",
                table: "CUSTOMERS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)");

            migrationBuilder.AlterColumn<string>(
                name: "ADDRESS",
                table: "CUSTOMERS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "CUSTOMERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATEDAT",
                table: "CATEGORIES",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SLUG",
                table: "CATEGORIES",
                type: "TEXT",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(150)",
                oldMaxLength: 150,
                oldNullable: true);

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
                name: "ISDELETED",
                table: "CATEGORIES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "NUMBER(1)");

            migrationBuilder.AlterColumn<bool>(
                name: "ISACTIVE",
                table: "CATEGORIES",
                type: "INTEGER",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "BOOLEAN",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<string>(
                name: "IMAGEURL",
                table: "CATEGORIES",
                type: "TEXT",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DISPLAYORDER",
                table: "CATEGORIES",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "DESCRIPTION",
                table: "CATEGORIES",
                type: "TEXT",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATEDAT",
                table: "CATEGORIES",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "CATEGORIES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATEDAT",
                table: "BANNERS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)",
                oldNullable: true);

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
                name: "ISDELETED",
                table: "BANNERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "NUMBER(1)");

            migrationBuilder.AlterColumn<bool>(
                name: "ISACTIVE",
                table: "BANNERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "BOOLEAN");

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
                oldType: "VARCHAR2(2000)",
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
                oldType: "VARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PASSWORDHASH",
                table: "ASPNETUSERS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2(2000)",
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

            migrationBuilder.AlterColumn<int>(
                name: "MEMBERSHIPPOINTS",
                table: "ASPNETUSERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LOCKOUTEND",
                table: "ASPNETUSERS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "TIMESTAMP WITH TIME ZONE",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "LOCKOUTENABLED",
                table: "ASPNETUSERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "NUMBER(1)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "JOINDATE",
                table: "ASPNETUSERS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)");

            migrationBuilder.AlterColumn<string>(
                name: "GENDER",
                table: "ASPNETUSERS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(20)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FULLNAME",
                table: "ASPNETUSERS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(100)",
                oldNullable: true);

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

            migrationBuilder.AlterColumn<DateTime>(
                name: "DATEOFBIRTH",
                table: "ASPNETUSERS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CONCURRENCYSTAMP",
                table: "ASPNETUSERS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AVATARURL",
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
                oldType: "VARCHAR2(2000)",
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

            migrationBuilder.CreateTable(
                name: "CAMPAIGNS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NAME = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    DESCRIPTION = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    STARTDATE = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ENDDATE = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TARGETSEGMENT = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    VOUCHERID = table.Column<int>(type: "INTEGER", nullable: true),
                    NOTIFICATIONTITLE = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    NOTIFICATIONMESSAGE = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    ISSENT = table.Column<bool>(type: "INTEGER", nullable: false),
                    SENTAT = table.Column<DateTime>(type: "TEXT", nullable: true),
                    RECIPIENTCOUNT = table.Column<int>(type: "INTEGER", nullable: false),
                    CREATEDAT = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UPDATEDAT = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ISDELETED = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CAMPAIGNS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CAMP_VOUCHER",
                        column: x => x.VOUCHERID,
                        principalTable: "VOUCHERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CUSTOMERS_USERID",
                table: "CUSTOMERS",
                column: "USERID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "ASPNETUSERS",
                column: "NORMALIZEDUSERNAME",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "ASPNETROLES",
                column: "NORMALIZEDNAME",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CAMPAIGNS_VOUCHERID",
                table: "CAMPAIGNS",
                column: "VOUCHERID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CAMPAIGNS");

            migrationBuilder.DropIndex(
                name: "IX_CUSTOMERS_USERID",
                table: "CUSTOMERS");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "ASPNETUSERS");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "ASPNETROLES");

            migrationBuilder.DropColumn(
                name: "ADMINNOTE",
                table: "RETURNREQUESTS");

            migrationBuilder.DropColumn(
                name: "PROCESSEDAT",
                table: "RETURNREQUESTS");

            if (!migrationBuilder.IsSqlite())
            {
                migrationBuilder.CreateSequence(
                    name: "HILOSEQUENCE");
            }

            migrationBuilder.AlterColumn<int>(
                name: "USEDCOUNT",
                table: "VOUCHERS",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATEDAT",
                table: "VOUCHERS",
                type: "TIMESTAMP(7)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "MINORDERAMOUNT",
                table: "VOUCHERS",
                type: "NUMBER(12,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "MAXUSAGECOUNT",
                table: "VOUCHERS",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<bool>(
                name: "ISDELETED",
                table: "VOUCHERS",
                type: "NUMBER(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<bool>(
                name: "ISACTIVE",
                table: "VOUCHERS",
                type: "BOOLEAN",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EXPIRYDATE",
                table: "VOUCHERS",
                type: "TIMESTAMP(7)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<long>(
                name: "DISCOUNTAMOUNT",
                table: "VOUCHERS",
                type: "NUMBER(12,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATEDAT",
                table: "VOUCHERS",
                type: "TIMESTAMP(7)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "CODE",
                table: "VOUCHERS",
                type: "NVARCHAR2(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "VOUCHERS",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<string>(
                name: "USERID",
                table: "USERADDRESSES",
                type: "VARCHAR2(450)",
                maxLength: 450,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 450);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATEDAT",
                table: "USERADDRESSES",
                type: "TIMESTAMP(7)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PHONENUMBER",
                table: "USERADDRESSES",
                type: "NVARCHAR2(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<bool>(
                name: "ISDELETED",
                table: "USERADDRESSES",
                type: "NUMBER(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<bool>(
                name: "ISDEFAULT",
                table: "USERADDRESSES",
                type: "BOOLEAN",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "FULLNAME",
                table: "USERADDRESSES",
                type: "NVARCHAR2(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATEDAT",
                table: "USERADDRESSES",
                type: "TIMESTAMP(7)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "ADDRESSLINE",
                table: "USERADDRESSES",
                type: "NVARCHAR2(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "USERADDRESSES",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "USERADDRESSES",
                type: "VARCHAR2(450)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATEDAT",
                table: "SUPPLIERS",
                type: "TIMESTAMP(7)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PHONE",
                table: "SUPPLIERS",
                type: "NVARCHAR2(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "SUPPLIERS",
                type: "NVARCHAR2(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<int>(
                name: "LEADTIMEDAYS",
                table: "SUPPLIERS",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<bool>(
                name: "ISDELETED",
                table: "SUPPLIERS",
                type: "NUMBER(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<bool>(
                name: "ISACTIVE",
                table: "SUPPLIERS",
                type: "BOOLEAN",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "EMAIL",
                table: "SUPPLIERS",
                type: "NVARCHAR2(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATEDAT",
                table: "SUPPLIERS",
                type: "TIMESTAMP(7)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "CONTACTPERSON",
                table: "SUPPLIERS",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ADDRESS",
                table: "SUPPLIERS",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "SUPPLIERS",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATEDAT",
                table: "STORES",
                type: "TIMESTAMP(7)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PHONE",
                table: "STORES",
                type: "NVARCHAR2(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "STORES",
                type: "NVARCHAR2(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "MANAGERNAME",
                table: "STORES",
                type: "NVARCHAR2(2000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<bool>(
                name: "ISDELETED",
                table: "STORES",
                type: "NUMBER(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<bool>(
                name: "ISACTIVE",
                table: "STORES",
                type: "BOOLEAN",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATEDAT",
                table: "STORES",
                type: "TIMESTAMP(7)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "ADDRESS",
                table: "STORES",
                type: "NVARCHAR2(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "STORES",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATEDAT",
                table: "STOCKADJUSTMENTS",
                type: "TIMESTAMP(7)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "REASON",
                table: "STOCKADJUSTMENTS",
                type: "NUMBER(3)",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "QUANTITYCHANGE",
                table: "STOCKADJUSTMENTS",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "QUANTITYBEFORE",
                table: "STOCKADJUSTMENTS",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "QUANTITYAFTER",
                table: "STOCKADJUSTMENTS",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "NOTE",
                table: "STOCKADJUSTMENTS",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "ISDELETED",
                table: "STOCKADJUSTMENTS",
                type: "NUMBER(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "INVENTORYID",
                table: "STOCKADJUSTMENTS",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATEDAT",
                table: "STOCKADJUSTMENTS",
                type: "TIMESTAMP(7)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "ADJUSTEDBYUSERID",
                table: "STOCKADJUSTMENTS",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "STOCKADJUSTMENTS",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATEDAT",
                table: "RETURNREQUESTS",
                type: "TIMESTAMP(7)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "STATUS",
                table: "RETURNREQUESTS",
                type: "NUMBER(3)",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<long>(
                name: "REFUNDAMOUNT",
                table: "RETURNREQUESTS",
                type: "NUMBER(12,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "REASON",
                table: "RETURNREQUESTS",
                type: "NVARCHAR2(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<int>(
                name: "ORDERID",
                table: "RETURNREQUESTS",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<bool>(
                name: "ISDELETED",
                table: "RETURNREQUESTS",
                type: "NUMBER(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATEDAT",
                table: "RETURNREQUESTS",
                type: "TIMESTAMP(7)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "RETURNREQUESTS",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "OrderId1",
                table: "RETURNREQUESTS",
                type: "NUMBER(10)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATEDAT",
                table: "PURCHASEORDERS",
                type: "TIMESTAMP(7)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "TOTALCOST",
                table: "PURCHASEORDERS",
                type: "NUMBER(16,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "SUPPLIERID",
                table: "PURCHASEORDERS",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "STOREID",
                table: "PURCHASEORDERS",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<byte>(
                name: "STATUS",
                table: "PURCHASEORDERS",
                type: "NUMBER(3)",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RECEIVEDDATE",
                table: "PURCHASEORDERS",
                type: "TIMESTAMP(7)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "POCODE",
                table: "PURCHASEORDERS",
                type: "NVARCHAR2(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ORDERDATE",
                table: "PURCHASEORDERS",
                type: "TIMESTAMP(7)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "NOTE",
                table: "PURCHASEORDERS",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "ISDELETED",
                table: "PURCHASEORDERS",
                type: "NUMBER(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EXPECTEDDATE",
                table: "PURCHASEORDERS",
                type: "TIMESTAMP(7)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATEDAT",
                table: "PURCHASEORDERS",
                type: "TIMESTAMP(7)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "PURCHASEORDERS",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATEDAT",
                table: "PURCHASEORDERDETAILS",
                type: "TIMESTAMP(7)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UNITCOST",
                table: "PURCHASEORDERDETAILS",
                type: "NUMBER(12,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<long>(
                name: "SUBTOTAL",
                table: "PURCHASEORDERDETAILS",
                type: "NUMBER(14,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "QUANTITYRECEIVED",
                table: "PURCHASEORDERDETAILS",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "QUANTITYORDERED",
                table: "PURCHASEORDERDETAILS",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "PURCHASEORDERID",
                table: "PURCHASEORDERDETAILS",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "PRODUCTSKUID",
                table: "PURCHASEORDERDETAILS",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<bool>(
                name: "ISDELETED",
                table: "PURCHASEORDERDETAILS",
                type: "NUMBER(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATEDAT",
                table: "PURCHASEORDERDETAILS",
                type: "TIMESTAMP(7)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "PURCHASEORDERDETAILS",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATEDAT",
                table: "PRODUCTSKUS",
                type: "TIMESTAMP(7)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "STOCK",
                table: "PRODUCTSKUS",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "SKUCODE",
                table: "PRODUCTSKUS",
                type: "NVARCHAR2(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "SKU",
                table: "PRODUCTSKUS",
                type: "NVARCHAR2(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "SIZE",
                table: "PRODUCTSKUS",
                type: "NVARCHAR2(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<int>(
                name: "PRODUCTID",
                table: "PRODUCTSKUS",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<bool>(
                name: "ISDELETED",
                table: "PRODUCTSKUS",
                type: "NUMBER(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<bool>(
                name: "ISACTIVE",
                table: "PRODUCTSKUS",
                type: "BOOLEAN",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATEDAT",
                table: "PRODUCTSKUS",
                type: "TIMESTAMP(7)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "COLOR",
                table: "PRODUCTSKUS",
                type: "NVARCHAR2(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "PRODUCTSKUS",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATEDAT",
                table: "PRODUCTS",
                type: "TIMESTAMP(7)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SUPPLIERID",
                table: "PRODUCTS",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "SLUG",
                table: "PRODUCTS",
                type: "NVARCHAR2(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "PRODUCTS",
                type: "NVARCHAR2(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<bool>(
                name: "ISDELETED",
                table: "PRODUCTS",
                type: "NUMBER(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<bool>(
                name: "ISACTIVE",
                table: "PRODUCTS",
                type: "BOOLEAN",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "IMAGEURL",
                table: "PRODUCTS",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DESCRIPTION",
                table: "PRODUCTS",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATEDAT",
                table: "PRODUCTS",
                type: "TIMESTAMP(7)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "CATEGORYID",
                table: "PRODUCTS",
                type: "NUMBER(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "PRODUCTS",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATEDAT",
                table: "PRODUCTIMAGES",
                type: "TIMESTAMP(7)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PRODUCTID",
                table: "PRODUCTIMAGES",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<bool>(
                name: "ISDELETED",
                table: "PRODUCTIMAGES",
                type: "NUMBER(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "IMAGEURL",
                table: "PRODUCTIMAGES",
                type: "NVARCHAR2(2000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "DISPLAYORDER",
                table: "PRODUCTIMAGES",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATEDAT",
                table: "PRODUCTIMAGES",
                type: "TIMESTAMP(7)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "PRODUCTIMAGES",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "VOUCHERID",
                table: "ORDERS",
                type: "NUMBER(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "USERID",
                table: "ORDERS",
                type: "VARCHAR2(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATEDAT",
                table: "ORDERS",
                type: "TIMESTAMP(7)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "TOTALAMOUNT",
                table: "ORDERS",
                type: "NUMBER(14,0)",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(decimal),
                oldType: "NUMBER(14,0)",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<long>(
                name: "SUBTOTAL",
                table: "ORDERS",
                type: "NUMBER(14,0)",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(decimal),
                oldType: "NUMBER(14,0)",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<int>(
                name: "STOREID",
                table: "ORDERS",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<byte>(
                name: "STATUS",
                table: "ORDERS",
                type: "NUMBER(3)",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "POINTSEARNED",
                table: "ORDERS",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "PHONE",
                table: "ORDERS",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "PAYMENTSTATUS",
                table: "ORDERS",
                type: "NUMBER(3)",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<byte>(
                name: "PAYMENTMETHOD",
                table: "ORDERS",
                type: "NUMBER(3)",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "ORDERCODE",
                table: "ORDERS",
                type: "NVARCHAR2(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "NOTE",
                table: "ORDERS",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "ISDELETED",
                table: "ORDERS",
                type: "NUMBER(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<decimal>(
                name: "DISCOUNTAMOUNT",
                table: "ORDERS",
                type: "DECIMAL(18, 2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "TEXT",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "CUSTOMERNAME",
                table: "ORDERS",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CUSTOMERID",
                table: "ORDERS",
                type: "NUMBER(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATEDAT",
                table: "ORDERS",
                type: "TIMESTAMP(7)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "ADDRESS",
                table: "ORDERS",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "ORDERS",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATEDAT",
                table: "ORDERDETAILS",
                type: "TIMESTAMP(7)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "QUANTITY",
                table: "ORDERDETAILS",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "PRODUCTSKUID",
                table: "ORDERDETAILS",
                type: "NUMBER(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PRODUCTID",
                table: "ORDERDETAILS",
                type: "NUMBER(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ORDERID",
                table: "ORDERDETAILS",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<bool>(
                name: "ISDELETED",
                table: "ORDERDETAILS",
                type: "NUMBER(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<decimal>(
                name: "DISCOUNTPERCENT",
                table: "ORDERDETAILS",
                type: "DECIMAL(18, 2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "TEXT",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATEDAT",
                table: "ORDERDETAILS",
                type: "TIMESTAMP(7)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "ORDERDETAILS",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<string>(
                name: "USERID",
                table: "NOTIFICATIONS",
                type: "VARCHAR2(450)",
                maxLength: 450,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 450);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATEDAT",
                table: "NOTIFICATIONS",
                type: "TIMESTAMP(7)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TITLE",
                table: "NOTIFICATIONS",
                type: "NVARCHAR2(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "MESSAGE",
                table: "NOTIFICATIONS",
                type: "NVARCHAR2(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<bool>(
                name: "ISREAD",
                table: "NOTIFICATIONS",
                type: "BOOLEAN",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<bool>(
                name: "ISDELETED",
                table: "NOTIFICATIONS",
                type: "NUMBER(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATEDAT",
                table: "NOTIFICATIONS",
                type: "TIMESTAMP(7)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "ACTIONURL",
                table: "NOTIFICATIONS",
                type: "NVARCHAR2(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "NOTIFICATIONS",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "NOTIFICATIONS",
                type: "VARCHAR2(450)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATEDAT",
                table: "LOYALTYTRANSACTIONS",
                type: "TIMESTAMP(7)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "POINTS",
                table: "LOYALTYTRANSACTIONS",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "ORDERID",
                table: "LOYALTYTRANSACTIONS",
                type: "NUMBER(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "ISDELETED",
                table: "LOYALTYTRANSACTIONS",
                type: "NUMBER(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "DESCRIPTION",
                table: "LOYALTYTRANSACTIONS",
                type: "NVARCHAR2(2000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "CUSTOMERID",
                table: "LOYALTYTRANSACTIONS",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATEDAT",
                table: "LOYALTYTRANSACTIONS",
                type: "TIMESTAMP(7)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "LOYALTYTRANSACTIONS",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATEDAT",
                table: "INVENTORIES",
                type: "TIMESTAMP(7)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "STOREID",
                table: "INVENTORIES",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "REORDERPOINT",
                table: "INVENTORIES",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "QUANTITYONHAND",
                table: "INVENTORIES",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "PRODUCTSKUID",
                table: "INVENTORIES",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "MAXSTOCKLEVEL",
                table: "INVENTORIES",
                type: "NUMBER(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LASTUPDATED",
                table: "INVENTORIES",
                type: "TIMESTAMP(7)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<bool>(
                name: "ISDELETED",
                table: "INVENTORIES",
                type: "NUMBER(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATEDAT",
                table: "INVENTORIES",
                type: "TIMESTAMP(7)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "INVENTORIES",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<string>(
                name: "USERID",
                table: "EMPLOYEES",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATEDAT",
                table: "EMPLOYEES",
                type: "TIMESTAMP(7)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "STOREID",
                table: "EMPLOYEES",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "POSITION",
                table: "EMPLOYEES",
                type: "NVARCHAR2(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "PHONE",
                table: "EMPLOYEES",
                type: "NVARCHAR2(2000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<bool>(
                name: "ISDELETED",
                table: "EMPLOYEES",
                type: "NUMBER(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<bool>(
                name: "ISACTIVE",
                table: "EMPLOYEES",
                type: "BOOLEAN",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "HIREDATE",
                table: "EMPLOYEES",
                type: "TIMESTAMP(7)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "FULLNAME",
                table: "EMPLOYEES",
                type: "NVARCHAR2(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "EMAIL",
                table: "EMPLOYEES",
                type: "NVARCHAR2(2000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATEDAT",
                table: "EMPLOYEES",
                type: "TIMESTAMP(7)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "EMPLOYEES",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<string>(
                name: "USERID",
                table: "CUSTOMERS",
                type: "VARCHAR2(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATEDAT",
                table: "CUSTOMERS",
                type: "TIMESTAMP(7)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TIER",
                table: "CUSTOMERS",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "PHONE",
                table: "CUSTOMERS",
                type: "NVARCHAR2(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<int>(
                name: "LOYALTYPOINTS",
                table: "CUSTOMERS",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "JOINDATE",
                table: "CUSTOMERS",
                type: "TIMESTAMP(7)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<bool>(
                name: "ISDELETED",
                table: "CUSTOMERS",
                type: "NUMBER(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "FULLNAME",
                table: "CUSTOMERS",
                type: "NVARCHAR2(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "EMAIL",
                table: "CUSTOMERS",
                type: "NVARCHAR2(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DATEOFBIRTH",
                table: "CUSTOMERS",
                type: "TIMESTAMP(7)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATEDAT",
                table: "CUSTOMERS",
                type: "TIMESTAMP(7)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "ADDRESS",
                table: "CUSTOMERS",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "CUSTOMERS",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATEDAT",
                table: "CATEGORIES",
                type: "TIMESTAMP(7)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SLUG",
                table: "CATEGORIES",
                type: "NVARCHAR2(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PARENTCATEGORYID",
                table: "CATEGORIES",
                type: "NUMBER(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "CATEGORIES",
                type: "NVARCHAR2(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<bool>(
                name: "ISDELETED",
                table: "CATEGORIES",
                type: "NUMBER(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<bool>(
                name: "ISACTIVE",
                table: "CATEGORIES",
                type: "BOOLEAN",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "INTEGER",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<string>(
                name: "IMAGEURL",
                table: "CATEGORIES",
                type: "NVARCHAR2(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DISPLAYORDER",
                table: "CATEGORIES",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "DESCRIPTION",
                table: "CATEGORIES",
                type: "NVARCHAR2(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATEDAT",
                table: "CATEGORIES",
                type: "TIMESTAMP(7)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "CATEGORIES",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATEDAT",
                table: "BANNERS",
                type: "TIMESTAMP(7)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TITLE",
                table: "BANNERS",
                type: "NVARCHAR2(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "SUBTITLE",
                table: "BANNERS",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "POSITION",
                table: "BANNERS",
                type: "NVARCHAR2(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LINKURL",
                table: "BANNERS",
                type: "NVARCHAR2(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "ISDELETED",
                table: "BANNERS",
                type: "NUMBER(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<bool>(
                name: "ISACTIVE",
                table: "BANNERS",
                type: "BOOLEAN",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "IMAGEURL",
                table: "BANNERS",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DISPLAYORDER",
                table: "BANNERS",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATEDAT",
                table: "BANNERS",
                type: "TIMESTAMP(7)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "BANNERS",
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
                type: "VARCHAR2(2000)",
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
                type: "VARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PASSWORDHASH",
                table: "ASPNETUSERS",
                type: "VARCHAR2(2000)",
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

            migrationBuilder.AlterColumn<int>(
                name: "MEMBERSHIPPOINTS",
                table: "ASPNETUSERS",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LOCKOUTEND",
                table: "ASPNETUSERS",
                type: "TIMESTAMP WITH TIME ZONE",
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "JOINDATE",
                table: "ASPNETUSERS",
                type: "TIMESTAMP(7)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "GENDER",
                table: "ASPNETUSERS",
                type: "NVARCHAR2(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FULLNAME",
                table: "ASPNETUSERS",
                type: "NVARCHAR2(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

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

            migrationBuilder.AlterColumn<DateTime>(
                name: "DATEOFBIRTH",
                table: "ASPNETUSERS",
                type: "TIMESTAMP(7)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CONCURRENCYSTAMP",
                table: "ASPNETUSERS",
                type: "VARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AVATARURL",
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
                type: "VARCHAR2(2000)",
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

            migrationBuilder.CreateIndex(
                name: "IX_CUSTOMERS_USERID",
                table: "CUSTOMERS",
                column: "USERID",
                unique: true,
                filter: "\"USERID\" IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "ASPNETUSERS",
                column: "NORMALIZEDUSERNAME",
                unique: true,
                filter: "\"NORMALIZEDUSERNAME\" IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "ASPNETROLES",
                column: "NORMALIZEDNAME",
                unique: true,
                filter: "\"NORMALIZEDNAME\" IS NOT NULL");

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
    }
}
