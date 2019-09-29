using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Requests;

namespace VKHackathon.WebApp.Controllers
{
    [Route("Menu")]
    public class MenuController : Controller
    {
        private readonly AppDbContext dbContext;

        public MenuController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost("AddFoodMenu")] //BusinessAPI
        public async Task<IActionResult> AddFoodMenu([FromBody] Guid restaurantId)
        {
            FoodMenu foodMenu = new FoodMenu()
            {
                RestaurantId = restaurantId,
                MenuItems = new List<MenuItem>()
            };

            await dbContext.FoodMenus.AddAsync(foodMenu);
            await dbContext.SaveChangesAsync();

            return Json(foodMenu.FoodMenuId);
        }

        [HttpPost("AddMenuItem")] //BusinessAPI
        public async Task<IActionResult> AddItemToMenu([FromBody] AddItemToMenu request)
        {
            var menu = await dbContext.FoodMenus.FindAsync(request.RestaurantId);

            MenuItem menuItem = new MenuItem()
            {
                Describe = request.Describe,
                Image = request.Image,
                ItemName = request.ItemName,
                Price = request.Price,
                FoodMenu = menu
            };

            menu.MenuItems.Add(menuItem);
            await dbContext.MenuItems.AddAsync(menuItem);
            await dbContext.SaveChangesAsync();

            return Ok(menuItem.MenuItemId);
        }
    }
}