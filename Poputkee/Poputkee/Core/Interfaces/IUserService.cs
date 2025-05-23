using Poputkee.Core.Models;

/*
|
| # Дополнительные рекомендации:
|  | 1. Добавить методы аутентификации/выхода
|  | 2. Реализовать проверку прав доступа
|  | 3. Добавить события изменения состояния пользователя
|  | 4. Реализовать механизм автоматического обновления данных
|
*/

namespace Poputkee.Core.Services
{
    /// <summary>
    /// Интерфейс сервиса для работы с текущим пользователем
    /// </summary>
    public interface IUserService
    {
        #region User Management

        /// <summary>
        /// Текущий авторизованный пользователь системы
        /// </summary>
        /// <remarks>
        /// Возвращает null если пользователь не аутентифицирован
        /// </remarks>
        /// <exception cref="ArgumentNullException">При попытке установить null</exception>
        User CurrentUser { get; set; }

        #endregion
    }
}