using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeautySuitePro.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Refunds");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Refunds");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Refunds",
                newName: "ProcessedAt");

            migrationBuilder.AddColumn<string>(
                name: "Method",
                table: "Refunds",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProcessedByName",
                table: "Refunds",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProcessingNotes",
                table: "Refunds",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Reason",
                table: "Refunds",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "RequestedAt",
                table: "Refunds",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "RequestedByName",
                table: "Refunds",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Method",
                table: "Refunds");

            migrationBuilder.DropColumn(
                name: "ProcessedByName",
                table: "Refunds");

            migrationBuilder.DropColumn(
                name: "ProcessingNotes",
                table: "Refunds");

            migrationBuilder.DropColumn(
                name: "Reason",
                table: "Refunds");

            migrationBuilder.DropColumn(
                name: "RequestedAt",
                table: "Refunds");

            migrationBuilder.DropColumn(
                name: "RequestedByName",
                table: "Refunds");

            migrationBuilder.RenameColumn(
                name: "ProcessedAt",
                table: "Refunds",
                newName: "UpdatedAt");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Refunds",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Refunds",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
