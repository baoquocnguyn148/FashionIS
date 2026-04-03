using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FashionStoreIS.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddProfileFeatures_SQLite_V2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NOTIFICATIONS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    USERID = table.Column<string>(type: "TEXT", maxLength: 450, nullable: false),
                    TITLE = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    MESSAGE = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    ISREAD = table.Column<bool>(type: "INTEGER", nullable: false),
                    ACTIONURL = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    CREATEDAT = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UPDATEDAT = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ISDELETED = table.Column<bool>(type: "INTEGER", nullable: false)
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
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ORDERID = table.Column<int>(type: "INTEGER", nullable: false),
                    REASON = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    STATUS = table.Column<byte>(type: "INTEGER", nullable: false),
                    REFUNDAMOUNT = table.Column<decimal>(type: "TEXT", nullable: false),
                    CREATEDAT = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UPDATEDAT = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ISDELETED = table.Column<bool>(type: "INTEGER", nullable: false)
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
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    USERID = table.Column<string>(type: "TEXT", maxLength: 450, nullable: false),
                    FULLNAME = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    PHONENUMBER = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    ADDRESSLINE = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    ISDEFAULT = table.Column<bool>(type: "INTEGER", nullable: false),
                    CREATEDAT = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UPDATEDAT = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ISDELETED = table.Column<bool>(type: "INTEGER", nullable: false)
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "NOTIFICATIONS");
            migrationBuilder.DropTable(name: "RETURNREQUESTS");
            migrationBuilder.DropTable(name: "USERADDRESSES");
        }
    }
}
