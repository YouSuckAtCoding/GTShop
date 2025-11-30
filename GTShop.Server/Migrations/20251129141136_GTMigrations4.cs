using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GTShop.Server.Migrations
{
    /// <inheritdoc />
    public partial class GTMigrations4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Items_Carts_Cart_IdId",
                table: "Cart_Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Items_Products_Product_IdId",
                table: "Cart_Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Items_Orders_Order_IdId",
                table: "Order_Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Items_Products_Product_IdId",
                table: "Order_Items");

            migrationBuilder.RenameColumn(
                name: "Product_IdId",
                table: "Order_Items",
                newName: "Product_Id");

            migrationBuilder.RenameColumn(
                name: "Order_IdId",
                table: "Order_Items",
                newName: "Order_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Order_Items_Product_IdId",
                table: "Order_Items",
                newName: "IX_Order_Items_Product_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Order_Items_Order_IdId",
                table: "Order_Items",
                newName: "IX_Order_Items_Order_Id");

            migrationBuilder.RenameColumn(
                name: "Product_IdId",
                table: "Cart_Items",
                newName: "Product_Id");

            migrationBuilder.RenameColumn(
                name: "Cart_IdId",
                table: "Cart_Items",
                newName: "Cart_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Cart_Items_Product_IdId",
                table: "Cart_Items",
                newName: "IX_Cart_Items_Product_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Cart_Items_Cart_IdId",
                table: "Cart_Items",
                newName: "IX_Cart_Items_Cart_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Items_Carts_Cart_Id",
                table: "Cart_Items",
                column: "Cart_Id",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Items_Products_Product_Id",
                table: "Cart_Items",
                column: "Product_Id",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Items_Orders_Order_Id",
                table: "Order_Items",
                column: "Order_Id",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Items_Products_Product_Id",
                table: "Order_Items",
                column: "Product_Id",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Items_Carts_Cart_Id",
                table: "Cart_Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Items_Products_Product_Id",
                table: "Cart_Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Items_Orders_Order_Id",
                table: "Order_Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Items_Products_Product_Id",
                table: "Order_Items");

            migrationBuilder.RenameColumn(
                name: "Product_Id",
                table: "Order_Items",
                newName: "Product_IdId");

            migrationBuilder.RenameColumn(
                name: "Order_Id",
                table: "Order_Items",
                newName: "Order_IdId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_Items_Product_Id",
                table: "Order_Items",
                newName: "IX_Order_Items_Product_IdId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_Items_Order_Id",
                table: "Order_Items",
                newName: "IX_Order_Items_Order_IdId");

            migrationBuilder.RenameColumn(
                name: "Product_Id",
                table: "Cart_Items",
                newName: "Product_IdId");

            migrationBuilder.RenameColumn(
                name: "Cart_Id",
                table: "Cart_Items",
                newName: "Cart_IdId");

            migrationBuilder.RenameIndex(
                name: "IX_Cart_Items_Product_Id",
                table: "Cart_Items",
                newName: "IX_Cart_Items_Product_IdId");

            migrationBuilder.RenameIndex(
                name: "IX_Cart_Items_Cart_Id",
                table: "Cart_Items",
                newName: "IX_Cart_Items_Cart_IdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Items_Carts_Cart_IdId",
                table: "Cart_Items",
                column: "Cart_IdId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Items_Products_Product_IdId",
                table: "Cart_Items",
                column: "Product_IdId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Items_Orders_Order_IdId",
                table: "Order_Items",
                column: "Order_IdId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Items_Products_Product_IdId",
                table: "Order_Items",
                column: "Product_IdId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
