using OrderService.rabbitmq_message;
using System;

namespace OrderService.rabbitmq_saga.StateMachine
{
    public class OrderValidateEvent : IOrderValidateEvent
    {
        private readonly OrderStateData orderSagaState;
        public OrderValidateEvent(OrderStateData orderStateData)
        {
            this.orderSagaState = orderStateData;
        }

        public Guid Id => orderSagaState.Id;
        public int CustomerId => orderSagaState.CustomerId;
        public int Quantity => orderSagaState.Quantity;
        public int Stock => orderSagaState.Stock;
        public string Status => orderSagaState.Status;
    }
}
