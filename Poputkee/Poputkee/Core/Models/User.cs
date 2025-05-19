using System;
using System.Collections.Generic;

namespace Poputkee.Core.Models
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Навигационное свойство для бронирований пользователя
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}