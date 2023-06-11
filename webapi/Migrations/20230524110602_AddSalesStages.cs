using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class AddSalesStages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndedAt",
                table: "RepairOrders");

            migrationBuilder.DropColumn(
                name: "StartedAt",
                table: "RepairOrders");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "RepairOrders");

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "RepairOrders",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SalesStages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IsFirstDefault = table.Column<bool>(type: "boolean", nullable: false),
                    IsLastDefault = table.Column<bool>(type: "boolean", nullable: false),
                    IsCancelDefault = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesStages", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "SalesStages",
                columns: new[] { "Id", "IsCancelDefault", "IsFirstDefault", "IsLastDefault", "Name" },
                values: new object[,]
                {
                    { 1, false, true, false, "Обращение клиента" },
                    { 2, false, false, false, "Приемка устройства" },
                    { 3, false, false, false, "Информирование клиента о стоимости ремонта" },
                    { 4, false, false, false, "Ожидание запчастей" },
                    { 5, false, false, false, "Ремонт" },
                    { 6, false, false, false, "Оплата ремонта" },
                    { 7, false, false, true, "Завершен" },
                    { 8, true, false, false, "Отказ" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RepairOrders_StatusId",
                table: "RepairOrders",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_RepairOrders_SalesStages_StatusId",
                table: "RepairOrders",
                column: "StatusId",
                principalTable: "SalesStages",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RepairOrders_SalesStages_StatusId",
                table: "RepairOrders");

            migrationBuilder.DropTable(
                name: "SalesStages");

            migrationBuilder.DropIndex(
                name: "IX_RepairOrders_StatusId",
                table: "RepairOrders");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "RepairOrders");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndedAt",
                table: "RepairOrders",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartedAt",
                table: "RepairOrders",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "RepairOrders",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
