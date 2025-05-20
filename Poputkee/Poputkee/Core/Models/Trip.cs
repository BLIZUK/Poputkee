using System;
using System.Collections.Generic;

namespace Poputkee.Core.Models;
//{
//    public class Trip
//    {
//        public Guid Id { get; set; } = Guid.NewGuid();
//        public string DriverName { get; set; }  // Имя водителя (можно заменить на связь с User)
//        public string FromCity { get; set; }
//        public string ToCity { get; set; }
//        public DateTime DepartureTime { get; set; }
//        public int AvailableSeats { get; set; }

//        // Навигационное свойство для бронирований этой поездки
//        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
//    }
//}


public class Trip
{
    public string FromCity { get; set; }
    public string ToCity { get; set; }
    public DateTime DepartureTime { get; set; }
    public int AvailableSeats { get; set; }
    public string DriverName { get; set; }
    public bool IsCompleted { get; set; } // Флаг завершенной поездки

}