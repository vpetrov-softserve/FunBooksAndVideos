using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AbstractProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActivated",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsShipped",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductType",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Products",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Domain.Membership",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IsActivated = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domain.Membership", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Domain.Membership_Products_Id",
                        column: x => x.Id,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Domain.Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductType = table.Column<int>(type: "INTEGER", nullable: false),
                    IsShipped = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domain.Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Domain.Product_Products_Id",
                        column: x => x.Id,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Domain.Membership");

            migrationBuilder.DropTable(
                name: "Domain.Product");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Products");

            migrationBuilder.AddColumn<bool>(
                name: "IsActivated",
                table: "Products",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsShipped",
                table: "Products",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ProductType",
                table: "Products",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
