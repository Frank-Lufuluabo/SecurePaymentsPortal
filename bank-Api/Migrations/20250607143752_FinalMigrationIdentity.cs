using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bank_Api.Migrations
{
    /// <inheritdoc />
    public partial class FinalMigrationIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "Staff",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "Staff",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "Staff",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "Staff",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "Staff",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "Staff",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "Staff",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Staff",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Staff",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "Staff",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "Staff",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "Staff",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Staff",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "Customers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "Customers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "Customers",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "Customers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "Customers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "Customers");
        }
    }
}
