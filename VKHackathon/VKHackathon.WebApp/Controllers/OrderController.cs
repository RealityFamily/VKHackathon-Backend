using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Requests;
using VKHackathon.WebApp.Services;
using VKHackathon.WebApp.Services.Interfaces;

namespace VKHackathon.WebApp.Controllers
{
    [Route("Order")]
    public class OrderController : Controller
    {
        private readonly AppDbContext dbContext;
        private readonly IOrderQueue orderQueue;
        private readonly ICodeGenerator codeGenerator;

        public OrderController(AppDbContext dbContext,
            IOrderQueue orderQueue,
            ICodeGenerator codeGenerator)
        {
            this.dbContext = dbContext;
            this.orderQueue = orderQueue;
            this.codeGenerator = codeGenerator;
        }

        [HttpPost("New")]
        public async Task<IActionResult> OrderAdd([FromBody] OrderAdd request)
        {
            var restaurant = await dbContext.Restaurants.FindAsync(request.RestaurantId);
            var client = await dbContext.Clients.FindAsync(request.ClientId);
            List<MenuItem> items = new List<MenuItem>();
            float sum = 0f;

            foreach (var itemId in request.Items)
            {
                var res = dbContext.MenuItems.FirstOrDefault(x => x.MenuItemId == itemId);
                sum += res.Price;
                items.Add(res);
            }

            Order order = new Order()
            {
                Client = client,
                Restaurant = restaurant,
                MenuItems = items,
                Price = sum,
                Time = DateTime.Now,
                Status = OrderStatus.Pending
            };

            orderQueue.PutInQueue(order);

            return Ok(order.OrderId);
        }

        [HttpDelete("Delete/{orderId}")]
        public IActionResult DeleteOrder(Guid orderId)
        {
            if (DateTime.Now.Subtract(orderQueue.FindOrder(orderId).Time) < TimeSpan.FromMinutes(20))
            {
                orderQueue.Dequeue(orderId);
            }

            return Ok();
        }

        [HttpGet("CheckStatus/{orderId}")]
        public IActionResult CheckOrderStatus(Guid orderId)
        {
            if (orderQueue.FindOrder(orderId).Status == OrderStatus.Ready)
            {
                return Json(new
                {
                    Status = orderQueue.FindOrder(orderId).Status.ToString(),
                    Code = codeGenerator.CodeGenerate(orderId)
                });
            }
            else
            {
                return Json(orderQueue
                    .FindOrder(orderId)
                    .Status
                    .ToString());
            }
        }

        [HttpPut("ChangeStatus")]
        public IActionResult ChangeStatus([FromBody] StatusChange request)
        {
            switch (request.Status)
            {
                case "Accepted":
                    {
                        orderQueue.FindOrder(request.OrderId).Status = OrderStatus.Accepted;
                        break;
                    }
                case "Declined":
                    {
                        orderQueue.FindOrder(request.OrderId).Status = OrderStatus.Declined;
                        break;
                    }
                case " InProgress":
                    {
                        orderQueue.FindOrder(request.OrderId).Status = OrderStatus.InProgress;
                        break;
                    }
                case "Ready":
                    {
                        orderQueue.FindOrder(request.OrderId).Status = OrderStatus.Ready;
                        break;
                    }
                default:
                    {
                        break;
                    }

            }
            return Ok();
        }

        [HttpGet("{restaurantId}")]
        public IActionResult GetOrders(Guid restaurantId)
        {
            return Json(orderQueue
                .FindAll(restaurantId)
                .Where(st => st.Status == OrderStatus.Pending)
                .Select(o => new
                {
                    o.MenuItems,
                    o.Price,
                    o.Time
            }));
        }

        [HttpPost("Issue")]
        public async Task<IActionResult> IssueOfOrder([FromBody] IssueOrder request)
        {
            Order order;

            if (((CodeGeneratorService)codeGenerator).OrderCodeDic[request.OrderId] == request.Code)
            {
                order = orderQueue.Dequeue(request.OrderId);
                order.Status = OrderStatus.Issued;

                await dbContext.Orders.AddAsync(order);
                await dbContext.SaveChangesAsync();
                return Ok();
            }

            return BadRequest();
        }

        [HttpGet("History/{clientId}")]
        public IActionResult GetOrderHistory(Guid clientId)
        {
            return Json(dbContext
                .Orders
                .Where(c => c.ClientId == clientId)
                .Select(o => new 
                {
                    o.Restaurant,
                    o.MenuItems,
                    o.Price,
                    o.Time
                }));
        }
    }
}