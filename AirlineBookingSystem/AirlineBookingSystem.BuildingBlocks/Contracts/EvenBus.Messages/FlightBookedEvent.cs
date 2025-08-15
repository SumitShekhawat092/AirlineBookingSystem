using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingSystem.BuildingBlocks.Contracts.EvenBus.Messages
{
    public record FlightBookedEvent(Guid BookingId, Guid FlightId, string PassengerName, string SeatNumber, DateTime BookingDate);
}
