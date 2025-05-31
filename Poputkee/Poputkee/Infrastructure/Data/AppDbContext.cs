using Microsoft.EntityFrameworkCore;
using Poputkee.Core.Models;

/*
|
| # Дополнительные рекомендации:
|  | 1. Создать отдельные классы конфигурации:
|  |------------------------------------------------------------------------|
|  | ```
|  |    // TripConfiguration.cs
|  |    public class TripConfiguration : IEntityTypeConfiguration<Trip>
|  |    {
|  |        public void Configure(EntityTypeBuilder<Trip> builder)
|  |        {
|  |            builder.Property(t => t.FromCity)
|  |                .HasMaxLength(100)
|  |                .IsRequired();
|  |        }
|  |    }
|  | ```
|  |------------------------------------------------------------------------|
|  | 2. Добавить индексы:
|  |------------------------------------------------------------------------|
|  | ```
|  |
|  |    builder.HasIndex(t => t.DepartureTime);
|  |
|  | ```
|  |------------------------------------------------------------------------|
|  | 3. Настроить точность для дат:
|  |------------------------------------------------------------------------|
|  | ```
|  |
|  |    builder.Property(t => t.CreatedAt)
|  |        .HasPrecision(3);
|  |
|  | ```
|  |------------------------------------------------------------------------|
|  | 4. Реализовать мягкое удаление:
|  |------------------------------------------------------------------------|
|  | ```
|  |
|  |    builder.HasQueryFilter(t => !t.IsDeleted);
|  |
|  | ```
|  |------------------------------------------------------------------------|
|  | 5. Добавить ограничения:
|  |------------------------------------------------------------------------|
|  | ```
|  |
|  |    builder.Property(t => t.AvailableSeats)
|  |        .HasDefaultValue(1)
|  |        .HasAnnotation("MinValue", 1);
|  |
|  | ```
|  |------------------------------------------------------------------------|
|
*/

namespace Poputkee.Infrastructure.Data
{
    /// <summary>
    /// Контекст базы данных приложения
    /// </summary>
    public class AppDbContext : DbContext
    {
        #region Constructor

        /// <summary>
        /// Инициализирует новый экземпляр контекста
        /// </summary>
        /// <param name="options">Настройки контекста</param>
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        #endregion

        #region DbSets

        /// <summary>
        /// Набор данных поездок
        /// </summary>
        public DbSet<Trip> Trips { get; set; }

        /// <summary>
        /// Набор данных пользователей
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Набор данных бронирований
        /// </summary>
        public DbSet<Booking> Bookings { get; set; }

        #endregion

        #region Model Configuration

        /// <summary>
        /// Конфигурация модели данных
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trip>(entity =>
            {
                entity.Property(t => t.FromCity).IsRequired().HasMaxLength(100);
                entity.Property(t => t.ToCity).IsRequired().HasMaxLength(100);
                entity.Property(t => t.DriverName).IsRequired().HasMaxLength(100);
                entity.Property(t => t.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            // Остальные конфигурации...
        }

        #endregion

        #region Relationship Configuration (Optional)

        /// <summary>
        /// Ручная настройка связей между сущностями
        /// </summary>
        private static void ConfigureRelationships(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasOne(b => b.Trip)
                    .WithMany(t => t.Bookings)
                    .HasForeignKey(b => b.TripId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(b => b.Passenger)
                    .WithMany(u => u.Bookings)
                    .HasForeignKey(b => b.PassengerId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }

        #endregion
    }
}