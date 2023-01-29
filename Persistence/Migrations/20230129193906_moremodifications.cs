using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class moremodifications : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Orders_OrderId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_OrderId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "UsersMemberships",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "UsersContentProducts",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OrderProductDetails",
                columns: table => new
                {
                    OrdersId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProductDetails", x => new { x.OrdersId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_OrderProductDetails_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProductDetails_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersMemberships_OrderId",
                table: "UsersMemberships",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersContentProducts_OrderId",
                table: "UsersContentProducts",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProductDetails_ProductsId",
                table: "OrderProductDetails",
                column: "ProductsId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersContentProducts_Orders_OrderId",
                table: "UsersContentProducts",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersMemberships_Orders_OrderId",
                table: "UsersMemberships",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersContentProducts_Orders_OrderId",
                table: "UsersContentProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersMemberships_Orders_OrderId",
                table: "UsersMemberships");

            migrationBuilder.DropTable(
                name: "OrderProductDetails");

            migrationBuilder.DropIndex(
                name: "IX_UsersMemberships_OrderId",
                table: "UsersMemberships");

            migrationBuilder.DropIndex(
                name: "IX_UsersContentProducts_OrderId",
                table: "UsersContentProducts");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "UsersMemberships");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "UsersContentProducts");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Products",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_OrderId",
                table: "Products",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Orders_OrderId",
                table: "Products",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}
