using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bank_Api.Migrations
{
    /// <inheritdoc />
    public partial class rolesupdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "Role" },
                values: new object[] { "2fca49f9-dd33-439e-b56b-3cfe7d73d587", "staff" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "Role" },
                values: new object[] { "c0796d8f-c317-40ab-b8c0-96082468f921", "customer" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "Role" },
                values: new object[] { "14693499-9305-4049-bc7f-f4a08e83c961", "employee" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "Role" },
                values: new object[] { "8bf85755-fe3e-43ef-860b-323958e4a218", "employee" });
        }
    }
}
