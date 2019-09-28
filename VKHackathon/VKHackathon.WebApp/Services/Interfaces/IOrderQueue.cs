using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VKHackathon.WebApp.Services.Interfaces
{
    public interface IOrderQueue
    {
        void PutInQueue(Order order);
        void ChangeStatus(Guid OrderId, OrderStatus status);
        Order Dequeue(Guid OrderId);
        Order FindOrder(Guid orderId);
        List<Order> FindAll(Guid restaurantId);
    }
}
