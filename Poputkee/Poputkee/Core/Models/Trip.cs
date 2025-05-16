using System;
using System.Collections.Generic;
using Poputkee.Core.Models;

namespace Poputkee.Core.Models
{
    public class Trip
    {
        // Исправленный Id (удалено дублирование)
        public Guid Id { get; set; } = Guid.NewGuid(); // Теперь тип Guid

        public string DriverName { get; set; }
        public string FromCity { get; set; }
        public string ToCity { get; set; }
        public DateTime DepartureTime { get; set; }
        public int AvailableSeats { get; set; }

        // Навигационное свойство для связи с Booking
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();

        // Устаревшее свойство (можно удалить, так как бронирования теперь в Bookings)
        // public List<string> Passengers { get; } = new List<string>();
    }
}