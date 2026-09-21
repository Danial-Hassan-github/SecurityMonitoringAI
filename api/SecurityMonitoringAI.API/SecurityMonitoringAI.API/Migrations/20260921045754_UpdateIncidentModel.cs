using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SecurityMonitoringAI.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateIncidentModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RiskScore",
                table: "Incidents",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Source",
                table: "Incidents",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RiskScore",
                table: "Incidents");

            migrationBuilder.DropColumn(
                name: "Source",
                table: "Incidents");
        }
    }
}
