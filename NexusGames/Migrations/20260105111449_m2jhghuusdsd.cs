using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NexusGames.Migrations
{
    /// <inheritdoc />
    public partial class m2jhghuusdsd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Games");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Games_CategoryId",
                table: "Games",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Categories_CategoryId",
                table: "Games",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Categories_CategoryId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_CategoryId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Games");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Games",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
