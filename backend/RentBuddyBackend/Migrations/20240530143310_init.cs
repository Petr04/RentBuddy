using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentBuddyBackend.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
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
                    Address = table.Column<string>(type: "text", nullable: false),
                    IsCombinedBathroom = table.Column<bool>(type: "boolean", nullable: false),
                    BathrooomCount = table.Column<int>(type: "integer", nullable: false),
                    TechnicType = table.Column<int[]>(type: "integer[]", nullable: false),
                    HasWifi = table.Column<bool>(type: "boolean", nullable: false),
                    HasPassengerElevator = table.Column<bool>(type: "boolean", nullable: false),
                    HasFreightElevator = table.Column<bool>(type: "boolean", nullable: false),
                    ParkingType = table.Column<int>(type: "integer", nullable: false),
                    YardType = table.Column<int>(type: "integer", nullable: false),
                    HasPet = table.Column<bool>(type: "boolean", nullable: false),
                    CanUserSmoke = table.Column<bool>(type: "boolean", nullable: false),
                    ImageLinks = table.Column<List<string>>(type: "text[]", nullable: false),
                    AboutApartment = table.Column<string>(type: "text", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlacklistEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UsersId = table.Column<List<Guid>>(type: "uuid[]", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlacklistEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FavoriteRoomsEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RoomsId = table.Column<List<Guid>>(type: "uuid[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteRoomsEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FavouritesEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UsersId = table.Column<List<Guid>>(type: "uuid[]", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouritesEntities", x => x.Id);
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
                    AboutMe = table.Column<string>(type: "text", nullable: false),
                    BlacklistId = table.Column<Guid>(type: "uuid", nullable: false),
                    FavoriteUsersId = table.Column<Guid>(type: "uuid", nullable: false),
                    FavoriteRoomsId = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    PasswordHash = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
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
                    ApartmentId = table.Column<Guid>(type: "uuid", nullable: true),
                    TechnicTypes = table.Column<int[]>(type: "integer[]", nullable: false),
                    FurnitureTypes = table.Column<int[]>(type: "integer[]", nullable: false),
                    AboutRoom = table.Column<string>(type: "text", nullable: false),
                    IsPublished = table.Column<bool>(type: "boolean", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_ApartmentId",
                table: "Rooms",
                column: "ApartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlacklistEntities");

            migrationBuilder.DropTable(
                name: "FavoriteRoomsEntities");

            migrationBuilder.DropTable(
                name: "FavouritesEntities");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Apartments");
        }
    }
}
