using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookstoreApplication.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorAwards_Author_AuthorId",
                table: "AuthorAwards");

            migrationBuilder.DropForeignKey(
                name: "FK_AuthorAwards_Award_AwardId",
                table: "AuthorAwards");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Publisher_PublisherId",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Award",
                table: "Award");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AuthorAwards",
                table: "AuthorAwards");

            migrationBuilder.RenameTable(
                name: "Award",
                newName: "Awards");

            migrationBuilder.RenameTable(
                name: "AuthorAwards",
                newName: "AuthorAwardBridge");

            migrationBuilder.RenameColumn(
                name: "DateOfBirth",
                table: "Author",
                newName: "Birthday");

            migrationBuilder.RenameIndex(
                name: "IX_AuthorAwards_AwardId",
                table: "AuthorAwardBridge",
                newName: "IX_AuthorAwardBridge_AwardId");

            migrationBuilder.RenameIndex(
                name: "IX_AuthorAwards_AuthorId",
                table: "AuthorAwardBridge",
                newName: "IX_AuthorAwardBridge_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Awards",
                table: "Awards",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuthorAwardBridge",
                table: "AuthorAwardBridge",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorAwardBridge_Author_AuthorId",
                table: "AuthorAwardBridge",
                column: "AuthorId",
                principalTable: "Author",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorAwardBridge_Awards_AwardId",
                table: "AuthorAwardBridge",
                column: "AwardId",
                principalTable: "Awards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Publisher_PublisherId",
                table: "Books",
                column: "PublisherId",
                principalTable: "Publisher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorAwardBridge_Author_AuthorId",
                table: "AuthorAwardBridge");

            migrationBuilder.DropForeignKey(
                name: "FK_AuthorAwardBridge_Awards_AwardId",
                table: "AuthorAwardBridge");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Publisher_PublisherId",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Awards",
                table: "Awards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AuthorAwardBridge",
                table: "AuthorAwardBridge");

            migrationBuilder.RenameTable(
                name: "Awards",
                newName: "Award");

            migrationBuilder.RenameTable(
                name: "AuthorAwardBridge",
                newName: "AuthorAwards");

            migrationBuilder.RenameColumn(
                name: "Birthday",
                table: "Author",
                newName: "DateOfBirth");

            migrationBuilder.RenameIndex(
                name: "IX_AuthorAwardBridge_AwardId",
                table: "AuthorAwards",
                newName: "IX_AuthorAwards_AwardId");

            migrationBuilder.RenameIndex(
                name: "IX_AuthorAwardBridge_AuthorId",
                table: "AuthorAwards",
                newName: "IX_AuthorAwards_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Award",
                table: "Award",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuthorAwards",
                table: "AuthorAwards",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorAwards_Author_AuthorId",
                table: "AuthorAwards",
                column: "AuthorId",
                principalTable: "Author",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorAwards_Award_AwardId",
                table: "AuthorAwards",
                column: "AwardId",
                principalTable: "Award",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Publisher_PublisherId",
                table: "Books",
                column: "PublisherId",
                principalTable: "Publisher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
