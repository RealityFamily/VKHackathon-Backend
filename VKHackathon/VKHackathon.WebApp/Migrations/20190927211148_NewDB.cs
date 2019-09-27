using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VKHackathon.WebApp.Migrations
{
    public partial class NewDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PurchasehistoryId",
                table: "History",
                newName: "PurchaseHistoryId");

            migrationBuilder.AddColumn<string>(
                name: "Describe",
                table: "MenuItems",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FoodMenuId",
                table: "MenuItems",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "MenuItems",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItemName",
                table: "MenuItems",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "MenuItems",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<Guid>(
                name: "ClientId",
                table: "History",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "History",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_FoodMenuId",
                table: "MenuItems",
                column: "FoodMenuId");

            migrationBuilder.CreateIndex(
                name: "IX_History_ClientId",
                table: "History",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_History_OrderId",
                table: "History",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_History_AspNetUsers_ClientId",
                table: "History",
                column: "ClientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_History_Orders_OrderId",
                table: "History",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItems_FoodMenus_FoodMenuId",
                table: "MenuItems",
                column: "FoodMenuId",
                principalTable: "FoodMenus",
                principalColumn: "FoodMenuId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_History_AspNetUsers_ClientId",
                table: "History");

            migrationBuilder.DropForeignKey(
                name: "FK_History_Orders_OrderId",
                table: "History");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_FoodMenus_FoodMenuId",
                table: "MenuItems");

            migrationBuilder.DropIndex(
                name: "IX_MenuItems_FoodMenuId",
                table: "MenuItems");

            migrationBuilder.DropIndex(
                name: "IX_History_ClientId",
                table: "History");

            migrationBuilder.DropIndex(
                name: "IX_History_OrderId",
                table: "History");

            migrationBuilder.DropColumn(
                name: "Describe",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "FoodMenuId",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "ItemName",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "History");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "History");

            migrationBuilder.RenameColumn(
                name: "PurchaseHistoryId",
                table: "History",
                newName: "PurchasehistoryId");
        }
    }
}
