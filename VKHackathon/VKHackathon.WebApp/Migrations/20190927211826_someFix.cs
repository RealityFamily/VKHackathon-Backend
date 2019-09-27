using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VKHackathon.WebApp.Migrations
{
    public partial class someFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RestaurantId",
                table: "FoodMenus",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "ShoppingCenter",
                columns: table => new
                {
                    ShoppingCenterId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCenter", x => x.ShoppingCenterId);
                });

            migrationBuilder.CreateTable(
                name: "Restaurant",
                columns: table => new
                {
                    RestaurantId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    ShoppingCenterCenterShoppingCenterId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurant", x => x.RestaurantId);
                    table.ForeignKey(
                        name: "FK_Restaurant_ShoppingCenter_ShoppingCenterCenterShoppingCente~",
                        column: x => x.ShoppingCenterCenterShoppingCenterId,
                        principalTable: "ShoppingCenter",
                        principalColumn: "ShoppingCenterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodMenus_RestaurantId",
                table: "FoodMenus",
                column: "RestaurantId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_ShoppingCenterCenterShoppingCenterId",
                table: "Restaurant",
                column: "ShoppingCenterCenterShoppingCenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodMenus_Restaurant_RestaurantId",
                table: "FoodMenus",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "RestaurantId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodMenus_Restaurant_RestaurantId",
                table: "FoodMenus");

            migrationBuilder.DropTable(
                name: "Restaurant");

            migrationBuilder.DropTable(
                name: "ShoppingCenter");

            migrationBuilder.DropIndex(
                name: "IX_FoodMenus_RestaurantId",
                table: "FoodMenus");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "FoodMenus");
        }
    }
}
