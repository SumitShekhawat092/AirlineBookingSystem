using AirlineBookingSystem.Bookings.Application.Commands;
using AirlineBookingSystem.Bookings.Core.Entities;
using AirlineBookingSystem.Bookings.Core.Repositories;
using AirlineBookingSystem.BuildingBlocks.Contracts.EvenBus.Messages;
using MassTransit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingSystem.Bookings.Application.Handlers
{
    public class CreateBookingHandler : IRequestHandler<CreateBookingCommand, Guid>
    {
        private readonly IBookingRepository _repository;
        private readonly IPublishEndpoint _publishEndpoint;
        public CreateBookingHandler(IBookingRepository repository, IPublishEndpoint publishEndpoint) {
            _repository = repository;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<Guid> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            var booking = new Booking
            {
                Id = Guid.NewGuid(),
                FlightId = request.FlightId,
                PassengerName = request.PassengerName,
                SeatNumber = request.SeatNumber,
                BookingDate = DateTime.UtcNow
            };
            await _repository.AddBookingAsync(booking);

            //publish FlightbookedEvent
            await _publishEndpoint.Publish(new FlightBookedEvent(
                booking.Id,
                booking.FlightId,
                booking.PassengerName,
                booking.SeatNumber,
                booking.BookingDate
                ));

            return booking.Id;
        }
    }
}
