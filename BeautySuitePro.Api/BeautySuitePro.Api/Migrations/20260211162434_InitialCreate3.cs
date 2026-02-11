using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeautySuitePro.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Refunds_Users_ProcessedBy",
                table: "Refunds");

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

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Refunds",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Refunds_Users_ProcessedBy",
                table: "Refunds",
                column: "ProcessedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Refunds_Users_ProcessedBy",
                table: "Refunds");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Refunds");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Refunds");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Refunds");

            migrationBuilder.AddForeignKey(
                name: "FK_Refunds_Users_ProcessedBy",
                table: "Refunds",
                column: "ProcessedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
