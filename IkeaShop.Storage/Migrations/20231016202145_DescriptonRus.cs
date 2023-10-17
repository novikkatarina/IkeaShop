using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IkeaShop.Migrations
{
    /// <inheritdoc />
    public partial class DescriptonRus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DescriptionRus",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescriptionRus",
                table: "Products");
        }
    }
}
