using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeWebsite.Migrations
{
    /// <inheritdoc />
    public partial class CollectionCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CollectionCategory",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CollectionCategory",
                table: "Posts");
        }
    }
}
