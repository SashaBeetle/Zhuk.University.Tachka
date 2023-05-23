using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zhuk.University.Tachka.Database.Migrations
{
    /// <inheritdoc />
    public partial class DateWithoutTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PlacementTime",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlacementTime",
                table: "Cars");
        }
    }
}
