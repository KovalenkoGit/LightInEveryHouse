using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LightInEveryHouse.Migrations
{
    /// <inheritdoc />
    public partial class newcolumndayNum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DayNum",
                table: "Schedules",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DayNum",
                table: "Schedules");
        }
    }
}
