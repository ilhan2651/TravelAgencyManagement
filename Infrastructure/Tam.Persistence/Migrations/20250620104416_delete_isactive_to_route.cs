using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tam.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class delete_isactive_to_route : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Routes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Routes",
                type: "boolean",
                nullable: false,
                defaultValue: true);
        }
    }
}
