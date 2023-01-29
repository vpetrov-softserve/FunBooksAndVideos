using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class modifications : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActivated",
                table: "Domain.Membership");

            migrationBuilder.RenameColumn(
                name: "IsShipped",
                table: "Domain.ContentProduct",
                newName: "Count");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Count",
                table: "Domain.ContentProduct",
                newName: "IsShipped");

            migrationBuilder.AddColumn<bool>(
                name: "IsActivated",
                table: "Domain.Membership",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }
    }
}
