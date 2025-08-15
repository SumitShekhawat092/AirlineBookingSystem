using AirlineBookingSystem.Bookings.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingSystem.Bookings.Application.Queries
{
    public record GetBookingQuery(Guid Id): IRequest<Booking>;
}
