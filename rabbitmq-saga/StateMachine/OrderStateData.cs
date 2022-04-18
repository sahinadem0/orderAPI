using Automatonymous;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderService.rabbitmq_saga.StateMachine
{
    public class OrderStateData : SagaStateMachineInstance
    {
        public Guid CorrelationId { get; set; }
        public string CurrentState { get; set; }
        public DateTime? OrderCreationDateTime { get; set; }
        public DateTime? OrderCancelDateTime { get; set; }
        public Guid Id { get; set; }
        public int CustomerId { get; set; }
        public int Quantity { get; set; }
        public int Stock { get; set; }
        public string Status { get; set; }
    }
}
