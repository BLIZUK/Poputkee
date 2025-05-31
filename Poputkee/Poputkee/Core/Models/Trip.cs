// Poputkee.Core/Models/Trip.cs
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Poputkee.Core.Models
{
    public class Trip
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(100)]
        public string FromCity { get; set; }

        [Required]
        [StringLength(100)]
        public string ToCity { get; set; }

        [Required]
        public DateTime DepartureTime { get; set; }

        [Range(1, 10)]
        public int AvailableSeats { get; set; }

        // Ссылка на водителя
        public Guid DriverId { get; set; }
        public string DriverName { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsCompleted { get; set; }

        public int? Rating { get; set; }
        public string Comment { get; set; }

        // Навигационное свойство
        public List<Booking> Bookings { get; set; } = new List<Booking>();
    }
}