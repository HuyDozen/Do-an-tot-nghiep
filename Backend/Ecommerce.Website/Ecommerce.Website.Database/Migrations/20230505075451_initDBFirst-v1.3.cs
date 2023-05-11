using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.Website.Database.Migrations
{
    /// <inheritdoc />
    public partial class initDBFirstv13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "short_desc",
                table: "Products",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "description",
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
                name: "short_desc",
                table: "Products",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "Products",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
