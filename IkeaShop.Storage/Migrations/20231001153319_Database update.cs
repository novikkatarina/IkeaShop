using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IkeaShop.Migrations
{
    /// <inheritdoc />
    public partial class Databaseupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LinkFirst",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LinkSecond",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LinkFirst",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "LinkSecond",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Products");
        }
    }
}
