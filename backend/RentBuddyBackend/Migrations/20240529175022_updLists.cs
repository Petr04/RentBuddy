using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentBuddyBackend.Migrations
{
    /// <inheritdoc />
    public partial class updLists : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_FavoriteRoomsEntities_FavoriteRoomsEntityId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_FavoriteRoomsEntities_FavoriteRoomsId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_FavouritesEntities_FavoriteUsersId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_FavoriteRoomsId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_FavoriteUsersId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_FavoriteRoomsEntityId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "FavoriteRoomsEntityId",
                table: "Rooms");

            migrationBuilder.AlterColumn<Guid>(
                name: "FavoriteUsersId",
                table: "Users",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "FavoriteRoomsId",
                table: "Users",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<List<Guid>>(
                name: "UsersId",
                table: "FavouritesEntities",
                type: "uuid[]",
                nullable: true);

            migrationBuilder.AddColumn<List<Guid>>(
                name: "RoomsId",
                table: "FavoriteRoomsEntities",
                type: "uuid[]",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "FavouritesEntities");

            migrationBuilder.DropColumn(
                name: "RoomsId",
                table: "FavoriteRoomsEntities");

            migrationBuilder.AlterColumn<Guid>(
                name: "FavoriteUsersId",
                table: "Users",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "FavoriteRoomsId",
                table: "Users",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "FavoriteRoomsEntityId",
                table: "Rooms",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_FavoriteRoomsId",
                table: "Users",
                column: "FavoriteRoomsId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_FavoriteUsersId",
                table: "Users",
                column: "FavoriteUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_FavoriteRoomsEntityId",
                table: "Rooms",
                column: "FavoriteRoomsEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_FavoriteRoomsEntities_FavoriteRoomsEntityId",
                table: "Rooms",
                column: "FavoriteRoomsEntityId",
                principalTable: "FavoriteRoomsEntities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_FavoriteRoomsEntities_FavoriteRoomsId",
                table: "Users",
                column: "FavoriteRoomsId",
                principalTable: "FavoriteRoomsEntities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_FavouritesEntities_FavoriteUsersId",
                table: "Users",
                column: "FavoriteUsersId",
                principalTable: "FavouritesEntities",
                principalColumn: "Id");
        }
    }
}
