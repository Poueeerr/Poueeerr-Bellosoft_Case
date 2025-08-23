using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Studying.Migrations
{
    /// <inheritdoc />
    public partial class fixingDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "date",
                table: "news",
                newName: "PublishedAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PublishedAt",
                table: "news",
                newName: "date");
        }
    }
}
