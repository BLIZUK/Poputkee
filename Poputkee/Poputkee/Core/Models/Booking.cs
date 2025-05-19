using System;

namespace Poputkee.Core.Models
{
    public class Booking
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime BookedAt { get; set; } = DateTime.UtcNow;

        // Внешние ключи
        public Guid TripId { get; set; }
        public Guid PassengerId { get; set; }

        // Навигационные свойства
        public Trip Trip { get; set; }
        public User Passenger { get; set; }
    }
}