using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRepairOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AspNetUserId",
                table: "RepairOrder");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndedAt",
                table: "RepairOrder",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartedAt",
                table: "RepairOrder",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndedAt",
                table: "RepairOrder");

            migrationBuilder.DropColumn(
                name: "StartedAt",
                table: "RepairOrder");

            migrationBuilder.AddColumn<string>(
                name: "AspNetUserId",
                table: "RepairOrder",
                type: "text",
                nullable: true);
        }
    }
}
