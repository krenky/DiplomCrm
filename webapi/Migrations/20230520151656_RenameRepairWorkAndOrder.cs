using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class RenameRepairWorkAndOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItem_RepairOrder_RepairOrderId",
                table: "InventoryItem");

            migrationBuilder.DropForeignKey(
                name: "FK_RepairOrder_AspNetUsers_ApplicationUserId",
                table: "RepairOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_RepairOrder_Customer_CustomerId",
                table: "RepairOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_RepairOrder_Device_DeviceId",
                table: "RepairOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_RepairOrderRepairWork_RepairOrder_repairOrdersId",
                table: "RepairOrderRepairWork");

            migrationBuilder.DropForeignKey(
                name: "FK_RepairOrderRepairWork_RepairWork_repairWorksId",
                table: "RepairOrderRepairWork");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RepairWork",
                table: "RepairWork");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RepairOrder",
                table: "RepairOrder");

            migrationBuilder.RenameTable(
                name: "RepairWork",
                newName: "RepairWorks");

            migrationBuilder.RenameTable(
                name: "RepairOrder",
                newName: "RepairOrders");

            migrationBuilder.RenameIndex(
                name: "IX_RepairOrder_DeviceId",
                table: "RepairOrders",
                newName: "IX_RepairOrders_DeviceId");

            migrationBuilder.RenameIndex(
                name: "IX_RepairOrder_CustomerId",
                table: "RepairOrders",
                newName: "IX_RepairOrders_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_RepairOrder_ApplicationUserId",
                table: "RepairOrders",
                newName: "IX_RepairOrders_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RepairWorks",
                table: "RepairWorks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RepairOrders",
                table: "RepairOrders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItem_RepairOrders_RepairOrderId",
                table: "InventoryItem",
                column: "RepairOrderId",
                principalTable: "RepairOrders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RepairOrderRepairWork_RepairOrders_repairOrdersId",
                table: "RepairOrderRepairWork",
                column: "repairOrdersId",
                principalTable: "RepairOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RepairOrderRepairWork_RepairWorks_repairWorksId",
                table: "RepairOrderRepairWork",
                column: "repairWorksId",
                principalTable: "RepairWorks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RepairOrders_AspNetUsers_ApplicationUserId",
                table: "RepairOrders",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RepairOrders_Customer_CustomerId",
                table: "RepairOrders",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RepairOrders_Device_DeviceId",
                table: "RepairOrders",
                column: "DeviceId",
                principalTable: "Device",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItem_RepairOrders_RepairOrderId",
                table: "InventoryItem");

            migrationBuilder.DropForeignKey(
                name: "FK_RepairOrderRepairWork_RepairOrders_repairOrdersId",
                table: "RepairOrderRepairWork");

            migrationBuilder.DropForeignKey(
                name: "FK_RepairOrderRepairWork_RepairWorks_repairWorksId",
                table: "RepairOrderRepairWork");

            migrationBuilder.DropForeignKey(
                name: "FK_RepairOrders_AspNetUsers_ApplicationUserId",
                table: "RepairOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_RepairOrders_Customer_CustomerId",
                table: "RepairOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_RepairOrders_Device_DeviceId",
                table: "RepairOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RepairWorks",
                table: "RepairWorks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RepairOrders",
                table: "RepairOrders");

            migrationBuilder.RenameTable(
                name: "RepairWorks",
                newName: "RepairWork");

            migrationBuilder.RenameTable(
                name: "RepairOrders",
                newName: "RepairOrder");

            migrationBuilder.RenameIndex(
                name: "IX_RepairOrders_DeviceId",
                table: "RepairOrder",
                newName: "IX_RepairOrder_DeviceId");

            migrationBuilder.RenameIndex(
                name: "IX_RepairOrders_CustomerId",
                table: "RepairOrder",
                newName: "IX_RepairOrder_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_RepairOrders_ApplicationUserId",
                table: "RepairOrder",
                newName: "IX_RepairOrder_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RepairWork",
                table: "RepairWork",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RepairOrder",
                table: "RepairOrder",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItem_RepairOrder_RepairOrderId",
                table: "InventoryItem",
                column: "RepairOrderId",
                principalTable: "RepairOrder",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RepairOrder_AspNetUsers_ApplicationUserId",
                table: "RepairOrder",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RepairOrder_Customer_CustomerId",
                table: "RepairOrder",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RepairOrder_Device_DeviceId",
                table: "RepairOrder",
                column: "DeviceId",
                principalTable: "Device",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RepairOrderRepairWork_RepairOrder_repairOrdersId",
                table: "RepairOrderRepairWork",
                column: "repairOrdersId",
                principalTable: "RepairOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RepairOrderRepairWork_RepairWork_repairWorksId",
                table: "RepairOrderRepairWork",
                column: "repairWorksId",
                principalTable: "RepairWork",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
