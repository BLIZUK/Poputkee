using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Poputkee.Poputkee.Core.Models
{
    public class Booking
    {
        public Guid Id { get; set; }
        public Guid TripId { get; set; }     // Внешний ключ на поездку
        public Guid PassengerId { get; set; } // Внешний ключ на пользователя
        public DateTime BookedAt { get; set; }

        // Навигационные свойства (опционально)
        public required Trip Trip { get; set; }
        public required User Passenger { get; set; }
    }
}
