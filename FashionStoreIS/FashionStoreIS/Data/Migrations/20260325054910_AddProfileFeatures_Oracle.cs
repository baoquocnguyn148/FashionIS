using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FashionStoreIS.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddProfileFeatures_Oracle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OD_PROD",
                table: "ORDERDETAILS");

            migrationBuilder.DropForeignKey(
                name: "FK_OD_SKU",
                table: "ORDERDETAILS");

            migrationBuilder.DropForeignKey(
                name: "FK_ORDERS_VOUCHERS_VOUCHERID",
                table: "ORDERS");

            migrationBuilder.DropForeignKey(
                name: "FK_ORD_CUST",
                table: "ORDERS");

            migrationBuilder.DropForeignKey(
                name: "FK_ORD_USER",
                table: "ORDERS");

            migrationBuilder.DropIndex(
                name: "IX_CUSTOMERS_USERID",
                table: "CUSTOMERS");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "ASPNETUSERS");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "ASPNETROLES");

            migrationBuilder.CreateSequence(
                name: "HILOSEQUENCE");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATEDAT",
                table: "VOUCHERS",
                type: "TIMESTAMP(7)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

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
                oldType: "TEXT(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "VOUCHERS",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "MAXUSAGECOUNT",
                table: "VOUCHERS",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "USEDCOUNT",
                table: "VOUCHERS",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

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
                oldType: "TEXT(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "SUPPLIERS",
                type: "NVARCHAR2(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT(150)",
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
                oldType: "TEXT(100)",
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
                oldType: "TEXT(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ADDRESS",
                table: "SUPPLIERS",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "SUPPLIERS",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

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
                oldType: "TEXT(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "STORES",
                type: "NVARCHAR2(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "MANAGERNAME",
                table: "STORES",
                type: "NVARCHAR2(2000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT(2000)");

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
                oldType: "TEXT(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "STORES",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

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
                oldType: "TEXT(2000)",
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
                oldType: "TEXT(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "STOCKADJUSTMENTS",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATEDAT",
                table: "PURCHASEORDERS",
                type: "TIMESTAMP(7)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

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
                oldType: "TEXT(20)",
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
                oldType: "TEXT(2000)",
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
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATEDAT",
                table: "PURCHASEORDERDETAILS",
                type: "TIMESTAMP(7)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

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
                oldType: "INTEGER");

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
                oldType: "TEXT(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "SKU",
                table: "PRODUCTSKUS",
                type: "NVARCHAR2(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "SIZE",
                table: "PRODUCTSKUS",
                type: "NVARCHAR2(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT(10)",
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
                oldType: "TEXT(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "PRODUCTSKUS",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

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
                oldType: "TEXT(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "PRODUCTS",
                type: "NVARCHAR2(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT(150)",
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
                oldType: "TEXT(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DESCRIPTION",
                table: "PRODUCTS",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT(2000)",
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
                oldType: "INTEGER");

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
                oldType: "TEXT(2000)");

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
                oldType: "INTEGER");

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
                oldType: "TEXT(450)",
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
                oldClrType: typeof(long),
                oldType: "NUMBER(14,0)");

            migrationBuilder.AlterColumn<long>(
                name: "SUBTOTAL",
                table: "ORDERS",
                type: "NUMBER(14,0)",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "NUMBER(14,0)");

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
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "PHONE",
                table: "ORDERS",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT(2000)",
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
                oldType: "TEXT(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "NOTE",
                table: "ORDERS",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT(2000)",
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
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "CUSTOMERNAME",
                table: "ORDERS",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT(2000)",
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
                oldType: "TEXT(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "ORDERS",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

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
                oldType: "TEXT");

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
                oldType: "INTEGER");

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
                oldType: "TEXT(2000)");

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
                oldType: "INTEGER");

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
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "USERID",
                table: "EMPLOYEES",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT(2000)",
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
                oldType: "TEXT(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "PHONE",
                table: "EMPLOYEES",
                type: "NVARCHAR2(2000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT(2000)");

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
                oldType: "TEXT(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "EMAIL",
                table: "EMPLOYEES",
                type: "NVARCHAR2(2000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT(2000)");

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
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "USERID",
                table: "CUSTOMERS",
                type: "VARCHAR2(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT(450)",
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
                oldType: "TEXT(15)",
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
                oldType: "TEXT(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "EMAIL",
                table: "CUSTOMERS",
                type: "NVARCHAR2(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT(100)",
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
                oldType: "TEXT(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "CUSTOMERS",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

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
                oldType: "TEXT(150)",
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
                oldType: "TEXT(100)",
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
                oldType: "TEXT(255)",
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
                oldType: "TEXT(500)",
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
                oldType: "INTEGER");

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
                oldType: "TEXT(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "SUBTITLE",
                table: "BANNERS",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "POSITION",
                table: "BANNERS",
                type: "NVARCHAR2(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LINKURL",
                table: "BANNERS",
                type: "NVARCHAR2(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT(200)",
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
                oldType: "TEXT(2000)",
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
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "VALUE",
                table: "ASPNETUSERTOKENS",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "ASPNETUSERTOKENS",
                type: "NVARCHAR2(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LOGINPROVIDER",
                table: "ASPNETUSERTOKENS",
                type: "NVARCHAR2(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "USERID",
                table: "ASPNETUSERTOKENS",
                type: "VARCHAR2(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT(450)");

            migrationBuilder.AlterColumn<string>(
                name: "USERNAME",
                table: "ASPNETUSERS",
                type: "VARCHAR2(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT(256)",
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
                oldType: "TEXT(2000)",
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
                oldType: "TEXT(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PASSWORDHASH",
                table: "ASPNETUSERS",
                type: "VARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NORMALIZEDUSERNAME",
                table: "ASPNETUSERS",
                type: "VARCHAR2(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NORMALIZEDEMAIL",
                table: "ASPNETUSERS",
                type: "VARCHAR2(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT(256)",
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
                oldType: "TEXT(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FULLNAME",
                table: "ASPNETUSERS",
                type: "NVARCHAR2(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT(2000)",
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
                oldType: "TEXT(256)",
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
                oldType: "TEXT(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AVATARURL",
                table: "ASPNETUSERS",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT(2000)",
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
                oldType: "TEXT(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ROLEID",
                table: "ASPNETUSERROLES",
                type: "VARCHAR2(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT(450)");

            migrationBuilder.AlterColumn<string>(
                name: "USERID",
                table: "ASPNETUSERROLES",
                type: "VARCHAR2(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT(450)");

            migrationBuilder.AlterColumn<string>(
                name: "USERID",
                table: "ASPNETUSERLOGINS",
                type: "VARCHAR2(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT(450)");

            migrationBuilder.AlterColumn<string>(
                name: "PROVIDERDISPLAYNAME",
                table: "ASPNETUSERLOGINS",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PROVIDERKEY",
                table: "ASPNETUSERLOGINS",
                type: "NVARCHAR2(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LOGINPROVIDER",
                table: "ASPNETUSERLOGINS",
                type: "NVARCHAR2(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "USERID",
                table: "ASPNETUSERCLAIMS",
                type: "VARCHAR2(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT(450)");

            migrationBuilder.AlterColumn<string>(
                name: "CLAIMVALUE",
                table: "ASPNETUSERCLAIMS",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CLAIMTYPE",
                table: "ASPNETUSERCLAIMS",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "ASPNETUSERCLAIMS",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "NORMALIZEDNAME",
                table: "ASPNETROLES",
                type: "VARCHAR2(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "ASPNETROLES",
                type: "VARCHAR2(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CONCURRENCYSTAMP",
                table: "ASPNETROLES",
                type: "VARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ID",
                table: "ASPNETROLES",
                type: "VARCHAR2(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ROLEID",
                table: "ASPNETROLECLAIMS",
                type: "VARCHAR2(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT(450)");

            migrationBuilder.AlterColumn<string>(
                name: "CLAIMVALUE",
                table: "ASPNETROLECLAIMS",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CLAIMTYPE",
                table: "ASPNETROLECLAIMS",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "ASPNETROLECLAIMS",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateTable(
                name: "NOTIFICATIONS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    USERID = table.Column<string>(type: "VARCHAR2(450)", maxLength: 450, nullable: false),
                    TITLE = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    MESSAGE = table.Column<string>(type: "NVARCHAR2(1000)", maxLength: 1000, nullable: false),
                    ISREAD = table.Column<bool>(type: "BOOLEAN", nullable: false),
                    ACTIONURL = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    CREATEDAT = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    UPDATEDAT = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    ISDELETED = table.Column<bool>(type: "NUMBER(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NOTIFICATIONS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NOTIF_USER",
                        column: x => x.USERID,
                        principalTable: "ASPNETUSERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RETURNREQUESTS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ORDERID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    REASON = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: false),
                    STATUS = table.Column<byte>(type: "NUMBER(3)", nullable: false),
                    REFUNDAMOUNT = table.Column<long>(type: "NUMBER(12,0)", nullable: false),
                    CREATEDAT = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    UPDATEDAT = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    ISDELETED = table.Column<bool>(type: "NUMBER(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RETURNREQUESTS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RR_ORDER",
                        column: x => x.ORDERID,
                        principalTable: "ORDERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "USERADDRESSES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    USERID = table.Column<string>(type: "VARCHAR2(450)", maxLength: 450, nullable: false),
                    FULLNAME = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    PHONENUMBER = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: false),
                    ADDRESSLINE = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    ISDEFAULT = table.Column<bool>(type: "BOOLEAN", nullable: false),
                    CREATEDAT = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    UPDATEDAT = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    ISDELETED = table.Column<bool>(type: "NUMBER(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERADDRESSES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UA_USER",
                        column: x => x.USERID,
                        principalTable: "ASPNETUSERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_NOTIFICATIONS_USERID",
                table: "NOTIFICATIONS",
                column: "USERID");

            migrationBuilder.CreateIndex(
                name: "IX_RETURNREQUESTS_ORDERID",
                table: "RETURNREQUESTS",
                column: "ORDERID");

            migrationBuilder.CreateIndex(
                name: "IX_USERADDRESSES_USERID",
                table: "USERADDRESSES",
                column: "USERID");

            migrationBuilder.AddForeignKey(
                name: "FK_ORDERDETAILS_PRODUCTSKUS_PRODUCTSKUID",
                table: "ORDERDETAILS",
                column: "PRODUCTSKUID",
                principalTable: "PRODUCTSKUS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ORDERDETAILS_PRODUCTS_PRODUCTID",
                table: "ORDERDETAILS",
                column: "PRODUCTID",
                principalTable: "PRODUCTS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ORDERS_ASPNETUSERS_USERID",
                table: "ORDERS",
                column: "USERID",
                principalTable: "ASPNETUSERS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ORDERS_CUSTOMERS_CUSTOMERID",
                table: "ORDERS",
                column: "CUSTOMERID",
                principalTable: "CUSTOMERS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ORDERS_VOUCHERS_VOUCHERID",
                table: "ORDERS",
                column: "VOUCHERID",
                principalTable: "VOUCHERS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ORDERDETAILS_PRODUCTSKUS_PRODUCTSKUID",
                table: "ORDERDETAILS");

            migrationBuilder.DropForeignKey(
                name: "FK_ORDERDETAILS_PRODUCTS_PRODUCTID",
                table: "ORDERDETAILS");

            migrationBuilder.DropForeignKey(
                name: "FK_ORDERS_ASPNETUSERS_USERID",
                table: "ORDERS");

            migrationBuilder.DropForeignKey(
                name: "FK_ORDERS_CUSTOMERS_CUSTOMERID",
                table: "ORDERS");

            migrationBuilder.DropForeignKey(
                name: "FK_ORDERS_VOUCHERS_VOUCHERID",
                table: "ORDERS");

            migrationBuilder.DropTable(
                name: "NOTIFICATIONS");

            migrationBuilder.DropTable(
                name: "RETURNREQUESTS");

            migrationBuilder.DropTable(
                name: "USERADDRESSES");

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
                name: "MAXUSAGECOUNT",
                table: "VOUCHERS");

            migrationBuilder.DropColumn(
                name: "USEDCOUNT",
                table: "VOUCHERS");

            migrationBuilder.DropSequence(
                name: "HILOSEQUENCE");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATEDAT",
                table: "VOUCHERS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)",
                oldNullable: true);

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
                type: "TEXT(50)",
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
                oldType: "NUMBER(10)");

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
                type: "TEXT(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "SUPPLIERS",
                type: "TEXT(150)",
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
                type: "TEXT(100)",
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
                type: "TEXT(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ADDRESS",
                table: "SUPPLIERS",
                type: "TEXT(2000)",
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
                oldType: "NUMBER(10)");

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
                type: "TEXT(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "STORES",
                type: "TEXT(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "MANAGERNAME",
                table: "STORES",
                type: "TEXT(2000)",
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
                type: "TEXT(200)",
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
                oldType: "NUMBER(10)");

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
                type: "TEXT(2000)",
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
                type: "TEXT(2000)",
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
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATEDAT",
                table: "PURCHASEORDERS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)",
                oldNullable: true);

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
                type: "TEXT(20)",
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
                type: "TEXT(2000)",
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
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATEDAT",
                table: "PURCHASEORDERDETAILS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)",
                oldNullable: true);

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
                oldType: "NUMBER(10)");

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
                type: "TEXT(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "SKU",
                table: "PRODUCTSKUS",
                type: "TEXT(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "SIZE",
                table: "PRODUCTSKUS",
                type: "TEXT(10)",
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
                type: "TEXT(50)",
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
                oldType: "NUMBER(10)");

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
                type: "TEXT(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "PRODUCTS",
                type: "TEXT(150)",
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
                type: "TEXT(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DESCRIPTION",
                table: "PRODUCTS",
                type: "TEXT(2000)",
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
                oldType: "NUMBER(10)");

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
                type: "TEXT(2000)",
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
                oldType: "NUMBER(10)");

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
                type: "TEXT(450)",
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

            migrationBuilder.AlterColumn<long>(
                name: "TOTALAMOUNT",
                table: "ORDERS",
                type: "NUMBER(14,0)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "NUMBER(14,0)",
                oldDefaultValue: 0L);

            migrationBuilder.AlterColumn<long>(
                name: "SUBTOTAL",
                table: "ORDERS",
                type: "NUMBER(14,0)",
                nullable: false,
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
                oldClrType: typeof(int),
                oldType: "NUMBER(10)",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "PHONE",
                table: "ORDERS",
                type: "TEXT(2000)",
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
                type: "TEXT(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "NOTE",
                table: "ORDERS",
                type: "TEXT(2000)",
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
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "CUSTOMERNAME",
                table: "ORDERS",
                type: "TEXT(2000)",
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
                type: "TEXT(2000)",
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
                oldType: "NUMBER(10)");

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
                oldType: "NUMBER(10)");

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
                type: "TEXT(2000)",
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
                oldType: "NUMBER(10)");

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
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<string>(
                name: "USERID",
                table: "EMPLOYEES",
                type: "TEXT(2000)",
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
                type: "TEXT(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "PHONE",
                table: "EMPLOYEES",
                type: "TEXT(2000)",
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
                type: "TEXT(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "EMAIL",
                table: "EMPLOYEES",
                type: "TEXT(2000)",
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
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<string>(
                name: "USERID",
                table: "CUSTOMERS",
                type: "TEXT(450)",
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
                type: "TEXT(15)",
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
                type: "TEXT(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "EMAIL",
                table: "CUSTOMERS",
                type: "TEXT(100)",
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
                type: "TEXT(2000)",
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
                oldType: "NUMBER(10)");

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
                type: "TEXT(150)",
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
                type: "TEXT(100)",
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
                type: "TEXT(255)",
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
                type: "TEXT(500)",
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
                oldType: "NUMBER(10)");

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
                type: "TEXT(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "SUBTITLE",
                table: "BANNERS",
                type: "TEXT(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "POSITION",
                table: "BANNERS",
                type: "TEXT(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LINKURL",
                table: "BANNERS",
                type: "TEXT(200)",
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
                type: "TEXT(2000)",
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
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<string>(
                name: "VALUE",
                table: "ASPNETUSERTOKENS",
                type: "TEXT(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "ASPNETUSERTOKENS",
                type: "TEXT(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LOGINPROVIDER",
                table: "ASPNETUSERTOKENS",
                type: "TEXT(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "USERID",
                table: "ASPNETUSERTOKENS",
                type: "TEXT(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2(450)");

            migrationBuilder.AlterColumn<string>(
                name: "USERNAME",
                table: "ASPNETUSERS",
                type: "TEXT(256)",
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
                type: "TEXT(2000)",
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
                type: "TEXT(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PASSWORDHASH",
                table: "ASPNETUSERS",
                type: "TEXT(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NORMALIZEDUSERNAME",
                table: "ASPNETUSERS",
                type: "TEXT(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NORMALIZEDEMAIL",
                table: "ASPNETUSERS",
                type: "TEXT(256)",
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
                type: "TEXT(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(20)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FULLNAME",
                table: "ASPNETUSERS",
                type: "TEXT(2000)",
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
                type: "TEXT(256)",
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
                type: "TEXT(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AVATARURL",
                table: "ASPNETUSERS",
                type: "TEXT(2000)",
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
                type: "TEXT(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ROLEID",
                table: "ASPNETUSERROLES",
                type: "TEXT(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2(450)");

            migrationBuilder.AlterColumn<string>(
                name: "USERID",
                table: "ASPNETUSERROLES",
                type: "TEXT(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2(450)");

            migrationBuilder.AlterColumn<string>(
                name: "USERID",
                table: "ASPNETUSERLOGINS",
                type: "TEXT(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2(450)");

            migrationBuilder.AlterColumn<string>(
                name: "PROVIDERDISPLAYNAME",
                table: "ASPNETUSERLOGINS",
                type: "TEXT(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PROVIDERKEY",
                table: "ASPNETUSERLOGINS",
                type: "TEXT(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LOGINPROVIDER",
                table: "ASPNETUSERLOGINS",
                type: "TEXT(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "USERID",
                table: "ASPNETUSERCLAIMS",
                type: "TEXT(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2(450)");

            migrationBuilder.AlterColumn<string>(
                name: "CLAIMVALUE",
                table: "ASPNETUSERCLAIMS",
                type: "TEXT(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CLAIMTYPE",
                table: "ASPNETUSERCLAIMS",
                type: "TEXT(2000)",
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
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<string>(
                name: "NORMALIZEDNAME",
                table: "ASPNETROLES",
                type: "TEXT(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "ASPNETROLES",
                type: "TEXT(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CONCURRENCYSTAMP",
                table: "ASPNETROLES",
                type: "TEXT(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ID",
                table: "ASPNETROLES",
                type: "TEXT(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ROLEID",
                table: "ASPNETROLECLAIMS",
                type: "TEXT(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2(450)");

            migrationBuilder.AlterColumn<string>(
                name: "CLAIMVALUE",
                table: "ASPNETROLECLAIMS",
                type: "TEXT(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CLAIMTYPE",
                table: "ASPNETROLECLAIMS",
                type: "TEXT(2000)",
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
                oldType: "NUMBER(10)");

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

            migrationBuilder.AddForeignKey(
                name: "FK_OD_PROD",
                table: "ORDERDETAILS",
                column: "PRODUCTID",
                principalTable: "PRODUCTS",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_OD_SKU",
                table: "ORDERDETAILS",
                column: "PRODUCTSKUID",
                principalTable: "PRODUCTSKUS",
                principalColumn: "ID");

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
                name: "FK_ORD_USER",
                table: "ORDERS",
                column: "USERID",
                principalTable: "ASPNETUSERS",
                principalColumn: "ID");
        }
    }
}
