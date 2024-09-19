using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotNet.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bus",
                columns: table => new
                {
                    BusId = table.Column<string>(type: "text", nullable: false),
                    BusName = table.Column<string>(type: "text", nullable: false),
                    BusType = table.Column<string>(type: "text", nullable: false),
                    BusSeatCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    CustomerName = table.Column<string>(type: "text", nullable: false),
                    CustomerEmail = table.Column<string>(type: "text", nullable: false),
                    CustomerMobileNo = table.Column<string>(type: "text", nullable: false),
                    LoginPassword = table.Column<string>(type: "text", nullable: false),
                    DateJoined = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Seat",
                columns: table => new
                {
                    BusId = table.Column<string>(type: "text", nullable: false),
                    SeatId = table.Column<string>(type: "text", nullable: false),
                    SeatType = table.Column<string>(type: "text", nullable: false),
                    SeatPrice = table.Column<int>(type: "integer", nullable: false),
                    SeatPlace = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bus");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Seat");
        }
    }
}
