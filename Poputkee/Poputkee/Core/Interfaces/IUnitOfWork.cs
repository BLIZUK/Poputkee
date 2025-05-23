using Poputkee.Core.Interfaces;
using Poputkee.Core.Models;
using System;
using System.Threading.Tasks;

/*
|
| # Дополнительные рекомендации:
|  | 1. Можно добавить синхронную версию Commit()
|  | 2. Реализовать механизм отката транзакций
|  | 3. Добавить методы для работы с отдельными транзакциями
|  | 4. Ввести логирование операций
|  | 5. Добавить проверку подключения к БД
|
*/

namespace Poputkee.Core.Interfaces
{
    /// <summary>
    /// Интерфейс Unit of Work для управления транзакциями и репозиториями
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        #region Repositories

        /// <summary>
        /// Репозиторий для работы с поездками
        /// </summary>
        IRepository<Trip> Trips { get; }

        /// <summary>
        /// Репозиторий для работы с пользователями
        /// </summary>
        IRepository<User> Users { get; }

        /// <summary>
        /// Репозиторий для работы с бронированиями
        /// </summary>
        IRepository<Booking> Bookings { get; }

        #endregion

        #region Transaction Management

        /// <summary>
        /// Асинхронное сохранение всех изменений в базе данных
        /// </summary>
        /// <returns>Количество затронутых записей</returns>
        /// <exception cref="DbUpdateException">При ошибке сохранения</exception>
        Task<int> CommitAsync();

        #endregion
    }
}