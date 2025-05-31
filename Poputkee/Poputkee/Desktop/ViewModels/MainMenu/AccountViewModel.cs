using Poputkee.Core.Interfaces;
using Poputkee.Core.Models;
using System;
using System.Diagnostics;
using System.Windows.Input;

namespace Poputkee.Desktop.ViewModels.MainMenu
{
    /// <summary>
    /// ViewModel для управления профилем пользователя
    /// </summary>
    public class AccountViewModel : BaseViewModel
    {
        private readonly IAccountService _accountService;
        private readonly INavigationService _navigationService;

        /// <summary>
        /// Текущий аккаунт пользователя
        /// </summary>
        public Account CurrentAccount { get; }

        /// <summary>
        /// Команда для перехода к редактированию профиля
        /// </summary>
        public ICommand EditCommand { get; }

        /// <summary>
        /// Конструктор с внедрением зависимостей
        /// </summary>
        public AccountViewModel(
            IAccountService accountService,
            INavigationService navigationService)
        {
            _accountService = accountService ??
                throw new ArgumentNullException(nameof(accountService));

            _navigationService = navigationService ??
                throw new ArgumentNullException(nameof(navigationService));

            // Получаем текущий аккаунт
            CurrentAccount = _accountService.GetAccount();

            // Инициализируем команду
            EditCommand = new RelayCommand(ExecuteEditCommand);
        }

        /// <summary>
        /// Выполнение команды редактирования
        /// </summary>
        private void ExecuteEditCommand(object parameter)
        {
            Debug.WriteLine($">>> Переход к редактированию профиля");
            _navigationService.NavigateTo<EditAccountViewModel>();
        }
    }
}