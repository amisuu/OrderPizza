using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RelevantPizza.Migrations
{
    public partial class AddInventoryItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItemDetails");

            migrationBuilder.AddColumn<int>(
                name: "OrderID",
                table: "OrderItems",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DriverOut",
                table: "Order",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DriverIn",
                table: "Order",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Customer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "InventoryItems",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    QuantityRemaining = table.Column<int>(nullable: false),
                    PricePerUnit = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryItems", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderID",
                table: "OrderItems",
                column: "OrderID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Order_OrderID",
                table: "OrderItems",
                column: "OrderID",
                principalTable: "Order",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Order_OrderID",
                table: "OrderItems");

            migrationBuilder.DropTable(
                name: "InventoryItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_OrderID",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "OrderID",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Customer");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DriverOut",
                table: "Order",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DriverIn",
                table: "Order",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "OrderItemDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItemDetails", x => x.ID);
                });
        }
    }
}
