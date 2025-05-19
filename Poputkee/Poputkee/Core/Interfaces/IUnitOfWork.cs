using Poputkee.Core.Interfaces;
using Poputkee.Core.Models;
using System;
using System.Threading.Tasks;

public interface IUnitOfWork : IDisposable
{
    // Репозитории для работы с сущностями
    IRepository<Trip> Trips { get; }
    IRepository<User> Users { get; }
    IRepository<Booking> Bookings { get; }

    // Сохранение изменений в БД
    Task<int> CommitAsync();
}