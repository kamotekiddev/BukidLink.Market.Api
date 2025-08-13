using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Market.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddProduceInventory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Inventory",
                newName: "Sku");

            migrationBuilder.AddColumn<int>(
                name: "BatchNumber",
                table: "Inventory",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateExpired",
                table: "Inventory",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateReceived",
                table: "Inventory",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BatchNumber",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "DateExpired",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "DateReceived",
                table: "Inventory");

            migrationBuilder.RenameColumn(
                name: "Sku",
                table: "Inventory",
                newName: "Name");
        }
    }
}
