using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class RenameRepairServiceInOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RepairOrderRepairWork_RepairWork_repairServicesId",
                table: "RepairOrderRepairWork");

            migrationBuilder.RenameColumn(
                name: "repairServicesId",
                table: "RepairOrderRepairWork",
                newName: "repairWorksId");

            migrationBuilder.RenameIndex(
                name: "IX_RepairOrderRepairWork_repairServicesId",
                table: "RepairOrderRepairWork",
                newName: "IX_RepairOrderRepairWork_repairWorksId");

            migrationBuilder.AddForeignKey(
                name: "FK_RepairOrderRepairWork_RepairWork_repairWorksId",
                table: "RepairOrderRepairWork",
                column: "repairWorksId",
                principalTable: "RepairWork",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RepairOrderRepairWork_RepairWork_repairWorksId",
                table: "RepairOrderRepairWork");

            migrationBuilder.RenameColumn(
                name: "repairWorksId",
                table: "RepairOrderRepairWork",
                newName: "repairServicesId");

            migrationBuilder.RenameIndex(
                name: "IX_RepairOrderRepairWork_repairWorksId",
                table: "RepairOrderRepairWork",
                newName: "IX_RepairOrderRepairWork_repairServicesId");

            migrationBuilder.AddForeignKey(
                name: "FK_RepairOrderRepairWork_RepairWork_repairServicesId",
                table: "RepairOrderRepairWork",
                column: "repairServicesId",
                principalTable: "RepairWork",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
