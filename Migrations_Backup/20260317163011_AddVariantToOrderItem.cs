using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FashionStoreIS.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddVariantToOrderItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleClaims_Roles_RoleId",
                table: "RoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_UserClaims_Users_UserId",
                table: "UserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLogins_Users_UserId",
                table: "UserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Roles_RoleId",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Users_UserId",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTokens_Users_UserId",
                table: "UserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTokens",
                table: "UserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserLogins",
                table: "UserLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserClaims",
                table: "UserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoleClaims",
                table: "RoleClaims");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Users");

            migrationBuilder.DropSequence(
                name: "EntityFrameworkHiLoSequence");

            migrationBuilder.RenameTable(
                name: "UserTokens",
                newName: "ASPNETUSERTOKENS");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "ASPNETUSERS");

            migrationBuilder.RenameTable(
                name: "UserRoles",
                newName: "ASPNETUSERROLES");

            migrationBuilder.RenameTable(
                name: "UserLogins",
                newName: "ASPNETUSERLOGINS");

            migrationBuilder.RenameTable(
                name: "UserClaims",
                newName: "ASPNETUSERCLAIMS");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "ASPNETROLES");

            migrationBuilder.RenameTable(
                name: "RoleClaims",
                newName: "ASPNETROLECLAIMS");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "ASPNETUSERTOKENS",
                newName: "VALUE");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ASPNETUSERTOKENS",
                newName: "NAME");

            migrationBuilder.RenameColumn(
                name: "LoginProvider",
                table: "ASPNETUSERTOKENS",
                newName: "LOGINPROVIDER");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ASPNETUSERTOKENS",
                newName: "USERID");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "ASPNETUSERS",
                newName: "USERNAME");

            migrationBuilder.RenameColumn(
                name: "TwoFactorEnabled",
                table: "ASPNETUSERS",
                newName: "TWOFACTORENABLED");

            migrationBuilder.RenameColumn(
                name: "SecurityStamp",
                table: "ASPNETUSERS",
                newName: "SECURITYSTAMP");

            migrationBuilder.RenameColumn(
                name: "PhoneNumberConfirmed",
                table: "ASPNETUSERS",
                newName: "PHONENUMBERCONFIRMED");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "ASPNETUSERS",
                newName: "PHONENUMBER");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "ASPNETUSERS",
                newName: "PASSWORDHASH");

            migrationBuilder.RenameColumn(
                name: "NormalizedUserName",
                table: "ASPNETUSERS",
                newName: "NORMALIZEDUSERNAME");

            migrationBuilder.RenameColumn(
                name: "NormalizedEmail",
                table: "ASPNETUSERS",
                newName: "NORMALIZEDEMAIL");

            migrationBuilder.RenameColumn(
                name: "LockoutEnd",
                table: "ASPNETUSERS",
                newName: "LOCKOUTEND");

            migrationBuilder.RenameColumn(
                name: "LockoutEnabled",
                table: "ASPNETUSERS",
                newName: "LOCKOUTENABLED");

            migrationBuilder.RenameColumn(
                name: "EmailConfirmed",
                table: "ASPNETUSERS",
                newName: "EMAILCONFIRMED");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "ASPNETUSERS",
                newName: "EMAIL");

            migrationBuilder.RenameColumn(
                name: "ConcurrencyStamp",
                table: "ASPNETUSERS",
                newName: "CONCURRENCYSTAMP");

            migrationBuilder.RenameColumn(
                name: "AccessFailedCount",
                table: "ASPNETUSERS",
                newName: "ACCESSFAILEDCOUNT");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ASPNETUSERS",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "ASPNETUSERROLES",
                newName: "ROLEID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ASPNETUSERROLES",
                newName: "USERID");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoles_RoleId",
                table: "ASPNETUSERROLES",
                newName: "IX_ASPNETUSERROLES_ROLEID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ASPNETUSERLOGINS",
                newName: "USERID");

            migrationBuilder.RenameColumn(
                name: "ProviderDisplayName",
                table: "ASPNETUSERLOGINS",
                newName: "PROVIDERDISPLAYNAME");

            migrationBuilder.RenameColumn(
                name: "ProviderKey",
                table: "ASPNETUSERLOGINS",
                newName: "PROVIDERKEY");

            migrationBuilder.RenameColumn(
                name: "LoginProvider",
                table: "ASPNETUSERLOGINS",
                newName: "LOGINPROVIDER");

            migrationBuilder.RenameIndex(
                name: "IX_UserLogins_UserId",
                table: "ASPNETUSERLOGINS",
                newName: "IX_ASPNETUSERLOGINS_USERID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ASPNETUSERCLAIMS",
                newName: "USERID");

            migrationBuilder.RenameColumn(
                name: "ClaimValue",
                table: "ASPNETUSERCLAIMS",
                newName: "CLAIMVALUE");

            migrationBuilder.RenameColumn(
                name: "ClaimType",
                table: "ASPNETUSERCLAIMS",
                newName: "CLAIMTYPE");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ASPNETUSERCLAIMS",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_UserClaims_UserId",
                table: "ASPNETUSERCLAIMS",
                newName: "IX_ASPNETUSERCLAIMS_USERID");

            migrationBuilder.RenameColumn(
                name: "NormalizedName",
                table: "ASPNETROLES",
                newName: "NORMALIZEDNAME");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ASPNETROLES",
                newName: "NAME");

            migrationBuilder.RenameColumn(
                name: "ConcurrencyStamp",
                table: "ASPNETROLES",
                newName: "CONCURRENCYSTAMP");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ASPNETROLES",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "ASPNETROLECLAIMS",
                newName: "ROLEID");

            migrationBuilder.RenameColumn(
                name: "ClaimValue",
                table: "ASPNETROLECLAIMS",
                newName: "CLAIMVALUE");

            migrationBuilder.RenameColumn(
                name: "ClaimType",
                table: "ASPNETROLECLAIMS",
                newName: "CLAIMTYPE");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ASPNETROLECLAIMS",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_RoleClaims_RoleId",
                table: "ASPNETROLECLAIMS",
                newName: "IX_ASPNETROLECLAIMS_ROLEID");

            migrationBuilder.CreateSequence(
                name: "HiLoSequence");

            migrationBuilder.AlterColumn<decimal>(
                name: "PriceOverride",
                table: "ProductVariants",
                type: "DECIMAL(18, 2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "ProductVariantId",
                table: "OrderItems",
                type: "NUMBER(10)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Banners",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<string>(
                name: "USERID",
                table: "ASPNETUSERTOKENS",
                type: "VARCHAR2(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(450)");

            migrationBuilder.AlterColumn<string>(
                name: "USERNAME",
                table: "ASPNETUSERS",
                type: "VARCHAR2(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NORMALIZEDUSERNAME",
                table: "ASPNETUSERS",
                type: "VARCHAR2(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NORMALIZEDEMAIL",
                table: "ASPNETUSERS",
                type: "VARCHAR2(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EMAIL",
                table: "ASPNETUSERS",
                type: "VARCHAR2(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ID",
                table: "ASPNETUSERS",
                type: "VARCHAR2(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ROLEID",
                table: "ASPNETUSERROLES",
                type: "VARCHAR2(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(450)");

            migrationBuilder.AlterColumn<string>(
                name: "USERID",
                table: "ASPNETUSERROLES",
                type: "VARCHAR2(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(450)");

            migrationBuilder.AlterColumn<string>(
                name: "USERID",
                table: "ASPNETUSERLOGINS",
                type: "VARCHAR2(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(450)");

            migrationBuilder.AlterColumn<string>(
                name: "USERID",
                table: "ASPNETUSERCLAIMS",
                type: "VARCHAR2(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(450)");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "ASPNETUSERCLAIMS",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<string>(
                name: "NORMALIZEDNAME",
                table: "ASPNETROLES",
                type: "VARCHAR2(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "ASPNETROLES",
                type: "VARCHAR2(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ID",
                table: "ASPNETROLES",
                type: "VARCHAR2(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ROLEID",
                table: "ASPNETROLECLAIMS",
                type: "VARCHAR2(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(450)");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "ASPNETROLECLAIMS",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ASPNETUSERTOKENS",
                table: "ASPNETUSERTOKENS",
                columns: new[] { "USERID", "LOGINPROVIDER", "NAME" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ASPNETUSERS",
                table: "ASPNETUSERS",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ASPNETUSERROLES",
                table: "ASPNETUSERROLES",
                columns: new[] { "USERID", "ROLEID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ASPNETUSERLOGINS",
                table: "ASPNETUSERLOGINS",
                columns: new[] { "LOGINPROVIDER", "PROVIDERKEY" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ASPNETUSERCLAIMS",
                table: "ASPNETUSERCLAIMS",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ASPNETROLES",
                table: "ASPNETROLES",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ASPNETROLECLAIMS",
                table: "ASPNETROLECLAIMS",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Vouchers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Code = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    MinOrderAmount = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    IsActive = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vouchers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductVariantId",
                table: "OrderItems",
                column: "ProductVariantId");

            migrationBuilder.AddForeignKey(
                name: "FK_ASPNETROLECLAIMS_ASPNETROLES_ROLEID",
                table: "ASPNETROLECLAIMS",
                column: "ROLEID",
                principalTable: "ASPNETROLES",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ASPNETUSERCLAIMS_ASPNETUSERS_USERID",
                table: "ASPNETUSERCLAIMS",
                column: "USERID",
                principalTable: "ASPNETUSERS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ASPNETUSERLOGINS_ASPNETUSERS_USERID",
                table: "ASPNETUSERLOGINS",
                column: "USERID",
                principalTable: "ASPNETUSERS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ASPNETUSERROLES_ASPNETROLES_ROLEID",
                table: "ASPNETUSERROLES",
                column: "ROLEID",
                principalTable: "ASPNETROLES",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ASPNETUSERROLES_ASPNETUSERS_USERID",
                table: "ASPNETUSERROLES",
                column: "USERID",
                principalTable: "ASPNETUSERS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ASPNETUSERTOKENS_ASPNETUSERS_USERID",
                table: "ASPNETUSERTOKENS",
                column: "USERID",
                principalTable: "ASPNETUSERS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_ProductVariants_ProductVariantId",
                table: "OrderItems",
                column: "ProductVariantId",
                principalTable: "ProductVariants",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ASPNETROLECLAIMS_ASPNETROLES_ROLEID",
                table: "ASPNETROLECLAIMS");

            migrationBuilder.DropForeignKey(
                name: "FK_ASPNETUSERCLAIMS_ASPNETUSERS_USERID",
                table: "ASPNETUSERCLAIMS");

            migrationBuilder.DropForeignKey(
                name: "FK_ASPNETUSERLOGINS_ASPNETUSERS_USERID",
                table: "ASPNETUSERLOGINS");

            migrationBuilder.DropForeignKey(
                name: "FK_ASPNETUSERROLES_ASPNETROLES_ROLEID",
                table: "ASPNETUSERROLES");

            migrationBuilder.DropForeignKey(
                name: "FK_ASPNETUSERROLES_ASPNETUSERS_USERID",
                table: "ASPNETUSERROLES");

            migrationBuilder.DropForeignKey(
                name: "FK_ASPNETUSERTOKENS_ASPNETUSERS_USERID",
                table: "ASPNETUSERTOKENS");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_ProductVariants_ProductVariantId",
                table: "OrderItems");

            migrationBuilder.DropTable(
                name: "Vouchers");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_ProductVariantId",
                table: "OrderItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ASPNETUSERTOKENS",
                table: "ASPNETUSERTOKENS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ASPNETUSERS",
                table: "ASPNETUSERS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ASPNETUSERROLES",
                table: "ASPNETUSERROLES");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ASPNETUSERLOGINS",
                table: "ASPNETUSERLOGINS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ASPNETUSERCLAIMS",
                table: "ASPNETUSERCLAIMS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ASPNETROLES",
                table: "ASPNETROLES");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ASPNETROLECLAIMS",
                table: "ASPNETROLECLAIMS");

            migrationBuilder.DropColumn(
                name: "ProductVariantId",
                table: "OrderItems");

            migrationBuilder.DropSequence(
                name: "HiLoSequence");

            migrationBuilder.RenameTable(
                name: "ASPNETUSERTOKENS",
                newName: "UserTokens");

            migrationBuilder.RenameTable(
                name: "ASPNETUSERS",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "ASPNETUSERROLES",
                newName: "UserRoles");

            migrationBuilder.RenameTable(
                name: "ASPNETUSERLOGINS",
                newName: "UserLogins");

            migrationBuilder.RenameTable(
                name: "ASPNETUSERCLAIMS",
                newName: "UserClaims");

            migrationBuilder.RenameTable(
                name: "ASPNETROLES",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "ASPNETROLECLAIMS",
                newName: "RoleClaims");

            migrationBuilder.RenameColumn(
                name: "VALUE",
                table: "UserTokens",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "NAME",
                table: "UserTokens",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "LOGINPROVIDER",
                table: "UserTokens",
                newName: "LoginProvider");

            migrationBuilder.RenameColumn(
                name: "USERID",
                table: "UserTokens",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "USERNAME",
                table: "Users",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "TWOFACTORENABLED",
                table: "Users",
                newName: "TwoFactorEnabled");

            migrationBuilder.RenameColumn(
                name: "SECURITYSTAMP",
                table: "Users",
                newName: "SecurityStamp");

            migrationBuilder.RenameColumn(
                name: "PHONENUMBERCONFIRMED",
                table: "Users",
                newName: "PhoneNumberConfirmed");

            migrationBuilder.RenameColumn(
                name: "PHONENUMBER",
                table: "Users",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "PASSWORDHASH",
                table: "Users",
                newName: "PasswordHash");

            migrationBuilder.RenameColumn(
                name: "NORMALIZEDUSERNAME",
                table: "Users",
                newName: "NormalizedUserName");

            migrationBuilder.RenameColumn(
                name: "NORMALIZEDEMAIL",
                table: "Users",
                newName: "NormalizedEmail");

            migrationBuilder.RenameColumn(
                name: "LOCKOUTEND",
                table: "Users",
                newName: "LockoutEnd");

            migrationBuilder.RenameColumn(
                name: "LOCKOUTENABLED",
                table: "Users",
                newName: "LockoutEnabled");

            migrationBuilder.RenameColumn(
                name: "EMAILCONFIRMED",
                table: "Users",
                newName: "EmailConfirmed");

            migrationBuilder.RenameColumn(
                name: "EMAIL",
                table: "Users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "CONCURRENCYSTAMP",
                table: "Users",
                newName: "ConcurrencyStamp");

            migrationBuilder.RenameColumn(
                name: "ACCESSFAILEDCOUNT",
                table: "Users",
                newName: "AccessFailedCount");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ROLEID",
                table: "UserRoles",
                newName: "RoleId");

            migrationBuilder.RenameColumn(
                name: "USERID",
                table: "UserRoles",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ASPNETUSERROLES_ROLEID",
                table: "UserRoles",
                newName: "IX_UserRoles_RoleId");

            migrationBuilder.RenameColumn(
                name: "USERID",
                table: "UserLogins",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "PROVIDERDISPLAYNAME",
                table: "UserLogins",
                newName: "ProviderDisplayName");

            migrationBuilder.RenameColumn(
                name: "PROVIDERKEY",
                table: "UserLogins",
                newName: "ProviderKey");

            migrationBuilder.RenameColumn(
                name: "LOGINPROVIDER",
                table: "UserLogins",
                newName: "LoginProvider");

            migrationBuilder.RenameIndex(
                name: "IX_ASPNETUSERLOGINS_USERID",
                table: "UserLogins",
                newName: "IX_UserLogins_UserId");

            migrationBuilder.RenameColumn(
                name: "USERID",
                table: "UserClaims",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "CLAIMVALUE",
                table: "UserClaims",
                newName: "ClaimValue");

            migrationBuilder.RenameColumn(
                name: "CLAIMTYPE",
                table: "UserClaims",
                newName: "ClaimType");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "UserClaims",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_ASPNETUSERCLAIMS_USERID",
                table: "UserClaims",
                newName: "IX_UserClaims_UserId");

            migrationBuilder.RenameColumn(
                name: "NORMALIZEDNAME",
                table: "Roles",
                newName: "NormalizedName");

            migrationBuilder.RenameColumn(
                name: "NAME",
                table: "Roles",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "CONCURRENCYSTAMP",
                table: "Roles",
                newName: "ConcurrencyStamp");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Roles",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ROLEID",
                table: "RoleClaims",
                newName: "RoleId");

            migrationBuilder.RenameColumn(
                name: "CLAIMVALUE",
                table: "RoleClaims",
                newName: "ClaimValue");

            migrationBuilder.RenameColumn(
                name: "CLAIMTYPE",
                table: "RoleClaims",
                newName: "ClaimType");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "RoleClaims",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_ASPNETROLECLAIMS_ROLEID",
                table: "RoleClaims",
                newName: "IX_RoleClaims_RoleId");

            migrationBuilder.CreateSequence(
                name: "EntityFrameworkHiLoSequence",
                incrementBy: 10);

            migrationBuilder.AlterColumn<decimal>(
                name: "PriceOverride",
                table: "ProductVariants",
                type: "DECIMAL(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Banners",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserTokens",
                type: "NVARCHAR2(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2(450)");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                type: "NVARCHAR2(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedUserName",
                table: "Users",
                type: "NVARCHAR2(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedEmail",
                table: "Users",
                type: "NVARCHAR2(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "NVARCHAR2(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Users",
                type: "NVARCHAR2(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2(450)");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Users",
                type: "TIMESTAMP(7)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Users",
                type: "NVARCHAR2(2000)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Users",
                type: "NVARCHAR2(2000)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RoleId",
                table: "UserRoles",
                type: "NVARCHAR2(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2(450)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserRoles",
                type: "NVARCHAR2(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2(450)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserLogins",
                type: "NVARCHAR2(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2(450)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserClaims",
                type: "NVARCHAR2(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2(450)");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "UserClaims",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedName",
                table: "Roles",
                type: "NVARCHAR2(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Roles",
                type: "NVARCHAR2(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Roles",
                type: "NVARCHAR2(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2(450)");

            migrationBuilder.AlterColumn<string>(
                name: "RoleId",
                table: "RoleClaims",
                type: "NVARCHAR2(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2(450)");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "RoleClaims",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTokens",
                table: "UserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserLogins",
                table: "UserLogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserClaims",
                table: "UserClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoleClaims",
                table: "RoleClaims",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleClaims_Roles_RoleId",
                table: "RoleClaims",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserClaims_Users_UserId",
                table: "UserClaims",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLogins_Users_UserId",
                table: "UserLogins",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Roles_RoleId",
                table: "UserRoles",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Users_UserId",
                table: "UserRoles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTokens_Users_UserId",
                table: "UserTokens",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
