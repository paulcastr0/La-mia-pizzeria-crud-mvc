using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lamiapizzeria.Migrations
{
    /// <inheritdoc />
    public partial class Creazionerelazione1aN1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Pizzas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Pizzas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_CategoryId",
                table: "Pizzas",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Category_CategoryId",
                table: "Pizzas",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Category_CategoryId",
                table: "Pizzas");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Pizzas_CategoryId",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Pizzas");
        }
    }
}
