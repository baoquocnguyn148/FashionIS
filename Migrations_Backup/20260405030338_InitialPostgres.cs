using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FashionStoreIS.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialPostgres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ALERTACTIONS_ASPNETUSERS_TAKENBYUSERID",
                table: "ALERTACTIONS");

            migrationBuilder.DropForeignKey(
                name: "FK_ALERTACTIONS_EXECUTIVEALERTS_EXECUTIVEALERTID",
                table: "ALERTACTIONS");

            migrationBuilder.DropForeignKey(
                name: "FK_EXECUTIVEALERTS_ASPNETUSERS_USERID",
                table: "EXECUTIVEALERTS");

            migrationBuilder.DropForeignKey(
                name: "FK_LOYALTYTRANSACTIONS_ORDERS_ORDERID",
                table: "LOYALTYTRANSACTIONS");

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

            migrationBuilder.DropForeignKey(
                name: "FK_PRODUCTIMAGES_PRODUCTS_PRODUCTID",
                table: "PRODUCTIMAGES");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PRODUCTIMAGES",
                table: "PRODUCTIMAGES");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EXECUTIVEALERTS",
                table: "EXECUTIVEALERTS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ALERTACTIONS",
                table: "ALERTACTIONS");

            migrationBuilder.RenameTable(
                name: "PRODUCTIMAGES",
                newName: "productimages");

            migrationBuilder.RenameTable(
                name: "EXECUTIVEALERTS",
                newName: "executivealerts");

            migrationBuilder.RenameTable(
                name: "ALERTACTIONS",
                newName: "alertactions");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "WISHLISTITEMS",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UPDATEDAT",
                table: "WISHLISTITEMS",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "ISDELETED",
                table: "WISHLISTITEMS",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "CREATEDAT",
                table: "WISHLISTITEMS",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "VOUCHERS",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UPDATEDAT",
                table: "VOUCHERS",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "ISDELETED",
                table: "VOUCHERS",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "CREATEDAT",
                table: "VOUCHERS",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "USERADDRESSES",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UPDATEDAT",
                table: "USERADDRESSES",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "ISDELETED",
                table: "USERADDRESSES",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "CREATEDAT",
                table: "USERADDRESSES",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "LEADTIMEDAYS",
                table: "SUPPLIERS",
                newName: "leadtimedays");

            migrationBuilder.RenameColumn(
                name: "ISACTIVE",
                table: "SUPPLIERS",
                newName: "isactive");

            migrationBuilder.RenameColumn(
                name: "CONTACTPERSON",
                table: "SUPPLIERS",
                newName: "contactperson");

            migrationBuilder.RenameColumn(
                name: "ADDRESS",
                table: "SUPPLIERS",
                newName: "address");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "SUPPLIERS",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UPDATEDAT",
                table: "SUPPLIERS",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "ISDELETED",
                table: "SUPPLIERS",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "CREATEDAT",
                table: "SUPPLIERS",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "MANAGERNAME",
                table: "STORES",
                newName: "managername");

            migrationBuilder.RenameColumn(
                name: "ISACTIVE",
                table: "STORES",
                newName: "isactive");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "STORES",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UPDATEDAT",
                table: "STORES",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "ISDELETED",
                table: "STORES",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "CREATEDAT",
                table: "STORES",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "REASON",
                table: "STOCKADJUSTMENTS",
                newName: "reason");

            migrationBuilder.RenameColumn(
                name: "QUANTITYCHANGE",
                table: "STOCKADJUSTMENTS",
                newName: "quantitychange");

            migrationBuilder.RenameColumn(
                name: "QUANTITYBEFORE",
                table: "STOCKADJUSTMENTS",
                newName: "quantitybefore");

            migrationBuilder.RenameColumn(
                name: "QUANTITYAFTER",
                table: "STOCKADJUSTMENTS",
                newName: "quantityafter");

            migrationBuilder.RenameColumn(
                name: "NOTE",
                table: "STOCKADJUSTMENTS",
                newName: "note");

            migrationBuilder.RenameColumn(
                name: "INVENTORYID",
                table: "STOCKADJUSTMENTS",
                newName: "inventoryid");

            migrationBuilder.RenameColumn(
                name: "ADJUSTEDBYUSERID",
                table: "STOCKADJUSTMENTS",
                newName: "adjustedbyuserid");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "STOCKADJUSTMENTS",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UPDATEDAT",
                table: "STOCKADJUSTMENTS",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "ISDELETED",
                table: "STOCKADJUSTMENTS",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "CREATEDAT",
                table: "STOCKADJUSTMENTS",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_STOCKADJUSTMENTS_INVENTORYID",
                table: "STOCKADJUSTMENTS",
                newName: "IX_STOCKADJUSTMENTS_inventoryid");

            migrationBuilder.RenameColumn(
                name: "STOREID",
                table: "SHIFTS",
                newName: "storeid");

            migrationBuilder.RenameColumn(
                name: "STARTTIME",
                table: "SHIFTS",
                newName: "starttime");

            migrationBuilder.RenameColumn(
                name: "NAME",
                table: "SHIFTS",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "ISACTIVE",
                table: "SHIFTS",
                newName: "isactive");

            migrationBuilder.RenameColumn(
                name: "ENDTIME",
                table: "SHIFTS",
                newName: "endtime");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "SHIFTS",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UPDATEDAT",
                table: "SHIFTS",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "ISDELETED",
                table: "SHIFTS",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "CREATEDAT",
                table: "SHIFTS",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_SHIFTS_STOREID",
                table: "SHIFTS",
                newName: "IX_SHIFTS_storeid");

            migrationBuilder.RenameColumn(
                name: "STATUS",
                table: "SCHEDULES",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "SHIFTID",
                table: "SCHEDULES",
                newName: "shiftid");

            migrationBuilder.RenameColumn(
                name: "NOTE",
                table: "SCHEDULES",
                newName: "note");

            migrationBuilder.RenameColumn(
                name: "EMPLOYEEID",
                table: "SCHEDULES",
                newName: "employeeid");

            migrationBuilder.RenameColumn(
                name: "DATE",
                table: "SCHEDULES",
                newName: "date");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "SCHEDULES",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UPDATEDAT",
                table: "SCHEDULES",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "ISDELETED",
                table: "SCHEDULES",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "CREATEDAT",
                table: "SCHEDULES",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_SCHEDULES_SHIFTID",
                table: "SCHEDULES",
                newName: "IX_SCHEDULES_shiftid");

            migrationBuilder.RenameIndex(
                name: "IX_SCHEDULES_EMPLOYEEID",
                table: "SCHEDULES",
                newName: "IX_SCHEDULES_employeeid");

            migrationBuilder.RenameColumn(
                name: "TYPE",
                table: "SALARYCOMPONENTS",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "NAME",
                table: "SALARYCOMPONENTS",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "ISACTIVE",
                table: "SALARYCOMPONENTS",
                newName: "isactive");

            migrationBuilder.RenameColumn(
                name: "DESCRIPTION",
                table: "SALARYCOMPONENTS",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "SALARYCOMPONENTS",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UPDATEDAT",
                table: "SALARYCOMPONENTS",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "ISDELETED",
                table: "SALARYCOMPONENTS",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "CREATEDAT",
                table: "SALARYCOMPONENTS",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "RETURNREQUESTS",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UPDATEDAT",
                table: "RETURNREQUESTS",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "ISDELETED",
                table: "RETURNREQUESTS",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "CREATEDAT",
                table: "RETURNREQUESTS",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "SUPPLIERID",
                table: "PURCHASEORDERS",
                newName: "supplierid");

            migrationBuilder.RenameColumn(
                name: "STOREID",
                table: "PURCHASEORDERS",
                newName: "storeid");

            migrationBuilder.RenameColumn(
                name: "STATUS",
                table: "PURCHASEORDERS",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "RECEIVEDDATE",
                table: "PURCHASEORDERS",
                newName: "receiveddate");

            migrationBuilder.RenameColumn(
                name: "ORDERDATE",
                table: "PURCHASEORDERS",
                newName: "orderdate");

            migrationBuilder.RenameColumn(
                name: "NOTE",
                table: "PURCHASEORDERS",
                newName: "note");

            migrationBuilder.RenameColumn(
                name: "EXPECTEDDATE",
                table: "PURCHASEORDERS",
                newName: "expecteddate");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "PURCHASEORDERS",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UPDATEDAT",
                table: "PURCHASEORDERS",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "ISDELETED",
                table: "PURCHASEORDERS",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "CREATEDAT",
                table: "PURCHASEORDERS",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_PURCHASEORDERS_SUPPLIERID",
                table: "PURCHASEORDERS",
                newName: "IX_PURCHASEORDERS_supplierid");

            migrationBuilder.RenameIndex(
                name: "IX_PURCHASEORDERS_STOREID",
                table: "PURCHASEORDERS",
                newName: "IX_PURCHASEORDERS_storeid");

            migrationBuilder.RenameColumn(
                name: "QUANTITYRECEIVED",
                table: "PURCHASEORDERDETAILS",
                newName: "quantityreceived");

            migrationBuilder.RenameColumn(
                name: "QUANTITYORDERED",
                table: "PURCHASEORDERDETAILS",
                newName: "quantityordered");

            migrationBuilder.RenameColumn(
                name: "PURCHASEORDERID",
                table: "PURCHASEORDERDETAILS",
                newName: "purchaseorderid");

            migrationBuilder.RenameColumn(
                name: "PRODUCTSKUID",
                table: "PURCHASEORDERDETAILS",
                newName: "productskuid");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "PURCHASEORDERDETAILS",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UPDATEDAT",
                table: "PURCHASEORDERDETAILS",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "ISDELETED",
                table: "PURCHASEORDERDETAILS",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "CREATEDAT",
                table: "PURCHASEORDERDETAILS",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_PURCHASEORDERDETAILS_PURCHASEORDERID",
                table: "PURCHASEORDERDETAILS",
                newName: "IX_PURCHASEORDERDETAILS_purchaseorderid");

            migrationBuilder.RenameIndex(
                name: "IX_PURCHASEORDERDETAILS_PRODUCTSKUID",
                table: "PURCHASEORDERDETAILS",
                newName: "IX_PURCHASEORDERDETAILS_productskuid");

            migrationBuilder.RenameColumn(
                name: "PRODUCTID",
                table: "PRODUCTSKUS",
                newName: "productid");

            migrationBuilder.RenameColumn(
                name: "ISACTIVE",
                table: "PRODUCTSKUS",
                newName: "isactive");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "PRODUCTSKUS",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UPDATEDAT",
                table: "PRODUCTSKUS",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "ISDELETED",
                table: "PRODUCTSKUS",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "CREATEDAT",
                table: "PRODUCTSKUS",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_PRODUCTSKUS_PRODUCTID",
                table: "PRODUCTSKUS",
                newName: "IX_PRODUCTSKUS_productid");

            migrationBuilder.RenameColumn(
                name: "PRICE",
                table: "PRODUCTS",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "ISACTIVE",
                table: "PRODUCTS",
                newName: "isactive");

            migrationBuilder.RenameColumn(
                name: "IMAGEURL",
                table: "PRODUCTS",
                newName: "imageurl");

            migrationBuilder.RenameColumn(
                name: "DESCRIPTION",
                table: "PRODUCTS",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "PRODUCTS",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UPDATEDAT",
                table: "PRODUCTS",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "ISDELETED",
                table: "PRODUCTS",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "CREATEDAT",
                table: "PRODUCTS",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "PRODUCTID",
                table: "productimages",
                newName: "productid");

            migrationBuilder.RenameColumn(
                name: "IMAGEURL",
                table: "productimages",
                newName: "imageurl");

            migrationBuilder.RenameColumn(
                name: "DISPLAYORDER",
                table: "productimages",
                newName: "displayorder");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "productimages",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UPDATEDAT",
                table: "productimages",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "ISDELETED",
                table: "productimages",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "CREATEDAT",
                table: "productimages",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_PRODUCTIMAGES_PRODUCTID",
                table: "productimages",
                newName: "IX_productimages_productid");

            migrationBuilder.RenameColumn(
                name: "STATUS",
                table: "PAYROLLS",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "PROCESSEDDATE",
                table: "PAYROLLS",
                newName: "processeddate");

            migrationBuilder.RenameColumn(
                name: "NOTE",
                table: "PAYROLLS",
                newName: "note");

            migrationBuilder.RenameColumn(
                name: "EMPLOYEEID",
                table: "PAYROLLS",
                newName: "employeeid");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "PAYROLLS",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UPDATEDAT",
                table: "PAYROLLS",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "ISDELETED",
                table: "PAYROLLS",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "CREATEDAT",
                table: "PAYROLLS",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_PAYROLLS_EMPLOYEEID",
                table: "PAYROLLS",
                newName: "IX_PAYROLLS_employeeid");

            migrationBuilder.RenameColumn(
                name: "SALARYCOMPONENTID",
                table: "PAYROLLITEMS",
                newName: "salarycomponentid");

            migrationBuilder.RenameColumn(
                name: "PAYROLLID",
                table: "PAYROLLITEMS",
                newName: "payrollid");

            migrationBuilder.RenameColumn(
                name: "NOTE",
                table: "PAYROLLITEMS",
                newName: "note");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "PAYROLLITEMS",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UPDATEDAT",
                table: "PAYROLLITEMS",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "ISDELETED",
                table: "PAYROLLITEMS",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "CREATEDAT",
                table: "PAYROLLITEMS",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_PAYROLLITEMS_SALARYCOMPONENTID",
                table: "PAYROLLITEMS",
                newName: "IX_PAYROLLITEMS_salarycomponentid");

            migrationBuilder.RenameIndex(
                name: "IX_PAYROLLITEMS_PAYROLLID",
                table: "PAYROLLITEMS",
                newName: "IX_PAYROLLITEMS_payrollid");

            migrationBuilder.RenameColumn(
                name: "VOUCHERID",
                table: "ORDERS",
                newName: "voucherid");

            migrationBuilder.RenameColumn(
                name: "USERID",
                table: "ORDERS",
                newName: "userid");

            migrationBuilder.RenameColumn(
                name: "STOREID",
                table: "ORDERS",
                newName: "storeid");

            migrationBuilder.RenameColumn(
                name: "POINTSEARNED",
                table: "ORDERS",
                newName: "pointsearned");

            migrationBuilder.RenameColumn(
                name: "PHONE",
                table: "ORDERS",
                newName: "phone");

            migrationBuilder.RenameColumn(
                name: "PAYMENTSTATUS",
                table: "ORDERS",
                newName: "paymentstatus");

            migrationBuilder.RenameColumn(
                name: "PAYMENTMETHOD",
                table: "ORDERS",
                newName: "paymentmethod");

            migrationBuilder.RenameColumn(
                name: "NOTE",
                table: "ORDERS",
                newName: "note");

            migrationBuilder.RenameColumn(
                name: "DISCOUNTAMOUNT",
                table: "ORDERS",
                newName: "discountamount");

            migrationBuilder.RenameColumn(
                name: "CUSTOMERNAME",
                table: "ORDERS",
                newName: "customername");

            migrationBuilder.RenameColumn(
                name: "CUSTOMERID",
                table: "ORDERS",
                newName: "customerid");

            migrationBuilder.RenameColumn(
                name: "ADDRESS",
                table: "ORDERS",
                newName: "address");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "ORDERS",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UPDATEDAT",
                table: "ORDERS",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "ISDELETED",
                table: "ORDERS",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "CREATEDAT",
                table: "ORDERS",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_ORDERS_VOUCHERID",
                table: "ORDERS",
                newName: "IX_ORDERS_voucherid");

            migrationBuilder.RenameIndex(
                name: "IX_ORDERS_USERID",
                table: "ORDERS",
                newName: "IX_ORDERS_userid");

            migrationBuilder.RenameIndex(
                name: "IX_ORDERS_STOREID",
                table: "ORDERS",
                newName: "IX_ORDERS_storeid");

            migrationBuilder.RenameIndex(
                name: "IX_ORDERS_CUSTOMERID",
                table: "ORDERS",
                newName: "IX_ORDERS_customerid");

            migrationBuilder.RenameColumn(
                name: "QUANTITY",
                table: "ORDERDETAILS",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "PRODUCTSKUID",
                table: "ORDERDETAILS",
                newName: "productskuid");

            migrationBuilder.RenameColumn(
                name: "PRODUCTID",
                table: "ORDERDETAILS",
                newName: "productid");

            migrationBuilder.RenameColumn(
                name: "ORDERID",
                table: "ORDERDETAILS",
                newName: "orderid");

            migrationBuilder.RenameColumn(
                name: "DISCOUNTPERCENT",
                table: "ORDERDETAILS",
                newName: "discountpercent");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "ORDERDETAILS",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UPDATEDAT",
                table: "ORDERDETAILS",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "ISDELETED",
                table: "ORDERDETAILS",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "CREATEDAT",
                table: "ORDERDETAILS",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_ORDERDETAILS_PRODUCTSKUID",
                table: "ORDERDETAILS",
                newName: "IX_ORDERDETAILS_productskuid");

            migrationBuilder.RenameIndex(
                name: "IX_ORDERDETAILS_PRODUCTID",
                table: "ORDERDETAILS",
                newName: "IX_ORDERDETAILS_productid");

            migrationBuilder.RenameIndex(
                name: "IX_ORDERDETAILS_ORDERID",
                table: "ORDERDETAILS",
                newName: "IX_ORDERDETAILS_orderid");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "NOTIFICATIONS",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UPDATEDAT",
                table: "NOTIFICATIONS",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "ISDELETED",
                table: "NOTIFICATIONS",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "CREATEDAT",
                table: "NOTIFICATIONS",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "POINTS",
                table: "LOYALTYTRANSACTIONS",
                newName: "points");

            migrationBuilder.RenameColumn(
                name: "ORDERID",
                table: "LOYALTYTRANSACTIONS",
                newName: "orderid");

            migrationBuilder.RenameColumn(
                name: "DESCRIPTION",
                table: "LOYALTYTRANSACTIONS",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "CUSTOMERID",
                table: "LOYALTYTRANSACTIONS",
                newName: "customerid");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "LOYALTYTRANSACTIONS",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UPDATEDAT",
                table: "LOYALTYTRANSACTIONS",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "ISDELETED",
                table: "LOYALTYTRANSACTIONS",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "CREATEDAT",
                table: "LOYALTYTRANSACTIONS",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_LOYALTYTRANSACTIONS_ORDERID",
                table: "LOYALTYTRANSACTIONS",
                newName: "IX_LOYALTYTRANSACTIONS_orderid");

            migrationBuilder.RenameIndex(
                name: "IX_LOYALTYTRANSACTIONS_CUSTOMERID",
                table: "LOYALTYTRANSACTIONS",
                newName: "IX_LOYALTYTRANSACTIONS_customerid");

            migrationBuilder.RenameColumn(
                name: "TYPE",
                table: "LEAVEREQUESTS",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "STATUS",
                table: "LEAVEREQUESTS",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "STARTDATE",
                table: "LEAVEREQUESTS",
                newName: "startdate");

            migrationBuilder.RenameColumn(
                name: "REASON",
                table: "LEAVEREQUESTS",
                newName: "reason");

            migrationBuilder.RenameColumn(
                name: "ENDDATE",
                table: "LEAVEREQUESTS",
                newName: "enddate");

            migrationBuilder.RenameColumn(
                name: "EMPLOYEEID",
                table: "LEAVEREQUESTS",
                newName: "employeeid");

            migrationBuilder.RenameColumn(
                name: "APPROVEDBYID",
                table: "LEAVEREQUESTS",
                newName: "approvedbyid");

            migrationBuilder.RenameColumn(
                name: "ADMINNOTE",
                table: "LEAVEREQUESTS",
                newName: "adminnote");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "LEAVEREQUESTS",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UPDATEDAT",
                table: "LEAVEREQUESTS",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "ISDELETED",
                table: "LEAVEREQUESTS",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "CREATEDAT",
                table: "LEAVEREQUESTS",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_LEAVEREQUESTS_EMPLOYEEID",
                table: "LEAVEREQUESTS",
                newName: "IX_LEAVEREQUESTS_employeeid");

            migrationBuilder.RenameColumn(
                name: "YEAR",
                table: "LEAVEBALANCES",
                newName: "year");

            migrationBuilder.RenameColumn(
                name: "SICKDAYSUSED",
                table: "LEAVEBALANCES",
                newName: "sickdaysused");

            migrationBuilder.RenameColumn(
                name: "SICKDAYSTOTAL",
                table: "LEAVEBALANCES",
                newName: "sickdaystotal");

            migrationBuilder.RenameColumn(
                name: "EMPLOYEEID",
                table: "LEAVEBALANCES",
                newName: "employeeid");

            migrationBuilder.RenameColumn(
                name: "ANNUALDAYSUSED",
                table: "LEAVEBALANCES",
                newName: "annualdaysused");

            migrationBuilder.RenameColumn(
                name: "ANNUALDAYSTOTAL",
                table: "LEAVEBALANCES",
                newName: "annualdaystotal");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "LEAVEBALANCES",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UPDATEDAT",
                table: "LEAVEBALANCES",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "ISDELETED",
                table: "LEAVEBALANCES",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "CREATEDAT",
                table: "LEAVEBALANCES",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_LEAVEBALANCES_EMPLOYEEID",
                table: "LEAVEBALANCES",
                newName: "IX_LEAVEBALANCES_employeeid");

            migrationBuilder.RenameColumn(
                name: "YEAR",
                table: "KPIREVIEWS",
                newName: "year");

            migrationBuilder.RenameColumn(
                name: "TOTALSCORE",
                table: "KPIREVIEWS",
                newName: "totalscore");

            migrationBuilder.RenameColumn(
                name: "TEAMWORKSCORE",
                table: "KPIREVIEWS",
                newName: "teamworkscore");

            migrationBuilder.RenameColumn(
                name: "SALESSCORE",
                table: "KPIREVIEWS",
                newName: "salesscore");

            migrationBuilder.RenameColumn(
                name: "REVIEWERID",
                table: "KPIREVIEWS",
                newName: "reviewerid");

            migrationBuilder.RenameColumn(
                name: "RANK",
                table: "KPIREVIEWS",
                newName: "rank");

            migrationBuilder.RenameColumn(
                name: "NOTES",
                table: "KPIREVIEWS",
                newName: "notes");

            migrationBuilder.RenameColumn(
                name: "MONTH",
                table: "KPIREVIEWS",
                newName: "month");

            migrationBuilder.RenameColumn(
                name: "EMPLOYEEID",
                table: "KPIREVIEWS",
                newName: "employeeid");

            migrationBuilder.RenameColumn(
                name: "ATTITUDESCORE",
                table: "KPIREVIEWS",
                newName: "attitudescore");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "KPIREVIEWS",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UPDATEDAT",
                table: "KPIREVIEWS",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "ISDELETED",
                table: "KPIREVIEWS",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "CREATEDAT",
                table: "KPIREVIEWS",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_KPIREVIEWS_REVIEWERID",
                table: "KPIREVIEWS",
                newName: "IX_KPIREVIEWS_reviewerid");

            migrationBuilder.RenameIndex(
                name: "IX_KPIREVIEWS_EMPLOYEEID",
                table: "KPIREVIEWS",
                newName: "IX_KPIREVIEWS_employeeid");

            migrationBuilder.RenameColumn(
                name: "STOREID",
                table: "INVENTORIES",
                newName: "storeid");

            migrationBuilder.RenameColumn(
                name: "REORDERPOINT",
                table: "INVENTORIES",
                newName: "reorderpoint");

            migrationBuilder.RenameColumn(
                name: "QUANTITYONHAND",
                table: "INVENTORIES",
                newName: "quantityonhand");

            migrationBuilder.RenameColumn(
                name: "PRODUCTSKUID",
                table: "INVENTORIES",
                newName: "productskuid");

            migrationBuilder.RenameColumn(
                name: "MAXSTOCKLEVEL",
                table: "INVENTORIES",
                newName: "maxstocklevel");

            migrationBuilder.RenameColumn(
                name: "LASTUPDATED",
                table: "INVENTORIES",
                newName: "lastupdated");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "INVENTORIES",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UPDATEDAT",
                table: "INVENTORIES",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "ISDELETED",
                table: "INVENTORIES",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "CREATEDAT",
                table: "INVENTORIES",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_INVENTORIES_STOREID",
                table: "INVENTORIES",
                newName: "IX_INVENTORIES_storeid");

            migrationBuilder.RenameIndex(
                name: "IX_INVENTORIES_PRODUCTSKUID",
                table: "INVENTORIES",
                newName: "IX_INVENTORIES_productskuid");

            migrationBuilder.RenameColumn(
                name: "USERID",
                table: "executivealerts",
                newName: "userid");

            migrationBuilder.RenameColumn(
                name: "TYPE",
                table: "executivealerts",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "TITLE",
                table: "executivealerts",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "SUBCATEGORY",
                table: "executivealerts",
                newName: "subcategory");

            migrationBuilder.RenameColumn(
                name: "SOURCESYSTEM",
                table: "executivealerts",
                newName: "sourcesystem");

            migrationBuilder.RenameColumn(
                name: "READAT",
                table: "executivealerts",
                newName: "readat");

            migrationBuilder.RenameColumn(
                name: "PRIORITY",
                table: "executivealerts",
                newName: "priority");

            migrationBuilder.RenameColumn(
                name: "ISREAD",
                table: "executivealerts",
                newName: "isread");

            migrationBuilder.RenameColumn(
                name: "ISARCHIVED",
                table: "executivealerts",
                newName: "isarchived");

            migrationBuilder.RenameColumn(
                name: "IMPACT",
                table: "executivealerts",
                newName: "impact");

            migrationBuilder.RenameColumn(
                name: "EXPIRESAT",
                table: "executivealerts",
                newName: "expiresat");

            migrationBuilder.RenameColumn(
                name: "DESCRIPTION",
                table: "executivealerts",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "CATEGORY",
                table: "executivealerts",
                newName: "category");

            migrationBuilder.RenameColumn(
                name: "ACTIONREQUIRED",
                table: "executivealerts",
                newName: "actionrequired");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "executivealerts",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UPDATEDAT",
                table: "executivealerts",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "ISDELETED",
                table: "executivealerts",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "CREATEDAT",
                table: "executivealerts",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_EXECUTIVEALERTS_USERID",
                table: "executivealerts",
                newName: "IX_executivealerts_userid");

            migrationBuilder.RenameColumn(
                name: "USERID",
                table: "EMPLOYEES",
                newName: "userid");

            migrationBuilder.RenameColumn(
                name: "STOREID",
                table: "EMPLOYEES",
                newName: "storeid");

            migrationBuilder.RenameColumn(
                name: "PHONE",
                table: "EMPLOYEES",
                newName: "phone");

            migrationBuilder.RenameColumn(
                name: "ISACTIVE",
                table: "EMPLOYEES",
                newName: "isactive");

            migrationBuilder.RenameColumn(
                name: "HIREDATE",
                table: "EMPLOYEES",
                newName: "hiredate");

            migrationBuilder.RenameColumn(
                name: "EMAIL",
                table: "EMPLOYEES",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "DEPARTMENTID",
                table: "EMPLOYEES",
                newName: "departmentid");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "EMPLOYEES",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UPDATEDAT",
                table: "EMPLOYEES",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "ISDELETED",
                table: "EMPLOYEES",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "CREATEDAT",
                table: "EMPLOYEES",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_EMPLOYEES_STOREID",
                table: "EMPLOYEES",
                newName: "IX_EMPLOYEES_storeid");

            migrationBuilder.RenameIndex(
                name: "IX_EMPLOYEES_DEPARTMENTID",
                table: "EMPLOYEES",
                newName: "IX_EMPLOYEES_departmentid");

            migrationBuilder.RenameColumn(
                name: "ISACTIVE",
                table: "DEPARTMENTS",
                newName: "isactive");

            migrationBuilder.RenameColumn(
                name: "DESCRIPTION",
                table: "DEPARTMENTS",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "DEPARTMENTS",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UPDATEDAT",
                table: "DEPARTMENTS",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "ISDELETED",
                table: "DEPARTMENTS",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "CREATEDAT",
                table: "DEPARTMENTS",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "USERID",
                table: "CUSTOMERS",
                newName: "userid");

            migrationBuilder.RenameColumn(
                name: "TIER",
                table: "CUSTOMERS",
                newName: "tier");

            migrationBuilder.RenameColumn(
                name: "LOYALTYPOINTS",
                table: "CUSTOMERS",
                newName: "loyaltypoints");

            migrationBuilder.RenameColumn(
                name: "JOINDATE",
                table: "CUSTOMERS",
                newName: "joindate");

            migrationBuilder.RenameColumn(
                name: "DATEOFBIRTH",
                table: "CUSTOMERS",
                newName: "dateofbirth");

            migrationBuilder.RenameColumn(
                name: "ADDRESS",
                table: "CUSTOMERS",
                newName: "address");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "CUSTOMERS",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UPDATEDAT",
                table: "CUSTOMERS",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "ISDELETED",
                table: "CUSTOMERS",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "CREATEDAT",
                table: "CUSTOMERS",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_CUSTOMERS_USERID",
                table: "CUSTOMERS",
                newName: "IX_CUSTOMERS_userid");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "CATEGORIES",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UPDATEDAT",
                table: "CATEGORIES",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "ISDELETED",
                table: "CATEGORIES",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "CREATEDAT",
                table: "CATEGORIES",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "VOUCHERID",
                table: "CAMPAIGNS",
                newName: "voucherid");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "CAMPAIGNS",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UPDATEDAT",
                table: "CAMPAIGNS",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "ISDELETED",
                table: "CAMPAIGNS",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "CREATEDAT",
                table: "CAMPAIGNS",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_CAMPAIGNS_VOUCHERID",
                table: "CAMPAIGNS",
                newName: "IX_CAMPAIGNS_voucherid");

            migrationBuilder.RenameColumn(
                name: "TITLE",
                table: "BANNERS",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "SUBTITLE",
                table: "BANNERS",
                newName: "subtitle");

            migrationBuilder.RenameColumn(
                name: "POSITION",
                table: "BANNERS",
                newName: "position");

            migrationBuilder.RenameColumn(
                name: "LINKURL",
                table: "BANNERS",
                newName: "linkurl");

            migrationBuilder.RenameColumn(
                name: "ISACTIVE",
                table: "BANNERS",
                newName: "isactive");

            migrationBuilder.RenameColumn(
                name: "IMAGEURL",
                table: "BANNERS",
                newName: "imageurl");

            migrationBuilder.RenameColumn(
                name: "DISPLAYORDER",
                table: "BANNERS",
                newName: "displayorder");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "BANNERS",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UPDATEDAT",
                table: "BANNERS",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "ISDELETED",
                table: "BANNERS",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "CREATEDAT",
                table: "BANNERS",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "STATUS",
                table: "ATTENDANCES",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "NOTE",
                table: "ATTENDANCES",
                newName: "note");

            migrationBuilder.RenameColumn(
                name: "EMPLOYEEID",
                table: "ATTENDANCES",
                newName: "employeeid");

            migrationBuilder.RenameColumn(
                name: "CHECKOUT",
                table: "ATTENDANCES",
                newName: "checkout");

            migrationBuilder.RenameColumn(
                name: "CHECKIN",
                table: "ATTENDANCES",
                newName: "checkin");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "ATTENDANCES",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UPDATEDAT",
                table: "ATTENDANCES",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "ISDELETED",
                table: "ATTENDANCES",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "CREATEDAT",
                table: "ATTENDANCES",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_ATTENDANCES_EMPLOYEEID",
                table: "ATTENDANCES",
                newName: "IX_ATTENDANCES_employeeid");

            migrationBuilder.RenameColumn(
                name: "USERNAME",
                table: "ASPNETUSERS",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "TWOFACTORENABLED",
                table: "ASPNETUSERS",
                newName: "twofactorenabled");

            migrationBuilder.RenameColumn(
                name: "SECURITYSTAMP",
                table: "ASPNETUSERS",
                newName: "securitystamp");

            migrationBuilder.RenameColumn(
                name: "PHONENUMBERCONFIRMED",
                table: "ASPNETUSERS",
                newName: "phonenumberconfirmed");

            migrationBuilder.RenameColumn(
                name: "PHONENUMBER",
                table: "ASPNETUSERS",
                newName: "phonenumber");

            migrationBuilder.RenameColumn(
                name: "PASSWORDHASH",
                table: "ASPNETUSERS",
                newName: "passwordhash");

            migrationBuilder.RenameColumn(
                name: "NORMALIZEDUSERNAME",
                table: "ASPNETUSERS",
                newName: "normalizedusername");

            migrationBuilder.RenameColumn(
                name: "NORMALIZEDEMAIL",
                table: "ASPNETUSERS",
                newName: "normalizedemail");

            migrationBuilder.RenameColumn(
                name: "MEMBERSHIPPOINTS",
                table: "ASPNETUSERS",
                newName: "membershippoints");

            migrationBuilder.RenameColumn(
                name: "LOCKOUTEND",
                table: "ASPNETUSERS",
                newName: "lockoutend");

            migrationBuilder.RenameColumn(
                name: "LOCKOUTENABLED",
                table: "ASPNETUSERS",
                newName: "lockoutenabled");

            migrationBuilder.RenameColumn(
                name: "JOINDATE",
                table: "ASPNETUSERS",
                newName: "joindate");

            migrationBuilder.RenameColumn(
                name: "GENDER",
                table: "ASPNETUSERS",
                newName: "gender");

            migrationBuilder.RenameColumn(
                name: "FULLNAME",
                table: "ASPNETUSERS",
                newName: "fullname");

            migrationBuilder.RenameColumn(
                name: "EMAILCONFIRMED",
                table: "ASPNETUSERS",
                newName: "emailconfirmed");

            migrationBuilder.RenameColumn(
                name: "EMAIL",
                table: "ASPNETUSERS",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "DATEOFBIRTH",
                table: "ASPNETUSERS",
                newName: "dateofbirth");

            migrationBuilder.RenameColumn(
                name: "CONCURRENCYSTAMP",
                table: "ASPNETUSERS",
                newName: "concurrencystamp");

            migrationBuilder.RenameColumn(
                name: "AVATARURL",
                table: "ASPNETUSERS",
                newName: "avatarurl");

            migrationBuilder.RenameColumn(
                name: "ACCESSFAILEDCOUNT",
                table: "ASPNETUSERS",
                newName: "accessfailedcount");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "ASPNETUSERS",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "PROVIDERDISPLAYNAME",
                table: "ASPNETUSERLOGINS",
                newName: "providerdisplayname");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "ASPNETUSERCLAIMS",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "NORMALIZEDNAME",
                table: "ASPNETROLES",
                newName: "normalizedname");

            migrationBuilder.RenameColumn(
                name: "NAME",
                table: "ASPNETROLES",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "CONCURRENCYSTAMP",
                table: "ASPNETROLES",
                newName: "concurrencystamp");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "ASPNETROLES",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "CLAIMVALUE",
                table: "ASPNETROLECLAIMS",
                newName: "claimvalue");

            migrationBuilder.RenameColumn(
                name: "CLAIMTYPE",
                table: "ASPNETROLECLAIMS",
                newName: "claimtype");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "ASPNETROLECLAIMS",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "TAKENBYUSERID",
                table: "alertactions",
                newName: "takenbyuserid");

            migrationBuilder.RenameColumn(
                name: "EXECUTIVEALERTID",
                table: "alertactions",
                newName: "executivealertid");

            migrationBuilder.RenameColumn(
                name: "ACTIONTYPE",
                table: "alertactions",
                newName: "actiontype");

            migrationBuilder.RenameColumn(
                name: "ACTIONNOTES",
                table: "alertactions",
                newName: "actionnotes");

            migrationBuilder.RenameColumn(
                name: "ACTIONAT",
                table: "alertactions",
                newName: "actionat");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "alertactions",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UPDATEDAT",
                table: "alertactions",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "ISDELETED",
                table: "alertactions",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "CREATEDAT",
                table: "alertactions",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_ALERTACTIONS_TAKENBYUSERID",
                table: "alertactions",
                newName: "IX_alertactions_takenbyuserid");

            migrationBuilder.RenameIndex(
                name: "IX_ALERTACTIONS_EXECUTIVEALERTID",
                table: "alertactions",
                newName: "IX_alertactions_executivealertid");

            migrationBuilder.AlterColumn<string>(
                name: "USERID",
                table: "WISHLISTITEMS",
                type: "character varying(450)",
                maxLength: 450,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 450);

            migrationBuilder.AlterColumn<int>(
                name: "PRODUCTID",
                table: "WISHLISTITEMS",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "WISHLISTITEMS",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "WISHLISTITEMS",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "is_deleted",
                table: "WISHLISTITEMS",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "WISHLISTITEMS",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "USEDCOUNT",
                table: "VOUCHERS",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "MAXUSAGECOUNT",
                table: "VOUCHERS",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<bool>(
                name: "ISACTIVE",
                table: "VOUCHERS",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EXPIRYDATE",
                table: "VOUCHERS",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "CODE",
                table: "VOUCHERS",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "VOUCHERS",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "VOUCHERS",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "is_deleted",
                table: "VOUCHERS",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "VOUCHERS",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "USERID",
                table: "USERADDRESSES",
                type: "character varying(450)",
                maxLength: 450,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 450);

            migrationBuilder.AlterColumn<string>(
                name: "PHONENUMBER",
                table: "USERADDRESSES",
                type: "character varying(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<bool>(
                name: "ISDEFAULT",
                table: "USERADDRESSES",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "FULLNAME",
                table: "USERADDRESSES",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "ADDRESSLINE",
                table: "USERADDRESSES",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "USERADDRESSES",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "USERADDRESSES",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "is_deleted",
                table: "USERADDRESSES",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "USERADDRESSES",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "PHONE",
                table: "SUPPLIERS",
                type: "character varying(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "SUPPLIERS",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<int>(
                name: "leadtimedays",
                table: "SUPPLIERS",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<bool>(
                name: "isactive",
                table: "SUPPLIERS",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "EMAIL",
                table: "SUPPLIERS",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "contactperson",
                table: "SUPPLIERS",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "address",
                table: "SUPPLIERS",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "SUPPLIERS",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "SUPPLIERS",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "is_deleted",
                table: "SUPPLIERS",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "SUPPLIERS",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "PHONE",
                table: "STORES",
                type: "character varying(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "STORES",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "managername",
                table: "STORES",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<bool>(
                name: "isactive",
                table: "STORES",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "ADDRESS",
                table: "STORES",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "STORES",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "STORES",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "is_deleted",
                table: "STORES",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "STORES",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<byte>(
                name: "reason",
                table: "STOCKADJUSTMENTS",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "quantitychange",
                table: "STOCKADJUSTMENTS",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "quantitybefore",
                table: "STOCKADJUSTMENTS",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "quantityafter",
                table: "STOCKADJUSTMENTS",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "note",
                table: "STOCKADJUSTMENTS",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "inventoryid",
                table: "STOCKADJUSTMENTS",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "adjustedbyuserid",
                table: "STOCKADJUSTMENTS",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "STOCKADJUSTMENTS",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "STOCKADJUSTMENTS",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "is_deleted",
                table: "STOCKADJUSTMENTS",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "STOCKADJUSTMENTS",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "storeid",
                table: "SHIFTS",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "starttime",
                table: "SHIFTS",
                type: "interval",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "SHIFTS",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<bool>(
                name: "isactive",
                table: "SHIFTS",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "endtime",
                table: "SHIFTS",
                type: "interval",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "SHIFTS",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "SHIFTS",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "is_deleted",
                table: "SHIFTS",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "SHIFTS",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<byte>(
                name: "status",
                table: "SCHEDULES",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "shiftid",
                table: "SCHEDULES",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "note",
                table: "SCHEDULES",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "employeeid",
                table: "SCHEDULES",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date",
                table: "SCHEDULES",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "SCHEDULES",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "SCHEDULES",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "is_deleted",
                table: "SCHEDULES",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "SCHEDULES",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<byte>(
                name: "type",
                table: "SALARYCOMPONENTS",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "SALARYCOMPONENTS",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<bool>(
                name: "isactive",
                table: "SALARYCOMPONENTS",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "SALARYCOMPONENTS",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "DEFAULTAMOUNT",
                table: "SALARYCOMPONENTS",
                type: "numeric(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(12,2)");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "SALARYCOMPONENTS",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "SALARYCOMPONENTS",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "is_deleted",
                table: "SALARYCOMPONENTS",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "SALARYCOMPONENTS",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<byte>(
                name: "STATUS",
                table: "RETURNREQUESTS",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "REASON",
                table: "RETURNREQUESTS",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PROCESSEDAT",
                table: "RETURNREQUESTS",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ORDERID",
                table: "RETURNREQUESTS",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "ADMINNOTE",
                table: "RETURNREQUESTS",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "RETURNREQUESTS",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "RETURNREQUESTS",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "is_deleted",
                table: "RETURNREQUESTS",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "RETURNREQUESTS",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "supplierid",
                table: "PURCHASEORDERS",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "storeid",
                table: "PURCHASEORDERS",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<byte>(
                name: "status",
                table: "PURCHASEORDERS",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "receiveddate",
                table: "PURCHASEORDERS",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "POCODE",
                table: "PURCHASEORDERS",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<DateTime>(
                name: "orderdate",
                table: "PURCHASEORDERS",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "note",
                table: "PURCHASEORDERS",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "expecteddate",
                table: "PURCHASEORDERS",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "PURCHASEORDERS",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "PURCHASEORDERS",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "is_deleted",
                table: "PURCHASEORDERS",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "PURCHASEORDERS",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "quantityreceived",
                table: "PURCHASEORDERDETAILS",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "quantityordered",
                table: "PURCHASEORDERDETAILS",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "purchaseorderid",
                table: "PURCHASEORDERDETAILS",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "productskuid",
                table: "PURCHASEORDERDETAILS",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "PURCHASEORDERDETAILS",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "PURCHASEORDERDETAILS",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "is_deleted",
                table: "PURCHASEORDERDETAILS",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "PURCHASEORDERDETAILS",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "STOCK",
                table: "PRODUCTSKUS",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "SKUCODE",
                table: "PRODUCTSKUS",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "SKU",
                table: "PRODUCTSKUS",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "SIZE",
                table: "PRODUCTSKUS",
                type: "character varying(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<decimal>(
                name: "SELLINGPRICE",
                table: "PRODUCTSKUS",
                type: "numeric(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(12,2)");

            migrationBuilder.AlterColumn<int>(
                name: "productid",
                table: "PRODUCTSKUS",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<decimal>(
                name: "PRICEOVERRIDE",
                table: "PRODUCTSKUS",
                type: "numeric(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(12,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "isactive",
                table: "PRODUCTSKUS",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<decimal>(
                name: "COSTPRICE",
                table: "PRODUCTSKUS",
                type: "numeric(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(12,2)");

            migrationBuilder.AlterColumn<string>(
                name: "COLOR",
                table: "PRODUCTSKUS",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "PRODUCTSKUS",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "PRODUCTSKUS",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "is_deleted",
                table: "PRODUCTSKUS",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "PRODUCTSKUS",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "SUPPLIERID",
                table: "PRODUCTS",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "STOCK",
                table: "PRODUCTS",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<string>(
                name: "SLUG",
                table: "PRODUCTS",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<decimal>(
                name: "price",
                table: "PRODUCTS",
                type: "numeric(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(12,2)");

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "PRODUCTS",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<bool>(
                name: "isactive",
                table: "PRODUCTS",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "imageurl",
                table: "PRODUCTS",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "PRODUCTS",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CATEGORYID",
                table: "PRODUCTS",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "PRODUCTS",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "PRODUCTS",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "is_deleted",
                table: "PRODUCTS",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "PRODUCTS",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "productid",
                table: "productimages",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "imageurl",
                table: "productimages",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "displayorder",
                table: "productimages",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "productimages",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "productimages",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "is_deleted",
                table: "productimages",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "productimages",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "YEAR",
                table: "PAYROLLS",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<double>(
                name: "TOTALHOURSWORKED",
                table: "PAYROLLS",
                type: "numeric(8,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "NUMBER(8,2)");

            migrationBuilder.AlterColumn<byte>(
                name: "status",
                table: "PAYROLLS",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "processeddate",
                table: "PAYROLLS",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "note",
                table: "PAYROLLS",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MONTH",
                table: "PAYROLLS",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "employeeid",
                table: "PAYROLLS",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<decimal>(
                name: "BASEHOURLYRATE",
                table: "PAYROLLS",
                type: "numeric(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(12,2)");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "PAYROLLS",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "PAYROLLS",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "is_deleted",
                table: "PAYROLLS",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "PAYROLLS",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "salarycomponentid",
                table: "PAYROLLITEMS",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "payrollid",
                table: "PAYROLLITEMS",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "note",
                table: "PAYROLLITEMS",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "PAYROLLITEMS",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "PAYROLLITEMS",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "is_deleted",
                table: "PAYROLLITEMS",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "PAYROLLITEMS",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "voucherid",
                table: "ORDERS",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "userid",
                table: "ORDERS",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TOTALAMOUNT",
                table: "ORDERS",
                type: "numeric(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric(14,0)",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "SUBTOTAL",
                table: "ORDERS",
                type: "numeric(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric(14,0)",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<int>(
                name: "storeid",
                table: "ORDERS",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<byte>(
                name: "STATUS",
                table: "ORDERS",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "pointsearned",
                table: "ORDERS",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "phone",
                table: "ORDERS",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "paymentstatus",
                table: "ORDERS",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<byte>(
                name: "paymentmethod",
                table: "ORDERS",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "ORDERCODE",
                table: "ORDERS",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "note",
                table: "ORDERS",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "discountamount",
                table: "ORDERS",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldDefaultValue: "0");

            migrationBuilder.AlterColumn<string>(
                name: "customername",
                table: "ORDERS",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "customerid",
                table: "ORDERS",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "address",
                table: "ORDERS",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "ORDERS",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "ORDERS",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "is_deleted",
                table: "ORDERS",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "ORDERS",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<decimal>(
                name: "UNITPRICE",
                table: "ORDERDETAILS",
                type: "numeric(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(12,0)");

            migrationBuilder.AlterColumn<decimal>(
                name: "SUBTOTAL",
                table: "ORDERDETAILS",
                type: "numeric(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(14,0)");

            migrationBuilder.AlterColumn<int>(
                name: "quantity",
                table: "ORDERDETAILS",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "productskuid",
                table: "ORDERDETAILS",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "productid",
                table: "ORDERDETAILS",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "orderid",
                table: "ORDERDETAILS",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<decimal>(
                name: "discountpercent",
                table: "ORDERDETAILS",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldDefaultValue: "0");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "ORDERDETAILS",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "ORDERDETAILS",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "is_deleted",
                table: "ORDERDETAILS",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "ORDERDETAILS",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "USERID",
                table: "NOTIFICATIONS",
                type: "character varying(450)",
                maxLength: 450,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 450);

            migrationBuilder.AlterColumn<string>(
                name: "TITLE",
                table: "NOTIFICATIONS",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "MESSAGE",
                table: "NOTIFICATIONS",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<bool>(
                name: "ISREAD",
                table: "NOTIFICATIONS",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "ACTIONURL",
                table: "NOTIFICATIONS",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "NOTIFICATIONS",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "NOTIFICATIONS",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "is_deleted",
                table: "NOTIFICATIONS",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "NOTIFICATIONS",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "points",
                table: "LOYALTYTRANSACTIONS",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "orderid",
                table: "LOYALTYTRANSACTIONS",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "LOYALTYTRANSACTIONS",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "customerid",
                table: "LOYALTYTRANSACTIONS",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "LOYALTYTRANSACTIONS",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "LOYALTYTRANSACTIONS",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "is_deleted",
                table: "LOYALTYTRANSACTIONS",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "LOYALTYTRANSACTIONS",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<byte>(
                name: "type",
                table: "LEAVEREQUESTS",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<byte>(
                name: "status",
                table: "LEAVEREQUESTS",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "startdate",
                table: "LEAVEREQUESTS",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "reason",
                table: "LEAVEREQUESTS",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "enddate",
                table: "LEAVEREQUESTS",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "employeeid",
                table: "LEAVEREQUESTS",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "approvedbyid",
                table: "LEAVEREQUESTS",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "adminnote",
                table: "LEAVEREQUESTS",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "LEAVEREQUESTS",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "LEAVEREQUESTS",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "is_deleted",
                table: "LEAVEREQUESTS",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "LEAVEREQUESTS",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "year",
                table: "LEAVEBALANCES",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "sickdaysused",
                table: "LEAVEBALANCES",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "sickdaystotal",
                table: "LEAVEBALANCES",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "employeeid",
                table: "LEAVEBALANCES",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "annualdaysused",
                table: "LEAVEBALANCES",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "annualdaystotal",
                table: "LEAVEBALANCES",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "LEAVEBALANCES",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "LEAVEBALANCES",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "is_deleted",
                table: "LEAVEBALANCES",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "LEAVEBALANCES",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "year",
                table: "KPIREVIEWS",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<decimal>(
                name: "totalscore",
                table: "KPIREVIEWS",
                type: "numeric(10,2)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<decimal>(
                name: "teamworkscore",
                table: "KPIREVIEWS",
                type: "numeric(10,2)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<decimal>(
                name: "salesscore",
                table: "KPIREVIEWS",
                type: "numeric(10,2)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "reviewerid",
                table: "KPIREVIEWS",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<byte>(
                name: "rank",
                table: "KPIREVIEWS",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "notes",
                table: "KPIREVIEWS",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "month",
                table: "KPIREVIEWS",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "employeeid",
                table: "KPIREVIEWS",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<decimal>(
                name: "attitudescore",
                table: "KPIREVIEWS",
                type: "numeric(10,2)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "KPIREVIEWS",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "KPIREVIEWS",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "is_deleted",
                table: "KPIREVIEWS",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "KPIREVIEWS",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "storeid",
                table: "INVENTORIES",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "reorderpoint",
                table: "INVENTORIES",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "quantityonhand",
                table: "INVENTORIES",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "productskuid",
                table: "INVENTORIES",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "maxstocklevel",
                table: "INVENTORIES",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "lastupdated",
                table: "INVENTORIES",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "INVENTORIES",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "INVENTORIES",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "is_deleted",
                table: "INVENTORIES",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "INVENTORIES",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "userid",
                table: "executivealerts",
                type: "character varying(450)",
                maxLength: 450,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 450,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "type",
                table: "executivealerts",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "title",
                table: "executivealerts",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "subcategory",
                table: "executivealerts",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "sourcesystem",
                table: "executivealerts",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "readat",
                table: "executivealerts",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "priority",
                table: "executivealerts",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "isread",
                table: "executivealerts",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<bool>(
                name: "isarchived",
                table: "executivealerts",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "expiresat",
                table: "executivealerts",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "executivealerts",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "category",
                table: "executivealerts",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "actionrequired",
                table: "executivealerts",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "executivealerts",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "executivealerts",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "is_deleted",
                table: "executivealerts",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "executivealerts",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "userid",
                table: "EMPLOYEES",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "storeid",
                table: "EMPLOYEES",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "POSITION",
                table: "EMPLOYEES",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "phone",
                table: "EMPLOYEES",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<bool>(
                name: "isactive",
                table: "EMPLOYEES",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "hiredate",
                table: "EMPLOYEES",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "FULLNAME",
                table: "EMPLOYEES",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "EMPLOYEES",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "departmentid",
                table: "EMPLOYEES",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "BASESALARYPERHOUR",
                table: "EMPLOYEES",
                type: "numeric(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(12,2)");

            migrationBuilder.AlterColumn<string>(
                name: "BANKNAME",
                table: "EMPLOYEES",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BANKACCOUNTNUMBER",
                table: "EMPLOYEES",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BANKACCOUNTNAME",
                table: "EMPLOYEES",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "EMPLOYEES",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "EMPLOYEES",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "is_deleted",
                table: "EMPLOYEES",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "EMPLOYEES",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "DEPARTMENTS",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<bool>(
                name: "isactive",
                table: "DEPARTMENTS",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "DEPARTMENTS",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "DEPARTMENTS",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "DEPARTMENTS",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "is_deleted",
                table: "DEPARTMENTS",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "DEPARTMENTS",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "userid",
                table: "CUSTOMERS",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "tier",
                table: "CUSTOMERS",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "PHONE",
                table: "CUSTOMERS",
                type: "character varying(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<int>(
                name: "loyaltypoints",
                table: "CUSTOMERS",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "joindate",
                table: "CUSTOMERS",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "FULLNAME",
                table: "CUSTOMERS",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "EMAIL",
                table: "CUSTOMERS",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "dateofbirth",
                table: "CUSTOMERS",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "address",
                table: "CUSTOMERS",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "CUSTOMERS",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "CUSTOMERS",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "is_deleted",
                table: "CUSTOMERS",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "CUSTOMERS",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "SLUG",
                table: "CATEGORIES",
                type: "character varying(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PARENTCATEGORYID",
                table: "CATEGORIES",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "CATEGORIES",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<bool>(
                name: "ISACTIVE",
                table: "CATEGORIES",
                type: "boolean",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldDefaultValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "IMAGEURL",
                table: "CATEGORIES",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DISPLAYORDER",
                table: "CATEGORIES",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "DESCRIPTION",
                table: "CATEGORIES",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "CATEGORIES",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "CATEGORIES",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "is_deleted",
                table: "CATEGORIES",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "CATEGORIES",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "voucherid",
                table: "CAMPAIGNS",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TARGETSEGMENT",
                table: "CAMPAIGNS",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "STARTDATE",
                table: "CAMPAIGNS",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SENTAT",
                table: "CAMPAIGNS",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RECIPIENTCOUNT",
                table: "CAMPAIGNS",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "NOTIFICATIONTITLE",
                table: "CAMPAIGNS",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "NOTIFICATIONMESSAGE",
                table: "CAMPAIGNS",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "CAMPAIGNS",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<bool>(
                name: "ISSENT",
                table: "CAMPAIGNS",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ENDDATE",
                table: "CAMPAIGNS",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "DESCRIPTION",
                table: "CAMPAIGNS",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "CAMPAIGNS",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "CAMPAIGNS",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "is_deleted",
                table: "CAMPAIGNS",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "CAMPAIGNS",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "title",
                table: "BANNERS",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "subtitle",
                table: "BANNERS",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "position",
                table: "BANNERS",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "linkurl",
                table: "BANNERS",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "isactive",
                table: "BANNERS",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "imageurl",
                table: "BANNERS",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "displayorder",
                table: "BANNERS",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "BANNERS",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "BANNERS",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "is_deleted",
                table: "BANNERS",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "BANNERS",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<double>(
                name: "TOTALHOURS",
                table: "ATTENDANCES",
                type: "numeric(5,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "NUMBER(5,2)");

            migrationBuilder.AlterColumn<byte>(
                name: "status",
                table: "ATTENDANCES",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "note",
                table: "ATTENDANCES",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "employeeid",
                table: "ATTENDANCES",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DATE",
                table: "ATTENDANCES",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "checkout",
                table: "ATTENDANCES",
                type: "interval",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "checkin",
                table: "ATTENDANCES",
                type: "interval",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "ATTENDANCES",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "ATTENDANCES",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "is_deleted",
                table: "ATTENDANCES",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "ATTENDANCES",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "VALUE",
                table: "ASPNETUSERTOKENS",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "ASPNETUSERTOKENS",
                type: "character varying(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LOGINPROVIDER",
                table: "ASPNETUSERTOKENS",
                type: "character varying(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "USERID",
                table: "ASPNETUSERTOKENS",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "username",
                table: "ASPNETUSERS",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "twofactorenabled",
                table: "ASPNETUSERS",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "securitystamp",
                table: "ASPNETUSERS",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "phonenumberconfirmed",
                table: "ASPNETUSERS",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "phonenumber",
                table: "ASPNETUSERS",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "passwordhash",
                table: "ASPNETUSERS",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "normalizedusername",
                table: "ASPNETUSERS",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "normalizedemail",
                table: "ASPNETUSERS",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "membershippoints",
                table: "ASPNETUSERS",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "lockoutend",
                table: "ASPNETUSERS",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "lockoutenabled",
                table: "ASPNETUSERS",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "joindate",
                table: "ASPNETUSERS",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "gender",
                table: "ASPNETUSERS",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "fullname",
                table: "ASPNETUSERS",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "emailconfirmed",
                table: "ASPNETUSERS",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "ASPNETUSERS",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "dateofbirth",
                table: "ASPNETUSERS",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "concurrencystamp",
                table: "ASPNETUSERS",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "avatarurl",
                table: "ASPNETUSERS",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "accessfailedcount",
                table: "ASPNETUSERS",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "id",
                table: "ASPNETUSERS",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "ROLEID",
                table: "ASPNETUSERROLES",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "USERID",
                table: "ASPNETUSERROLES",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "USERID",
                table: "ASPNETUSERLOGINS",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "providerdisplayname",
                table: "ASPNETUSERLOGINS",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PROVIDERKEY",
                table: "ASPNETUSERLOGINS",
                type: "character varying(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LOGINPROVIDER",
                table: "ASPNETUSERLOGINS",
                type: "character varying(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "USERID",
                table: "ASPNETUSERCLAIMS",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "CLAIMVALUE",
                table: "ASPNETUSERCLAIMS",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CLAIMTYPE",
                table: "ASPNETUSERCLAIMS",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "ASPNETUSERCLAIMS",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "normalizedname",
                table: "ASPNETROLES",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "ASPNETROLES",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "concurrencystamp",
                table: "ASPNETROLES",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "id",
                table: "ASPNETROLES",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "ROLEID",
                table: "ASPNETROLECLAIMS",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "claimvalue",
                table: "ASPNETROLECLAIMS",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "claimtype",
                table: "ASPNETROLECLAIMS",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "ASPNETROLECLAIMS",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "takenbyuserid",
                table: "alertactions",
                type: "character varying(450)",
                maxLength: 450,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 450);

            migrationBuilder.AlterColumn<int>(
                name: "executivealertid",
                table: "alertactions",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "actiontype",
                table: "alertactions",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "actionnotes",
                table: "alertactions",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "actionat",
                table: "alertactions",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "alertactions",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "alertactions",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "is_deleted",
                table: "alertactions",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "alertactions",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_productimages",
                table: "productimages",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_executivealerts",
                table: "executivealerts",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_alertactions",
                table: "alertactions",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_alertactions_ASPNETUSERS_takenbyuserid",
                table: "alertactions",
                column: "takenbyuserid",
                principalTable: "ASPNETUSERS",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_alertactions_executivealerts_executivealertid",
                table: "alertactions",
                column: "executivealertid",
                principalTable: "executivealerts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_executivealerts_ASPNETUSERS_userid",
                table: "executivealerts",
                column: "userid",
                principalTable: "ASPNETUSERS",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_LOYALTYTRANSACTIONS_ORDERS_orderid",
                table: "LOYALTYTRANSACTIONS",
                column: "orderid",
                principalTable: "ORDERS",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_ORDERDETAILS_PRODUCTSKUS_productskuid",
                table: "ORDERDETAILS",
                column: "productskuid",
                principalTable: "PRODUCTSKUS",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ORDERDETAILS_PRODUCTS_productid",
                table: "ORDERDETAILS",
                column: "productid",
                principalTable: "PRODUCTS",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ORDERS_ASPNETUSERS_userid",
                table: "ORDERS",
                column: "userid",
                principalTable: "ASPNETUSERS",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ORDERS_CUSTOMERS_customerid",
                table: "ORDERS",
                column: "customerid",
                principalTable: "CUSTOMERS",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ORDERS_VOUCHERS_voucherid",
                table: "ORDERS",
                column: "voucherid",
                principalTable: "VOUCHERS",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_productimages_PRODUCTS_productid",
                table: "productimages",
                column: "productid",
                principalTable: "PRODUCTS",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_alertactions_ASPNETUSERS_takenbyuserid",
                table: "alertactions");

            migrationBuilder.DropForeignKey(
                name: "FK_alertactions_executivealerts_executivealertid",
                table: "alertactions");

            migrationBuilder.DropForeignKey(
                name: "FK_executivealerts_ASPNETUSERS_userid",
                table: "executivealerts");

            migrationBuilder.DropForeignKey(
                name: "FK_LOYALTYTRANSACTIONS_ORDERS_orderid",
                table: "LOYALTYTRANSACTIONS");

            migrationBuilder.DropForeignKey(
                name: "FK_ORDERDETAILS_PRODUCTSKUS_productskuid",
                table: "ORDERDETAILS");

            migrationBuilder.DropForeignKey(
                name: "FK_ORDERDETAILS_PRODUCTS_productid",
                table: "ORDERDETAILS");

            migrationBuilder.DropForeignKey(
                name: "FK_ORDERS_ASPNETUSERS_userid",
                table: "ORDERS");

            migrationBuilder.DropForeignKey(
                name: "FK_ORDERS_CUSTOMERS_customerid",
                table: "ORDERS");

            migrationBuilder.DropForeignKey(
                name: "FK_ORDERS_VOUCHERS_voucherid",
                table: "ORDERS");

            migrationBuilder.DropForeignKey(
                name: "FK_productimages_PRODUCTS_productid",
                table: "productimages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_productimages",
                table: "productimages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_executivealerts",
                table: "executivealerts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_alertactions",
                table: "alertactions");

            migrationBuilder.RenameTable(
                name: "productimages",
                newName: "PRODUCTIMAGES");

            migrationBuilder.RenameTable(
                name: "executivealerts",
                newName: "EXECUTIVEALERTS");

            migrationBuilder.RenameTable(
                name: "alertactions",
                newName: "ALERTACTIONS");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "WISHLISTITEMS",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "WISHLISTITEMS",
                newName: "UPDATEDAT");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "WISHLISTITEMS",
                newName: "ISDELETED");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "WISHLISTITEMS",
                newName: "CREATEDAT");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "VOUCHERS",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "VOUCHERS",
                newName: "UPDATEDAT");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "VOUCHERS",
                newName: "ISDELETED");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "VOUCHERS",
                newName: "CREATEDAT");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "USERADDRESSES",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "USERADDRESSES",
                newName: "UPDATEDAT");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "USERADDRESSES",
                newName: "ISDELETED");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "USERADDRESSES",
                newName: "CREATEDAT");

            migrationBuilder.RenameColumn(
                name: "leadtimedays",
                table: "SUPPLIERS",
                newName: "LEADTIMEDAYS");

            migrationBuilder.RenameColumn(
                name: "isactive",
                table: "SUPPLIERS",
                newName: "ISACTIVE");

            migrationBuilder.RenameColumn(
                name: "contactperson",
                table: "SUPPLIERS",
                newName: "CONTACTPERSON");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "SUPPLIERS",
                newName: "ADDRESS");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "SUPPLIERS",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "SUPPLIERS",
                newName: "UPDATEDAT");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "SUPPLIERS",
                newName: "ISDELETED");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "SUPPLIERS",
                newName: "CREATEDAT");

            migrationBuilder.RenameColumn(
                name: "managername",
                table: "STORES",
                newName: "MANAGERNAME");

            migrationBuilder.RenameColumn(
                name: "isactive",
                table: "STORES",
                newName: "ISACTIVE");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "STORES",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "STORES",
                newName: "UPDATEDAT");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "STORES",
                newName: "ISDELETED");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "STORES",
                newName: "CREATEDAT");

            migrationBuilder.RenameColumn(
                name: "reason",
                table: "STOCKADJUSTMENTS",
                newName: "REASON");

            migrationBuilder.RenameColumn(
                name: "quantitychange",
                table: "STOCKADJUSTMENTS",
                newName: "QUANTITYCHANGE");

            migrationBuilder.RenameColumn(
                name: "quantitybefore",
                table: "STOCKADJUSTMENTS",
                newName: "QUANTITYBEFORE");

            migrationBuilder.RenameColumn(
                name: "quantityafter",
                table: "STOCKADJUSTMENTS",
                newName: "QUANTITYAFTER");

            migrationBuilder.RenameColumn(
                name: "note",
                table: "STOCKADJUSTMENTS",
                newName: "NOTE");

            migrationBuilder.RenameColumn(
                name: "inventoryid",
                table: "STOCKADJUSTMENTS",
                newName: "INVENTORYID");

            migrationBuilder.RenameColumn(
                name: "adjustedbyuserid",
                table: "STOCKADJUSTMENTS",
                newName: "ADJUSTEDBYUSERID");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "STOCKADJUSTMENTS",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "STOCKADJUSTMENTS",
                newName: "UPDATEDAT");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "STOCKADJUSTMENTS",
                newName: "ISDELETED");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "STOCKADJUSTMENTS",
                newName: "CREATEDAT");

            migrationBuilder.RenameIndex(
                name: "IX_STOCKADJUSTMENTS_inventoryid",
                table: "STOCKADJUSTMENTS",
                newName: "IX_STOCKADJUSTMENTS_INVENTORYID");

            migrationBuilder.RenameColumn(
                name: "storeid",
                table: "SHIFTS",
                newName: "STOREID");

            migrationBuilder.RenameColumn(
                name: "starttime",
                table: "SHIFTS",
                newName: "STARTTIME");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "SHIFTS",
                newName: "NAME");

            migrationBuilder.RenameColumn(
                name: "isactive",
                table: "SHIFTS",
                newName: "ISACTIVE");

            migrationBuilder.RenameColumn(
                name: "endtime",
                table: "SHIFTS",
                newName: "ENDTIME");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "SHIFTS",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "SHIFTS",
                newName: "UPDATEDAT");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "SHIFTS",
                newName: "ISDELETED");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "SHIFTS",
                newName: "CREATEDAT");

            migrationBuilder.RenameIndex(
                name: "IX_SHIFTS_storeid",
                table: "SHIFTS",
                newName: "IX_SHIFTS_STOREID");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "SCHEDULES",
                newName: "STATUS");

            migrationBuilder.RenameColumn(
                name: "shiftid",
                table: "SCHEDULES",
                newName: "SHIFTID");

            migrationBuilder.RenameColumn(
                name: "note",
                table: "SCHEDULES",
                newName: "NOTE");

            migrationBuilder.RenameColumn(
                name: "employeeid",
                table: "SCHEDULES",
                newName: "EMPLOYEEID");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "SCHEDULES",
                newName: "DATE");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "SCHEDULES",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "SCHEDULES",
                newName: "UPDATEDAT");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "SCHEDULES",
                newName: "ISDELETED");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "SCHEDULES",
                newName: "CREATEDAT");

            migrationBuilder.RenameIndex(
                name: "IX_SCHEDULES_shiftid",
                table: "SCHEDULES",
                newName: "IX_SCHEDULES_SHIFTID");

            migrationBuilder.RenameIndex(
                name: "IX_SCHEDULES_employeeid",
                table: "SCHEDULES",
                newName: "IX_SCHEDULES_EMPLOYEEID");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "SALARYCOMPONENTS",
                newName: "TYPE");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "SALARYCOMPONENTS",
                newName: "NAME");

            migrationBuilder.RenameColumn(
                name: "isactive",
                table: "SALARYCOMPONENTS",
                newName: "ISACTIVE");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "SALARYCOMPONENTS",
                newName: "DESCRIPTION");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "SALARYCOMPONENTS",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "SALARYCOMPONENTS",
                newName: "UPDATEDAT");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "SALARYCOMPONENTS",
                newName: "ISDELETED");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "SALARYCOMPONENTS",
                newName: "CREATEDAT");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "RETURNREQUESTS",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "RETURNREQUESTS",
                newName: "UPDATEDAT");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "RETURNREQUESTS",
                newName: "ISDELETED");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "RETURNREQUESTS",
                newName: "CREATEDAT");

            migrationBuilder.RenameColumn(
                name: "supplierid",
                table: "PURCHASEORDERS",
                newName: "SUPPLIERID");

            migrationBuilder.RenameColumn(
                name: "storeid",
                table: "PURCHASEORDERS",
                newName: "STOREID");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "PURCHASEORDERS",
                newName: "STATUS");

            migrationBuilder.RenameColumn(
                name: "receiveddate",
                table: "PURCHASEORDERS",
                newName: "RECEIVEDDATE");

            migrationBuilder.RenameColumn(
                name: "orderdate",
                table: "PURCHASEORDERS",
                newName: "ORDERDATE");

            migrationBuilder.RenameColumn(
                name: "note",
                table: "PURCHASEORDERS",
                newName: "NOTE");

            migrationBuilder.RenameColumn(
                name: "expecteddate",
                table: "PURCHASEORDERS",
                newName: "EXPECTEDDATE");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "PURCHASEORDERS",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "PURCHASEORDERS",
                newName: "UPDATEDAT");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "PURCHASEORDERS",
                newName: "ISDELETED");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "PURCHASEORDERS",
                newName: "CREATEDAT");

            migrationBuilder.RenameIndex(
                name: "IX_PURCHASEORDERS_supplierid",
                table: "PURCHASEORDERS",
                newName: "IX_PURCHASEORDERS_SUPPLIERID");

            migrationBuilder.RenameIndex(
                name: "IX_PURCHASEORDERS_storeid",
                table: "PURCHASEORDERS",
                newName: "IX_PURCHASEORDERS_STOREID");

            migrationBuilder.RenameColumn(
                name: "quantityreceived",
                table: "PURCHASEORDERDETAILS",
                newName: "QUANTITYRECEIVED");

            migrationBuilder.RenameColumn(
                name: "quantityordered",
                table: "PURCHASEORDERDETAILS",
                newName: "QUANTITYORDERED");

            migrationBuilder.RenameColumn(
                name: "purchaseorderid",
                table: "PURCHASEORDERDETAILS",
                newName: "PURCHASEORDERID");

            migrationBuilder.RenameColumn(
                name: "productskuid",
                table: "PURCHASEORDERDETAILS",
                newName: "PRODUCTSKUID");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "PURCHASEORDERDETAILS",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "PURCHASEORDERDETAILS",
                newName: "UPDATEDAT");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "PURCHASEORDERDETAILS",
                newName: "ISDELETED");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "PURCHASEORDERDETAILS",
                newName: "CREATEDAT");

            migrationBuilder.RenameIndex(
                name: "IX_PURCHASEORDERDETAILS_purchaseorderid",
                table: "PURCHASEORDERDETAILS",
                newName: "IX_PURCHASEORDERDETAILS_PURCHASEORDERID");

            migrationBuilder.RenameIndex(
                name: "IX_PURCHASEORDERDETAILS_productskuid",
                table: "PURCHASEORDERDETAILS",
                newName: "IX_PURCHASEORDERDETAILS_PRODUCTSKUID");

            migrationBuilder.RenameColumn(
                name: "productid",
                table: "PRODUCTSKUS",
                newName: "PRODUCTID");

            migrationBuilder.RenameColumn(
                name: "isactive",
                table: "PRODUCTSKUS",
                newName: "ISACTIVE");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "PRODUCTSKUS",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "PRODUCTSKUS",
                newName: "UPDATEDAT");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "PRODUCTSKUS",
                newName: "ISDELETED");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "PRODUCTSKUS",
                newName: "CREATEDAT");

            migrationBuilder.RenameIndex(
                name: "IX_PRODUCTSKUS_productid",
                table: "PRODUCTSKUS",
                newName: "IX_PRODUCTSKUS_PRODUCTID");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "PRODUCTS",
                newName: "PRICE");

            migrationBuilder.RenameColumn(
                name: "isactive",
                table: "PRODUCTS",
                newName: "ISACTIVE");

            migrationBuilder.RenameColumn(
                name: "imageurl",
                table: "PRODUCTS",
                newName: "IMAGEURL");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "PRODUCTS",
                newName: "DESCRIPTION");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "PRODUCTS",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "PRODUCTS",
                newName: "UPDATEDAT");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "PRODUCTS",
                newName: "ISDELETED");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "PRODUCTS",
                newName: "CREATEDAT");

            migrationBuilder.RenameColumn(
                name: "productid",
                table: "PRODUCTIMAGES",
                newName: "PRODUCTID");

            migrationBuilder.RenameColumn(
                name: "imageurl",
                table: "PRODUCTIMAGES",
                newName: "IMAGEURL");

            migrationBuilder.RenameColumn(
                name: "displayorder",
                table: "PRODUCTIMAGES",
                newName: "DISPLAYORDER");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "PRODUCTIMAGES",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "PRODUCTIMAGES",
                newName: "UPDATEDAT");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "PRODUCTIMAGES",
                newName: "ISDELETED");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "PRODUCTIMAGES",
                newName: "CREATEDAT");

            migrationBuilder.RenameIndex(
                name: "IX_productimages_productid",
                table: "PRODUCTIMAGES",
                newName: "IX_PRODUCTIMAGES_PRODUCTID");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "PAYROLLS",
                newName: "STATUS");

            migrationBuilder.RenameColumn(
                name: "processeddate",
                table: "PAYROLLS",
                newName: "PROCESSEDDATE");

            migrationBuilder.RenameColumn(
                name: "note",
                table: "PAYROLLS",
                newName: "NOTE");

            migrationBuilder.RenameColumn(
                name: "employeeid",
                table: "PAYROLLS",
                newName: "EMPLOYEEID");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "PAYROLLS",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "PAYROLLS",
                newName: "UPDATEDAT");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "PAYROLLS",
                newName: "ISDELETED");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "PAYROLLS",
                newName: "CREATEDAT");

            migrationBuilder.RenameIndex(
                name: "IX_PAYROLLS_employeeid",
                table: "PAYROLLS",
                newName: "IX_PAYROLLS_EMPLOYEEID");

            migrationBuilder.RenameColumn(
                name: "salarycomponentid",
                table: "PAYROLLITEMS",
                newName: "SALARYCOMPONENTID");

            migrationBuilder.RenameColumn(
                name: "payrollid",
                table: "PAYROLLITEMS",
                newName: "PAYROLLID");

            migrationBuilder.RenameColumn(
                name: "note",
                table: "PAYROLLITEMS",
                newName: "NOTE");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "PAYROLLITEMS",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "PAYROLLITEMS",
                newName: "UPDATEDAT");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "PAYROLLITEMS",
                newName: "ISDELETED");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "PAYROLLITEMS",
                newName: "CREATEDAT");

            migrationBuilder.RenameIndex(
                name: "IX_PAYROLLITEMS_salarycomponentid",
                table: "PAYROLLITEMS",
                newName: "IX_PAYROLLITEMS_SALARYCOMPONENTID");

            migrationBuilder.RenameIndex(
                name: "IX_PAYROLLITEMS_payrollid",
                table: "PAYROLLITEMS",
                newName: "IX_PAYROLLITEMS_PAYROLLID");

            migrationBuilder.RenameColumn(
                name: "voucherid",
                table: "ORDERS",
                newName: "VOUCHERID");

            migrationBuilder.RenameColumn(
                name: "userid",
                table: "ORDERS",
                newName: "USERID");

            migrationBuilder.RenameColumn(
                name: "storeid",
                table: "ORDERS",
                newName: "STOREID");

            migrationBuilder.RenameColumn(
                name: "pointsearned",
                table: "ORDERS",
                newName: "POINTSEARNED");

            migrationBuilder.RenameColumn(
                name: "phone",
                table: "ORDERS",
                newName: "PHONE");

            migrationBuilder.RenameColumn(
                name: "paymentstatus",
                table: "ORDERS",
                newName: "PAYMENTSTATUS");

            migrationBuilder.RenameColumn(
                name: "paymentmethod",
                table: "ORDERS",
                newName: "PAYMENTMETHOD");

            migrationBuilder.RenameColumn(
                name: "note",
                table: "ORDERS",
                newName: "NOTE");

            migrationBuilder.RenameColumn(
                name: "discountamount",
                table: "ORDERS",
                newName: "DISCOUNTAMOUNT");

            migrationBuilder.RenameColumn(
                name: "customername",
                table: "ORDERS",
                newName: "CUSTOMERNAME");

            migrationBuilder.RenameColumn(
                name: "customerid",
                table: "ORDERS",
                newName: "CUSTOMERID");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "ORDERS",
                newName: "ADDRESS");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ORDERS",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "ORDERS",
                newName: "UPDATEDAT");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "ORDERS",
                newName: "ISDELETED");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "ORDERS",
                newName: "CREATEDAT");

            migrationBuilder.RenameIndex(
                name: "IX_ORDERS_voucherid",
                table: "ORDERS",
                newName: "IX_ORDERS_VOUCHERID");

            migrationBuilder.RenameIndex(
                name: "IX_ORDERS_userid",
                table: "ORDERS",
                newName: "IX_ORDERS_USERID");

            migrationBuilder.RenameIndex(
                name: "IX_ORDERS_storeid",
                table: "ORDERS",
                newName: "IX_ORDERS_STOREID");

            migrationBuilder.RenameIndex(
                name: "IX_ORDERS_customerid",
                table: "ORDERS",
                newName: "IX_ORDERS_CUSTOMERID");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "ORDERDETAILS",
                newName: "QUANTITY");

            migrationBuilder.RenameColumn(
                name: "productskuid",
                table: "ORDERDETAILS",
                newName: "PRODUCTSKUID");

            migrationBuilder.RenameColumn(
                name: "productid",
                table: "ORDERDETAILS",
                newName: "PRODUCTID");

            migrationBuilder.RenameColumn(
                name: "orderid",
                table: "ORDERDETAILS",
                newName: "ORDERID");

            migrationBuilder.RenameColumn(
                name: "discountpercent",
                table: "ORDERDETAILS",
                newName: "DISCOUNTPERCENT");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ORDERDETAILS",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "ORDERDETAILS",
                newName: "UPDATEDAT");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "ORDERDETAILS",
                newName: "ISDELETED");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "ORDERDETAILS",
                newName: "CREATEDAT");

            migrationBuilder.RenameIndex(
                name: "IX_ORDERDETAILS_productskuid",
                table: "ORDERDETAILS",
                newName: "IX_ORDERDETAILS_PRODUCTSKUID");

            migrationBuilder.RenameIndex(
                name: "IX_ORDERDETAILS_productid",
                table: "ORDERDETAILS",
                newName: "IX_ORDERDETAILS_PRODUCTID");

            migrationBuilder.RenameIndex(
                name: "IX_ORDERDETAILS_orderid",
                table: "ORDERDETAILS",
                newName: "IX_ORDERDETAILS_ORDERID");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "NOTIFICATIONS",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "NOTIFICATIONS",
                newName: "UPDATEDAT");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "NOTIFICATIONS",
                newName: "ISDELETED");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "NOTIFICATIONS",
                newName: "CREATEDAT");

            migrationBuilder.RenameColumn(
                name: "points",
                table: "LOYALTYTRANSACTIONS",
                newName: "POINTS");

            migrationBuilder.RenameColumn(
                name: "orderid",
                table: "LOYALTYTRANSACTIONS",
                newName: "ORDERID");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "LOYALTYTRANSACTIONS",
                newName: "DESCRIPTION");

            migrationBuilder.RenameColumn(
                name: "customerid",
                table: "LOYALTYTRANSACTIONS",
                newName: "CUSTOMERID");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "LOYALTYTRANSACTIONS",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "LOYALTYTRANSACTIONS",
                newName: "UPDATEDAT");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "LOYALTYTRANSACTIONS",
                newName: "ISDELETED");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "LOYALTYTRANSACTIONS",
                newName: "CREATEDAT");

            migrationBuilder.RenameIndex(
                name: "IX_LOYALTYTRANSACTIONS_orderid",
                table: "LOYALTYTRANSACTIONS",
                newName: "IX_LOYALTYTRANSACTIONS_ORDERID");

            migrationBuilder.RenameIndex(
                name: "IX_LOYALTYTRANSACTIONS_customerid",
                table: "LOYALTYTRANSACTIONS",
                newName: "IX_LOYALTYTRANSACTIONS_CUSTOMERID");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "LEAVEREQUESTS",
                newName: "TYPE");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "LEAVEREQUESTS",
                newName: "STATUS");

            migrationBuilder.RenameColumn(
                name: "startdate",
                table: "LEAVEREQUESTS",
                newName: "STARTDATE");

            migrationBuilder.RenameColumn(
                name: "reason",
                table: "LEAVEREQUESTS",
                newName: "REASON");

            migrationBuilder.RenameColumn(
                name: "enddate",
                table: "LEAVEREQUESTS",
                newName: "ENDDATE");

            migrationBuilder.RenameColumn(
                name: "employeeid",
                table: "LEAVEREQUESTS",
                newName: "EMPLOYEEID");

            migrationBuilder.RenameColumn(
                name: "approvedbyid",
                table: "LEAVEREQUESTS",
                newName: "APPROVEDBYID");

            migrationBuilder.RenameColumn(
                name: "adminnote",
                table: "LEAVEREQUESTS",
                newName: "ADMINNOTE");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "LEAVEREQUESTS",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "LEAVEREQUESTS",
                newName: "UPDATEDAT");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "LEAVEREQUESTS",
                newName: "ISDELETED");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "LEAVEREQUESTS",
                newName: "CREATEDAT");

            migrationBuilder.RenameIndex(
                name: "IX_LEAVEREQUESTS_employeeid",
                table: "LEAVEREQUESTS",
                newName: "IX_LEAVEREQUESTS_EMPLOYEEID");

            migrationBuilder.RenameColumn(
                name: "year",
                table: "LEAVEBALANCES",
                newName: "YEAR");

            migrationBuilder.RenameColumn(
                name: "sickdaysused",
                table: "LEAVEBALANCES",
                newName: "SICKDAYSUSED");

            migrationBuilder.RenameColumn(
                name: "sickdaystotal",
                table: "LEAVEBALANCES",
                newName: "SICKDAYSTOTAL");

            migrationBuilder.RenameColumn(
                name: "employeeid",
                table: "LEAVEBALANCES",
                newName: "EMPLOYEEID");

            migrationBuilder.RenameColumn(
                name: "annualdaysused",
                table: "LEAVEBALANCES",
                newName: "ANNUALDAYSUSED");

            migrationBuilder.RenameColumn(
                name: "annualdaystotal",
                table: "LEAVEBALANCES",
                newName: "ANNUALDAYSTOTAL");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "LEAVEBALANCES",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "LEAVEBALANCES",
                newName: "UPDATEDAT");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "LEAVEBALANCES",
                newName: "ISDELETED");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "LEAVEBALANCES",
                newName: "CREATEDAT");

            migrationBuilder.RenameIndex(
                name: "IX_LEAVEBALANCES_employeeid",
                table: "LEAVEBALANCES",
                newName: "IX_LEAVEBALANCES_EMPLOYEEID");

            migrationBuilder.RenameColumn(
                name: "year",
                table: "KPIREVIEWS",
                newName: "YEAR");

            migrationBuilder.RenameColumn(
                name: "totalscore",
                table: "KPIREVIEWS",
                newName: "TOTALSCORE");

            migrationBuilder.RenameColumn(
                name: "teamworkscore",
                table: "KPIREVIEWS",
                newName: "TEAMWORKSCORE");

            migrationBuilder.RenameColumn(
                name: "salesscore",
                table: "KPIREVIEWS",
                newName: "SALESSCORE");

            migrationBuilder.RenameColumn(
                name: "reviewerid",
                table: "KPIREVIEWS",
                newName: "REVIEWERID");

            migrationBuilder.RenameColumn(
                name: "rank",
                table: "KPIREVIEWS",
                newName: "RANK");

            migrationBuilder.RenameColumn(
                name: "notes",
                table: "KPIREVIEWS",
                newName: "NOTES");

            migrationBuilder.RenameColumn(
                name: "month",
                table: "KPIREVIEWS",
                newName: "MONTH");

            migrationBuilder.RenameColumn(
                name: "employeeid",
                table: "KPIREVIEWS",
                newName: "EMPLOYEEID");

            migrationBuilder.RenameColumn(
                name: "attitudescore",
                table: "KPIREVIEWS",
                newName: "ATTITUDESCORE");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "KPIREVIEWS",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "KPIREVIEWS",
                newName: "UPDATEDAT");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "KPIREVIEWS",
                newName: "ISDELETED");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "KPIREVIEWS",
                newName: "CREATEDAT");

            migrationBuilder.RenameIndex(
                name: "IX_KPIREVIEWS_reviewerid",
                table: "KPIREVIEWS",
                newName: "IX_KPIREVIEWS_REVIEWERID");

            migrationBuilder.RenameIndex(
                name: "IX_KPIREVIEWS_employeeid",
                table: "KPIREVIEWS",
                newName: "IX_KPIREVIEWS_EMPLOYEEID");

            migrationBuilder.RenameColumn(
                name: "storeid",
                table: "INVENTORIES",
                newName: "STOREID");

            migrationBuilder.RenameColumn(
                name: "reorderpoint",
                table: "INVENTORIES",
                newName: "REORDERPOINT");

            migrationBuilder.RenameColumn(
                name: "quantityonhand",
                table: "INVENTORIES",
                newName: "QUANTITYONHAND");

            migrationBuilder.RenameColumn(
                name: "productskuid",
                table: "INVENTORIES",
                newName: "PRODUCTSKUID");

            migrationBuilder.RenameColumn(
                name: "maxstocklevel",
                table: "INVENTORIES",
                newName: "MAXSTOCKLEVEL");

            migrationBuilder.RenameColumn(
                name: "lastupdated",
                table: "INVENTORIES",
                newName: "LASTUPDATED");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "INVENTORIES",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "INVENTORIES",
                newName: "UPDATEDAT");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "INVENTORIES",
                newName: "ISDELETED");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "INVENTORIES",
                newName: "CREATEDAT");

            migrationBuilder.RenameIndex(
                name: "IX_INVENTORIES_storeid",
                table: "INVENTORIES",
                newName: "IX_INVENTORIES_STOREID");

            migrationBuilder.RenameIndex(
                name: "IX_INVENTORIES_productskuid",
                table: "INVENTORIES",
                newName: "IX_INVENTORIES_PRODUCTSKUID");

            migrationBuilder.RenameColumn(
                name: "userid",
                table: "EXECUTIVEALERTS",
                newName: "USERID");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "EXECUTIVEALERTS",
                newName: "TYPE");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "EXECUTIVEALERTS",
                newName: "TITLE");

            migrationBuilder.RenameColumn(
                name: "subcategory",
                table: "EXECUTIVEALERTS",
                newName: "SUBCATEGORY");

            migrationBuilder.RenameColumn(
                name: "sourcesystem",
                table: "EXECUTIVEALERTS",
                newName: "SOURCESYSTEM");

            migrationBuilder.RenameColumn(
                name: "readat",
                table: "EXECUTIVEALERTS",
                newName: "READAT");

            migrationBuilder.RenameColumn(
                name: "priority",
                table: "EXECUTIVEALERTS",
                newName: "PRIORITY");

            migrationBuilder.RenameColumn(
                name: "isread",
                table: "EXECUTIVEALERTS",
                newName: "ISREAD");

            migrationBuilder.RenameColumn(
                name: "isarchived",
                table: "EXECUTIVEALERTS",
                newName: "ISARCHIVED");

            migrationBuilder.RenameColumn(
                name: "impact",
                table: "EXECUTIVEALERTS",
                newName: "IMPACT");

            migrationBuilder.RenameColumn(
                name: "expiresat",
                table: "EXECUTIVEALERTS",
                newName: "EXPIRESAT");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "EXECUTIVEALERTS",
                newName: "DESCRIPTION");

            migrationBuilder.RenameColumn(
                name: "category",
                table: "EXECUTIVEALERTS",
                newName: "CATEGORY");

            migrationBuilder.RenameColumn(
                name: "actionrequired",
                table: "EXECUTIVEALERTS",
                newName: "ACTIONREQUIRED");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "EXECUTIVEALERTS",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "EXECUTIVEALERTS",
                newName: "UPDATEDAT");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "EXECUTIVEALERTS",
                newName: "ISDELETED");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "EXECUTIVEALERTS",
                newName: "CREATEDAT");

            migrationBuilder.RenameIndex(
                name: "IX_executivealerts_userid",
                table: "EXECUTIVEALERTS",
                newName: "IX_EXECUTIVEALERTS_USERID");

            migrationBuilder.RenameColumn(
                name: "userid",
                table: "EMPLOYEES",
                newName: "USERID");

            migrationBuilder.RenameColumn(
                name: "storeid",
                table: "EMPLOYEES",
                newName: "STOREID");

            migrationBuilder.RenameColumn(
                name: "phone",
                table: "EMPLOYEES",
                newName: "PHONE");

            migrationBuilder.RenameColumn(
                name: "isactive",
                table: "EMPLOYEES",
                newName: "ISACTIVE");

            migrationBuilder.RenameColumn(
                name: "hiredate",
                table: "EMPLOYEES",
                newName: "HIREDATE");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "EMPLOYEES",
                newName: "EMAIL");

            migrationBuilder.RenameColumn(
                name: "departmentid",
                table: "EMPLOYEES",
                newName: "DEPARTMENTID");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "EMPLOYEES",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "EMPLOYEES",
                newName: "UPDATEDAT");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "EMPLOYEES",
                newName: "ISDELETED");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "EMPLOYEES",
                newName: "CREATEDAT");

            migrationBuilder.RenameIndex(
                name: "IX_EMPLOYEES_storeid",
                table: "EMPLOYEES",
                newName: "IX_EMPLOYEES_STOREID");

            migrationBuilder.RenameIndex(
                name: "IX_EMPLOYEES_departmentid",
                table: "EMPLOYEES",
                newName: "IX_EMPLOYEES_DEPARTMENTID");

            migrationBuilder.RenameColumn(
                name: "isactive",
                table: "DEPARTMENTS",
                newName: "ISACTIVE");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "DEPARTMENTS",
                newName: "DESCRIPTION");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "DEPARTMENTS",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "DEPARTMENTS",
                newName: "UPDATEDAT");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "DEPARTMENTS",
                newName: "ISDELETED");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "DEPARTMENTS",
                newName: "CREATEDAT");

            migrationBuilder.RenameColumn(
                name: "userid",
                table: "CUSTOMERS",
                newName: "USERID");

            migrationBuilder.RenameColumn(
                name: "tier",
                table: "CUSTOMERS",
                newName: "TIER");

            migrationBuilder.RenameColumn(
                name: "loyaltypoints",
                table: "CUSTOMERS",
                newName: "LOYALTYPOINTS");

            migrationBuilder.RenameColumn(
                name: "joindate",
                table: "CUSTOMERS",
                newName: "JOINDATE");

            migrationBuilder.RenameColumn(
                name: "dateofbirth",
                table: "CUSTOMERS",
                newName: "DATEOFBIRTH");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "CUSTOMERS",
                newName: "ADDRESS");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "CUSTOMERS",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "CUSTOMERS",
                newName: "UPDATEDAT");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "CUSTOMERS",
                newName: "ISDELETED");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "CUSTOMERS",
                newName: "CREATEDAT");

            migrationBuilder.RenameIndex(
                name: "IX_CUSTOMERS_userid",
                table: "CUSTOMERS",
                newName: "IX_CUSTOMERS_USERID");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "CATEGORIES",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "CATEGORIES",
                newName: "UPDATEDAT");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "CATEGORIES",
                newName: "ISDELETED");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "CATEGORIES",
                newName: "CREATEDAT");

            migrationBuilder.RenameColumn(
                name: "voucherid",
                table: "CAMPAIGNS",
                newName: "VOUCHERID");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "CAMPAIGNS",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "CAMPAIGNS",
                newName: "UPDATEDAT");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "CAMPAIGNS",
                newName: "ISDELETED");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "CAMPAIGNS",
                newName: "CREATEDAT");

            migrationBuilder.RenameIndex(
                name: "IX_CAMPAIGNS_voucherid",
                table: "CAMPAIGNS",
                newName: "IX_CAMPAIGNS_VOUCHERID");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "BANNERS",
                newName: "TITLE");

            migrationBuilder.RenameColumn(
                name: "subtitle",
                table: "BANNERS",
                newName: "SUBTITLE");

            migrationBuilder.RenameColumn(
                name: "position",
                table: "BANNERS",
                newName: "POSITION");

            migrationBuilder.RenameColumn(
                name: "linkurl",
                table: "BANNERS",
                newName: "LINKURL");

            migrationBuilder.RenameColumn(
                name: "isactive",
                table: "BANNERS",
                newName: "ISACTIVE");

            migrationBuilder.RenameColumn(
                name: "imageurl",
                table: "BANNERS",
                newName: "IMAGEURL");

            migrationBuilder.RenameColumn(
                name: "displayorder",
                table: "BANNERS",
                newName: "DISPLAYORDER");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "BANNERS",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "BANNERS",
                newName: "UPDATEDAT");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "BANNERS",
                newName: "ISDELETED");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "BANNERS",
                newName: "CREATEDAT");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "ATTENDANCES",
                newName: "STATUS");

            migrationBuilder.RenameColumn(
                name: "note",
                table: "ATTENDANCES",
                newName: "NOTE");

            migrationBuilder.RenameColumn(
                name: "employeeid",
                table: "ATTENDANCES",
                newName: "EMPLOYEEID");

            migrationBuilder.RenameColumn(
                name: "checkout",
                table: "ATTENDANCES",
                newName: "CHECKOUT");

            migrationBuilder.RenameColumn(
                name: "checkin",
                table: "ATTENDANCES",
                newName: "CHECKIN");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ATTENDANCES",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "ATTENDANCES",
                newName: "UPDATEDAT");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "ATTENDANCES",
                newName: "ISDELETED");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "ATTENDANCES",
                newName: "CREATEDAT");

            migrationBuilder.RenameIndex(
                name: "IX_ATTENDANCES_employeeid",
                table: "ATTENDANCES",
                newName: "IX_ATTENDANCES_EMPLOYEEID");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "ASPNETUSERS",
                newName: "USERNAME");

            migrationBuilder.RenameColumn(
                name: "twofactorenabled",
                table: "ASPNETUSERS",
                newName: "TWOFACTORENABLED");

            migrationBuilder.RenameColumn(
                name: "securitystamp",
                table: "ASPNETUSERS",
                newName: "SECURITYSTAMP");

            migrationBuilder.RenameColumn(
                name: "phonenumberconfirmed",
                table: "ASPNETUSERS",
                newName: "PHONENUMBERCONFIRMED");

            migrationBuilder.RenameColumn(
                name: "phonenumber",
                table: "ASPNETUSERS",
                newName: "PHONENUMBER");

            migrationBuilder.RenameColumn(
                name: "passwordhash",
                table: "ASPNETUSERS",
                newName: "PASSWORDHASH");

            migrationBuilder.RenameColumn(
                name: "normalizedusername",
                table: "ASPNETUSERS",
                newName: "NORMALIZEDUSERNAME");

            migrationBuilder.RenameColumn(
                name: "normalizedemail",
                table: "ASPNETUSERS",
                newName: "NORMALIZEDEMAIL");

            migrationBuilder.RenameColumn(
                name: "membershippoints",
                table: "ASPNETUSERS",
                newName: "MEMBERSHIPPOINTS");

            migrationBuilder.RenameColumn(
                name: "lockoutend",
                table: "ASPNETUSERS",
                newName: "LOCKOUTEND");

            migrationBuilder.RenameColumn(
                name: "lockoutenabled",
                table: "ASPNETUSERS",
                newName: "LOCKOUTENABLED");

            migrationBuilder.RenameColumn(
                name: "joindate",
                table: "ASPNETUSERS",
                newName: "JOINDATE");

            migrationBuilder.RenameColumn(
                name: "gender",
                table: "ASPNETUSERS",
                newName: "GENDER");

            migrationBuilder.RenameColumn(
                name: "fullname",
                table: "ASPNETUSERS",
                newName: "FULLNAME");

            migrationBuilder.RenameColumn(
                name: "emailconfirmed",
                table: "ASPNETUSERS",
                newName: "EMAILCONFIRMED");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "ASPNETUSERS",
                newName: "EMAIL");

            migrationBuilder.RenameColumn(
                name: "dateofbirth",
                table: "ASPNETUSERS",
                newName: "DATEOFBIRTH");

            migrationBuilder.RenameColumn(
                name: "concurrencystamp",
                table: "ASPNETUSERS",
                newName: "CONCURRENCYSTAMP");

            migrationBuilder.RenameColumn(
                name: "avatarurl",
                table: "ASPNETUSERS",
                newName: "AVATARURL");

            migrationBuilder.RenameColumn(
                name: "accessfailedcount",
                table: "ASPNETUSERS",
                newName: "ACCESSFAILEDCOUNT");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ASPNETUSERS",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "providerdisplayname",
                table: "ASPNETUSERLOGINS",
                newName: "PROVIDERDISPLAYNAME");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ASPNETUSERCLAIMS",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "normalizedname",
                table: "ASPNETROLES",
                newName: "NORMALIZEDNAME");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "ASPNETROLES",
                newName: "NAME");

            migrationBuilder.RenameColumn(
                name: "concurrencystamp",
                table: "ASPNETROLES",
                newName: "CONCURRENCYSTAMP");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ASPNETROLES",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "claimvalue",
                table: "ASPNETROLECLAIMS",
                newName: "CLAIMVALUE");

            migrationBuilder.RenameColumn(
                name: "claimtype",
                table: "ASPNETROLECLAIMS",
                newName: "CLAIMTYPE");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ASPNETROLECLAIMS",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "takenbyuserid",
                table: "ALERTACTIONS",
                newName: "TAKENBYUSERID");

            migrationBuilder.RenameColumn(
                name: "executivealertid",
                table: "ALERTACTIONS",
                newName: "EXECUTIVEALERTID");

            migrationBuilder.RenameColumn(
                name: "actiontype",
                table: "ALERTACTIONS",
                newName: "ACTIONTYPE");

            migrationBuilder.RenameColumn(
                name: "actionnotes",
                table: "ALERTACTIONS",
                newName: "ACTIONNOTES");

            migrationBuilder.RenameColumn(
                name: "actionat",
                table: "ALERTACTIONS",
                newName: "ACTIONAT");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ALERTACTIONS",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "ALERTACTIONS",
                newName: "UPDATEDAT");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "ALERTACTIONS",
                newName: "ISDELETED");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "ALERTACTIONS",
                newName: "CREATEDAT");

            migrationBuilder.RenameIndex(
                name: "IX_alertactions_takenbyuserid",
                table: "ALERTACTIONS",
                newName: "IX_ALERTACTIONS_TAKENBYUSERID");

            migrationBuilder.RenameIndex(
                name: "IX_alertactions_executivealertid",
                table: "ALERTACTIONS",
                newName: "IX_ALERTACTIONS_EXECUTIVEALERTID");

            migrationBuilder.AlterColumn<string>(
                name: "USERID",
                table: "WISHLISTITEMS",
                type: "TEXT",
                maxLength: 450,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(450)",
                oldMaxLength: 450);

            migrationBuilder.AlterColumn<int>(
                name: "PRODUCTID",
                table: "WISHLISTITEMS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "WISHLISTITEMS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "UPDATEDAT",
                table: "WISHLISTITEMS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ISDELETED",
                table: "WISHLISTITEMS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "CREATEDAT",
                table: "WISHLISTITEMS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<int>(
                name: "USEDCOUNT",
                table: "VOUCHERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "MAXUSAGECOUNT",
                table: "VOUCHERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ISACTIVE",
                table: "VOUCHERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "EXPIRYDATE",
                table: "VOUCHERS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "CODE",
                table: "VOUCHERS",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "VOUCHERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "UPDATEDAT",
                table: "VOUCHERS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ISDELETED",
                table: "VOUCHERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "CREATEDAT",
                table: "VOUCHERS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "USERID",
                table: "USERADDRESSES",
                type: "TEXT",
                maxLength: 450,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(450)",
                oldMaxLength: 450);

            migrationBuilder.AlterColumn<string>(
                name: "PHONENUMBER",
                table: "USERADDRESSES",
                type: "TEXT",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<int>(
                name: "ISDEFAULT",
                table: "USERADDRESSES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "FULLNAME",
                table: "USERADDRESSES",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "ADDRESSLINE",
                table: "USERADDRESSES",
                type: "TEXT",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "USERADDRESSES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "UPDATEDAT",
                table: "USERADDRESSES",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ISDELETED",
                table: "USERADDRESSES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "CREATEDAT",
                table: "USERADDRESSES",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<int>(
                name: "LEADTIMEDAYS",
                table: "SUPPLIERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ISACTIVE",
                table: "SUPPLIERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "CONTACTPERSON",
                table: "SUPPLIERS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ADDRESS",
                table: "SUPPLIERS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PHONE",
                table: "SUPPLIERS",
                type: "TEXT",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "SUPPLIERS",
                type: "TEXT",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "EMAIL",
                table: "SUPPLIERS",
                type: "TEXT",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "SUPPLIERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "UPDATEDAT",
                table: "SUPPLIERS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ISDELETED",
                table: "SUPPLIERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "CREATEDAT",
                table: "SUPPLIERS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "MANAGERNAME",
                table: "STORES",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "ISACTIVE",
                table: "STORES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "PHONE",
                table: "STORES",
                type: "TEXT",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "STORES",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "ADDRESS",
                table: "STORES",
                type: "TEXT",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "STORES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "UPDATEDAT",
                table: "STORES",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ISDELETED",
                table: "STORES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "CREATEDAT",
                table: "STORES",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<int>(
                name: "REASON",
                table: "STOCKADJUSTMENTS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "smallint");

            migrationBuilder.AlterColumn<int>(
                name: "QUANTITYCHANGE",
                table: "STOCKADJUSTMENTS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "QUANTITYBEFORE",
                table: "STOCKADJUSTMENTS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "QUANTITYAFTER",
                table: "STOCKADJUSTMENTS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "NOTE",
                table: "STOCKADJUSTMENTS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "INVENTORYID",
                table: "STOCKADJUSTMENTS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "ADJUSTEDBYUSERID",
                table: "STOCKADJUSTMENTS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "STOCKADJUSTMENTS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "UPDATEDAT",
                table: "STOCKADJUSTMENTS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ISDELETED",
                table: "STOCKADJUSTMENTS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "CREATEDAT",
                table: "STOCKADJUSTMENTS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<int>(
                name: "STOREID",
                table: "SHIFTS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "STARTTIME",
                table: "SHIFTS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "interval");

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "SHIFTS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "ISACTIVE",
                table: "SHIFTS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "ENDTIME",
                table: "SHIFTS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "interval");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "SHIFTS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "UPDATEDAT",
                table: "SHIFTS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ISDELETED",
                table: "SHIFTS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "CREATEDAT",
                table: "SHIFTS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<int>(
                name: "STATUS",
                table: "SCHEDULES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "smallint");

            migrationBuilder.AlterColumn<int>(
                name: "SHIFTID",
                table: "SCHEDULES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "NOTE",
                table: "SCHEDULES",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EMPLOYEEID",
                table: "SCHEDULES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "DATE",
                table: "SCHEDULES",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "SCHEDULES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "UPDATEDAT",
                table: "SCHEDULES",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ISDELETED",
                table: "SCHEDULES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "CREATEDAT",
                table: "SCHEDULES",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<int>(
                name: "TYPE",
                table: "SALARYCOMPONENTS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "smallint");

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "SALARYCOMPONENTS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "ISACTIVE",
                table: "SALARYCOMPONENTS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "DESCRIPTION",
                table: "SALARYCOMPONENTS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "DEFAULTAMOUNT",
                table: "SALARYCOMPONENTS",
                type: "numeric(12,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "SALARYCOMPONENTS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "UPDATEDAT",
                table: "SALARYCOMPONENTS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ISDELETED",
                table: "SALARYCOMPONENTS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "CREATEDAT",
                table: "SALARYCOMPONENTS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<int>(
                name: "STATUS",
                table: "RETURNREQUESTS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "smallint");

            migrationBuilder.AlterColumn<string>(
                name: "REASON",
                table: "RETURNREQUESTS",
                type: "TEXT",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "PROCESSEDAT",
                table: "RETURNREQUESTS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ORDERID",
                table: "RETURNREQUESTS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "ADMINNOTE",
                table: "RETURNREQUESTS",
                type: "TEXT",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "RETURNREQUESTS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "UPDATEDAT",
                table: "RETURNREQUESTS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ISDELETED",
                table: "RETURNREQUESTS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "CREATEDAT",
                table: "RETURNREQUESTS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<int>(
                name: "SUPPLIERID",
                table: "PURCHASEORDERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "STOREID",
                table: "PURCHASEORDERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "STATUS",
                table: "PURCHASEORDERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "smallint");

            migrationBuilder.AlterColumn<string>(
                name: "RECEIVEDDATE",
                table: "PURCHASEORDERS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ORDERDATE",
                table: "PURCHASEORDERS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "NOTE",
                table: "PURCHASEORDERS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EXPECTEDDATE",
                table: "PURCHASEORDERS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "POCODE",
                table: "PURCHASEORDERS",
                type: "TEXT",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "PURCHASEORDERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "UPDATEDAT",
                table: "PURCHASEORDERS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ISDELETED",
                table: "PURCHASEORDERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "CREATEDAT",
                table: "PURCHASEORDERS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<int>(
                name: "QUANTITYRECEIVED",
                table: "PURCHASEORDERDETAILS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "QUANTITYORDERED",
                table: "PURCHASEORDERDETAILS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "PURCHASEORDERID",
                table: "PURCHASEORDERDETAILS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "PRODUCTSKUID",
                table: "PURCHASEORDERDETAILS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "PURCHASEORDERDETAILS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "UPDATEDAT",
                table: "PURCHASEORDERDETAILS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ISDELETED",
                table: "PURCHASEORDERDETAILS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "CREATEDAT",
                table: "PURCHASEORDERDETAILS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<int>(
                name: "PRODUCTID",
                table: "PRODUCTSKUS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ISACTIVE",
                table: "PRODUCTSKUS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<int>(
                name: "STOCK",
                table: "PRODUCTSKUS",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "SKUCODE",
                table: "PRODUCTSKUS",
                type: "TEXT",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "SKU",
                table: "PRODUCTSKUS",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "SIZE",
                table: "PRODUCTSKUS",
                type: "TEXT",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<decimal>(
                name: "SELLINGPRICE",
                table: "PRODUCTSKUS",
                type: "numeric(12,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PRICEOVERRIDE",
                table: "PRODUCTSKUS",
                type: "numeric(12,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "COSTPRICE",
                table: "PRODUCTSKUS",
                type: "numeric(12,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "COLOR",
                table: "PRODUCTSKUS",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "PRODUCTSKUS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "UPDATEDAT",
                table: "PRODUCTSKUS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ISDELETED",
                table: "PRODUCTSKUS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "CREATEDAT",
                table: "PRODUCTSKUS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<decimal>(
                name: "PRICE",
                table: "PRODUCTS",
                type: "numeric(12,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "ISACTIVE",
                table: "PRODUCTS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "IMAGEURL",
                table: "PRODUCTS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DESCRIPTION",
                table: "PRODUCTS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SUPPLIERID",
                table: "PRODUCTS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "STOCK",
                table: "PRODUCTS",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "SLUG",
                table: "PRODUCTS",
                type: "TEXT",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "PRODUCTS",
                type: "TEXT",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<int>(
                name: "CATEGORYID",
                table: "PRODUCTS",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "PRODUCTS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "UPDATEDAT",
                table: "PRODUCTS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ISDELETED",
                table: "PRODUCTS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "CREATEDAT",
                table: "PRODUCTS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<int>(
                name: "PRODUCTID",
                table: "PRODUCTIMAGES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "IMAGEURL",
                table: "PRODUCTIMAGES",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "DISPLAYORDER",
                table: "PRODUCTIMAGES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "PRODUCTIMAGES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "UPDATEDAT",
                table: "PRODUCTIMAGES",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ISDELETED",
                table: "PRODUCTIMAGES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "CREATEDAT",
                table: "PRODUCTIMAGES",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<int>(
                name: "STATUS",
                table: "PAYROLLS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "smallint");

            migrationBuilder.AlterColumn<string>(
                name: "PROCESSEDDATE",
                table: "PAYROLLS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NOTE",
                table: "PAYROLLS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EMPLOYEEID",
                table: "PAYROLLS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "YEAR",
                table: "PAYROLLS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<double>(
                name: "TOTALHOURSWORKED",
                table: "PAYROLLS",
                type: "NUMBER(8,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "numeric(8,2)");

            migrationBuilder.AlterColumn<int>(
                name: "MONTH",
                table: "PAYROLLS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<decimal>(
                name: "BASEHOURLYRATE",
                table: "PAYROLLS",
                type: "numeric(12,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "PAYROLLS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "UPDATEDAT",
                table: "PAYROLLS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ISDELETED",
                table: "PAYROLLS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "CREATEDAT",
                table: "PAYROLLS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<int>(
                name: "SALARYCOMPONENTID",
                table: "PAYROLLITEMS",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PAYROLLID",
                table: "PAYROLLITEMS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "NOTE",
                table: "PAYROLLITEMS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "PAYROLLITEMS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "UPDATEDAT",
                table: "PAYROLLITEMS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ISDELETED",
                table: "PAYROLLITEMS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "CREATEDAT",
                table: "PAYROLLITEMS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<int>(
                name: "VOUCHERID",
                table: "ORDERS",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "USERID",
                table: "ORDERS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "STOREID",
                table: "ORDERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "POINTSEARNED",
                table: "ORDERS",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "PHONE",
                table: "ORDERS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PAYMENTSTATUS",
                table: "ORDERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "smallint");

            migrationBuilder.AlterColumn<int>(
                name: "PAYMENTMETHOD",
                table: "ORDERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "smallint");

            migrationBuilder.AlterColumn<string>(
                name: "NOTE",
                table: "ORDERS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DISCOUNTAMOUNT",
                table: "ORDERS",
                type: "TEXT",
                nullable: false,
                defaultValue: "0",
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "CUSTOMERNAME",
                table: "ORDERS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CUSTOMERID",
                table: "ORDERS",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ADDRESS",
                table: "ORDERS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TOTALAMOUNT",
                table: "ORDERS",
                type: "numeric(14,0)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "SUBTOTAL",
                table: "ORDERS",
                type: "numeric(14,0)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<int>(
                name: "STATUS",
                table: "ORDERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "smallint");

            migrationBuilder.AlterColumn<string>(
                name: "ORDERCODE",
                table: "ORDERS",
                type: "TEXT",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "ORDERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "UPDATEDAT",
                table: "ORDERS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ISDELETED",
                table: "ORDERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "CREATEDAT",
                table: "ORDERS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<int>(
                name: "QUANTITY",
                table: "ORDERDETAILS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "PRODUCTSKUID",
                table: "ORDERDETAILS",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PRODUCTID",
                table: "ORDERDETAILS",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ORDERID",
                table: "ORDERDETAILS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "DISCOUNTPERCENT",
                table: "ORDERDETAILS",
                type: "TEXT",
                nullable: false,
                defaultValue: "0",
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "UNITPRICE",
                table: "ORDERDETAILS",
                type: "numeric(12,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "SUBTOTAL",
                table: "ORDERDETAILS",
                type: "numeric(14,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "ORDERDETAILS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "UPDATEDAT",
                table: "ORDERDETAILS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ISDELETED",
                table: "ORDERDETAILS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "CREATEDAT",
                table: "ORDERDETAILS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "USERID",
                table: "NOTIFICATIONS",
                type: "TEXT",
                maxLength: 450,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(450)",
                oldMaxLength: 450);

            migrationBuilder.AlterColumn<string>(
                name: "TITLE",
                table: "NOTIFICATIONS",
                type: "TEXT",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "MESSAGE",
                table: "NOTIFICATIONS",
                type: "TEXT",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<int>(
                name: "ISREAD",
                table: "NOTIFICATIONS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "ACTIONURL",
                table: "NOTIFICATIONS",
                type: "TEXT",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "NOTIFICATIONS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "UPDATEDAT",
                table: "NOTIFICATIONS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ISDELETED",
                table: "NOTIFICATIONS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "CREATEDAT",
                table: "NOTIFICATIONS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<int>(
                name: "POINTS",
                table: "LOYALTYTRANSACTIONS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ORDERID",
                table: "LOYALTYTRANSACTIONS",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DESCRIPTION",
                table: "LOYALTYTRANSACTIONS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "CUSTOMERID",
                table: "LOYALTYTRANSACTIONS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "LOYALTYTRANSACTIONS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "UPDATEDAT",
                table: "LOYALTYTRANSACTIONS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ISDELETED",
                table: "LOYALTYTRANSACTIONS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "CREATEDAT",
                table: "LOYALTYTRANSACTIONS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<int>(
                name: "TYPE",
                table: "LEAVEREQUESTS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "smallint");

            migrationBuilder.AlterColumn<int>(
                name: "STATUS",
                table: "LEAVEREQUESTS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "smallint");

            migrationBuilder.AlterColumn<string>(
                name: "STARTDATE",
                table: "LEAVEREQUESTS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "REASON",
                table: "LEAVEREQUESTS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ENDDATE",
                table: "LEAVEREQUESTS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<int>(
                name: "EMPLOYEEID",
                table: "LEAVEREQUESTS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "APPROVEDBYID",
                table: "LEAVEREQUESTS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ADMINNOTE",
                table: "LEAVEREQUESTS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "LEAVEREQUESTS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "UPDATEDAT",
                table: "LEAVEREQUESTS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ISDELETED",
                table: "LEAVEREQUESTS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "CREATEDAT",
                table: "LEAVEREQUESTS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<int>(
                name: "YEAR",
                table: "LEAVEBALANCES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "SICKDAYSUSED",
                table: "LEAVEBALANCES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "SICKDAYSTOTAL",
                table: "LEAVEBALANCES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "EMPLOYEEID",
                table: "LEAVEBALANCES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ANNUALDAYSUSED",
                table: "LEAVEBALANCES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ANNUALDAYSTOTAL",
                table: "LEAVEBALANCES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "LEAVEBALANCES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "UPDATEDAT",
                table: "LEAVEBALANCES",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ISDELETED",
                table: "LEAVEBALANCES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "CREATEDAT",
                table: "LEAVEBALANCES",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<int>(
                name: "YEAR",
                table: "KPIREVIEWS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "TOTALSCORE",
                table: "KPIREVIEWS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(10,2)");

            migrationBuilder.AlterColumn<string>(
                name: "TEAMWORKSCORE",
                table: "KPIREVIEWS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(10,2)");

            migrationBuilder.AlterColumn<string>(
                name: "SALESSCORE",
                table: "KPIREVIEWS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(10,2)");

            migrationBuilder.AlterColumn<string>(
                name: "REVIEWERID",
                table: "KPIREVIEWS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "RANK",
                table: "KPIREVIEWS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "smallint");

            migrationBuilder.AlterColumn<string>(
                name: "NOTES",
                table: "KPIREVIEWS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MONTH",
                table: "KPIREVIEWS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "EMPLOYEEID",
                table: "KPIREVIEWS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "ATTITUDESCORE",
                table: "KPIREVIEWS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(10,2)");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "KPIREVIEWS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "UPDATEDAT",
                table: "KPIREVIEWS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ISDELETED",
                table: "KPIREVIEWS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "CREATEDAT",
                table: "KPIREVIEWS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<int>(
                name: "STOREID",
                table: "INVENTORIES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "REORDERPOINT",
                table: "INVENTORIES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "QUANTITYONHAND",
                table: "INVENTORIES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "PRODUCTSKUID",
                table: "INVENTORIES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "MAXSTOCKLEVEL",
                table: "INVENTORIES",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LASTUPDATED",
                table: "INVENTORIES",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "INVENTORIES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "UPDATEDAT",
                table: "INVENTORIES",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ISDELETED",
                table: "INVENTORIES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "CREATEDAT",
                table: "INVENTORIES",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "USERID",
                table: "EXECUTIVEALERTS",
                type: "TEXT",
                maxLength: 450,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(450)",
                oldMaxLength: 450,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TYPE",
                table: "EXECUTIVEALERTS",
                type: "TEXT",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "TITLE",
                table: "EXECUTIVEALERTS",
                type: "TEXT",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "SUBCATEGORY",
                table: "EXECUTIVEALERTS",
                type: "TEXT",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SOURCESYSTEM",
                table: "EXECUTIVEALERTS",
                type: "TEXT",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "READAT",
                table: "EXECUTIVEALERTS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PRIORITY",
                table: "EXECUTIVEALERTS",
                type: "TEXT",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ISREAD",
                table: "EXECUTIVEALERTS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<int>(
                name: "ISARCHIVED",
                table: "EXECUTIVEALERTS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "EXPIRESAT",
                table: "EXECUTIVEALERTS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DESCRIPTION",
                table: "EXECUTIVEALERTS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "CATEGORY",
                table: "EXECUTIVEALERTS",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "ACTIONREQUIRED",
                table: "EXECUTIVEALERTS",
                type: "TEXT",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "EXECUTIVEALERTS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "UPDATEDAT",
                table: "EXECUTIVEALERTS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ISDELETED",
                table: "EXECUTIVEALERTS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "CREATEDAT",
                table: "EXECUTIVEALERTS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "USERID",
                table: "EMPLOYEES",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "STOREID",
                table: "EMPLOYEES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "PHONE",
                table: "EMPLOYEES",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "ISACTIVE",
                table: "EMPLOYEES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "HIREDATE",
                table: "EMPLOYEES",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "EMAIL",
                table: "EMPLOYEES",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "DEPARTMENTID",
                table: "EMPLOYEES",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "POSITION",
                table: "EMPLOYEES",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FULLNAME",
                table: "EMPLOYEES",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<decimal>(
                name: "BASESALARYPERHOUR",
                table: "EMPLOYEES",
                type: "numeric(12,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "BANKNAME",
                table: "EMPLOYEES",
                type: "TEXT",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BANKACCOUNTNUMBER",
                table: "EMPLOYEES",
                type: "TEXT",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BANKACCOUNTNAME",
                table: "EMPLOYEES",
                type: "TEXT",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "EMPLOYEES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "UPDATEDAT",
                table: "EMPLOYEES",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ISDELETED",
                table: "EMPLOYEES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "CREATEDAT",
                table: "EMPLOYEES",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<int>(
                name: "ISACTIVE",
                table: "DEPARTMENTS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "DESCRIPTION",
                table: "DEPARTMENTS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "DEPARTMENTS",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "DEPARTMENTS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "UPDATEDAT",
                table: "DEPARTMENTS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ISDELETED",
                table: "DEPARTMENTS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "CREATEDAT",
                table: "DEPARTMENTS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "USERID",
                table: "CUSTOMERS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TIER",
                table: "CUSTOMERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "LOYALTYPOINTS",
                table: "CUSTOMERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "JOINDATE",
                table: "CUSTOMERS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "DATEOFBIRTH",
                table: "CUSTOMERS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ADDRESS",
                table: "CUSTOMERS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PHONE",
                table: "CUSTOMERS",
                type: "TEXT",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "FULLNAME",
                table: "CUSTOMERS",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "EMAIL",
                table: "CUSTOMERS",
                type: "TEXT",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "CUSTOMERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "UPDATEDAT",
                table: "CUSTOMERS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ISDELETED",
                table: "CUSTOMERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "CREATEDAT",
                table: "CUSTOMERS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "SLUG",
                table: "CATEGORIES",
                type: "TEXT",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PARENTCATEGORYID",
                table: "CATEGORIES",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "CATEGORIES",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<int>(
                name: "ISACTIVE",
                table: "CATEGORIES",
                type: "INTEGER",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<string>(
                name: "IMAGEURL",
                table: "CATEGORIES",
                type: "TEXT",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DISPLAYORDER",
                table: "CATEGORIES",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "DESCRIPTION",
                table: "CATEGORIES",
                type: "TEXT",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "CATEGORIES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "UPDATEDAT",
                table: "CATEGORIES",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ISDELETED",
                table: "CATEGORIES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "CREATEDAT",
                table: "CATEGORIES",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<int>(
                name: "VOUCHERID",
                table: "CAMPAIGNS",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TARGETSEGMENT",
                table: "CAMPAIGNS",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "STARTDATE",
                table: "CAMPAIGNS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "SENTAT",
                table: "CAMPAIGNS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RECIPIENTCOUNT",
                table: "CAMPAIGNS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "NOTIFICATIONTITLE",
                table: "CAMPAIGNS",
                type: "TEXT",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "NOTIFICATIONMESSAGE",
                table: "CAMPAIGNS",
                type: "TEXT",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "CAMPAIGNS",
                type: "TEXT",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<int>(
                name: "ISSENT",
                table: "CAMPAIGNS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "ENDDATE",
                table: "CAMPAIGNS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "DESCRIPTION",
                table: "CAMPAIGNS",
                type: "TEXT",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "CAMPAIGNS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "UPDATEDAT",
                table: "CAMPAIGNS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ISDELETED",
                table: "CAMPAIGNS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "CREATEDAT",
                table: "CAMPAIGNS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "TITLE",
                table: "BANNERS",
                type: "TEXT",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "SUBTITLE",
                table: "BANNERS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "POSITION",
                table: "BANNERS",
                type: "TEXT",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LINKURL",
                table: "BANNERS",
                type: "TEXT",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ISACTIVE",
                table: "BANNERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "IMAGEURL",
                table: "BANNERS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DISPLAYORDER",
                table: "BANNERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "BANNERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "UPDATEDAT",
                table: "BANNERS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ISDELETED",
                table: "BANNERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "CREATEDAT",
                table: "BANNERS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<int>(
                name: "STATUS",
                table: "ATTENDANCES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "smallint");

            migrationBuilder.AlterColumn<string>(
                name: "NOTE",
                table: "ATTENDANCES",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EMPLOYEEID",
                table: "ATTENDANCES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "CHECKOUT",
                table: "ATTENDANCES",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "interval",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CHECKIN",
                table: "ATTENDANCES",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "interval",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "TOTALHOURS",
                table: "ATTENDANCES",
                type: "NUMBER(5,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "numeric(5,2)");

            migrationBuilder.AlterColumn<string>(
                name: "DATE",
                table: "ATTENDANCES",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "ATTENDANCES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "UPDATEDAT",
                table: "ATTENDANCES",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ISDELETED",
                table: "ATTENDANCES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "CREATEDAT",
                table: "ATTENDANCES",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "VALUE",
                table: "ASPNETUSERTOKENS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "ASPNETUSERTOKENS",
                type: "TEXT",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LOGINPROVIDER",
                table: "ASPNETUSERTOKENS",
                type: "TEXT",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "USERID",
                table: "ASPNETUSERTOKENS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "USERNAME",
                table: "ASPNETUSERS",
                type: "TEXT",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TWOFACTORENABLED",
                table: "ASPNETUSERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "SECURITYSTAMP",
                table: "ASPNETUSERS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PHONENUMBERCONFIRMED",
                table: "ASPNETUSERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "PHONENUMBER",
                table: "ASPNETUSERS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PASSWORDHASH",
                table: "ASPNETUSERS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NORMALIZEDUSERNAME",
                table: "ASPNETUSERS",
                type: "TEXT",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NORMALIZEDEMAIL",
                table: "ASPNETUSERS",
                type: "TEXT",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MEMBERSHIPPOINTS",
                table: "ASPNETUSERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "LOCKOUTEND",
                table: "ASPNETUSERS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LOCKOUTENABLED",
                table: "ASPNETUSERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "JOINDATE",
                table: "ASPNETUSERS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "GENDER",
                table: "ASPNETUSERS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FULLNAME",
                table: "ASPNETUSERS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EMAILCONFIRMED",
                table: "ASPNETUSERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "EMAIL",
                table: "ASPNETUSERS",
                type: "TEXT",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DATEOFBIRTH",
                table: "ASPNETUSERS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CONCURRENCYSTAMP",
                table: "ASPNETUSERS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AVATARURL",
                table: "ASPNETUSERS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ACCESSFAILEDCOUNT",
                table: "ASPNETUSERS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "ID",
                table: "ASPNETUSERS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "ROLEID",
                table: "ASPNETUSERROLES",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "USERID",
                table: "ASPNETUSERROLES",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "PROVIDERDISPLAYNAME",
                table: "ASPNETUSERLOGINS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "USERID",
                table: "ASPNETUSERLOGINS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "PROVIDERKEY",
                table: "ASPNETUSERLOGINS",
                type: "TEXT",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LOGINPROVIDER",
                table: "ASPNETUSERLOGINS",
                type: "TEXT",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "USERID",
                table: "ASPNETUSERCLAIMS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "CLAIMVALUE",
                table: "ASPNETUSERCLAIMS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CLAIMTYPE",
                table: "ASPNETUSERCLAIMS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "ASPNETUSERCLAIMS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "NORMALIZEDNAME",
                table: "ASPNETROLES",
                type: "TEXT",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "ASPNETROLES",
                type: "TEXT",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CONCURRENCYSTAMP",
                table: "ASPNETROLES",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ID",
                table: "ASPNETROLES",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "CLAIMVALUE",
                table: "ASPNETROLECLAIMS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CLAIMTYPE",
                table: "ASPNETROLECLAIMS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ROLEID",
                table: "ASPNETROLECLAIMS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "ASPNETROLECLAIMS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "TAKENBYUSERID",
                table: "ALERTACTIONS",
                type: "TEXT",
                maxLength: 450,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(450)",
                oldMaxLength: 450);

            migrationBuilder.AlterColumn<int>(
                name: "EXECUTIVEALERTID",
                table: "ALERTACTIONS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "ACTIONTYPE",
                table: "ALERTACTIONS",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "ACTIONNOTES",
                table: "ALERTACTIONS",
                type: "TEXT",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ACTIONAT",
                table: "ALERTACTIONS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "ALERTACTIONS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "UPDATEDAT",
                table: "ALERTACTIONS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ISDELETED",
                table: "ALERTACTIONS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "CREATEDAT",
                table: "ALERTACTIONS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PRODUCTIMAGES",
                table: "PRODUCTIMAGES",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EXECUTIVEALERTS",
                table: "EXECUTIVEALERTS",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ALERTACTIONS",
                table: "ALERTACTIONS",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ALERTACTIONS_ASPNETUSERS_TAKENBYUSERID",
                table: "ALERTACTIONS",
                column: "TAKENBYUSERID",
                principalTable: "ASPNETUSERS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ALERTACTIONS_EXECUTIVEALERTS_EXECUTIVEALERTID",
                table: "ALERTACTIONS",
                column: "EXECUTIVEALERTID",
                principalTable: "EXECUTIVEALERTS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EXECUTIVEALERTS_ASPNETUSERS_USERID",
                table: "EXECUTIVEALERTS",
                column: "USERID",
                principalTable: "ASPNETUSERS",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_LOYALTYTRANSACTIONS_ORDERS_ORDERID",
                table: "LOYALTYTRANSACTIONS",
                column: "ORDERID",
                principalTable: "ORDERS",
                principalColumn: "ID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUCTIMAGES_PRODUCTS_PRODUCTID",
                table: "PRODUCTIMAGES",
                column: "PRODUCTID",
                principalTable: "PRODUCTS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
