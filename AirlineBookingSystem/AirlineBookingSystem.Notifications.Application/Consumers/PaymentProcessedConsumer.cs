using AirlineBookingSystem.BuildingBlocks.Contracts.EvenBus.Messages;
using AirlineBookingSystem.Notifications.Application.Commands;
using MassTransit;
using MassTransit.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingSystem.Notifications.Application.Consumers
{
    public class PaymentProcessedConsumer : IConsumer<PaymentProcessedEvent>
    {
        private readonly IMediator _mediator;

        public PaymentProcessedConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<PaymentProcessedEvent> context)
        {
            var paymentProcessedEvent = context.Message;
            var message = $"Payment of ${paymentProcessedEvent.Amount} for Booking Id: {paymentProcessedEvent.BookingId} was Processed successfully.";
            var command = new SendNotificationCommand("someone@ss.com", message, "Email");
            await _mediator.Send(command);
        }
    }
}
