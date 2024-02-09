using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeWebsite.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostCollectionModel_Collections_CollectionId",
                table: "PostCollectionModel");

            migrationBuilder.DropForeignKey(
                name: "FK_PostCollectionModel_Posts_PostId",
                table: "PostCollectionModel");

            migrationBuilder.DropForeignKey(
                name: "FK_PostTagModel_Posts_PostId",
                table: "PostTagModel");

            migrationBuilder.DropForeignKey(
                name: "FK_PostTagModel_RecipeTags_TagId",
                table: "PostTagModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostTagModel",
                table: "PostTagModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostCollectionModel",
                table: "PostCollectionModel");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Collections");

            migrationBuilder.RenameTable(
                name: "PostTagModel",
                newName: "PostTags");

            migrationBuilder.RenameTable(
                name: "PostCollectionModel",
                newName: "PostCollections");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Collections",
                newName: "CollectionTitle");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Collections",
                newName: "CollectionImage");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Collections",
                newName: "CollectionId");

            migrationBuilder.RenameIndex(
                name: "IX_PostTagModel_TagId",
                table: "PostTags",
                newName: "IX_PostTags_TagId");

            migrationBuilder.RenameIndex(
                name: "IX_PostCollectionModel_PostId",
                table: "PostCollections",
                newName: "IX_PostCollections_PostId");

            migrationBuilder.AddColumn<string>(
                name: "CollectionDescription",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostTags",
                table: "PostTags",
                columns: new[] { "PostId", "TagId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostCollections",
                table: "PostCollections",
                columns: new[] { "CollectionId", "PostId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PostCollections_Collections_CollectionId",
                table: "PostCollections",
                column: "CollectionId",
                principalTable: "Collections",
                principalColumn: "CollectionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostCollections_Posts_PostId",
                table: "PostCollections",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostCollections_Collections_CollectionId",
                table: "PostCollections");

            migrationBuilder.DropForeignKey(
                name: "FK_PostCollections_Posts_PostId",
                table: "PostCollections");

            migrationBuilder.DropForeignKey(
                name: "FK_PostTags_Posts_PostId",
                table: "PostTags");

            migrationBuilder.DropForeignKey(
                name: "FK_PostTags_RecipeTags_TagId",
                table: "PostTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostTags",
                table: "PostTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostCollections",
                table: "PostCollections");

            migrationBuilder.DropColumn(
                name: "CollectionDescription",
                table: "Collections");

            migrationBuilder.RenameTable(
                name: "PostTags",
                newName: "PostTagModel");

            migrationBuilder.RenameTable(
                name: "PostCollections",
                newName: "PostCollectionModel");

            migrationBuilder.RenameColumn(
                name: "CollectionTitle",
                table: "Collections",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "CollectionImage",
                table: "Collections",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "CollectionId",
                table: "Collections",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_PostTags_TagId",
                table: "PostTagModel",
                newName: "IX_PostTagModel_TagId");

            migrationBuilder.RenameIndex(
                name: "IX_PostCollections_PostId",
                table: "PostCollectionModel",
                newName: "IX_PostCollectionModel_PostId");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostTagModel",
                table: "PostTagModel",
                columns: new[] { "PostId", "TagId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostCollectionModel",
                table: "PostCollectionModel",
                columns: new[] { "CollectionId", "PostId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PostCollectionModel_Collections_CollectionId",
                table: "PostCollectionModel",
                column: "CollectionId",
                principalTable: "Collections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostCollectionModel_Posts_PostId",
                table: "PostCollectionModel",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
    }
}
