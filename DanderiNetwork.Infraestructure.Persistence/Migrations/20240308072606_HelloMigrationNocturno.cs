﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DanderiNetwork.Infraestructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class HelloMigrationNocturno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsernameUserFollowed",
                table: "Following");

            migrationBuilder.AlterColumn<string>(
                name: "UserMainID",
                table: "Following",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "FollowingUserID",
                table: "Following",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserMainID",
                table: "Following",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "FollowingUserID",
                table: "Following",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "UsernameUserFollowed",
                table: "Following",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
