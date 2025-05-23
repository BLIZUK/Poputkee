using System;
using System.Collections.Generic;

namespace Poputkee.Core.Models
{
    /// <summary>
    /// Класс, представляющий информацию о поездке
    /// </summary>
    public class Trip
    {
        #region Core Properties

        /// <summary>
        /// Уникальный идентификатор поездки
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Пункт отправления
        /// </summary>
        public  string FromCity { get; set; }

        /// <summary>
        /// Пункт назначения
        /// </summary>
        public  string ToCity { get; set; }

        /// <summary>
        /// Дата и время отправления
        /// </summary>
        public DateTime DepartureTime { get; set; }

        /// <summary>
        /// Количество доступных мест
        /// </summary>
        public int AvailableSeats { get; set; }

        #endregion

        #region Driver Information

        /// <summary>
        /// Имя водителя
        /// </summary>
        public  string DriverName { get; set; }

        #endregion

        #region Status & Feedback

        /// <summary>
        /// Флаг завершения поездки
        /// </summary>
        public bool IsCompleted { get; set; }

        /// <summary>
        /// Оценка поездки (от 1 до 5)
        /// </summary>
        public int? Rating { get; set; }

        /// <summary>
        /// Комментарий к поездке
        /// </summary>
        public  string Comment { get; set; }

        #endregion

        #region Navigation Properties

        /// <summary>
        /// Список бронирований для этой поездки
        /// </summary>
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();

        #endregion
    }
}