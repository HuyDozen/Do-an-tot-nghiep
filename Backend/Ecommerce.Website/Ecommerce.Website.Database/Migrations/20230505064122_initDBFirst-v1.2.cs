using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.Website.Database.Migrations
{
    /// <inheritdoc />
    public partial class initDBFirstv12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "images",
                table: "Products",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)");

            migrationBuilder.AlterColumn<string>(
                name: "image",
                table: "Products",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "images",
                table: "Products",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "image",
                table: "Products",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
