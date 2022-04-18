using System;

namespace OrderService.rabbitmq_message
{
    public class IOrderMessage
    {
        public Guid Id { get; set; }
        public int CustomerId { get; set; }
        public int Quantity { get; set; }
        public int Stock { get; set; }
        public string Status { get; set; }
    }
}
