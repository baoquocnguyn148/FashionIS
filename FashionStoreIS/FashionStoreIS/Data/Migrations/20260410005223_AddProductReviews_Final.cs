using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FashionStoreIS.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddProductReviews_Final : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PRODUCTREVIEWS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                        .Annotation("Sqlite:Autoincrement", true),
                    PRODUCTID = table.Column<int>(nullable: false),
                    USERID = table.Column<string>(nullable: false),
                    RATING = table.Column<int>(nullable: false),
                    COMMENT = table.Column<string>(maxLength: 1000, nullable: true),
                    ISAPPROVED = table.Column<bool>(nullable: false),
                    CREATEDAT = table.Column<DateTime>(nullable: false),
                    UPDATEDAT = table.Column<DateTime>(nullable: true),
                    ISDELETED = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCTREVIEWS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PRODUCTREVIEWS_ASPNETUSERS_USERID",
                        column: x => x.USERID,
                        principalTable: "ASPNETUSERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PRODUCTREVIEWS_PRODUCTS_PRODUCTID",
                        column: x => x.PRODUCTID,
                        principalTable: "PRODUCTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTREVIEWS_PRODUCTID",
                table: "PRODUCTREVIEWS",
                column: "PRODUCTID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTREVIEWS_USERID",
                table: "PRODUCTREVIEWS",
                column: "USERID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PRODUCTREVIEWS");
        }
    }
}
