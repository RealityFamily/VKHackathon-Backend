using Microsoft.EntityFrameworkCore.Migrations;

namespace VKHackathon.WebApp.Migrations
{
    public partial class fixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_ShoppingCenters_ShoppingCenterCenterShoppingCen~",
                table: "Restaurants");

            migrationBuilder.RenameColumn(
                name: "ShoppingCenterCenterShoppingCenterId",
                table: "Restaurants",
                newName: "ShoppingCenterId");

            migrationBuilder.RenameIndex(
                name: "IX_Restaurants_ShoppingCenterCenterShoppingCenterId",
                table: "Restaurants",
                newName: "IX_Restaurants_ShoppingCenterId");

            migrationBuilder.AddColumn<float>(
                name: "Rate",
                table: "Restaurants",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_ShoppingCenters_ShoppingCenterId",
                table: "Restaurants",
                column: "ShoppingCenterId",
                principalTable: "ShoppingCenters",
                principalColumn: "ShoppingCenterId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_ShoppingCenters_ShoppingCenterId",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "Rate",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "ShoppingCenterId",
                table: "Restaurants",
                newName: "ShoppingCenterCenterShoppingCenterId");

            migrationBuilder.RenameIndex(
                name: "IX_Restaurants_ShoppingCenterId",
                table: "Restaurants",
                newName: "IX_Restaurants_ShoppingCenterCenterShoppingCenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_ShoppingCenters_ShoppingCenterCenterShoppingCen~",
                table: "Restaurants",
                column: "ShoppingCenterCenterShoppingCenterId",
                principalTable: "ShoppingCenters",
                principalColumn: "ShoppingCenterId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
