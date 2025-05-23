using Poputkee.Core.Interfaces;
using Poputkee.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Poputkee.Core.Services
{
    /// <summary>
    /// Мок-реализация сервиса для работы с поездками (для тестирования/разработки)
    /// </summary>
    public class MockTripService : ITripService
    {
        #region Fields

        private readonly List<Trip> _trips = new()
        {
            new Trip
            {
                //Id = 1,
                FromCity = "Москва",
                ToCity = "Санкт-Петербург",
                DepartureTime = DateTime.Now.AddDays(-3),
                AvailableSeats = 2,
                DriverName = "Иван Иванов",
                Comment = "",
                IsCompleted = true
            },
            new Trip
            {
                //Id = 2,
                FromCity = "Казань",
                ToCity = "Екатеринбург",
                DepartureTime = DateTime.Now.AddDays(-7),
                AvailableSeats = 3,
                DriverName = "Мария Петрова",
                Comment = "",
                IsCompleted = true
            }
        };

        #endregion


        #region Public Methods

        /// <summary>
        /// Получение списка завершенных поездок
        /// </summary>
        public List<Trip> GetCompletedTrips()
        {
            // Возвращаем копию списка для имитации реального поведения
            return _trips.Where(t => t.IsCompleted).ToList();
        }

        /// <summary>
        /// Обновление информации о поездке
        /// </summary>
        /// <param name="trip">Обновленные данные поездки</param>
        /// <exception cref="ArgumentException">Если поездка не найдена</exception>
        public void UpdateTrip(Trip trip)
        {
            var existingTrip = _trips.FirstOrDefault(t => t.Id == trip.Id);

            if (existingTrip == null)
            {
                throw new ArgumentException("Поездка не найдена");
            }

            existingTrip.Rating = trip.Rating;
            existingTrip.Comment = trip.Comment;
        }

        #endregion
    }
}