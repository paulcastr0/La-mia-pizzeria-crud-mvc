using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lamiapizzeria.Migrations
{
    /// <inheritdoc />
    public partial class Creazionerelazione1aN9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "category",
                table: "Categories",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Categories",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Categories",
                newName: "category");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Categories",
                newName: "CategoryId");
        }
    }
}
