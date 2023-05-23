using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class AddOrders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItem_RepairOrders_RepairOrderId",
                table: "InventoryItem");

            migrationBuilder.DropIndex(
                name: "IX_InventoryItem_RepairOrderId",
                table: "InventoryItem");

            migrationBuilder.DropColumn(
                name: "RepairOrderId",
                table: "InventoryItem");

            migrationBuilder.CreateTable(
                name: "InventoryItemRepairOrder",
                columns: table => new
                {
                    PartsUsedId = table.Column<int>(type: "integer", nullable: false),
                    repairOrdersId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryItemRepairOrder", x => new { x.PartsUsedId, x.repairOrdersId });
                    table.ForeignKey(
                        name: "FK_InventoryItemRepairOrder_InventoryItem_PartsUsedId",
                        column: x => x.PartsUsedId,
                        principalTable: "InventoryItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryItemRepairOrder_RepairOrders_repairOrdersId",
                        column: x => x.repairOrdersId,
                        principalTable: "RepairOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItemRepairOrder_repairOrdersId",
                table: "InventoryItemRepairOrder",
                column: "repairOrdersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryItemRepairOrder");

            migrationBuilder.AddColumn<int>(
                name: "RepairOrderId",
                table: "InventoryItem",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItem_RepairOrderId",
                table: "InventoryItem",
                column: "RepairOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItem_RepairOrders_RepairOrderId",
                table: "InventoryItem",
                column: "RepairOrderId",
                principalTable: "RepairOrders",
                principalColumn: "Id");
        }
    }
}
