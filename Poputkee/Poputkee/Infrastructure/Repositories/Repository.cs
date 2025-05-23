using Microsoft.EntityFrameworkCore;
using Poputkee.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

/*
|
| # Дополнительные рекомендации:
|  | 1. Добавить методы фильтрации:
|  |------------------------------------------------------------------------|
|  | ```
|  |    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
{
    return await _dbSet.Where(predicate).ToListAsync();
}
|  |
|  | ```
|  |------------------------------------------------------------------------|
|  | 2. Реализовать паттерн Specification:
|  |------------------------------------------------------------------------|
|  | ```
|  |
|  |    public async Task<IEnumerable<T>> GetAsync(ISpecification<T> spec)
{
    return await ApplySpecification(spec).ToListAsync();
}
|  |
|  | ```
|  |------------------------------------------------------------------------|
|  | 3. Добавить пагинацию:
|  |------------------------------------------------------------------------|
|  | ```
|  |
|  |    public async Task<PagedResult<T>> GetPagedAsync(int page, int pageSize)
{
    var result = new PagedResult<T> {
        Total = await _dbSet.CountAsync(),
        Items = await _dbSet.Skip((page - 1) * pageSize)
                           .Take(pageSize)
                           .ToListAsync()
    };
    return result;
}
|  |
|  | ```
|  |------------------------------------------------------------------------|
|  | 4. Реализовать включение связанных сущностей:
|  |------------------------------------------------------------------------|
|  | ```
|  |
|  |    public async Task<T> GetByIdWithIncludeAsync(Guid id, params Expression<Func<T, object>>[] includes)
{
    var query = _dbSet.AsQueryable();
    foreach (var include in includes)
    {
        query = query.Include(include);
    }
    return await query.FirstOrDefaultAsync(e => e.Id == id);
}
|  |
|  | ```
|  |------------------------------------------------------------------------|
|
*/

namespace Poputkee.Infrastructure.Repositories
{
    /// <summary>
    /// Базовая реализация репозитория для работы с сущностями
    /// </summary>
    /// <typeparam name="T">Тип сущности</typeparam>
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext _context;
        protected readonly DbSet<T> _dbSet;

        /// <summary>
        /// Инициализирует новый экземпляр репозитория
        /// </summary>
        /// <param name="context">Контекст базы данных</param>
        /// <exception cref="ArgumentNullException">Если контекст равен null</exception>
        public Repository(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<T>();
        }

        #region CRUD Operations

        /// <inheritdoc/>
        public async Task<T> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("Идентификатор не может быть пустым", nameof(id));

            try
            {
                return await _dbSet.FindAsync(id);
            }
            catch (Exception ex)
            {
                // Логирование ошибки
                throw new RepositoryException("Ошибка при получении сущности", ex);
            }
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await _dbSet.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Ошибка при получении списка сущностей", ex);
            }
        }

        /// <inheritdoc/>
        public async Task AddAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            try
            {
                await _dbSet.AddAsync(entity);
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Ошибка при добавлении сущности", ex);
            }
        }

        /// <inheritdoc/>
        public async Task UpdateAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            try
            {
                _dbSet.Update(entity);
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Ошибка при обновлении сущности", ex);
            }
        }

        /// <inheritdoc/>
        public async Task DeleteAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            try
            {
                _dbSet.Remove(entity);
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Ошибка при удалении сущности", ex);
            }
        }

        #endregion
    }

    /// <summary>
    /// Специальное исключение для ошибок репозитория
    /// </summary>
    public class RepositoryException : Exception
    {
        public RepositoryException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}