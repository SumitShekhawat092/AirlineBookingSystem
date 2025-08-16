using AirlineBookingSystem.Flights.Core.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingSystem.Flights.Infrastructure.Data
{
    public interface IFlightContext
    {
        IMongoCollection<Flight> Flights { get; }
    }
}
