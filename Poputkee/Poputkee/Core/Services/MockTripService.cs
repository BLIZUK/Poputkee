using Poputkee.Core.Interfaces;
using Poputkee.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poputkee.Core.Services
{
    public class MockTripService : ITripService
    {
        // Пример реализации с мок-данными
        public List<Trip> GetCompletedTrips()
        {
            return new List<Trip>
            {
                new Trip
                {
                    FromCity = "Москва",
                    ToCity = "Санкт-Петербург",
                    DepartureTime = DateTime.Now.AddDays(-3),
                    AvailableSeats = 2,
                    DriverName = "Иван Иванов",
                    IsCompleted = true
                },
                new Trip
                {
                    FromCity = "Казань",
                    ToCity = "Екатеринбург",
                    DepartureTime = DateTime.Now.AddDays(-7),
                    AvailableSeats = 3,
                    DriverName = "Мария Петрова",
                    IsCompleted = true
                }
            };
        }
    }
}
