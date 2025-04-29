using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bank_Api.Migrations
{
    /// <inheritdoc />
    public partial class CustomerTableWithAuth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAuthenticated",
                table: "Customers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAuthenticated",
                table: "Customers");
        }
    }
}
