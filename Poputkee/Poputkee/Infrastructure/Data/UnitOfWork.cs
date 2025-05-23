using Poputkee.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Poputkee.Core.Interfaces;
using Poputkee.Core.Models;
using System;
using System.Threading.Tasks;

/*
|
| # Дополнительные рекомендации:
|  | 1. Добавить транзакционность:
|  |------------------------------------------------------------------------|
|  | ```
|  |    public async Task BeginTransactionAsync() 
|  |        => await _context.Database.BeginTransactionAsync();
|  |
|  |    public async Task CommitTransactionAsync() 
|  |        => await _context.Database.CommitTransactionAsync();
|  | ```
|  |------------------------------------------------------------------------|
|  | 2. Реализовать откат изменений:
|  |------------------------------------------------------------------------|
|  | ```
|  |    public async Task RollbackAsync()
|  |    {
|  |        foreach (var entry in _context.ChangeTracker.Entries())
|  |        {
|  |            switch (entry.State)
|  |            {
|  |                case EntityState.Modified:
|  |                  entry.State = EntityState.Unchanged;
|  |                  break;
|  |              case EntityState.Added:
|  |                  entry.State = EntityState.Detached;
|  |                  break;
|  |              case EntityState.Deleted:
|  |                  entry.Reload();
|  |                  break;
|  |            }
|  |        }
|  |        await Task.CompletedTask;
|  |    }
|  | ```
|  |------------------------------------------------------------------------|
|  | 3. Добавить метрики:
|  |------------------------------------------------------------------------|
|  | ```
|  |
|  |    public int TotalChanges => _context.ChangeTracker.Entries().Count();
|  |
|  | ```
|  |------------------------------------------------------------------------|
|
*/

namespace Poputkee.Infrastructure.Data
{
    /// <summary>
    /// Реализация Unit of Work для управления транзакциями и репозиториями
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        #region Fields

        private readonly AppDbContext _context;
        private bool _disposed;

        #endregion

        #region Repositories

        /// <inheritdoc/>
        public IRepository<Trip> Trips { get; }

        /// <inheritdoc/>
        public IRepository<User> Users { get; }

        /// <inheritdoc/>
        public IRepository<Booking> Bookings { get; }

        #endregion

        #region Constructor

        /// <summary>
        /// Инициализирует новый экземпляр Unit of Work
        /// </summary>
        /// <param name="context">Контекст базы данных</param>
        /// <exception cref="ArgumentNullException">Если контекст равен null</exception>
        public UnitOfWork(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

            Trips = new Repository<Trip>(_context);
            Users = new Repository<User>(_context);
            Bookings = new Repository<Booking>(_context);
        }

        #endregion

        #region Public Methods

        /// <inheritdoc/>
        public async Task<int> CommitAsync()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                // TODO: Добавить логирование ошибок
                throw new ApplicationException("Ошибка сохранения изменений", ex);
            }
        }

        #endregion

        #region IDisposable Implementation

        /// <inheritdoc/>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                _disposed = true;
            }
        }

        /// <summary>
        /// Финализатор
        /// </summary>
        ~UnitOfWork() => Dispose(false);

        #endregion
    }
}