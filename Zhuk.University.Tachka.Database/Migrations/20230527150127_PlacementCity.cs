using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zhuk.University.Tachka.Database.Migrations
{
    /// <inheritdoc />
    public partial class PlacementCity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PlacementCity",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlacementCity",
                table: "Cars");
        }
    }
}
