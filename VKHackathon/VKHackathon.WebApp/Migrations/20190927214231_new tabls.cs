using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VKHackathon.WebApp.Migrations
{
    public partial class newtabls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodMenus_Restaurant_RestaurantId",
                table: "FoodMenus");

            migrationBuilder.DropForeignKey(
                name: "FK_Restaurant_ShoppingCenter_ShoppingCenterCenterShoppingCente~",
                table: "Restaurant");

            migrationBuilder.DropTable(
                name: "History");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCenter",
                table: "ShoppingCenter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Restaurant",
                table: "Restaurant");

            migrationBuilder.RenameTable(
                name: "ShoppingCenter",
                newName: "ShoppingCenters");

            migrationBuilder.RenameTable(
                name: "Restaurant",
                newName: "Restaurants");

            migrationBuilder.RenameIndex(
                name: "IX_Restaurant_ShoppingCenterCenterShoppingCenterId",
                table: "Restaurants",
                newName: "IX_Restaurants_ShoppingCenterCenterShoppingCenterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCenters",
                table: "ShoppingCenters",
                column: "ShoppingCenterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Restaurants",
                table: "Restaurants",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodMenus_Restaurants_RestaurantId",
                table: "FoodMenus",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "RestaurantId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_ShoppingCenters_ShoppingCenterCenterShoppingCen~",
                table: "Restaurants",
                column: "ShoppingCenterCenterShoppingCenterId",
                principalTable: "ShoppingCenters",
                principalColumn: "ShoppingCenterId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodMenus_Restaurants_RestaurantId",
                table: "FoodMenus");

            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_ShoppingCenters_ShoppingCenterCenterShoppingCen~",
                table: "Restaurants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCenters",
                table: "ShoppingCenters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Restaurants",
                table: "Restaurants");

            migrationBuilder.RenameTable(
                name: "ShoppingCenters",
                newName: "ShoppingCenter");

            migrationBuilder.RenameTable(
                name: "Restaurants",
                newName: "Restaurant");

            migrationBuilder.RenameIndex(
                name: "IX_Restaurants_ShoppingCenterCenterShoppingCenterId",
                table: "Restaurant",
                newName: "IX_Restaurant_ShoppingCenterCenterShoppingCenterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCenter",
                table: "ShoppingCenter",
                column: "ShoppingCenterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Restaurant",
                table: "Restaurant",
                column: "RestaurantId");

            migrationBuilder.CreateTable(
                name: "History",
                columns: table => new
                {
                    PurchaseHistoryId = table.Column<Guid>(nullable: false),
                    ClientId = table.Column<Guid>(nullable: true),
                    OrderId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_History", x => x.PurchaseHistoryId);
                    table.ForeignKey(
                        name: "FK_History_AspNetUsers_ClientId",
                        column: x => x.ClientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_History_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_History_ClientId",
                table: "History",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_History_OrderId",
                table: "History",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodMenus_Restaurant_RestaurantId",
                table: "FoodMenus",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "RestaurantId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurant_ShoppingCenter_ShoppingCenterCenterShoppingCente~",
                table: "Restaurant",
                column: "ShoppingCenterCenterShoppingCenterId",
                principalTable: "ShoppingCenter",
                principalColumn: "ShoppingCenterId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
