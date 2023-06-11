using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class AddAdvertisingСompany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdvertisingСompanyId",
                table: "RepairOrders",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AdvertisingСompany",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Discount = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertisingСompany", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RepairOrders_AdvertisingСompanyId",
                table: "RepairOrders",
                column: "AdvertisingСompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_RepairOrders_AdvertisingСompany_AdvertisingСompanyId",
                table: "RepairOrders",
                column: "AdvertisingСompanyId",
                principalTable: "AdvertisingСompany",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RepairOrders_AdvertisingСompany_AdvertisingСompanyId",
                table: "RepairOrders");

            migrationBuilder.DropTable(
                name: "AdvertisingСompany");

            migrationBuilder.DropIndex(
                name: "IX_RepairOrders_AdvertisingСompanyId",
                table: "RepairOrders");

            migrationBuilder.DropColumn(
                name: "AdvertisingСompanyId",
                table: "RepairOrders");
        }
    }
}
