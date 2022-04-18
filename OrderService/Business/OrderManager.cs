using OrderService.Core;
using OrderService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Business
{
    public class OrderManager:IOrderService
    {
        private readonly IRepository<Order> _orderRepository;


        public OrderManager(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void DeleteOrder(Guid orderId)
        {
            var order = _orderRepository.Get(o => o.Id == orderId);
            _orderRepository.Delete(order);
        }

        public void  SaveOrder(Order order)
        {
            var orderDb =  _orderRepository.AddAsync(order);

        }
    }
}
