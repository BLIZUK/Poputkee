using Poputkee.Core.Models;

/*
|
| # Дополнительные рекомендации:
|  | 1. Добавить систему аутентификации
|  | 2. Реализовать проверку прав доступа
|  | 3. Добавить события при изменении пользователя
|  | 4. Реализовать систему кэширования
|  | 5. Добавить поддержку сессий
|
*/

namespace Poputkee.Core.Services
{
    /// <summary>
    /// Сервис для управления текущим пользователем системы
    /// </summary>
    public class UserService : IUserService
    {
        #region Fields

        private User _currentUser;

        #endregion

        #region IUserService Implementation

        /// <summary>
        /// Текущий авторизованный пользователь
        /// </summary>
        /// <exception cref="ArgumentNullException">При попытке установить null</exception>
        public User CurrentUser
        {
            get => _currentUser;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value),
                        "Нельзя установить null в качестве текущего пользователя");
                }
                _currentUser = value;

                // Можно добавить логирование изменения пользователя
                // Logger.LogInformation($"User changed to {value.UserName}");
            }
        }

        #endregion
    }
}