using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentBuddyBackend.Migrations
{
    /// <inheritdoc />
    public partial class RegAndAuth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Apartments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RoomsCount = table.Column<int>(type: "integer", nullable: false),
                    CurrentFloor = table.Column<int>(type: "integer", nullable: false),
                    MaxFloor = table.Column<int>(type: "integer", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlacklistEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlacklistEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FavouritesEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouritesEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    Square = table.Column<int>(type: "integer", nullable: false),
                    InhabitantsCount = table.Column<int>(type: "integer", nullable: false),
                    ImageLink = table.Column<string>(type: "text", nullable: false),
                    ApartmentId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Apartments_ApartmentId",
                        column: x => x.ApartmentId,
                        principalTable: "Apartments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Lastname = table.Column<string>(type: "text", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    IsSmoke = table.Column<bool>(type: "boolean", nullable: false),
                    HasPet = table.Column<bool>(type: "boolean", nullable: false),
                    CommunicationLevel = table.Column<int>(type: "integer", nullable: false),
                    PureLevel = table.Column<int>(type: "integer", nullable: false),
                    RiseTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    SleepTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TimeSpentAtHome = table.Column<int>(type: "integer", nullable: false),
                    FavoritesUsersId = table.Column<Guid>(type: "uuid", nullable: false),
                    BlacklistId = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    FavoritesId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_BlacklistEntities_BlacklistId",
                        column: x => x.BlacklistId,
                        principalTable: "BlacklistEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_FavouritesEntities_FavoritesId",
                        column: x => x.FavoritesId,
                        principalTable: "FavouritesEntities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_ApartmentId",
                table: "Rooms",
                column: "ApartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_BlacklistId",
                table: "Users",
                column: "BlacklistId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_FavoritesId",
                table: "Users",
                column: "FavoritesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Apartments");

            migrationBuilder.DropTable(
                name: "BlacklistEntities");

            migrationBuilder.DropTable(
                name: "FavouritesEntities");
        }
    }
}
