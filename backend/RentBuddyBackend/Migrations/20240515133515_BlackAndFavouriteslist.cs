using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentBuddyBackend.Migrations
{
    /// <inheritdoc />
    public partial class BlackAndFavouriteslist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Blacklist",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FavoritesUsers",
                table: "Users");

            migrationBuilder.AddColumn<Guid>(
                name: "BlacklistId",
                table: "Users",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "FavoritesUsersId",
                table: "Users",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlacklistId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FavoritesUsersId",
                table: "Users");

            migrationBuilder.AddColumn<List<Guid>>(
                name: "Blacklist",
                table: "Users",
                type: "uuid[]",
                nullable: false);

            migrationBuilder.AddColumn<List<Guid>>(
                name: "FavoritesUsers",
                table: "Users",
                type: "uuid[]",
                nullable: false);
        }
    }
}
