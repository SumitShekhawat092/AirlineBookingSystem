using AirlineBookingSystem.Bookings.Core.Entities;
using AirlineBookingSystem.Bookings.Core.Repositories;
using Dapper;
using Newtonsoft.Json;
using StackExchange.Redis;
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
        private readonly IDatabase _redisDatabase;
        private const string RedisKeyPrefix = "booking_";
        public BookingRepository(IDatabase redisConnection)
        {
            _redisDatabase = redisConnection;
        }
        public async Task AddBookingAsync(Booking booking)
        {
            var data = JsonConvert.SerializeObject(booking);
            await _redisDatabase.StringSetAsync($"{RedisKeyPrefix}{booking.Id}", data);
        }

        public async Task<Booking> GetBookingByIdAsync(Guid id)
        {
            var data = await _redisDatabase.StringGetAsync($"{RedisKeyPrefix}{id}");
            return string.IsNullOrEmpty(data) ? null : JsonConvert.DeserializeObject<Booking>(data);
        }
    }
}
