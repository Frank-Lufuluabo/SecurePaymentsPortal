using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bank_Api.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedTransactionsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SwiftCode",
                table: "Transactions",
                newName: "swiftCode");

            migrationBuilder.RenameColumn(
                name: "Reference",
                table: "Transactions",
                newName: "reference");

            migrationBuilder.RenameColumn(
                name: "RecipientName",
                table: "Transactions",
                newName: "recipientName");

            migrationBuilder.RenameColumn(
                name: "RecipientAccount",
                table: "Transactions",
                newName: "recipientAccount");

            migrationBuilder.RenameColumn(
                name: "CustomerName",
                table: "Transactions",
                newName: "customerName");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Transactions",
                newName: "customerId");

            migrationBuilder.RenameColumn(
                name: "Currency",
                table: "Transactions",
                newName: "currency");

            migrationBuilder.RenameColumn(
                name: "BankName",
                table: "Transactions",
                newName: "bankName");

            migrationBuilder.RenameColumn(
                name: "BankAddress",
                table: "Transactions",
                newName: "bankAddress");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Transactions",
                newName: "amount");

            migrationBuilder.RenameColumn(
                name: "AccountNumber",
                table: "Transactions",
                newName: "accountNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "swiftCode",
                table: "Transactions",
                newName: "SwiftCode");

            migrationBuilder.RenameColumn(
                name: "reference",
                table: "Transactions",
                newName: "Reference");

            migrationBuilder.RenameColumn(
                name: "recipientName",
                table: "Transactions",
                newName: "RecipientName");

            migrationBuilder.RenameColumn(
                name: "recipientAccount",
                table: "Transactions",
                newName: "RecipientAccount");

            migrationBuilder.RenameColumn(
                name: "customerName",
                table: "Transactions",
                newName: "CustomerName");

            migrationBuilder.RenameColumn(
                name: "customerId",
                table: "Transactions",
                newName: "CustomerId");

            migrationBuilder.RenameColumn(
                name: "currency",
                table: "Transactions",
                newName: "Currency");

            migrationBuilder.RenameColumn(
                name: "bankName",
                table: "Transactions",
                newName: "BankName");

            migrationBuilder.RenameColumn(
                name: "bankAddress",
                table: "Transactions",
                newName: "BankAddress");

            migrationBuilder.RenameColumn(
                name: "amount",
                table: "Transactions",
                newName: "Amount");

            migrationBuilder.RenameColumn(
                name: "accountNumber",
                table: "Transactions",
                newName: "AccountNumber");
        }
    }
}
