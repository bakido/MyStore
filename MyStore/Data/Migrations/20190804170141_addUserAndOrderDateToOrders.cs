using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyStore.Data.Migrations
{
    public partial class addUserAndOrderDateToOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "OrderDate",
                table: "order",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "userIdId",
                table: "order",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_order_userIdId",
                table: "order",
                column: "userIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_order_AspNetUsers_userIdId",
                table: "order",
                column: "userIdId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_order_AspNetUsers_userIdId",
                table: "order");

            migrationBuilder.DropIndex(
                name: "IX_order_userIdId",
                table: "order");

            migrationBuilder.DropColumn(
                name: "OrderDate",
                table: "order");

            migrationBuilder.DropColumn(
                name: "userIdId",
                table: "order");
        }
    }
}
