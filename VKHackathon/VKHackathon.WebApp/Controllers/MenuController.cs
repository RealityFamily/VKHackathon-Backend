using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Requests;

namespace VKHackathon.WebApp.Controllers
{
    [Route("Menu")]
    public class MenuController : Controller
    {
        private readonly AppDbContext dbContext;
        private readonly IHostingEnvironment env;

        public MenuController(AppDbContext dbContext, IHostingEnvironment env)
        {
            this.dbContext = dbContext;
            this.env = env;
        }

        [HttpPost("AddFoodMenu/{name}")] //BusinessAPI
        public async Task<IActionResult> AddFoodMenu(string name)
        {
            if (name == "mcdonalds")
            {
                name = "Макдоналдс";
            }
            var rest = dbContext.Restaurants.Where(x => x.Name == name).ToList();

            FoodMenu foodMenu = new FoodMenu()
            {
                Restaurants = rest,
                MenuItems = new List<MenuItem>()
            };

            await dbContext.FoodMenus.AddAsync(foodMenu);
            await dbContext.SaveChangesAsync();

            return Json(foodMenu.FoodMenuId);
        }

        [HttpPost("AddMenuItem")] //BusinessAPI
        public async Task<IActionResult> AddItemToMenu([FromBody] AddItemToMenu request)
        {
            var menu = dbContext.FoodMenus.Include(x => x.MenuItems).FirstOrDefault(v => v.FoodMenuId == request.MenuId);
            
            MenuItem menuItem = new MenuItem()
            {
                Describe = request.Describe,
                ImagePath = Path.Combine($"{request.ItemName}.png"),
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