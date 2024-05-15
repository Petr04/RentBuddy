using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentBuddyBackend.Migrations
{
    /// <inheritdoc />
    public partial class UserCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    TimeSpentAtHome = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
