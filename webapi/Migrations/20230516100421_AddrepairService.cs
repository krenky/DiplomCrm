using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class AddrepairService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RepairService",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepairService", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RepairOrderRepairService",
                columns: table => new
                {
                    repairOrdersId = table.Column<int>(type: "integer", nullable: false),
                    repairServicesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepairOrderRepairService", x => new { x.repairOrdersId, x.repairServicesId });
                    table.ForeignKey(
                        name: "FK_RepairOrderRepairService_RepairOrder_repairOrdersId",
                        column: x => x.repairOrdersId,
                        principalTable: "RepairOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RepairOrderRepairService_RepairService_repairServicesId",
                        column: x => x.repairServicesId,
                        principalTable: "RepairService",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RepairOrderRepairService_repairServicesId",
                table: "RepairOrderRepairService",
                column: "repairServicesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RepairOrderRepairService");

            migrationBuilder.DropTable(
                name: "RepairService");
        }
    }
}
