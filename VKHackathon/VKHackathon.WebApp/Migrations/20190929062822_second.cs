using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VKHackathon.WebApp.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_FoodMenus_FoodMenuId",
                table: "Restaurants");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_FoodMenuId",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "FoodMenuId",
                table: "Restaurants");

            migrationBuilder.AddColumn<Guid>(
                name: "MenuFoodMenuId",
                table: "Restaurants",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_MenuFoodMenuId",
                table: "Restaurants",
                column: "MenuFoodMenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_FoodMenus_MenuFoodMenuId",
                table: "Restaurants",
                column: "MenuFoodMenuId",
                principalTable: "FoodMenus",
                principalColumn: "FoodMenuId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_FoodMenus_MenuFoodMenuId",
                table: "Restaurants");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_MenuFoodMenuId",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "MenuFoodMenuId",
                table: "Restaurants");

            migrationBuilder.AddColumn<Guid>(
                name: "FoodMenuId",
                table: "Restaurants",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_FoodMenuId",
                table: "Restaurants",
                column: "FoodMenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_FoodMenus_FoodMenuId",
                table: "Restaurants",
                column: "FoodMenuId",
                principalTable: "FoodMenus",
                principalColumn: "FoodMenuId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
