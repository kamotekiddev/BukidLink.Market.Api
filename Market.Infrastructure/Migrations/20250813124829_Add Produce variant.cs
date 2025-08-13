using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Market.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddProducevariant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Produce");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateExpired",
                table: "Inventory",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ProduceVariants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProduceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    UnitOfMeasure = table.Column<int>(type: "integer", nullable: false),
                    UniSize = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProduceVariants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProduceVariants_Produce_ProduceId",
                        column: x => x.ProduceId,
                        principalTable: "Produce",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProduceVariants_ProduceId",
                table: "ProduceVariants",
                column: "ProduceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProduceVariants");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Produce",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateExpired",
                table: "Inventory",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");
        }
    }
}
