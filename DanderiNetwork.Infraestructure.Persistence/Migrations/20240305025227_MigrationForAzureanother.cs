using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DanderiNetwork.Infraestructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class MigrationForAzureanother : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_CommentID",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_CommentID",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CommentID",
                table: "Comments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CommentID",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CommentID",
                table: "Comments",
                column: "CommentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_CommentID",
                table: "Comments",
                column: "CommentID",
                principalTable: "Comments",
                principalColumn: "ID");
        }
    }
}
