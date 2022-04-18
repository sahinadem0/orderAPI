using System;
using System.Collections.Generic;
using System.Text;

namespace OrderService.rabbitmq_message
{
    public interface IOrderCancelEvent
    {
        public Guid Id { get; }
        public int CustomerId { get;}
        public int Quantity { get;}
        public int Stock { get;}
        public string Status { get; }
    }
}
