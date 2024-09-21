using MassTransit;
using Shared.Events;

namespace Payment.API.Consumers
{
    public class StockReservedEventConsumer(IPublishEndpoint _publishEndpoint) : IConsumer<StockReservedEvent>
    {
        public async Task Consume(ConsumeContext<StockReservedEvent> context)
        {
            if (true)
            {
                PaymentCompletedEvent paymentCompletedEvent = new PaymentCompletedEvent()
                {
                    OrderId = context.Message.OrderId,
                };

                await _publishEndpoint.Publish(paymentCompletedEvent);

                await Console.Out.WriteLineAsync("Payment is succceeded...");
            }
            else
            {
                PaymentFailedEvent paymentFailedEvent = new PaymentFailedEvent()
                {
                    OrderId = context.Message.OrderId,
                    OrderItems = context.Message.OrderItems,
                    Message = "Payment is failed!"
                };

                await _publishEndpoint.Publish(paymentFailedEvent);

                await Console.Out.WriteLineAsync("Payment is failed...");
            }
        }
    }
}
