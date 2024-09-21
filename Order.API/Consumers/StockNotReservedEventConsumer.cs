﻿using MassTransit;
using Order.API.Models.Contexts;
using Shared.Events;

namespace Order.API.Consumers
{
    public class StockNotReservedEventConsumer(OrderApiDbContext _context) : IConsumer<StockNotReservedEvent>
    {
        public async Task Consume(ConsumeContext<StockNotReservedEvent> context)
        {
            var order = await _context.Orders.FindAsync(context.Message.OrderId);

            if (order == null)
            {
                throw new Exception("Order is null");
            }

            order.OrderStatus = Enums.OrderStatus.Fail;

            await _context.SaveChangesAsync();
        }
    }
}
