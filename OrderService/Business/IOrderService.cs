using OrderService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Business
{
    public interface IOrderService
    {
        //List<Order> GetAllOrder();

        void SaveOrder(Order order);
        //Order GetOrder(Guid orderId);
        void DeleteOrder(Guid orderId);
    }
}
