using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeWebsite.Migrations
{
    /// <inheritdoc />
    public partial class PostCollections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostTags_Posts_PostId",
                table: "PostTags");

            migrationBuilder.DropForeignKey(
                name: "FK_PostTags_RecipeTags_TagId",
                table: "PostTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostTags",
                table: "PostTags");

            migrationBuilder.RenameTable(
                name: "PostTags",
                newName: "PostTagModel");

            migrationBuilder.RenameIndex(
                name: "IX_PostTags_TagId",
                table: "PostTagModel",
                newName: "IX_PostTagModel_TagId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostTagModel",
                table: "PostTagModel",
                columns: new[] { "PostId", "TagId" });

            migrationBuilder.CreateTable(
                name: "PostCollectionModel",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false),
                    CollectionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostCollectionModel", x => new { x.CollectionId, x.PostId });
                    table.ForeignKey(
                        name: "FK_PostCollectionModel_Collections_CollectionId",
                        column: x => x.CollectionId,
                        principalTable: "Collections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostCollectionModel_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostCollectionModel_PostId",
                table: "PostCollectionModel",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostTagModel_Posts_PostId",
                table: "PostTagModel",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostTagModel_RecipeTags_TagId",
                table: "PostTagModel",
                column: "TagId",
                principalTable: "RecipeTags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostTagModel_Posts_PostId",
                table: "PostTagModel");

            migrationBuilder.DropForeignKey(
                name: "FK_PostTagModel_RecipeTags_TagId",
                table: "PostTagModel");

            migrationBuilder.DropTable(
                name: "PostCollectionModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostTagModel",
                table: "PostTagModel");

            migrationBuilder.RenameTable(
                name: "PostTagModel",
                newName: "PostTags");

            migrationBuilder.RenameIndex(
                name: "IX_PostTagModel_TagId",
                table: "PostTags",
                newName: "IX_PostTags_TagId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostTags",
                table: "PostTags",
                columns: new[] { "PostId", "TagId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PostTags_Posts_PostId",
                table: "PostTags",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostTags_RecipeTags_TagId",
                table: "PostTags",
                column: "TagId",
                principalTable: "RecipeTags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
