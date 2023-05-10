using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.Website.Database.Migrations
{
    /// <inheritdoc />
    public partial class initDBFirstv11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_User_UserId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_User_UserId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Order_OrderId",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Product_ProductId",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Product",
                newName: "category_id");

            migrationBuilder.RenameIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                newName: "IX_Product_category_id");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "OrderDetail",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "OrderDetail",
                newName: "product_id");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "OrderDetail",
                newName: "order_id");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetail_ProductId",
                table: "OrderDetail",
                newName: "IX_OrderDetail_product_id");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetail_OrderId",
                table: "OrderDetail",
                newName: "IX_OrderDetail_order_id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Order",
                newName: "user_id");

            migrationBuilder.RenameIndex(
                name: "IX_Order_UserId",
                table: "Order",
                newName: "IX_Order_user_id");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Address",
                newName: "state");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Address",
                newName: "country");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Address",
                newName: "city");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Address",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "PostalCode",
                table: "Address",
                newName: "Postal_code");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Address",
                newName: "phone_number");

            migrationBuilder.RenameColumn(
                name: "LineSecond",
                table: "Address",
                newName: "line_second");

            migrationBuilder.RenameIndex(
                name: "IX_Address_UserId",
                table: "Address",
                newName: "IX_Address_user_id");

            migrationBuilder.AddColumn<string>(
                name: "full_name",
                table: "User",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_User_user_id",
                table: "Address",
                column: "user_id",
                principalTable: "User",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_User_user_id",
                table: "Order",
                column: "user_id",
                principalTable: "User",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Order_order_id",
                table: "OrderDetail",
                column: "order_id",
                principalTable: "Order",
                principalColumn: "order_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Product_product_id",
                table: "OrderDetail",
                column: "product_id",
                principalTable: "Product",
                principalColumn: "product_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_category_id",
                table: "Product",
                column: "category_id",
                principalTable: "Category",
                principalColumn: "category_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_User_user_id",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_User_user_id",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Order_order_id",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Product_product_id",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_category_id",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "full_name",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "category_id",
                table: "Product",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_category_id",
                table: "Product",
                newName: "IX_Product_CategoryId");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "OrderDetail",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "product_id",
                table: "OrderDetail",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "order_id",
                table: "OrderDetail",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetail_product_id",
                table: "OrderDetail",
                newName: "IX_OrderDetail_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetail_order_id",
                table: "OrderDetail",
                newName: "IX_OrderDetail_OrderId");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "Order",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_user_id",
                table: "Order",
                newName: "IX_Order_UserId");

            migrationBuilder.RenameColumn(
                name: "state",
                table: "Address",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "country",
                table: "Address",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "Address",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "Address",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "phone_number",
                table: "Address",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "line_second",
                table: "Address",
                newName: "LineSecond");

            migrationBuilder.RenameColumn(
                name: "Postal_code",
                table: "Address",
                newName: "PostalCode");

            migrationBuilder.RenameIndex(
                name: "IX_Address_user_id",
                table: "Address",
                newName: "IX_Address_UserId");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "User",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_User_UserId",
                table: "Address",
                column: "UserId",
                principalTable: "User",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_User_UserId",
                table: "Order",
                column: "UserId",
                principalTable: "User",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Order_OrderId",
                table: "OrderDetail",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "order_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Product_ProductId",
                table: "OrderDetail",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "product_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Product",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "category_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
