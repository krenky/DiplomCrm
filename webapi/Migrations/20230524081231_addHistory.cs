using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class addHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "customerHistories",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_customerHistories_CustomerId",
                table: "customerHistories",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_customerHistories_Customer_CustomerId",
                table: "customerHistories",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_customerHistories_Customer_CustomerId",
                table: "customerHistories");

            migrationBuilder.DropIndex(
                name: "IX_customerHistories_CustomerId",
                table: "customerHistories");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "customerHistories");
        }
    }
}
