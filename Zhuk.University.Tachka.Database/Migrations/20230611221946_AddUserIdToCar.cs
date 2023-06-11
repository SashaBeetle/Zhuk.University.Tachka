using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zhuk.University.Tachka.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddUserIdToCar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Cars");
        }
    }
}
