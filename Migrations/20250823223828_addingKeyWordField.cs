using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Studying.Migrations
{
    /// <inheritdoc />
    public partial class addingKeyWordField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "keyword",
                table: "news",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "keyword",
                table: "news");
        }
    }
}
