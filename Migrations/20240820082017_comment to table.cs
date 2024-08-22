using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LightInEveryHouse.Migrations
{
    /// <inheritdoc />
    public partial class commenttotable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterTable(
                name: "Schedules",
                comment: "This table contains the day and period of blackout.");

            migrationBuilder.AlterTable(
                name: "Group",
                comment: "This table contains groups with a description of which objects belong to this group and the possible time of turning off the light");

            migrationBuilder.AlterTable(
                name: "Address",
                comment: "This table contains addresses for which blackout schedules apply.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterTable(
                name: "Schedules",
                oldComment: "This table contains the day and period of blackout.");

            migrationBuilder.AlterTable(
                name: "Group",
                oldComment: "This table contains groups with a description of which objects belong to this group and the possible time of turning off the light");

            migrationBuilder.AlterTable(
                name: "Address",
                oldComment: "This table contains addresses for which blackout schedules apply.");
        }
    }
}
