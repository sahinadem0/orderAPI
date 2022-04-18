using System;

namespace OrderService.rabbitmq_message
{
    public interface IStartOrder
    {
        public Guid Id { get; }
        public int CustomerId { get; }
        public int Quantity { get;}
        public int Stock { get;}
        public string Status { get; }
    }
}
