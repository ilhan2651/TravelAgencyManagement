using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Tam.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class adding_entities_roomtype_hotelroomoption_hotelreservationroomoption_and_fixedGuideLanguage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelPurchases_Hotels_HotelId",
                table: "HotelPurchases");

            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_Locations_LocationId",
                table: "Hotels");

            migrationBuilder.CreateTable(
                name: "RoomTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HotelRoomOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HotelId = table.Column<int>(type: "integer", nullable: false),
                    RoomTypeId = table.Column<int>(type: "integer", nullable: false),
                    PricePerNight = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Capacity = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelRoomOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelRoomOptions_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HotelRoomOptions_RoomTypes_RoomTypeId",
                        column: x => x.RoomTypeId,
                        principalTable: "RoomTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotelReservationRoomOptions",
                columns: table => new
                {
                    HotelReservationId = table.Column<int>(type: "integer", nullable: false),
                    HotelRoomOptionId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelReservationRoomOptions", x => new { x.HotelReservationId, x.HotelRoomOptionId });
                    table.ForeignKey(
                        name: "FK_HotelReservationRoomOptions_HotelReservations_HotelReservat~",
                        column: x => x.HotelReservationId,
                        principalTable: "HotelReservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HotelReservationRoomOptions_HotelRoomOptions_HotelRoomOptio~",
                        column: x => x.HotelRoomOptionId,
                        principalTable: "HotelRoomOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HotelReservationRoomOptions_HotelRoomOptionId",
                table: "HotelReservationRoomOptions",
                column: "HotelRoomOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelRoomOptions_HotelId",
                table: "HotelRoomOptions",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelRoomOptions_RoomTypeId",
                table: "HotelRoomOptions",
                column: "RoomTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelPurchases_Hotels_HotelId",
                table: "HotelPurchases",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_Locations_LocationId",
                table: "Hotels",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelPurchases_Hotels_HotelId",
                table: "HotelPurchases");

            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_Locations_LocationId",
                table: "Hotels");

            migrationBuilder.DropTable(
                name: "HotelReservationRoomOptions");

            migrationBuilder.DropTable(
                name: "HotelRoomOptions");

            migrationBuilder.DropTable(
                name: "RoomTypes");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelPurchases_Hotels_HotelId",
                table: "HotelPurchases",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_Locations_LocationId",
                table: "Hotels",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
