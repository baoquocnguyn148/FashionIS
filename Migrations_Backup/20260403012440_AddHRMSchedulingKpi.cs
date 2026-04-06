using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FashionStoreIS.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddHRMSchedulingKpi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BANKACCOUNTNAME",
                table: "EMPLOYEES",
                type: "TEXT",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BANKACCOUNTNUMBER",
                table: "EMPLOYEES",
                type: "TEXT",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BANKNAME",
                table: "EMPLOYEES",
                type: "TEXT",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "BASESALARYPERHOUR",
                table: "EMPLOYEES",
                type: "NUMBER(12,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "DEPARTMENTID",
                table: "EMPLOYEES",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ATTENDANCES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EMPLOYEEID = table.Column<int>(type: "INTEGER", nullable: false),
                    DATE = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CHECKIN = table.Column<TimeSpan>(type: "TEXT", nullable: true),
                    CHECKOUT = table.Column<TimeSpan>(type: "TEXT", nullable: true),
                    TOTALHOURS = table.Column<double>(type: "NUMBER(5,2)", nullable: false),
                    STATUS = table.Column<byte>(type: "INTEGER", nullable: false),
                    NOTE = table.Column<string>(type: "TEXT", nullable: true),
                    CREATEDAT = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UPDATEDAT = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ISDELETED = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATTENDANCES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ATT_EMP",
                        column: x => x.EMPLOYEEID,
                        principalTable: "EMPLOYEES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DEPARTMENTS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NAME = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    DESCRIPTION = table.Column<string>(type: "TEXT", nullable: true),
                    ISACTIVE = table.Column<bool>(type: "INTEGER", nullable: false),
                    CREATEDAT = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UPDATEDAT = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ISDELETED = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEPARTMENTS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EXECUTIVEALERTS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TYPE = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    TITLE = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    DESCRIPTION = table.Column<string>(type: "TEXT", nullable: false),
                    IMPACT = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ACTIONREQUIRED = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    CATEGORY = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    SUBCATEGORY = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    USERID = table.Column<string>(type: "TEXT", maxLength: 450, nullable: true),
                    ISREAD = table.Column<bool>(type: "INTEGER", nullable: false),
                    READAT = table.Column<DateTime>(type: "TEXT", nullable: true),
                    PRIORITY = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    EXPIRESAT = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ISARCHIVED = table.Column<bool>(type: "INTEGER", nullable: false),
                    SOURCESYSTEM = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    CREATEDAT = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UPDATEDAT = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ISDELETED = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EXECUTIVEALERTS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EXECUTIVEALERTS_ASPNETUSERS_USERID",
                        column: x => x.USERID,
                        principalTable: "ASPNETUSERS",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "KPIREVIEWS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EMPLOYEEID = table.Column<int>(type: "INTEGER", nullable: false),
                    REVIEWERID = table.Column<string>(type: "TEXT", nullable: false),
                    MONTH = table.Column<int>(type: "INTEGER", nullable: false),
                    YEAR = table.Column<int>(type: "INTEGER", nullable: false),
                    SALESSCORE = table.Column<decimal>(type: "TEXT", nullable: false),
                    ATTITUDESCORE = table.Column<decimal>(type: "TEXT", nullable: false),
                    TEAMWORKSCORE = table.Column<decimal>(type: "TEXT", nullable: false),
                    TOTALSCORE = table.Column<decimal>(type: "TEXT", nullable: false),
                    RANK = table.Column<byte>(type: "INTEGER", nullable: false),
                    NOTES = table.Column<string>(type: "TEXT", nullable: true),
                    CREATEDAT = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UPDATEDAT = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ISDELETED = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KPIREVIEWS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_KPI_EMP",
                        column: x => x.EMPLOYEEID,
                        principalTable: "EMPLOYEES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KPI_REV",
                        column: x => x.REVIEWERID,
                        principalTable: "ASPNETUSERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LEAVEBALANCES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EMPLOYEEID = table.Column<int>(type: "INTEGER", nullable: false),
                    YEAR = table.Column<int>(type: "INTEGER", nullable: false),
                    ANNUALDAYSTOTAL = table.Column<int>(type: "INTEGER", nullable: false),
                    ANNUALDAYSUSED = table.Column<int>(type: "INTEGER", nullable: false),
                    SICKDAYSTOTAL = table.Column<int>(type: "INTEGER", nullable: false),
                    SICKDAYSUSED = table.Column<int>(type: "INTEGER", nullable: false),
                    CREATEDAT = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UPDATEDAT = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ISDELETED = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LEAVEBALANCES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LB_EMP",
                        column: x => x.EMPLOYEEID,
                        principalTable: "EMPLOYEES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LEAVEREQUESTS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EMPLOYEEID = table.Column<int>(type: "INTEGER", nullable: false),
                    STARTDATE = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ENDDATE = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TYPE = table.Column<byte>(type: "INTEGER", nullable: false),
                    STATUS = table.Column<byte>(type: "INTEGER", nullable: false),
                    REASON = table.Column<string>(type: "TEXT", nullable: true),
                    ADMINNOTE = table.Column<string>(type: "TEXT", nullable: true),
                    APPROVEDBYID = table.Column<string>(type: "TEXT", nullable: true),
                    CREATEDAT = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UPDATEDAT = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ISDELETED = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LEAVEREQUESTS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LEAVE_EMP",
                        column: x => x.EMPLOYEEID,
                        principalTable: "EMPLOYEES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PAYROLLS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EMPLOYEEID = table.Column<int>(type: "INTEGER", nullable: false),
                    MONTH = table.Column<int>(type: "INTEGER", nullable: false),
                    YEAR = table.Column<int>(type: "INTEGER", nullable: false),
                    TOTALHOURSWORKED = table.Column<double>(type: "NUMBER(8,2)", nullable: false),
                    BASEHOURLYRATE = table.Column<decimal>(type: "NUMBER(12,2)", nullable: false),
                    TOTALBASESALARY = table.Column<decimal>(type: "NUMBER(14,2)", nullable: false),
                    TOTALADDITIONS = table.Column<decimal>(type: "NUMBER(14,2)", nullable: false),
                    TOTALDEDUCTIONS = table.Column<decimal>(type: "NUMBER(14,2)", nullable: false),
                    NETSALARY = table.Column<decimal>(type: "NUMBER(14,2)", nullable: false),
                    STATUS = table.Column<byte>(type: "INTEGER", nullable: false),
                    PROCESSEDDATE = table.Column<DateTime>(type: "TEXT", nullable: true),
                    NOTE = table.Column<string>(type: "TEXT", nullable: true),
                    CREATEDAT = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UPDATEDAT = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ISDELETED = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAYROLLS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PAY_EMP",
                        column: x => x.EMPLOYEEID,
                        principalTable: "EMPLOYEES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SALARYCOMPONENTS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NAME = table.Column<string>(type: "TEXT", nullable: false),
                    TYPE = table.Column<byte>(type: "INTEGER", nullable: false),
                    DEFAULTAMOUNT = table.Column<decimal>(type: "NUMBER(12,2)", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "TEXT", nullable: true),
                    ISACTIVE = table.Column<bool>(type: "INTEGER", nullable: false),
                    CREATEDAT = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UPDATEDAT = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ISDELETED = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SALARYCOMPONENTS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SHIFTS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NAME = table.Column<string>(type: "TEXT", nullable: false),
                    STARTTIME = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    ENDTIME = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    STOREID = table.Column<int>(type: "INTEGER", nullable: false),
                    ISACTIVE = table.Column<bool>(type: "INTEGER", nullable: false),
                    CREATEDAT = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UPDATEDAT = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ISDELETED = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHIFTS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SHIFT_STORE",
                        column: x => x.STOREID,
                        principalTable: "STORES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WISHLISTITEMS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    USERID = table.Column<string>(type: "TEXT", maxLength: 450, nullable: false),
                    PRODUCTID = table.Column<int>(type: "INTEGER", nullable: false),
                    CREATEDAT = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UPDATEDAT = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ISDELETED = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WISHLISTITEMS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WL_PRODUCT",
                        column: x => x.PRODUCTID,
                        principalTable: "PRODUCTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WL_USER",
                        column: x => x.USERID,
                        principalTable: "ASPNETUSERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ALERTACTIONS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EXECUTIVEALERTID = table.Column<int>(type: "INTEGER", nullable: false),
                    ACTIONTYPE = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    TAKENBYUSERID = table.Column<string>(type: "TEXT", maxLength: 450, nullable: false),
                    ACTIONNOTES = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    ACTIONAT = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CREATEDAT = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UPDATEDAT = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ISDELETED = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ALERTACTIONS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ALERTACTIONS_ASPNETUSERS_TAKENBYUSERID",
                        column: x => x.TAKENBYUSERID,
                        principalTable: "ASPNETUSERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ALERTACTIONS_EXECUTIVEALERTS_EXECUTIVEALERTID",
                        column: x => x.EXECUTIVEALERTID,
                        principalTable: "EXECUTIVEALERTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PAYROLLITEMS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PAYROLLID = table.Column<int>(type: "INTEGER", nullable: false),
                    SALARYCOMPONENTID = table.Column<int>(type: "INTEGER", nullable: true),
                    AMOUNT = table.Column<decimal>(type: "NUMBER(12,2)", nullable: false),
                    NOTE = table.Column<string>(type: "TEXT", nullable: true),
                    CREATEDAT = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UPDATEDAT = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ISDELETED = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAYROLLITEMS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PI_PAY",
                        column: x => x.PAYROLLID,
                        principalTable: "PAYROLLS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PI_SC",
                        column: x => x.SALARYCOMPONENTID,
                        principalTable: "SALARYCOMPONENTS",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "SCHEDULES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EMPLOYEEID = table.Column<int>(type: "INTEGER", nullable: false),
                    SHIFTID = table.Column<int>(type: "INTEGER", nullable: false),
                    DATE = table.Column<DateTime>(type: "TEXT", nullable: false),
                    STATUS = table.Column<byte>(type: "INTEGER", nullable: false),
                    NOTE = table.Column<string>(type: "TEXT", nullable: true),
                    CREATEDAT = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UPDATEDAT = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ISDELETED = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SCHEDULES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SCHED_EMP",
                        column: x => x.EMPLOYEEID,
                        principalTable: "EMPLOYEES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SCHED_SHIFT",
                        column: x => x.SHIFTID,
                        principalTable: "SHIFTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEES_DEPARTMENTID",
                table: "EMPLOYEES",
                column: "DEPARTMENTID");

            migrationBuilder.CreateIndex(
                name: "IX_ALERTACTIONS_EXECUTIVEALERTID",
                table: "ALERTACTIONS",
                column: "EXECUTIVEALERTID");

            migrationBuilder.CreateIndex(
                name: "IX_ALERTACTIONS_TAKENBYUSERID",
                table: "ALERTACTIONS",
                column: "TAKENBYUSERID");

            migrationBuilder.CreateIndex(
                name: "IX_ATTENDANCES_EMPLOYEEID",
                table: "ATTENDANCES",
                column: "EMPLOYEEID");

            migrationBuilder.CreateIndex(
                name: "IX_EXECUTIVEALERTS_USERID",
                table: "EXECUTIVEALERTS",
                column: "USERID");

            migrationBuilder.CreateIndex(
                name: "IX_KPIREVIEWS_EMPLOYEEID",
                table: "KPIREVIEWS",
                column: "EMPLOYEEID");

            migrationBuilder.CreateIndex(
                name: "IX_KPIREVIEWS_REVIEWERID",
                table: "KPIREVIEWS",
                column: "REVIEWERID");

            migrationBuilder.CreateIndex(
                name: "IX_LEAVEBALANCES_EMPLOYEEID",
                table: "LEAVEBALANCES",
                column: "EMPLOYEEID");

            migrationBuilder.CreateIndex(
                name: "IX_LEAVEREQUESTS_EMPLOYEEID",
                table: "LEAVEREQUESTS",
                column: "EMPLOYEEID");

            migrationBuilder.CreateIndex(
                name: "IX_PAYROLLITEMS_PAYROLLID",
                table: "PAYROLLITEMS",
                column: "PAYROLLID");

            migrationBuilder.CreateIndex(
                name: "IX_PAYROLLITEMS_SALARYCOMPONENTID",
                table: "PAYROLLITEMS",
                column: "SALARYCOMPONENTID");

            migrationBuilder.CreateIndex(
                name: "IX_PAYROLLS_EMPLOYEEID",
                table: "PAYROLLS",
                column: "EMPLOYEEID");

            migrationBuilder.CreateIndex(
                name: "IX_SCHEDULES_EMPLOYEEID",
                table: "SCHEDULES",
                column: "EMPLOYEEID");

            migrationBuilder.CreateIndex(
                name: "IX_SCHEDULES_SHIFTID",
                table: "SCHEDULES",
                column: "SHIFTID");

            migrationBuilder.CreateIndex(
                name: "IX_SHIFTS_STOREID",
                table: "SHIFTS",
                column: "STOREID");

            migrationBuilder.CreateIndex(
                name: "IX_WISHLISTITEMS_PRODUCTID",
                table: "WISHLISTITEMS",
                column: "PRODUCTID");

            migrationBuilder.CreateIndex(
                name: "UQ_WL_USER_PROD",
                table: "WISHLISTITEMS",
                columns: new[] { "USERID", "PRODUCTID" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EMP_DEPT",
                table: "EMPLOYEES",
                column: "DEPARTMENTID",
                principalTable: "DEPARTMENTS",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EMP_DEPT",
                table: "EMPLOYEES");

            migrationBuilder.DropTable(
                name: "ALERTACTIONS");

            migrationBuilder.DropTable(
                name: "ATTENDANCES");

            migrationBuilder.DropTable(
                name: "DEPARTMENTS");

            migrationBuilder.DropTable(
                name: "KPIREVIEWS");

            migrationBuilder.DropTable(
                name: "LEAVEBALANCES");

            migrationBuilder.DropTable(
                name: "LEAVEREQUESTS");

            migrationBuilder.DropTable(
                name: "PAYROLLITEMS");

            migrationBuilder.DropTable(
                name: "SCHEDULES");

            migrationBuilder.DropTable(
                name: "WISHLISTITEMS");

            migrationBuilder.DropTable(
                name: "EXECUTIVEALERTS");

            migrationBuilder.DropTable(
                name: "PAYROLLS");

            migrationBuilder.DropTable(
                name: "SALARYCOMPONENTS");

            migrationBuilder.DropTable(
                name: "SHIFTS");

            migrationBuilder.DropIndex(
                name: "IX_EMPLOYEES_DEPARTMENTID",
                table: "EMPLOYEES");

            migrationBuilder.DropColumn(
                name: "BANKACCOUNTNAME",
                table: "EMPLOYEES");

            migrationBuilder.DropColumn(
                name: "BANKACCOUNTNUMBER",
                table: "EMPLOYEES");

            migrationBuilder.DropColumn(
                name: "BANKNAME",
                table: "EMPLOYEES");

            migrationBuilder.DropColumn(
                name: "BASESALARYPERHOUR",
                table: "EMPLOYEES");

            migrationBuilder.DropColumn(
                name: "DEPARTMENTID",
                table: "EMPLOYEES");
        }
    }
}
