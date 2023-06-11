using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class ChangeStatusID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RepairOrders_SalesStages_StatusId",
                table: "RepairOrders");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "RepairOrders",
                newName: "SalesStagesId");

            migrationBuilder.RenameIndex(
                name: "IX_RepairOrders_StatusId",
                table: "RepairOrders",
                newName: "IX_RepairOrders_SalesStagesId");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "RepairOrderHistory",
                newName: "SalesStagesId");

            migrationBuilder.AddForeignKey(
                name: "FK_RepairOrders_SalesStages_SalesStagesId",
                table: "RepairOrders",
                column: "SalesStagesId",
                principalTable: "SalesStages",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RepairOrders_SalesStages_SalesStagesId",
                table: "RepairOrders");

            migrationBuilder.RenameColumn(
                name: "SalesStagesId",
                table: "RepairOrders",
                newName: "StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_RepairOrders_SalesStagesId",
                table: "RepairOrders",
                newName: "IX_RepairOrders_StatusId");

            migrationBuilder.RenameColumn(
                name: "SalesStagesId",
                table: "RepairOrderHistory",
                newName: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_RepairOrders_SalesStages_StatusId",
                table: "RepairOrders",
                column: "StatusId",
                principalTable: "SalesStages",
                principalColumn: "Id");
        }
    }
}
