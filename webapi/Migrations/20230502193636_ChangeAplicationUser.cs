using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class ChangeAplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02f5a2bf-3078-435c-ab31-52c3fb5d16d3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1dbe60e0-9802-42e9-a952-18bda1c61d89");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36812fae-6dfa-4b45-b06c-54c6053332f6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "72e8e07b-75e4-40e6-a9e9-13b3414c6b32");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "811865b7-2384-47ea-8b46-59a2553924aa");

            migrationBuilder.AlterColumn<string>(
                name: "JobTitle",
                table: "AspNetUsers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2e1a14e6-aaf7-481b-a934-1aa80b40ae5a", null, "Technician", null },
                    { "48161cdb-a762-4317-a422-30f08b6391f8", null, "Executive", null },
                    { "4f520630-2235-4964-bcc1-568cc4789682", null, "ServiceManager", null },
                    { "dfb5c8fa-6011-4c4b-ae15-d129958b22a4", null, "ITSupport", null },
                    { "f7bd4202-d227-4785-8d3a-2ac0c0e624e1", null, "Administrator", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2e1a14e6-aaf7-481b-a934-1aa80b40ae5a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "48161cdb-a762-4317-a422-30f08b6391f8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4f520630-2235-4964-bcc1-568cc4789682");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dfb5c8fa-6011-4c4b-ae15-d129958b22a4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7bd4202-d227-4785-8d3a-2ac0c0e624e1");

            migrationBuilder.AlterColumn<string>(
                name: "JobTitle",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "02f5a2bf-3078-435c-ab31-52c3fb5d16d3", null, "Administrator", null },
                    { "1dbe60e0-9802-42e9-a952-18bda1c61d89", null, "Technician", null },
                    { "36812fae-6dfa-4b45-b06c-54c6053332f6", null, "ServiceManager", null },
                    { "72e8e07b-75e4-40e6-a9e9-13b3414c6b32", null, "Executive", null },
                    { "811865b7-2384-47ea-8b46-59a2553924aa", null, "ITSupport", null }
                });
        }
    }
}
