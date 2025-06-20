﻿using Poputkee.Core.Models;
using System.Collections.Generic;

/*
|
| # Дополнительные рекомендации:
|  | 1.Добавить методы для:
|  |  |  - Получения активных поездок
|  |  |  - Фильтрации по датам
|  |  |  - Поиска по параметрам
|  | 2. Реализовать пагинацию для больших коллекций
|  | 3. Добавить методы для работы с отменами поездок
|  | 4. Ввести систему валидации входных параметров
|  | 5. Реализовать поддержку асинхронных операций
|
*/

namespace Poputkee.Core.Services
{
    /// <summary>
    /// Интерфейс сервиса для работы с поездками
    /// </summary>
    public interface ITripService
    {
        #region Trip Management Operations

        /// <summary>
        /// Получение списка завершенных поездок
        /// </summary>
        /// <returns>Коллекция завершенных поездок</returns>
        Task<List<Trip>> GetCompletedTripsAsync();

        /// <summary>
        /// Обновление информации о поездке
        /// </summary>
        /// <param name="trip">Обновляемая поездка</param>
        /// <exception cref="ArgumentNullException">Если поездка равна null</exception>
        /// <exception cref="ArgumentException">Если поездка не найдена</exception>
        Task UpdateTripAsync(Trip trip);
        Task CreateTripAsync(Trip trip); // Асинхронное создание

        #endregion
    }
}