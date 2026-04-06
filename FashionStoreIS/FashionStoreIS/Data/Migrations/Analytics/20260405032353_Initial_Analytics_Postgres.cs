using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FashionStoreIS.Data.Migrations.Analytics
{
    /// <inheritdoc />
    public partial class Initial_Analytics_Postgres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dim_customer",
                columns: table => new
                {
                    customersurrogatekey = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    customerid = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: false),
                    fullname = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    phone = table.Column<string>(type: "text", nullable: false),
                    regionorcity = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dim_customer", x => x.customersurrogatekey);
                });

            migrationBuilder.CreateTable(
                name: "dim_date",
                columns: table => new
                {
                    datekey = table.Column<int>(type: "integer", nullable: false),
                    date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    day = table.Column<int>(type: "integer", nullable: false),
                    month = table.Column<int>(type: "integer", nullable: false),
                    year = table.Column<int>(type: "integer", nullable: false),
                    quarter = table.Column<int>(type: "integer", nullable: false),
                    isweekend = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dim_date", x => x.datekey);
                });

            migrationBuilder.CreateTable(
                name: "dim_product",
                columns: table => new
                {
                    productsurrogatekey = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    productid = table.Column<int>(type: "integer", nullable: false),
                    productskuid = table.Column<int>(type: "integer", nullable: true),
                    productname = table.Column<string>(type: "text", nullable: false),
                    categoryname = table.Column<string>(type: "text", nullable: false),
                    color = table.Column<string>(type: "text", nullable: false),
                    size = table.Column<string>(type: "text", nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false),
                    validfrom = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    validto = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dim_product", x => x.productsurrogatekey);
                });

            migrationBuilder.CreateTable(
                name: "fact_sales",
                columns: table => new
                {
                    factsalesid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    datekey = table.Column<int>(type: "integer", nullable: false),
                    productsurrogatekey = table.Column<int>(type: "integer", nullable: false),
                    customersurrogatekey = table.Column<int>(type: "integer", nullable: false),
                    orderid = table.Column<int>(type: "integer", nullable: false),
                    ordercode = table.Column<string>(type: "text", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    unitprice = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    salesamount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    discountamount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    cogs = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    grossprofit = table.Column<decimal>(type: "numeric(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fact_sales", x => x.factsalesid);
                    table.ForeignKey(
                        name: "FK_fact_sales_dim_customer_customersurrogatekey",
                        column: x => x.customersurrogatekey,
                        principalTable: "dim_customer",
                        principalColumn: "customersurrogatekey",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_fact_sales_dim_date_datekey",
                        column: x => x.datekey,
                        principalTable: "dim_date",
                        principalColumn: "datekey",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_fact_sales_dim_product_productsurrogatekey",
                        column: x => x.productsurrogatekey,
                        principalTable: "dim_product",
                        principalColumn: "productsurrogatekey",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_fact_sales_customersurrogatekey",
                table: "fact_sales",
                column: "customersurrogatekey");

            migrationBuilder.CreateIndex(
                name: "IX_fact_sales_datekey",
                table: "fact_sales",
                column: "datekey");

            migrationBuilder.CreateIndex(
                name: "IX_fact_sales_productsurrogatekey",
                table: "fact_sales",
                column: "productsurrogatekey");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "fact_sales");

            migrationBuilder.DropTable(
                name: "dim_customer");

            migrationBuilder.DropTable(
                name: "dim_date");

            migrationBuilder.DropTable(
                name: "dim_product");
        }
    }
}
