using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SecurityMonitoringAI.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSecurityEventModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DestinationIp",
                table: "SecurityEvents",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DestinationPort",
                table: "SecurityEvents",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "SecurityEvents",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Protocol",
                table: "SecurityEvents",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SourcePort",
                table: "SecurityEvents",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SourceType",
                table: "SecurityEvents",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DestinationIp",
                table: "SecurityEvents");

            migrationBuilder.DropColumn(
                name: "DestinationPort",
                table: "SecurityEvents");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "SecurityEvents");

            migrationBuilder.DropColumn(
                name: "Protocol",
                table: "SecurityEvents");

            migrationBuilder.DropColumn(
                name: "SourcePort",
                table: "SecurityEvents");

            migrationBuilder.DropColumn(
                name: "SourceType",
                table: "SecurityEvents");
        }
    }
}
