using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        public string Salt { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? LastLogin { get; set; }

        public string AvatarUrl { get; set; } = "https://i.pravatar.cc/150?img=0";

        public string PhoneNumber { get; set; } = string.Empty;

        public bool IsDriver { get; set; } // Флаг, является ли пользователь водителем

        // Навигационные свойства
        public List<Trip> CreatedTrips { get; set; } = new List<Trip>();
        public List<Booking> Bookings { get; set; } = new List<Booking>();
    }
}