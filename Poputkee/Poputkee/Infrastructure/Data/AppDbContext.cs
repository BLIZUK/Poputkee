// Poputkee.Infrastructure/Data/AppDbContext.cs
using Microsoft.EntityFrameworkCore;
using Poputkee.Core.Models;

namespace Poputkee.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // Сущности БД
    public DbSet<Trip> Trips { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Booking> Bookings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Конфигурация связей
        modelBuilder.Entity<Booking>()
            .HasOne(b => b.Trip)
            .WithMany(t => t.Bookings)
            .HasForeignKey(b => b.TripId);

        modelBuilder.Entity<Booking>()
            .HasOne(b => b.Passenger)
            .WithMany(u => u.Bookings)
            .HasForeignKey(b => b.PassengerId);
    }

}