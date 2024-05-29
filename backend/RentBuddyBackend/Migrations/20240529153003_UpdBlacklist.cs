using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentBuddyBackend.Migrations
{
    /// <inheritdoc />
    public partial class UpdBlacklist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_BlacklistEntities_BlacklistId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_BlacklistId",
                table: "Users");

            migrationBuilder.AlterColumn<Guid>(
                name: "BlacklistId",
                table: "Users",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<List<Guid>>(
                name: "UsersId",
                table: "BlacklistEntities",
                type: "uuid[]",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "BlacklistEntities");

            migrationBuilder.AlterColumn<Guid>(
                name: "BlacklistId",
                table: "Users",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.CreateIndex(
                name: "IX_Users_BlacklistId",
                table: "Users",
                column: "BlacklistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_BlacklistEntities_BlacklistId",
                table: "Users",
                column: "BlacklistId",
                principalTable: "BlacklistEntities",
                principalColumn: "Id");
        }
    }
}
