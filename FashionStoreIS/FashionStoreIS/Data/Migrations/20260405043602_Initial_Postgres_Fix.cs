using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FashionStoreIS.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Postgres_Fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "aspnetroles",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalizedname = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    concurrencystamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aspnetroles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "aspnetusers",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    fullname = table.Column<string>(type: "text", nullable: true),
                    dateofbirth = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    gender = table.Column<string>(type: "text", nullable: true),
                    avatarurl = table.Column<string>(type: "text", nullable: true),
                    membershippoints = table.Column<int>(type: "integer", nullable: false),
                    joindate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    username = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalizedusername = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalizedemail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    emailconfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    passwordhash = table.Column<string>(type: "text", nullable: true),
                    securitystamp = table.Column<string>(type: "text", nullable: true),
                    concurrencystamp = table.Column<string>(type: "text", nullable: true),
                    phonenumber = table.Column<string>(type: "text", nullable: true),
                    phonenumberconfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    twofactorenabled = table.Column<bool>(type: "boolean", nullable: false),
                    lockoutend = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    lockoutenabled = table.Column<bool>(type: "boolean", nullable: false),
                    accessfailedcount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aspnetusers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "BANNERS",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    subtitle = table.Column<string>(type: "text", nullable: true),
                    imageurl = table.Column<string>(type: "text", nullable: true),
                    linkurl = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    position = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    isactive = table.Column<bool>(type: "boolean", nullable: false),
                    displayorder = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BANNERS", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CATEGORIES",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NAME = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    SLUG = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    DESCRIPTION = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IMAGEURL = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    DISPLAYORDER = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    ISACTIVE = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    PARENTCATEGORYID = table.Column<int>(type: "integer", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORIES", x => x.id);
                    table.ForeignKey(
                        name: "FK_CAT_PARENT",
                        column: x => x.PARENTCATEGORYID,
                        principalTable: "CATEGORIES",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "DEPARTMENTS",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NAME = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    isactive = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEPARTMENTS", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SALARYCOMPONENTS",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    type = table.Column<byte>(type: "smallint", nullable: false),
                    DEFAULTAMOUNT = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    isactive = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SALARYCOMPONENTS", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "STORES",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NAME = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ADDRESS = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    PHONE = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    managername = table.Column<string>(type: "text", nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STORES", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SUPPLIERS",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NAME = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    contactperson = table.Column<string>(type: "text", nullable: true),
                    PHONE = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    EMAIL = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    address = table.Column<string>(type: "text", nullable: true),
                    leadtimedays = table.Column<int>(type: "integer", nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUPPLIERS", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "VOUCHERS",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CODE = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    DISCOUNTAMOUNT = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    MINORDERAMOUNT = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    EXPIRYDATE = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ISACTIVE = table.Column<bool>(type: "boolean", nullable: false),
                    MAXUSAGECOUNT = table.Column<int>(type: "integer", nullable: false),
                    USEDCOUNT = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VOUCHERS", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "aspnetroleclaims",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    roleid = table.Column<string>(type: "text", nullable: false),
                    claimtype = table.Column<string>(type: "text", nullable: true),
                    claimvalue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aspnetroleclaims", x => x.id);
                    table.ForeignKey(
                        name: "FK_aspnetroleclaims_aspnetroles_roleid",
                        column: x => x.roleid,
                        principalTable: "aspnetroles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "aspnetuserclaims",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userid = table.Column<string>(type: "text", nullable: false),
                    claimtype = table.Column<string>(type: "text", nullable: true),
                    claimvalue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aspnetuserclaims", x => x.id);
                    table.ForeignKey(
                        name: "FK_aspnetuserclaims_aspnetusers_userid",
                        column: x => x.userid,
                        principalTable: "aspnetusers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "aspnetuserlogins",
                columns: table => new
                {
                    loginprovider = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    providerkey = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    providerdisplayname = table.Column<string>(type: "text", nullable: true),
                    userid = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aspnetuserlogins", x => new { x.loginprovider, x.providerkey });
                    table.ForeignKey(
                        name: "FK_aspnetuserlogins_aspnetusers_userid",
                        column: x => x.userid,
                        principalTable: "aspnetusers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "aspnetuserroles",
                columns: table => new
                {
                    userid = table.Column<string>(type: "text", nullable: false),
                    roleid = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aspnetuserroles", x => new { x.userid, x.roleid });
                    table.ForeignKey(
                        name: "FK_aspnetuserroles_aspnetroles_roleid",
                        column: x => x.roleid,
                        principalTable: "aspnetroles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_aspnetuserroles_aspnetusers_userid",
                        column: x => x.userid,
                        principalTable: "aspnetusers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "aspnetusertokens",
                columns: table => new
                {
                    userid = table.Column<string>(type: "text", nullable: false),
                    loginprovider = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aspnetusertokens", x => new { x.userid, x.loginprovider, x.name });
                    table.ForeignKey(
                        name: "FK_aspnetusertokens_aspnetusers_userid",
                        column: x => x.userid,
                        principalTable: "aspnetusers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CUSTOMERS",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FULLNAME = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PHONE = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    EMAIL = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    address = table.Column<string>(type: "text", nullable: true),
                    dateofbirth = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    tier = table.Column<int>(type: "integer", nullable: false),
                    loyaltypoints = table.Column<int>(type: "integer", nullable: false),
                    userid = table.Column<string>(type: "text", nullable: true),
                    joindate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMERS", x => x.id);
                    table.ForeignKey(
                        name: "FK_CUST_USER",
                        column: x => x.userid,
                        principalTable: "aspnetusers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "executivealerts",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    impact = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    actionrequired = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    category = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    subcategory = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    userid = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: true),
                    isread = table.Column<bool>(type: "boolean", nullable: false),
                    readat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    priority = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    expiresat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    isarchived = table.Column<bool>(type: "boolean", nullable: false),
                    sourcesystem = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_executivealerts", x => x.id);
                    table.ForeignKey(
                        name: "FK_executivealerts_aspnetusers_userid",
                        column: x => x.userid,
                        principalTable: "aspnetusers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "NOTIFICATIONS",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    USERID = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: false),
                    TITLE = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    MESSAGE = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    ISREAD = table.Column<bool>(type: "boolean", nullable: false),
                    ACTIONURL = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NOTIFICATIONS", x => x.id);
                    table.ForeignKey(
                        name: "FK_NOTIF_USER",
                        column: x => x.USERID,
                        principalTable: "aspnetusers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "USERADDRESSES",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    USERID = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: false),
                    FULLNAME = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PHONENUMBER = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    ADDRESSLINE = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    ISDEFAULT = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERADDRESSES", x => x.id);
                    table.ForeignKey(
                        name: "FK_UA_USER",
                        column: x => x.USERID,
                        principalTable: "aspnetusers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EMPLOYEES",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FULLNAME = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    phone = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    POSITION = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    hiredate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false),
                    BASESALARYPERHOUR = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    BANKACCOUNTNUMBER = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    BANKNAME = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    BANKACCOUNTNAME = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    departmentid = table.Column<int>(type: "integer", nullable: true),
                    userid = table.Column<string>(type: "text", nullable: true),
                    storeid = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPLOYEES", x => x.id);
                    table.ForeignKey(
                        name: "FK_EMP_DEPT",
                        column: x => x.departmentid,
                        principalTable: "DEPARTMENTS",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_EMP_STORE",
                        column: x => x.storeid,
                        principalTable: "STORES",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SHIFTS",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    starttime = table.Column<TimeSpan>(type: "interval", nullable: false),
                    endtime = table.Column<TimeSpan>(type: "interval", nullable: false),
                    storeid = table.Column<int>(type: "integer", nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHIFTS", x => x.id);
                    table.ForeignKey(
                        name: "FK_SHIFT_STORE",
                        column: x => x.storeid,
                        principalTable: "STORES",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCTS",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NAME = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    SLUG = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    imageurl = table.Column<string>(type: "text", nullable: true),
                    price = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    STOCK = table.Column<int>(type: "int", nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false),
                    categoryid = table.Column<int>(type: "integer", nullable: true),
                    supplierid = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCTS", x => x.id);
                    table.ForeignKey(
                        name: "FK_PROD_CAT",
                        column: x => x.categoryid,
                        principalTable: "CATEGORIES",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_PROD_SUP",
                        column: x => x.supplierid,
                        principalTable: "SUPPLIERS",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PURCHASEORDERS",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    POCODE = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    orderdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    expecteddate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    receiveddate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    status = table.Column<byte>(type: "smallint", nullable: false),
                    TOTALCOST = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    note = table.Column<string>(type: "text", nullable: true),
                    supplierid = table.Column<int>(type: "integer", nullable: false),
                    storeid = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PURCHASEORDERS", x => x.id);
                    table.ForeignKey(
                        name: "FK_PO_STORE",
                        column: x => x.storeid,
                        principalTable: "STORES",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PO_SUP",
                        column: x => x.supplierid,
                        principalTable: "SUPPLIERS",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CAMPAIGNS",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NAME = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    DESCRIPTION = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    STARTDATE = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ENDDATE = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TARGETSEGMENT = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    voucherid = table.Column<int>(type: "integer", nullable: true),
                    NOTIFICATIONTITLE = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    NOTIFICATIONMESSAGE = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    ISSENT = table.Column<bool>(type: "boolean", nullable: false),
                    SENTAT = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    RECIPIENTCOUNT = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CAMPAIGNS", x => x.id);
                    table.ForeignKey(
                        name: "FK_CAMP_VOUCHER",
                        column: x => x.voucherid,
                        principalTable: "VOUCHERS",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ORDERS",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ORDERCODE = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    STATUS = table.Column<byte>(type: "smallint", nullable: false),
                    paymentmethod = table.Column<byte>(type: "smallint", nullable: false),
                    paymentstatus = table.Column<byte>(type: "smallint", nullable: false),
                    SUBTOTAL = table.Column<decimal>(type: "numeric(18,2)", nullable: false, defaultValue: 0m),
                    discountamount = table.Column<decimal>(type: "numeric", nullable: false, defaultValue: 0m),
                    TOTALAMOUNT = table.Column<decimal>(type: "numeric(18,2)", nullable: false, defaultValue: 0m),
                    pointsearned = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    note = table.Column<string>(type: "text", nullable: true),
                    voucherid = table.Column<int>(type: "integer", nullable: true),
                    customername = table.Column<string>(type: "text", nullable: true),
                    phone = table.Column<string>(type: "text", nullable: true),
                    address = table.Column<string>(type: "text", nullable: true),
                    storeid = table.Column<int>(type: "integer", nullable: false),
                    customerid = table.Column<int>(type: "integer", nullable: true),
                    userid = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDERS", x => x.id);
                    table.ForeignKey(
                        name: "FK_ORDERS_CUSTOMERS_customerid",
                        column: x => x.customerid,
                        principalTable: "CUSTOMERS",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ORDERS_VOUCHERS_voucherid",
                        column: x => x.voucherid,
                        principalTable: "VOUCHERS",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ORDERS_aspnetusers_userid",
                        column: x => x.userid,
                        principalTable: "aspnetusers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ORD_STORE",
                        column: x => x.storeid,
                        principalTable: "STORES",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "alertactions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    executivealertid = table.Column<int>(type: "integer", nullable: false),
                    actiontype = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    takenbyuserid = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: false),
                    actionnotes = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    actionat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alertactions", x => x.id);
                    table.ForeignKey(
                        name: "FK_alertactions_aspnetusers_takenbyuserid",
                        column: x => x.takenbyuserid,
                        principalTable: "aspnetusers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_alertactions_executivealerts_executivealertid",
                        column: x => x.executivealertid,
                        principalTable: "executivealerts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ATTENDANCES",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    employeeid = table.Column<int>(type: "integer", nullable: false),
                    DATE = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    checkin = table.Column<TimeSpan>(type: "interval", nullable: true),
                    checkout = table.Column<TimeSpan>(type: "interval", nullable: true),
                    TOTALHOURS = table.Column<double>(type: "numeric(5,2)", nullable: false),
                    status = table.Column<byte>(type: "smallint", nullable: false),
                    note = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATTENDANCES", x => x.id);
                    table.ForeignKey(
                        name: "FK_ATT_EMP",
                        column: x => x.employeeid,
                        principalTable: "EMPLOYEES",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KPIREVIEWS",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    employeeid = table.Column<int>(type: "integer", nullable: false),
                    reviewerid = table.Column<string>(type: "text", nullable: false),
                    month = table.Column<int>(type: "integer", nullable: false),
                    year = table.Column<int>(type: "integer", nullable: false),
                    salesscore = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    attitudescore = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    teamworkscore = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    totalscore = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    rank = table.Column<byte>(type: "smallint", nullable: false),
                    notes = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KPIREVIEWS", x => x.id);
                    table.ForeignKey(
                        name: "FK_KPI_EMP",
                        column: x => x.employeeid,
                        principalTable: "EMPLOYEES",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KPI_REV",
                        column: x => x.reviewerid,
                        principalTable: "aspnetusers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LEAVEBALANCES",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    employeeid = table.Column<int>(type: "integer", nullable: false),
                    year = table.Column<int>(type: "integer", nullable: false),
                    annualdaystotal = table.Column<int>(type: "integer", nullable: false),
                    annualdaysused = table.Column<int>(type: "integer", nullable: false),
                    sickdaystotal = table.Column<int>(type: "integer", nullable: false),
                    sickdaysused = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LEAVEBALANCES", x => x.id);
                    table.ForeignKey(
                        name: "FK_LB_EMP",
                        column: x => x.employeeid,
                        principalTable: "EMPLOYEES",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LEAVEREQUESTS",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    employeeid = table.Column<int>(type: "integer", nullable: false),
                    startdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    enddate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    type = table.Column<byte>(type: "smallint", nullable: false),
                    status = table.Column<byte>(type: "smallint", nullable: false),
                    reason = table.Column<string>(type: "text", nullable: true),
                    adminnote = table.Column<string>(type: "text", nullable: true),
                    approvedbyid = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LEAVEREQUESTS", x => x.id);
                    table.ForeignKey(
                        name: "FK_LEAVE_EMP",
                        column: x => x.employeeid,
                        principalTable: "EMPLOYEES",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PAYROLLS",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    employeeid = table.Column<int>(type: "integer", nullable: false),
                    MONTH = table.Column<int>(type: "integer", nullable: false),
                    YEAR = table.Column<int>(type: "integer", nullable: false),
                    TOTALHOURSWORKED = table.Column<double>(type: "numeric(8,2)", nullable: false),
                    BASEHOURLYRATE = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    TOTALBASESALARY = table.Column<decimal>(type: "numeric(14,2)", nullable: false),
                    TOTALADDITIONS = table.Column<decimal>(type: "numeric(14,2)", nullable: false),
                    TOTALDEDUCTIONS = table.Column<decimal>(type: "numeric(14,2)", nullable: false),
                    NETSALARY = table.Column<decimal>(type: "numeric(14,2)", nullable: false),
                    status = table.Column<byte>(type: "smallint", nullable: false),
                    processeddate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    note = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAYROLLS", x => x.id);
                    table.ForeignKey(
                        name: "FK_PAY_EMP",
                        column: x => x.employeeid,
                        principalTable: "EMPLOYEES",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SCHEDULES",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    employeeid = table.Column<int>(type: "integer", nullable: false),
                    shiftid = table.Column<int>(type: "integer", nullable: false),
                    date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    status = table.Column<byte>(type: "smallint", nullable: false),
                    note = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SCHEDULES", x => x.id);
                    table.ForeignKey(
                        name: "FK_SCHED_EMP",
                        column: x => x.employeeid,
                        principalTable: "EMPLOYEES",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SCHED_SHIFT",
                        column: x => x.shiftid,
                        principalTable: "SHIFTS",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productimages",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    productid = table.Column<int>(type: "integer", nullable: false),
                    imageurl = table.Column<string>(type: "text", nullable: false),
                    displayorder = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productimages", x => x.id);
                    table.ForeignKey(
                        name: "FK_productimages_PRODUCTS_productid",
                        column: x => x.productid,
                        principalTable: "PRODUCTS",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCTSKUS",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SKU = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    SKUCODE = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    SIZE = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    COLOR = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    COSTPRICE = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    SELLINGPRICE = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    PRICEOVERRIDE = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    STOCK = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    isactive = table.Column<bool>(type: "boolean", nullable: false),
                    productid = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCTSKUS", x => x.id);
                    table.ForeignKey(
                        name: "FK_SKU_PROD",
                        column: x => x.productid,
                        principalTable: "PRODUCTS",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "wishlistitems",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    USERID = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: false),
                    PRODUCTID = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wishlistitems", x => x.id);
                    table.ForeignKey(
                        name: "FK_WL_PRODUCT",
                        column: x => x.PRODUCTID,
                        principalTable: "PRODUCTS",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WL_USER",
                        column: x => x.USERID,
                        principalTable: "aspnetusers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LOYALTYTRANSACTIONS",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    points = table.Column<int>(type: "integer", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    orderid = table.Column<int>(type: "integer", nullable: true),
                    customerid = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOYALTYTRANSACTIONS", x => x.id);
                    table.ForeignKey(
                        name: "FK_LOYALTYTRANSACTIONS_ORDERS_orderid",
                        column: x => x.orderid,
                        principalTable: "ORDERS",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_LT_CUST",
                        column: x => x.customerid,
                        principalTable: "CUSTOMERS",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RETURNREQUESTS",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ORDERID = table.Column<int>(type: "integer", nullable: false),
                    REASON = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    STATUS = table.Column<byte>(type: "smallint", nullable: false),
                    REFUNDAMOUNT = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    ADMINNOTE = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    PROCESSEDAT = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RETURNREQUESTS", x => x.id);
                    table.ForeignKey(
                        name: "FK_RR_ORDER",
                        column: x => x.ORDERID,
                        principalTable: "ORDERS",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PAYROLLITEMS",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    payrollid = table.Column<int>(type: "integer", nullable: false),
                    salarycomponentid = table.Column<int>(type: "integer", nullable: true),
                    AMOUNT = table.Column<decimal>(type: "numeric(12,2)", nullable: false),
                    note = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAYROLLITEMS", x => x.id);
                    table.ForeignKey(
                        name: "FK_PI_PAY",
                        column: x => x.payrollid,
                        principalTable: "PAYROLLS",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PI_SC",
                        column: x => x.salarycomponentid,
                        principalTable: "SALARYCOMPONENTS",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "INVENTORIES",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    quantityonhand = table.Column<int>(type: "integer", nullable: false),
                    reorderpoint = table.Column<int>(type: "integer", nullable: false),
                    maxstocklevel = table.Column<int>(type: "integer", nullable: true),
                    lastupdated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    storeid = table.Column<int>(type: "integer", nullable: false),
                    productskuid = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INVENTORIES", x => x.id);
                    table.ForeignKey(
                        name: "FK_INV_SKU",
                        column: x => x.productskuid,
                        principalTable: "PRODUCTSKUS",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_INV_STORE",
                        column: x => x.storeid,
                        principalTable: "STORES",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ORDERDETAILS",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    UNITPRICE = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    discountpercent = table.Column<decimal>(type: "numeric", nullable: false, defaultValue: 0m),
                    SUBTOTAL = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    orderid = table.Column<int>(type: "integer", nullable: false),
                    productskuid = table.Column<int>(type: "integer", nullable: true),
                    productid = table.Column<int>(type: "integer", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDERDETAILS", x => x.id);
                    table.ForeignKey(
                        name: "FK_OD_ORD",
                        column: x => x.orderid,
                        principalTable: "ORDERS",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ORDERDETAILS_PRODUCTSKUS_productskuid",
                        column: x => x.productskuid,
                        principalTable: "PRODUCTSKUS",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ORDERDETAILS_PRODUCTS_productid",
                        column: x => x.productid,
                        principalTable: "PRODUCTS",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PURCHASEORDERDETAILS",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    quantityordered = table.Column<int>(type: "integer", nullable: false),
                    quantityreceived = table.Column<int>(type: "integer", nullable: false),
                    UNITCOST = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    SUBTOTAL = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    purchaseorderid = table.Column<int>(type: "integer", nullable: false),
                    productskuid = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PURCHASEORDERDETAILS", x => x.id);
                    table.ForeignKey(
                        name: "FK_POD_PO",
                        column: x => x.purchaseorderid,
                        principalTable: "PURCHASEORDERS",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_POD_SKU",
                        column: x => x.productskuid,
                        principalTable: "PRODUCTSKUS",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "STOCKADJUSTMENTS",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    quantitybefore = table.Column<int>(type: "integer", nullable: false),
                    quantitychange = table.Column<int>(type: "integer", nullable: false),
                    quantityafter = table.Column<int>(type: "integer", nullable: false),
                    reason = table.Column<byte>(type: "smallint", nullable: false),
                    note = table.Column<string>(type: "text", nullable: true),
                    adjustedbyuserid = table.Column<string>(type: "text", nullable: true),
                    inventoryid = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STOCKADJUSTMENTS", x => x.id);
                    table.ForeignKey(
                        name: "FK_SA_INV",
                        column: x => x.inventoryid,
                        principalTable: "INVENTORIES",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_alertactions_executivealertid",
                table: "alertactions",
                column: "executivealertid");

            migrationBuilder.CreateIndex(
                name: "IX_alertactions_takenbyuserid",
                table: "alertactions",
                column: "takenbyuserid");

            migrationBuilder.CreateIndex(
                name: "IX_aspnetroleclaims_roleid",
                table: "aspnetroleclaims",
                column: "roleid");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "aspnetroles",
                column: "normalizedname",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_aspnetuserclaims_userid",
                table: "aspnetuserclaims",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_aspnetuserlogins_userid",
                table: "aspnetuserlogins",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_aspnetuserroles_roleid",
                table: "aspnetuserroles",
                column: "roleid");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "aspnetusers",
                column: "normalizedemail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "aspnetusers",
                column: "normalizedusername",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ATTENDANCES_employeeid",
                table: "ATTENDANCES",
                column: "employeeid");

            migrationBuilder.CreateIndex(
                name: "IX_CAMPAIGNS_voucherid",
                table: "CAMPAIGNS",
                column: "voucherid");

            migrationBuilder.CreateIndex(
                name: "IX_CATEGORIES_PARENTCATEGORYID",
                table: "CATEGORIES",
                column: "PARENTCATEGORYID");

            migrationBuilder.CreateIndex(
                name: "IX_CUSTOMERS_userid",
                table: "CUSTOMERS",
                column: "userid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEES_departmentid",
                table: "EMPLOYEES",
                column: "departmentid");

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEES_storeid",
                table: "EMPLOYEES",
                column: "storeid");

            migrationBuilder.CreateIndex(
                name: "IX_executivealerts_userid",
                table: "executivealerts",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_INVENTORIES_productskuid",
                table: "INVENTORIES",
                column: "productskuid");

            migrationBuilder.CreateIndex(
                name: "IX_INVENTORIES_storeid",
                table: "INVENTORIES",
                column: "storeid");

            migrationBuilder.CreateIndex(
                name: "IX_KPIREVIEWS_employeeid",
                table: "KPIREVIEWS",
                column: "employeeid");

            migrationBuilder.CreateIndex(
                name: "IX_KPIREVIEWS_reviewerid",
                table: "KPIREVIEWS",
                column: "reviewerid");

            migrationBuilder.CreateIndex(
                name: "IX_LEAVEBALANCES_employeeid",
                table: "LEAVEBALANCES",
                column: "employeeid");

            migrationBuilder.CreateIndex(
                name: "IX_LEAVEREQUESTS_employeeid",
                table: "LEAVEREQUESTS",
                column: "employeeid");

            migrationBuilder.CreateIndex(
                name: "IX_LOYALTYTRANSACTIONS_customerid",
                table: "LOYALTYTRANSACTIONS",
                column: "customerid");

            migrationBuilder.CreateIndex(
                name: "IX_LOYALTYTRANSACTIONS_orderid",
                table: "LOYALTYTRANSACTIONS",
                column: "orderid");

            migrationBuilder.CreateIndex(
                name: "IX_NOTIFICATIONS_USERID",
                table: "NOTIFICATIONS",
                column: "USERID");

            migrationBuilder.CreateIndex(
                name: "IX_ORDERDETAILS_orderid",
                table: "ORDERDETAILS",
                column: "orderid");

            migrationBuilder.CreateIndex(
                name: "IX_ORDERDETAILS_productid",
                table: "ORDERDETAILS",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "IX_ORDERDETAILS_productskuid",
                table: "ORDERDETAILS",
                column: "productskuid");

            migrationBuilder.CreateIndex(
                name: "IX_ORDERS_customerid",
                table: "ORDERS",
                column: "customerid");

            migrationBuilder.CreateIndex(
                name: "IX_ORDERS_ORDERCODE",
                table: "ORDERS",
                column: "ORDERCODE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ORDERS_storeid",
                table: "ORDERS",
                column: "storeid");

            migrationBuilder.CreateIndex(
                name: "IX_ORDERS_userid",
                table: "ORDERS",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_ORDERS_voucherid",
                table: "ORDERS",
                column: "voucherid");

            migrationBuilder.CreateIndex(
                name: "IX_PAYROLLITEMS_payrollid",
                table: "PAYROLLITEMS",
                column: "payrollid");

            migrationBuilder.CreateIndex(
                name: "IX_PAYROLLITEMS_salarycomponentid",
                table: "PAYROLLITEMS",
                column: "salarycomponentid");

            migrationBuilder.CreateIndex(
                name: "IX_PAYROLLS_employeeid",
                table: "PAYROLLS",
                column: "employeeid");

            migrationBuilder.CreateIndex(
                name: "IX_productimages_productid",
                table: "productimages",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTS_categoryid",
                table: "PRODUCTS",
                column: "categoryid");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTS_supplierid",
                table: "PRODUCTS",
                column: "supplierid");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTSKUS_productid",
                table: "PRODUCTSKUS",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "IX_PURCHASEORDERDETAILS_productskuid",
                table: "PURCHASEORDERDETAILS",
                column: "productskuid");

            migrationBuilder.CreateIndex(
                name: "IX_PURCHASEORDERDETAILS_purchaseorderid",
                table: "PURCHASEORDERDETAILS",
                column: "purchaseorderid");

            migrationBuilder.CreateIndex(
                name: "IX_PURCHASEORDERS_storeid",
                table: "PURCHASEORDERS",
                column: "storeid");

            migrationBuilder.CreateIndex(
                name: "IX_PURCHASEORDERS_supplierid",
                table: "PURCHASEORDERS",
                column: "supplierid");

            migrationBuilder.CreateIndex(
                name: "IX_RETURNREQUESTS_ORDERID",
                table: "RETURNREQUESTS",
                column: "ORDERID");

            migrationBuilder.CreateIndex(
                name: "IX_SCHEDULES_employeeid",
                table: "SCHEDULES",
                column: "employeeid");

            migrationBuilder.CreateIndex(
                name: "IX_SCHEDULES_shiftid",
                table: "SCHEDULES",
                column: "shiftid");

            migrationBuilder.CreateIndex(
                name: "IX_SHIFTS_storeid",
                table: "SHIFTS",
                column: "storeid");

            migrationBuilder.CreateIndex(
                name: "IX_STOCKADJUSTMENTS_inventoryid",
                table: "STOCKADJUSTMENTS",
                column: "inventoryid");

            migrationBuilder.CreateIndex(
                name: "IX_USERADDRESSES_USERID",
                table: "USERADDRESSES",
                column: "USERID");

            migrationBuilder.CreateIndex(
                name: "IX_VOUCHERS_CODE",
                table: "VOUCHERS",
                column: "CODE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_wishlistitems_PRODUCTID",
                table: "wishlistitems",
                column: "PRODUCTID");

            migrationBuilder.CreateIndex(
                name: "UQ_WL_USER_PROD",
                table: "wishlistitems",
                columns: new[] { "USERID", "PRODUCTID" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "alertactions");

            migrationBuilder.DropTable(
                name: "aspnetroleclaims");

            migrationBuilder.DropTable(
                name: "aspnetuserclaims");

            migrationBuilder.DropTable(
                name: "aspnetuserlogins");

            migrationBuilder.DropTable(
                name: "aspnetuserroles");

            migrationBuilder.DropTable(
                name: "aspnetusertokens");

            migrationBuilder.DropTable(
                name: "ATTENDANCES");

            migrationBuilder.DropTable(
                name: "BANNERS");

            migrationBuilder.DropTable(
                name: "CAMPAIGNS");

            migrationBuilder.DropTable(
                name: "KPIREVIEWS");

            migrationBuilder.DropTable(
                name: "LEAVEBALANCES");

            migrationBuilder.DropTable(
                name: "LEAVEREQUESTS");

            migrationBuilder.DropTable(
                name: "LOYALTYTRANSACTIONS");

            migrationBuilder.DropTable(
                name: "NOTIFICATIONS");

            migrationBuilder.DropTable(
                name: "ORDERDETAILS");

            migrationBuilder.DropTable(
                name: "PAYROLLITEMS");

            migrationBuilder.DropTable(
                name: "productimages");

            migrationBuilder.DropTable(
                name: "PURCHASEORDERDETAILS");

            migrationBuilder.DropTable(
                name: "RETURNREQUESTS");

            migrationBuilder.DropTable(
                name: "SCHEDULES");

            migrationBuilder.DropTable(
                name: "STOCKADJUSTMENTS");

            migrationBuilder.DropTable(
                name: "USERADDRESSES");

            migrationBuilder.DropTable(
                name: "wishlistitems");

            migrationBuilder.DropTable(
                name: "executivealerts");

            migrationBuilder.DropTable(
                name: "aspnetroles");

            migrationBuilder.DropTable(
                name: "PAYROLLS");

            migrationBuilder.DropTable(
                name: "SALARYCOMPONENTS");

            migrationBuilder.DropTable(
                name: "PURCHASEORDERS");

            migrationBuilder.DropTable(
                name: "ORDERS");

            migrationBuilder.DropTable(
                name: "SHIFTS");

            migrationBuilder.DropTable(
                name: "INVENTORIES");

            migrationBuilder.DropTable(
                name: "EMPLOYEES");

            migrationBuilder.DropTable(
                name: "CUSTOMERS");

            migrationBuilder.DropTable(
                name: "VOUCHERS");

            migrationBuilder.DropTable(
                name: "PRODUCTSKUS");

            migrationBuilder.DropTable(
                name: "DEPARTMENTS");

            migrationBuilder.DropTable(
                name: "STORES");

            migrationBuilder.DropTable(
                name: "aspnetusers");

            migrationBuilder.DropTable(
                name: "PRODUCTS");

            migrationBuilder.DropTable(
                name: "CATEGORIES");

            migrationBuilder.DropTable(
                name: "SUPPLIERS");
        }
    }
}
