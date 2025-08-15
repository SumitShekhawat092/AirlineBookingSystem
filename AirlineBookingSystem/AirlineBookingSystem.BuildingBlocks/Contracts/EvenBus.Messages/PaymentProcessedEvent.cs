using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingSystem.BuildingBlocks.Contracts.EvenBus.Messages
{
    public record PaymentProcessedEvent(Guid PaymentId, Guid BookingId, decimal Amount, DateTime PaymentDate);
}
