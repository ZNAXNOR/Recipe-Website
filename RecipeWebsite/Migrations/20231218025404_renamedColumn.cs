using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeWebsite.Migrations
{
    /// <inheritdoc />
    public partial class renamedColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "RecipeTags",
                newName: "TagsName");

            migrationBuilder.RenameColumn(
                name: "CategoryDescription",
                table: "RecipeTags",
                newName: "TagsDescription");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TagsName",
                table: "RecipeTags",
                newName: "CategoryName");

            migrationBuilder.RenameColumn(
                name: "TagsDescription",
                table: "RecipeTags",
                newName: "CategoryDescription");
        }
    }
}
