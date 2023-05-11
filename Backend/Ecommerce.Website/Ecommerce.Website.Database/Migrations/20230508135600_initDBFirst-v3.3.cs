using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.Website.Database.Migrations
{
    /// <inheritdoc />
    public partial class initDBFirstv33 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Products_ProductId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Products_ProductId",
                table: "Ratings");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Ratings",
                newName: "product_id");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_ProductId",
                table: "Ratings",
                newName: "IX_Ratings_product_id");

            migrationBuilder.RenameColumn(
                name: "rating_count",
                table: "Comments",
                newName: "content");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Comments",
                newName: "product_id");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_ProductId",
                table: "Comments",
                newName: "IX_Comments_product_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Products_product_id",
                table: "Comments",
                column: "product_id",
                principalTable: "Products",
                principalColumn: "product_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Products_product_id",
                table: "Ratings",
                column: "product_id",
                principalTable: "Products",
                principalColumn: "product_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Products_product_id",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Products_product_id",
                table: "Ratings");

            migrationBuilder.RenameColumn(
                name: "product_id",
                table: "Ratings",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_product_id",
                table: "Ratings",
                newName: "IX_Ratings_ProductId");

            migrationBuilder.RenameColumn(
                name: "product_id",
                table: "Comments",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "content",
                table: "Comments",
                newName: "rating_count");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_product_id",
                table: "Comments",
                newName: "IX_Comments_ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Products_ProductId",
                table: "Comments",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "product_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Products_ProductId",
                table: "Ratings",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "product_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
