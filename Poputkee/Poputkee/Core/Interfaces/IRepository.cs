// System namespaces
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

/*
|
| # Дополнительные рекомендации:
|  | - Можно добавить методы для работы с предикатами
|  | - Реализовать пагинацию в GetAllAsync
|  | - Добавить методы для массовых операций
|  | - Ввести систему кэширования
|
*/

namespace Poputkee.Core.Interfaces;

/// <summary>
/// Общий интерфейс репозитория для работы с сущностями
/// </summary>
/// <typeparam name="T">Тип сущности</typeparam>
public interface IRepository<T> where T : class
{
    #region Basic CRUD Operations

    /// <summary>
    /// Получение сущности по идентификатору
    /// </summary>
    /// <param name="id">Уникальный идентификатор сущности</param>
    /// <returns>Найденная сущность или null</returns>
    Task<T> GetByIdAsync(Guid id);

    /// <summary>
    /// Получение всех сущностей
    /// </summary>
    /// <returns>Коллекция всех сущностей</returns>
    Task<IEnumerable<T>> GetAllAsync();

    /// <summary>
    /// Добавление новой сущности
    /// </summary>
    /// <param name="entity">Добавляемая сущность</param>
    /// <exception cref="ArgumentNullException">Если сущность равна null</exception>
    Task AddAsync(T entity);

    /// <summary>
    /// Обновление существующей сущности
    /// </summary>
    /// <param name="entity">Обновляемая сущность</param>
    /// <exception cref="ArgumentNullException">Если сущность равна null</exception>
    Task UpdateAsync(T entity);

    /// <summary>
    /// Удаление сущности
    /// </summary>
    /// <param name="entity">Удаляемая сущность</param>
    /// <exception cref="ArgumentNullException">Если сущность равна null</exception>
    Task DeleteAsync(T entity);

    #endregion
}