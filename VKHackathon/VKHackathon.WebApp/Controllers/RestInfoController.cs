using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Models;
using Models.Requests;
using Models.Responses;

namespace VKHackathon.WebApp.Controllers
{
    [Route("RestInfo")]
    public class RestInfoController : Controller
    {
        private readonly AppDbContext dbContext;

        public RestInfoController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost("New")] //BusinessAPI
        public async Task<IActionResult> PostRest([FromBody] PostRestInfo request)
        {
            Restaurant restaurant = new Restaurant()
            {
                Name = request.Name,
                Address = request.Address,
                Rate = request.Rate
            };

            await dbContext.Restaurants.AddAsync(restaurant);
            await dbContext.SaveChangesAsync();

            return Json(restaurant.RestaurantId);
        }

        [HttpPost("NewCenter")] //BusinessAPI
        public async Task<IActionResult> PostShoppingCenter([FromBody] PostShoppingCenter request)
        {
            ShoppingCenter center = new ShoppingCenter()
            {
                Name = request.Name,
                Address = request.Address
            };

            await dbContext.ShoppingCenters.AddAsync(center);
            await dbContext.SaveChangesAsync();

            return Json(center.ShoppingCenterId);
        }

        [HttpPost("AddToCenter")] //BusinessAPI
        public async Task<IActionResult> AddRestToCenter([FromBody] AddRestToCenter request)
        {
            var center = await dbContext.ShoppingCenters.FindAsync(request.ShoppingCenterId);
            var restaurant = await dbContext.Restaurants.FindAsync(request.RestaurantId);

            if (center.Restaurants == null)
            {
                center.Restaurants = new List<Restaurant>();
                center.Restaurants.Add(restaurant);
            }
            else
            {
                center.Restaurants.Add(restaurant);
            }

            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("GetRestaurants/{page}")]
        public IActionResult GetRestaurants(int page)
        {
            
            var restaurants = dbContext
                .Restaurants
                .OrderByDescending(r => r.Rate)
                .Skip(page * 10)
                .Take(10)
                .ToList()
                .Distinct((x, y) => x.Name == y.Name)
                .Select(r => new GetRestaurantsInfo
                {
                    RestaurantId = r.RestaurantId,
                    Name = r.Name,
                    Rate = r.Rate
                });

            return Json(restaurants);
        }

        [HttpGet("menu/{restaurantId}")]
        public IActionResult GetMenu(Guid restaurantId)
        {
            var menu = dbContext
                .FoodMenus
                .FirstOrDefault(r => r.RestaurantId == restaurantId)
                .MenuItems
                .Select(r => new GetMenu()
                {
                    MenuItemId = r.MenuItemId,
                    ItemName = r.ItemName,
                    Price = r.Price,
                    Describe = r.Describe,
                    Image = r.Image
                });

            return Json(menu);
        }

        [HttpGet("GetInfo/{name}")]
        public IActionResult GetRestaurants(string name)
        {
            return Json(dbContext
                .Restaurants
                .Where(r => r.Name == name)
                .Select(x => new
                {
                    x.Name,
                    x.Address
                }));
        }
    }
}