using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lamiapizzeria.Migrations
{
    /// <inheritdoc />
    public partial class Creazionerelazione1aN8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Categories",
                newName: "category");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "category",
                table: "Categories",
                newName: "Title");
        }
    }
}
