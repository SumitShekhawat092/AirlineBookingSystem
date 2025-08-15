using AirlineBookingSystem.Bookings.Application.Queries;
using AirlineBookingSystem.Bookings.Core.Entities;
using AirlineBookingSystem.Bookings.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingSystem.Bookings.Application.Handlers
{
    public class GetBookingHandler : IRequestHandler<GetBookingQuery,Booking>
    {
        private readonly IBookingRepository _repository;
        public GetBookingHandler(IBookingRepository repository) => _repository = repository;

        public async Task<Booking> Handle(GetBookingQuery request, CancellationToken cancellation)
        {
            return await _repository.GetBookingByIdAsync(request.Id);
        }
        
    }
}
