using Poputkee.Core.Interfaces;
using Poputkee.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Poputkee.Core.Services;
using System.Windows;
using System.Diagnostics;

namespace Poputkee.Desktop.ViewModels.MainMenu
{
    public class AccountViewModel : BaseViewModel
    {
        private readonly IAccountService _accountService;
        private readonly INavigationService _navigationService;
        public Account CurrentAccount { get; }

        public ICommand EditCommand { get; }   // null!
                                                            /*
                                                             * Свойство EditCommand в AccountViewModel объявлено, но не инициализировано:
                                                             * Это вызывает ошибку времени выполнения при попытке вызвать команду.
                                                             */

        // , INavigationService navigationService
        // _navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));

        public AccountViewModel(IAccountService accountService, INavigationService navigationService)
        {

            _accountService = accountService;
            _navigationService = navigationService;
            CurrentAccount = _accountService.GetAccount();

            // Инициализируйте команду
            EditCommand = new RelayCommand(() => _navigationService.NavigateTo<EditAccountViewModel>());

            try
            {
                //.NavigateTo<EditAccountViewModel>();  // ОШИБКА!
                                                                        /*
                                                                         * Это приводит к автоматическому переходу на EditAccountViewModel при создании AccountViewModel,
                                                                         * что недопустимо. Навигация должна выполняться через команду (например, по клику кнопки),
                                                                         * а не в конструкторе.
                                                                         */
    }
            catch (Exception ex)
            {
                Debug.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    } 
}
