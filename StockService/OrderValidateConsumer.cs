using MassTransit;
using OrderService.rabbitmq_message;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace StockService
{
    public class OrderValidateConsumer :
      IConsumer<ICardValidatorEvent>
    {
        public async Task Consume(ConsumeContext<ICardValidatorEvent> context)
        {
            var data = context.Message;

            if (data.Stock < data.Quantity)
            {
                await context.Publish<IOrderCancelEvent>(
          new { Id = context.Message.Id, Stock = context.Message.Stock });
            }
            else
            {
                // send to next microservice
            }
        }
    }
}
