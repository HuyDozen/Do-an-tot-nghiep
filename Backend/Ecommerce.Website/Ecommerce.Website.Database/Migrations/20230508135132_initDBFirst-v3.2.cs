using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.Website.Database.Migrations
{
    /// <inheritdoc />
    public partial class initDBFirstv32 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "order_id",
                table: "Ratings",
                newName: "rating_id");

            migrationBuilder.RenameColumn(
                name: "order_id",
                table: "Comments",
                newName: "comment_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "rating_id",
                table: "Ratings",
                newName: "order_id");

            migrationBuilder.RenameColumn(
                name: "comment_id",
                table: "Comments",
                newName: "order_id");
        }
    }
}
