using AirlineBookingSystem.Flights.Core.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingSystem.Flights.Infrastructure.Data
{
    public class FlightContext : IFlightContext
    {
        public IMongoCollection<Flight> Flights { get; set; }

        public FlightContext(IConfiguration configuration) 
        {
            var client = new MongoClient(configuration["Databasesettings:ConnectionString"]);
            var database = client.GetDatabase(configuration["Databasesettings:DatabaseName"]);
            Flights = database.GetCollection<Flight>(configuration["Databasesettings:CollectionName"]);
        }
    }
}
