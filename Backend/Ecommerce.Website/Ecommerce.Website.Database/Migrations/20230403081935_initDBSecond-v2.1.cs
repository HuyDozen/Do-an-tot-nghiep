using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Ecommerce.Website.Database.Migrations
{
    /// <inheritdoc />
    public partial class initDBSecondv21 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_category_id",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "short_desc",
                table: "Products",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)");

            migrationBuilder.AlterColumn<int>(
                name: "quanity",
                table: "Products",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "category_id",
                table: "Products",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    product_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    token = table.Column<string>(type: "varchar(255)", nullable: false),
                    jwt_id = table.Column<string>(type: "varchar(255)", nullable: false),
                    is_used = table.Column<string>(type: "varchar(255)", nullable: false),
                    is_revoked = table.Column<string>(type: "varchar(255)", nullable: false),
                    expired_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    modified_by = table.Column<string>(type: "varchar(255)", nullable: true),
                    modified_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    created_by = table.Column<string>(type: "varchar(255)", nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.product_id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_user_id",
                table: "RefreshTokens",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_category_id",
                table: "Products",
                column: "category_id",
                principalTable: "Categories",
                principalColumn: "category_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_category_id",
                table: "Products");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.AlterColumn<string>(
                name: "short_desc",
                table: "Products",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "quanity",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "category_id",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_category_id",
                table: "Products",
                column: "category_id",
                principalTable: "Categories",
                principalColumn: "category_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
