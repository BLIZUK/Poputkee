// Poputkee.Infrastructure/Data/UnitOfWork.cs
using Microsoft.EntityFrameworkCore;
using Poputkee.Core.Interfaces;
using Poputkee.Core.Models;
using System;
using System.Threading.Tasks;

namespace Poputkee.Infrastructure.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
        Trips = new Repository<Trip>(_context);
        Users = new Repository<User>(_context);
        Bookings = new Repository<Booking>(_context);
    }

    // Репозитории
    public IRepository<Trip> Trips { get; }
    public IRepository<User> Users { get; }
    public IRepository<Booking> Bookings { get; }

    // Сохранение изменений
    public async Task<int> CommitAsync() => await _context.SaveChangesAsync();

    // Освобождение ресурсов
    public void Dispose() => _context.Dispose();
}