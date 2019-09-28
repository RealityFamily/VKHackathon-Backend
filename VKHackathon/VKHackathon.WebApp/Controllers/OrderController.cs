using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VKHackathon.WebApp.Services.Interfaces;

namespace VKHackathon.WebApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly AppDbContext dbContext;
        private readonly IOrderQueue orderQueue;
        public OrderController(AppDbContext dbContext, IOrderQueue orderQueue)
        {
            this.dbContext = dbContext;
            this.orderQueue = orderQueue;
        }








    }
}