using Automatonymous;
using OrderService.rabbitmq_message;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderService.rabbitmq_saga.StateMachine
{
    public class OrderStateMachine :
       MassTransitStateMachine<OrderStateData>
    {
        public OrderStateMachine()
        {
            Event(() => OrderStartedEvent, x => x.CorrelateById(m => m.Message.Id));

            Event(() => OrderCancelledEvent, x => x.CorrelateById(m => m.Message.Id));

            InstanceState(x => x.CurrentState);

            Initially(
               When(OrderStartedEvent)
                .Then(context =>
                {
                    context.Instance.OrderCreationDateTime = DateTime.Now;
                    context.Instance.Id = context.Data.Id;
                    context.Instance.CustomerId = context.Data.CustomerId;
                    context.Instance.Quantity = context.Data.Quantity;
                    context.Instance.Stock = context.Data.Stock;
                    context.Instance.Status = context.Data.Status;
                })
               .TransitionTo(OrderStarted)
               .Publish(context => new OrderValidateEvent(context.Instance)));

            During(OrderStarted,
                When(OrderCancelledEvent)
                    .Then(context => context.Instance.OrderCancelDateTime =
                        DateTime.Now)
                     .TransitionTo(OrderCancelled)

              );
        }

        public State OrderStarted { get; private set; }
        public State OrderCancelled { get; private set; }
        public Event<IOrderStartedEvent> OrderStartedEvent { get; private set; }
        public Event<IOrderCancelEvent> OrderCancelledEvent { get; private set; }
    }
}
