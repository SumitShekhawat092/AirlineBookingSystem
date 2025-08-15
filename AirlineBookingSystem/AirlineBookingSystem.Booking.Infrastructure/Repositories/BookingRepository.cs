using AirlineBookingSystem.Bookings.Core.Entities;
using AirlineBookingSystem.Bookings.Core.Repositories;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingSystem.Bookings.Infrastructure.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly IDbConnection _dbConnection;
        public BookingRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public async Task AddBookingAsync(Booking booking)
        {
            const string sql = @"
            INSERT INTO Bookings (Id, FlightId, PassengerName, SeatNumber, BookingDate)
            VALUES (@Id, @FlightId, @PassengerName, @SeatNumber, @BookingDate)";

            await _dbConnection.ExecuteAsync(sql, booking);
        }

        public async Task<Booking> GetBookingByIdAsync(int id)
        {
            const string sql = @"SELECT Id, FlightId, PassengerName, SeatNumber, BookingDate FROM Bookings WHERE Id = @Id";
            return await _dbConnection.QuerySingleOrDefaultAsync<Booking>(sql, new { Id = id });
        }
    }
}
