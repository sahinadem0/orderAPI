using MassTransit;
using OrderService.Business;
using OrderService.rabbitmq_message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService
{
    public class CancelOrderConsumer : IConsumer<IOrderCancelEvent>
    {
        private readonly IOrderService _orderService;

        public CancelOrderConsumer(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task Consume(ConsumeContext<IOrderCancelEvent> context)
        {
            var data = context.Message;

            // delete from order database
            _orderService.DeleteOrder(data.Id);
        }
    }
}
