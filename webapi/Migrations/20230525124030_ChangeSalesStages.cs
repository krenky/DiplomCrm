using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class ChangeSalesStages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NextStagesId",
                table: "SalesStages",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "SalesStages",
                keyColumn: "Id",
                keyValue: 1,
                column: "NextStagesId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "SalesStages",
                keyColumn: "Id",
                keyValue: 2,
                column: "NextStagesId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "SalesStages",
                keyColumn: "Id",
                keyValue: 3,
                column: "NextStagesId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "SalesStages",
                keyColumn: "Id",
                keyValue: 4,
                column: "NextStagesId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "SalesStages",
                keyColumn: "Id",
                keyValue: 5,
                column: "NextStagesId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "SalesStages",
                keyColumn: "Id",
                keyValue: 6,
                column: "NextStagesId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "SalesStages",
                keyColumn: "Id",
                keyValue: 7,
                column: "NextStagesId",
                value: null);

            migrationBuilder.UpdateData(
                table: "SalesStages",
                keyColumn: "Id",
                keyValue: 8,
                column: "NextStagesId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_SalesStages_NextStagesId",
                table: "SalesStages",
                column: "NextStagesId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesStages_SalesStages_NextStagesId",
                table: "SalesStages",
                column: "NextStagesId",
                principalTable: "SalesStages",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesStages_SalesStages_NextStagesId",
                table: "SalesStages");

            migrationBuilder.DropIndex(
                name: "IX_SalesStages_NextStagesId",
                table: "SalesStages");

            migrationBuilder.DropColumn(
                name: "NextStagesId",
                table: "SalesStages");
        }
    }
}
