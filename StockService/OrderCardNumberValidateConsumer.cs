using MassTransit;
using OrderService.rabbitmq_message;
using System.Threading.Tasks;

namespace StockService
{
    public class OrderCardNumberValidateConsumer :
       IConsumer<IOrderMessage>
    {
        public async Task Consume(ConsumeContext<IOrderMessage> context)
        {
            var data = context.Message;
        }
    }
}
