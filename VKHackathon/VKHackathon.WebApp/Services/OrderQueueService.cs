using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VKHackathon.WebApp.Services.Interfaces;

namespace VKHackathon.WebApp.Services
{
    public class OrderQueueService : IOrderQueue
    {
        private readonly List<Order> orders = new List<Order>();

        public void ChangeStatus(Guid OrderId, OrderStatus status) =>
            orders.Find(x => x.OrderId == OrderId).Status = status;


        public Order Dequeue(Guid OrderId)
        {
            var order = orders.FirstOrDefault(x => x.OrderId == OrderId);
            orders.Remove(order);
            return order;
        }

        public List<Order> FindAll(Guid restaurantId)
        {
            return orders.FindAll(r => r.RestaurantId == restaurantId);
        }

        public Order FindOrder(Guid orderId)
        {
            return orders.FirstOrDefault(x => x.OrderId == orderId);
        }

        public void PutInQueue(Order order) =>
            orders.Add(order);
    }
}
