using System;
using System.Collections.Generic;

/*
|
| # Дополнительные рекомендации:
|  |------------------------------------------------------------------------|
|  | ```
|  |    // Добавить дополнительные поля
|  |    public string HashedPassword { get; set; }
|  |    public UserRole Role { get; set; } = UserRole.User;
|  |    public DateTime? LastLogin { get; set; }
|  |
|  |    // Добавить методы безопасности
|  |    public void SetPassword(string password)
|  |    {
|  |        // Реализация хэширования
|  |    }
|  |
|  |    // Добавить перечисление ролей
|  |    public enum UserRole
|  |    {
|  |        User,
|  |        Driver,
|  |        Admin
|  |    }
|  | ```
|  |------------------------------------------------------------------------|
|
*/

namespace Poputkee.Core.Models
{
    /// <summary>
    /// Класс, представляющий пользователя системы
    /// </summary>
    public class User
    {
        #region Core Properties

        /// <summary>
        /// Уникальный идентификатор пользователя
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Полное имя пользователя
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Адрес электронной почты (уникальный идентификатор)
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Дата и время регистрации (в UTC)
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        #endregion

        #region Navigation Properties

        /// <summary>
        /// Коллекция бронирований пользователя
        /// </summary>
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();

        #endregion

        #region Methods (Пример расширения функциональности)

        /// <summary>
        /// Валидация основных свойств пользователя
        /// </summary>
        public bool Validate()
        {
            return !string.IsNullOrWhiteSpace(Name)
                && !string.IsNullOrWhiteSpace(Email)
                && Email.Contains("@");
        }

        #endregion
    }
}