using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bank_Api.Migrations
{
    /// <inheritdoc />
    public partial class addpasswwordHash : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "Password" },
                values: new object[] { "c52a6cfb-5ce2-40c9-931b-18b14d59c4d1", "AQAAAAIAAYagAAAAEHKYakvN8FuknKOR+jafqOKC/2O1hCcJ8purvOfMZge3Y8nB42gERg+qStEHkPTgpw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "Password" },
                values: new object[] { "f8043af3-9a2c-404f-9411-70fe88f479c9", "AQAAAAIAAYagAAAAEKjwffDuLIppwH2wfXmGzlfSAmK+z6s2/YIPriDixsP5Zr0OcXrKO0s/glKe2XNprw==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "Password" },
                values: new object[] { "8fb6bb40-97ad-4969-95c2-f810bf5932c6", "password" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "Password" },
                values: new object[] { "fc085224-b482-44ae-8abf-5912a59f6a85", "password" });
        }
    }
}
