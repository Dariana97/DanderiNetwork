using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DanderiNetwork.Infraestructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Following",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserMainID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FollowingUserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Following", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Caption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdReference = table.Column<int>(type: "int", nullable: true),
                    PostID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserIDReplied = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostID",
                        column: x => x.PostID,
                        principalTable: "Posts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostID",
                table: "Comments",
                column: "PostID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Following");

            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
