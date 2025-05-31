// Poputkee.Core/Services/TripService.cs
using Microsoft.EntityFrameworkCore;
using Poputkee.Core.Interfaces;
using Poputkee.Core.Models;
using Poputkee.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poputkee.Core.Services
{
    public class TripService : ITripService
    {
        private readonly AppDbContext _context;

        public TripService(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateTripAsync(Trip trip)
        {
            if (trip == null)
                throw new ArgumentNullException(nameof(trip));

            // Получаем текущего пользователя (заглушка)
            var currentUser = await GetCurrentUserAsync();

            trip.Id = Guid.NewGuid();
            trip.DriverId = currentUser.Id;
            trip.DriverName = currentUser.Name;
            trip.CreatedAt = DateTime.UtcNow;
            trip.IsCompleted = false;

            _context.Trips.Add(trip);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Trip>> GetCompletedTripsAsync()
        {
            return await _context.Trips
                .Where(t => t.IsCompleted)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task UpdateTripAsync(Trip trip)
        {
            var existingTrip = await _context.Trips.FindAsync(trip.Id);
            if (existingTrip == null)
                throw new KeyNotFoundException("Поездка не найдена");

            existingTrip.Rating = trip.Rating;
            existingTrip.Comment = trip.Comment;

            await _context.SaveChangesAsync();
        }

        private async Task<User> GetCurrentUserAsync()
        {
            // В реальном приложении здесь должна быть логика получения текущего пользователя
            // Заглушка для примера
            return await _context.Users.FirstOrDefaultAsync()
                ?? throw new InvalidOperationException("Пользователь не найден");
        }
    } 
}
