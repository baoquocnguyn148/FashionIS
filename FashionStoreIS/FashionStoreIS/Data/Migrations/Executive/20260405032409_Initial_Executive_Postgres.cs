using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FashionStoreIS.Data.Migrations.Executive
{
    /// <inheritdoc />
    public partial class Initial_Executive_Postgres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "applicationuser",
                columns: table => new
                {
                    id = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    fullname = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    dateofbirth = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    gender = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    avatarurl = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    membershippoints = table.Column<int>(type: "integer", nullable: false),
                    joindate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    username = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    normalizedusername = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    email = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    normalizedemail = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    emailconfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    passwordhash = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    securitystamp = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    concurrencystamp = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    phonenumber = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    phonenumberconfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    twofactorenabled = table.Column<bool>(type: "boolean", nullable: false),
                    lockoutend = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    lockoutenabled = table.Column<bool>(type: "boolean", nullable: false),
                    accessfailedcount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_applicationuser", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    slug = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    imageurl = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    displayorder = table.Column<int>(type: "integer", nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false),
                    parentcategoryid = table.Column<int>(type: "integer", nullable: true),
                    createdat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updatedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.id);
                    table.ForeignKey(
                        name: "FK_category_category_parentcategoryid",
                        column: x => x.parentcategoryid,
                        principalTable: "category",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "competitiveintelligence",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    competitorname = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    datatype = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    datacontent = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    datatimestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    source = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    region = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    confidencescore = table.Column<decimal>(type: "numeric(5,2)", precision: 18, scale: 2, nullable: true),
                    isverified = table.Column<bool>(type: "boolean", nullable: false),
                    analysis = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    createdat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updatedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_competitiveintelligence", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "externalmarketdata",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    datasource = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    datatype = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    jsondata = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    datatimestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    processedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    currency = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    region = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    isvalidated = table.Column<bool>(type: "boolean", nullable: false),
                    confidencescore = table.Column<decimal>(type: "numeric(5,2)", precision: 18, scale: 2, nullable: true),
                    processingnotes = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    createdat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updatedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_externalmarketdata", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "store",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    address = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    phone = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    managername = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false),
                    createdat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updatedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_store", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "strategickpis",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    kpitype = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    periodtype = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    value = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    targetvalue = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: true),
                    variancepercentage = table.Column<decimal>(type: "numeric(5,2)", precision: 18, scale: 2, nullable: false),
                    periodstart = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    periodend = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    notes = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    datasource = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    confidencelevel = table.Column<decimal>(type: "numeric(5,2)", precision: 18, scale: 2, nullable: true),
                    isforecast = table.Column<bool>(type: "boolean", nullable: false),
                    createdat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updatedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_strategickpis", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "supplier",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    contactperson = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    phone = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    email = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    address = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    leadtimedays = table.Column<int>(type: "integer", nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false),
                    createdat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updatedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_supplier", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "voucher",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    discountamount = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    minorderamount = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    expirydate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false),
                    maxusagecount = table.Column<int>(type: "integer", nullable: false),
                    usedcount = table.Column<int>(type: "integer", nullable: false),
                    createdat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updatedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_voucher", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "alertconfigurations",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userid = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: false),
                    alerttype = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    metricname = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    @operator = table.Column<string>(name: "operator", type: "character varying(20)", maxLength: 20, nullable: true),
                    thresholdvalue = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: true),
                    isenabled = table.Column<bool>(type: "boolean", nullable: false),
                    frequency = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    notificationmethod = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    prioritylevel = table.Column<int>(type: "integer", nullable: true),
                    isactive = table.Column<bool>(type: "boolean", nullable: false),
                    createdat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updatedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alertconfigurations", x => x.id);
                    table.ForeignKey(
                        name: "FK_alertconfigurations_applicationuser_userid",
                        column: x => x.userid,
                        principalTable: "applicationuser",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fullname = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    phone = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    email = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    address = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    dateofbirth = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    tier = table.Column<int>(type: "integer", nullable: false),
                    loyaltypoints = table.Column<int>(type: "integer", nullable: false),
                    userid = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    joindate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    createdat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updatedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.id);
                    table.ForeignKey(
                        name: "FK_customer_applicationuser_userid",
                        column: x => x.userid,
                        principalTable: "applicationuser",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "dashboardlayouts",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userid = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: false),
                    dashboardtype = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    layoutconfig = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    theme = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    isdefault = table.Column<bool>(type: "boolean", nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false),
                    displayorder = table.Column<int>(type: "integer", nullable: true),
                    createdat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updatedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dashboardlayouts", x => x.id);
                    table.ForeignKey(
                        name: "FK_dashboardlayouts_applicationuser_userid",
                        column: x => x.userid,
                        principalTable: "applicationuser",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "executivealerts",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    impact = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: true),
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
                    createdat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updatedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_executivealerts", x => x.id);
                    table.ForeignKey(
                        name: "FK_executivealerts_applicationuser_userid",
                        column: x => x.userid,
                        principalTable: "applicationuser",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "executiveuserpreferences",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userid = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: false),
                    preferencekey = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    preferencevalue = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    category = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    isactive = table.Column<bool>(type: "boolean", nullable: false),
                    createdat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updatedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_executiveuserpreferences", x => x.id);
                    table.ForeignKey(
                        name: "FK_executiveuserpreferences_applicationuser_userid",
                        column: x => x.userid,
                        principalTable: "applicationuser",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "notification",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userid = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: false),
                    title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    message = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    isread = table.Column<bool>(type: "boolean", nullable: false),
                    actionurl = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    applicationuserid = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    createdat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updatedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notification", x => x.id);
                    table.ForeignKey(
                        name: "FK_notification_applicationuser_applicationuserid",
                        column: x => x.applicationuserid,
                        principalTable: "applicationuser",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "reportsubscriptions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userid = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: false),
                    reporttype = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    frequency = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    format = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    recipients = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    isenabled = table.Column<bool>(type: "boolean", nullable: false),
                    lastsent = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    nextscheduled = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    parameters = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    createdat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updatedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reportsubscriptions", x => x.id);
                    table.ForeignKey(
                        name: "FK_reportsubscriptions_applicationuser_userid",
                        column: x => x.userid,
                        principalTable: "applicationuser",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "scenarioanalysisresults",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    scenarioname = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    scenariotype = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    inputparameters = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    impactanalysis = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    recommendations = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    confidencelevel = table.Column<decimal>(type: "numeric(5,2)", precision: 18, scale: 2, nullable: false),
                    createdbyuserid = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: true),
                    timehorizonmonths = table.Column<int>(type: "integer", nullable: false),
                    assumptions = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    limitations = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    isarchived = table.Column<bool>(type: "boolean", nullable: false),
                    createdat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updatedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_scenarioanalysisresults", x => x.id);
                    table.ForeignKey(
                        name: "FK_scenarioanalysisresults_applicationuser_createdbyuserid",
                        column: x => x.createdbyuserid,
                        principalTable: "applicationuser",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "strategicinitiatives",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    initiativename = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    priority = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    owneruserid = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: true),
                    startdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    targetdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    completiondate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    budget = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: true),
                    actualcost = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: true),
                    progresspercentage = table.Column<decimal>(type: "numeric(5,2)", precision: 18, scale: 2, nullable: true),
                    successcriteria = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    risks = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    dependencies = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    createdat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updatedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_strategicinitiatives", x => x.id);
                    table.ForeignKey(
                        name: "FK_strategicinitiatives_applicationuser_owneruserid",
                        column: x => x.owneruserid,
                        principalTable: "applicationuser",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "useraddress",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userid = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: false),
                    fullname = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    phonenumber = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    addressline = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    isdefault = table.Column<bool>(type: "boolean", nullable: false),
                    applicationuserid = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    createdat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updatedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_useraddress", x => x.id);
                    table.ForeignKey(
                        name: "FK_useraddress_applicationuser_applicationuserid",
                        column: x => x.applicationuserid,
                        principalTable: "applicationuser",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "competitivealerts",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    competitiveintelligenceid = table.Column<int>(type: "integer", nullable: false),
                    alerttype = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    impact = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    recommendedaction = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    isresolved = table.Column<bool>(type: "boolean", nullable: false),
                    resolvedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    createdat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updatedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_competitivealerts", x => x.id);
                    table.ForeignKey(
                        name: "FK_competitivealerts_competitiveintelligence_competitiveintell~",
                        column: x => x.competitiveintelligenceid,
                        principalTable: "competitiveintelligence",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "kpicomparisons",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    strategickpiid = table.Column<int>(type: "integer", nullable: false),
                    comparisontype = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    comparisonvalue = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    variancepercentage = table.Column<decimal>(type: "numeric(5,2)", precision: 18, scale: 2, nullable: false),
                    notes = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    createdat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updatedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kpicomparisons", x => x.id);
                    table.ForeignKey(
                        name: "FK_kpicomparisons_strategickpis_strategickpiid",
                        column: x => x.strategickpiid,
                        principalTable: "strategickpis",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    slug = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    imageurl = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    price = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    stock = table.Column<int>(type: "integer", nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false),
                    categoryid = table.Column<int>(type: "integer", nullable: true),
                    supplierid = table.Column<int>(type: "integer", nullable: false),
                    createdat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updatedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.id);
                    table.ForeignKey(
                        name: "FK_product_category_categoryid",
                        column: x => x.categoryid,
                        principalTable: "category",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_product_supplier_supplierid",
                        column: x => x.supplierid,
                        principalTable: "supplier",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "purchaseorder",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    pocode = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    orderdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    expecteddate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    receiveddate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    status = table.Column<byte>(type: "smallint", nullable: false),
                    totalcost = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    note = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    supplierid = table.Column<int>(type: "integer", nullable: false),
                    storeid = table.Column<int>(type: "integer", nullable: false),
                    createdat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updatedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_purchaseorder", x => x.id);
                    table.ForeignKey(
                        name: "FK_purchaseorder_store_storeid",
                        column: x => x.storeid,
                        principalTable: "store",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_purchaseorder_supplier_supplierid",
                        column: x => x.supplierid,
                        principalTable: "supplier",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "order",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ordercode = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    status = table.Column<byte>(type: "smallint", nullable: false),
                    paymentmethod = table.Column<byte>(type: "smallint", nullable: false),
                    paymentstatus = table.Column<byte>(type: "smallint", nullable: false),
                    subtotal = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    discountamount = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    totalamount = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    pointsearned = table.Column<int>(type: "integer", nullable: false),
                    note = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    voucherid = table.Column<int>(type: "integer", nullable: true),
                    customername = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    phone = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    address = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    storeid = table.Column<int>(type: "integer", nullable: false),
                    customerid = table.Column<int>(type: "integer", nullable: true),
                    userid = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    createdat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updatedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order", x => x.id);
                    table.ForeignKey(
                        name: "FK_order_applicationuser_userid",
                        column: x => x.userid,
                        principalTable: "applicationuser",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_order_customer_customerid",
                        column: x => x.customerid,
                        principalTable: "customer",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_order_store_storeid",
                        column: x => x.storeid,
                        principalTable: "store",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_order_voucher_voucherid",
                        column: x => x.voucherid,
                        principalTable: "voucher",
                        principalColumn: "id");
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
                    createdat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updatedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alertactions", x => x.id);
                    table.ForeignKey(
                        name: "FK_alertactions_applicationuser_takenbyuserid",
                        column: x => x.takenbyuserid,
                        principalTable: "applicationuser",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_alertactions_executivealerts_executivealertid",
                        column: x => x.executivealertid,
                        principalTable: "executivealerts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "scenarioriskfactors",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    scenarioanalysisresultid = table.Column<int>(type: "integer", nullable: false),
                    riskdescription = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    riskcategory = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    impactlevel = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    probability = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    mitigationstrategy = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    createdat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updatedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_scenarioriskfactors", x => x.id);
                    table.ForeignKey(
                        name: "FK_scenarioriskfactors_scenarioanalysisresults_scenarioanalysi~",
                        column: x => x.scenarioanalysisresultid,
                        principalTable: "scenarioanalysisresults",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "initiativemilestones",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    strategicinitiativeid = table.Column<int>(type: "integer", nullable: false),
                    milestonename = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    targetdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    completeddate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    deliverables = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    createdat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updatedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_initiativemilestones", x => x.id);
                    table.ForeignKey(
                        name: "FK_initiativemilestones_strategicinitiatives_strategicinitiati~",
                        column: x => x.strategicinitiativeid,
                        principalTable: "strategicinitiatives",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productimage",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    productid = table.Column<int>(type: "integer", nullable: false),
                    imageurl = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    displayorder = table.Column<int>(type: "integer", nullable: false),
                    createdat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updatedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productimage", x => x.id);
                    table.ForeignKey(
                        name: "FK_productimage_product_productid",
                        column: x => x.productid,
                        principalTable: "product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productsku",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    sku = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    skucode = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    size = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    color = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    costprice = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    sellingprice = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    priceoverride = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: true),
                    stock = table.Column<int>(type: "integer", nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false),
                    productid = table.Column<int>(type: "integer", nullable: false),
                    createdat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updatedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productsku", x => x.id);
                    table.ForeignKey(
                        name: "FK_productsku_product_productid",
                        column: x => x.productid,
                        principalTable: "product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "returnrequest",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    orderid = table.Column<int>(type: "integer", nullable: false),
                    reason = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    refundamount = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    adminnote = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    processedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    createdat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updatedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_returnrequest", x => x.id);
                    table.ForeignKey(
                        name: "FK_returnrequest_order_orderid",
                        column: x => x.orderid,
                        principalTable: "order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "inventory",
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
                    createdat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updatedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventory", x => x.id);
                    table.ForeignKey(
                        name: "FK_inventory_productsku_productskuid",
                        column: x => x.productskuid,
                        principalTable: "productsku",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_inventory_store_storeid",
                        column: x => x.storeid,
                        principalTable: "store",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orderdetail",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    unitprice = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    discountpercent = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    subtotal = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    orderid = table.Column<int>(type: "integer", nullable: false),
                    productskuid = table.Column<int>(type: "integer", nullable: true),
                    productid = table.Column<int>(type: "integer", nullable: true),
                    createdat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updatedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderdetail", x => x.id);
                    table.ForeignKey(
                        name: "FK_orderdetail_order_orderid",
                        column: x => x.orderid,
                        principalTable: "order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orderdetail_product_productid",
                        column: x => x.productid,
                        principalTable: "product",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_orderdetail_productsku_productskuid",
                        column: x => x.productskuid,
                        principalTable: "productsku",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "purchaseorderdetail",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    quantityordered = table.Column<int>(type: "integer", nullable: false),
                    quantityreceived = table.Column<int>(type: "integer", nullable: false),
                    unitcost = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    subtotal = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    purchaseorderid = table.Column<int>(type: "integer", nullable: false),
                    productskuid = table.Column<int>(type: "integer", nullable: false),
                    createdat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updatedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_purchaseorderdetail", x => x.id);
                    table.ForeignKey(
                        name: "FK_purchaseorderdetail_productsku_productskuid",
                        column: x => x.productskuid,
                        principalTable: "productsku",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_purchaseorderdetail_purchaseorder_purchaseorderid",
                        column: x => x.purchaseorderid,
                        principalTable: "purchaseorder",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "stockadjustment",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    quantitybefore = table.Column<int>(type: "integer", nullable: false),
                    quantitychange = table.Column<int>(type: "integer", nullable: false),
                    quantityafter = table.Column<int>(type: "integer", nullable: false),
                    reason = table.Column<byte>(type: "smallint", nullable: false),
                    note = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    adjustedbyuserid = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    inventoryid = table.Column<int>(type: "integer", nullable: false),
                    createdat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updatedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stockadjustment", x => x.id);
                    table.ForeignKey(
                        name: "FK_stockadjustment_inventory_inventoryid",
                        column: x => x.inventoryid,
                        principalTable: "inventory",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_alertactions_executivealertid_actionat",
                table: "alertactions",
                columns: new[] { "executivealertid", "actionat" });

            migrationBuilder.CreateIndex(
                name: "IX_alertactions_takenbyuserid",
                table: "alertactions",
                column: "takenbyuserid");

            migrationBuilder.CreateIndex(
                name: "IX_alertconfigurations_isenabled",
                table: "alertconfigurations",
                column: "isenabled");

            migrationBuilder.CreateIndex(
                name: "IX_alertconfigurations_userid_alerttype",
                table: "alertconfigurations",
                columns: new[] { "userid", "alerttype" });

            migrationBuilder.CreateIndex(
                name: "IX_category_parentcategoryid",
                table: "category",
                column: "parentcategoryid");

            migrationBuilder.CreateIndex(
                name: "IX_competitivealerts_competitiveintelligenceid",
                table: "competitivealerts",
                column: "competitiveintelligenceid");

            migrationBuilder.CreateIndex(
                name: "IX_competitivealerts_isresolved",
                table: "competitivealerts",
                column: "isresolved");

            migrationBuilder.CreateIndex(
                name: "IX_competitiveintelligence_competitorname_datatype",
                table: "competitiveintelligence",
                columns: new[] { "competitorname", "datatype" });

            migrationBuilder.CreateIndex(
                name: "IX_competitiveintelligence_datatimestamp",
                table: "competitiveintelligence",
                column: "datatimestamp");

            migrationBuilder.CreateIndex(
                name: "IX_competitiveintelligence_isverified",
                table: "competitiveintelligence",
                column: "isverified");

            migrationBuilder.CreateIndex(
                name: "IX_customer_userid",
                table: "customer",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_dashboardlayouts_isactive",
                table: "dashboardlayouts",
                column: "isactive");

            migrationBuilder.CreateIndex(
                name: "IX_dashboardlayouts_userid_dashboardtype",
                table: "dashboardlayouts",
                columns: new[] { "userid", "dashboardtype" });

            migrationBuilder.CreateIndex(
                name: "IX_executivealerts_category",
                table: "executivealerts",
                column: "category");

            migrationBuilder.CreateIndex(
                name: "IX_executivealerts_createdat",
                table: "executivealerts",
                column: "createdat");

            migrationBuilder.CreateIndex(
                name: "IX_executivealerts_priority",
                table: "executivealerts",
                column: "priority");

            migrationBuilder.CreateIndex(
                name: "IX_executivealerts_type",
                table: "executivealerts",
                column: "type");

            migrationBuilder.CreateIndex(
                name: "IX_executivealerts_userid_isread",
                table: "executivealerts",
                columns: new[] { "userid", "isread" });

            migrationBuilder.CreateIndex(
                name: "IX_executiveuserpreferences_category",
                table: "executiveuserpreferences",
                column: "category");

            migrationBuilder.CreateIndex(
                name: "IX_executiveuserpreferences_userid_preferencekey",
                table: "executiveuserpreferences",
                columns: new[] { "userid", "preferencekey" });

            migrationBuilder.CreateIndex(
                name: "IX_externalmarketdata_datasource_datatype",
                table: "externalmarketdata",
                columns: new[] { "datasource", "datatype" });

            migrationBuilder.CreateIndex(
                name: "IX_externalmarketdata_datatimestamp",
                table: "externalmarketdata",
                column: "datatimestamp");

            migrationBuilder.CreateIndex(
                name: "IX_externalmarketdata_processedat",
                table: "externalmarketdata",
                column: "processedat");

            migrationBuilder.CreateIndex(
                name: "IX_initiativemilestones_status",
                table: "initiativemilestones",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "IX_initiativemilestones_strategicinitiativeid_targetdate",
                table: "initiativemilestones",
                columns: new[] { "strategicinitiativeid", "targetdate" });

            migrationBuilder.CreateIndex(
                name: "IX_inventory_productskuid",
                table: "inventory",
                column: "productskuid");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_storeid",
                table: "inventory",
                column: "storeid");

            migrationBuilder.CreateIndex(
                name: "IX_kpicomparisons_strategickpiid",
                table: "kpicomparisons",
                column: "strategickpiid");

            migrationBuilder.CreateIndex(
                name: "IX_notification_applicationuserid",
                table: "notification",
                column: "applicationuserid");

            migrationBuilder.CreateIndex(
                name: "IX_order_customerid",
                table: "order",
                column: "customerid");

            migrationBuilder.CreateIndex(
                name: "IX_order_storeid",
                table: "order",
                column: "storeid");

            migrationBuilder.CreateIndex(
                name: "IX_order_userid",
                table: "order",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_order_voucherid",
                table: "order",
                column: "voucherid");

            migrationBuilder.CreateIndex(
                name: "IX_orderdetail_orderid",
                table: "orderdetail",
                column: "orderid");

            migrationBuilder.CreateIndex(
                name: "IX_orderdetail_productid",
                table: "orderdetail",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "IX_orderdetail_productskuid",
                table: "orderdetail",
                column: "productskuid");

            migrationBuilder.CreateIndex(
                name: "IX_product_categoryid",
                table: "product",
                column: "categoryid");

            migrationBuilder.CreateIndex(
                name: "IX_product_supplierid",
                table: "product",
                column: "supplierid");

            migrationBuilder.CreateIndex(
                name: "IX_productimage_productid",
                table: "productimage",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "IX_productsku_productid",
                table: "productsku",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "IX_purchaseorder_storeid",
                table: "purchaseorder",
                column: "storeid");

            migrationBuilder.CreateIndex(
                name: "IX_purchaseorder_supplierid",
                table: "purchaseorder",
                column: "supplierid");

            migrationBuilder.CreateIndex(
                name: "IX_purchaseorderdetail_productskuid",
                table: "purchaseorderdetail",
                column: "productskuid");

            migrationBuilder.CreateIndex(
                name: "IX_purchaseorderdetail_purchaseorderid",
                table: "purchaseorderdetail",
                column: "purchaseorderid");

            migrationBuilder.CreateIndex(
                name: "IX_reportsubscriptions_isenabled",
                table: "reportsubscriptions",
                column: "isenabled");

            migrationBuilder.CreateIndex(
                name: "IX_reportsubscriptions_nextscheduled",
                table: "reportsubscriptions",
                column: "nextscheduled");

            migrationBuilder.CreateIndex(
                name: "IX_reportsubscriptions_userid_reporttype",
                table: "reportsubscriptions",
                columns: new[] { "userid", "reporttype" });

            migrationBuilder.CreateIndex(
                name: "IX_returnrequest_orderid",
                table: "returnrequest",
                column: "orderid");

            migrationBuilder.CreateIndex(
                name: "IX_scenarioanalysisresults_createdat",
                table: "scenarioanalysisresults",
                column: "createdat");

            migrationBuilder.CreateIndex(
                name: "IX_scenarioanalysisresults_createdbyuserid",
                table: "scenarioanalysisresults",
                column: "createdbyuserid");

            migrationBuilder.CreateIndex(
                name: "IX_scenarioanalysisresults_isarchived",
                table: "scenarioanalysisresults",
                column: "isarchived");

            migrationBuilder.CreateIndex(
                name: "IX_scenarioanalysisresults_scenariotype",
                table: "scenarioanalysisresults",
                column: "scenariotype");

            migrationBuilder.CreateIndex(
                name: "IX_scenarioriskfactors_scenarioanalysisresultid",
                table: "scenarioriskfactors",
                column: "scenarioanalysisresultid");

            migrationBuilder.CreateIndex(
                name: "IX_stockadjustment_inventoryid",
                table: "stockadjustment",
                column: "inventoryid");

            migrationBuilder.CreateIndex(
                name: "IX_strategicinitiatives_owneruserid",
                table: "strategicinitiatives",
                column: "owneruserid");

            migrationBuilder.CreateIndex(
                name: "IX_strategicinitiatives_priority",
                table: "strategicinitiatives",
                column: "priority");

            migrationBuilder.CreateIndex(
                name: "IX_strategicinitiatives_status",
                table: "strategicinitiatives",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "IX_strategicinitiatives_targetdate",
                table: "strategicinitiatives",
                column: "targetdate");

            migrationBuilder.CreateIndex(
                name: "IX_strategickpis_isforecast",
                table: "strategickpis",
                column: "isforecast");

            migrationBuilder.CreateIndex(
                name: "IX_strategickpis_kpitype_periodstart_periodend",
                table: "strategickpis",
                columns: new[] { "kpitype", "periodstart", "periodend" });

            migrationBuilder.CreateIndex(
                name: "IX_strategickpis_periodtype",
                table: "strategickpis",
                column: "periodtype");

            migrationBuilder.CreateIndex(
                name: "IX_useraddress_applicationuserid",
                table: "useraddress",
                column: "applicationuserid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "alertactions");

            migrationBuilder.DropTable(
                name: "alertconfigurations");

            migrationBuilder.DropTable(
                name: "competitivealerts");

            migrationBuilder.DropTable(
                name: "dashboardlayouts");

            migrationBuilder.DropTable(
                name: "executiveuserpreferences");

            migrationBuilder.DropTable(
                name: "externalmarketdata");

            migrationBuilder.DropTable(
                name: "initiativemilestones");

            migrationBuilder.DropTable(
                name: "kpicomparisons");

            migrationBuilder.DropTable(
                name: "notification");

            migrationBuilder.DropTable(
                name: "orderdetail");

            migrationBuilder.DropTable(
                name: "productimage");

            migrationBuilder.DropTable(
                name: "purchaseorderdetail");

            migrationBuilder.DropTable(
                name: "reportsubscriptions");

            migrationBuilder.DropTable(
                name: "returnrequest");

            migrationBuilder.DropTable(
                name: "scenarioriskfactors");

            migrationBuilder.DropTable(
                name: "stockadjustment");

            migrationBuilder.DropTable(
                name: "useraddress");

            migrationBuilder.DropTable(
                name: "executivealerts");

            migrationBuilder.DropTable(
                name: "competitiveintelligence");

            migrationBuilder.DropTable(
                name: "strategicinitiatives");

            migrationBuilder.DropTable(
                name: "strategickpis");

            migrationBuilder.DropTable(
                name: "purchaseorder");

            migrationBuilder.DropTable(
                name: "order");

            migrationBuilder.DropTable(
                name: "scenarioanalysisresults");

            migrationBuilder.DropTable(
                name: "inventory");

            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropTable(
                name: "voucher");

            migrationBuilder.DropTable(
                name: "productsku");

            migrationBuilder.DropTable(
                name: "store");

            migrationBuilder.DropTable(
                name: "applicationuser");

            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropTable(
                name: "supplier");
        }
    }
}
