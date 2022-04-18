using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.Business;
using OrderService.Models;
using OrderService.rabbitmq_message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ISendEndpointProvider _sendEndpointProvider;
        private readonly IOrderService _orderService;

        public OrderController(
          ISendEndpointProvider sendEndpointProvider,
          IOrderService orderService)
        {
            _sendEndpointProvider = sendEndpointProvider;
            _orderService = orderService;
        }
                 
        [HttpPost]
        [Route("createorderstatemachine")]
        public async Task<IActionResult> CreateOrderUsingStateMachine([FromBody] Order orderModel)
        {
            var endpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("queue:" + BusConstants.SagaBusQueue));

            _orderService.SaveOrder(orderModel);

            await endpoint.Send<IOrderStartedEvent>(new
            {
                Id = orderModel.Id,
                CustomerId = orderModel.CustomerId,
                Quantity = orderModel.Quantity,
                Stock = orderModel.Stock,
                Status = orderModel.Status
            });

            return Ok("Success");
        }
    }
}
