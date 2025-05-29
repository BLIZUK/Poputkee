using Poputkee.Core.Interfaces;
using Poputkee.Core.Models;
using System;
using System.Diagnostics;
using System.Windows.Input;

namespace Poputkee.Desktop.ViewModels.MainMenu
{
    public class AccountViewModel : BaseViewModel
    {
        private readonly IAccountService _accountService;
        private readonly INavigationService _navigationService;
        public Account CurrentAccount { get; }

        public ICommand EditCommand { get; }

        public AccountViewModel(IAccountService accountService, INavigationService navigationService)
        {
            _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
            _navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));

            CurrentAccount = _accountService.GetAccount();

            // Исправленная команда с параметром
            EditCommand = new RelayCommand(_ =>
            {
                Debug.WriteLine(">>> EditCommand вызван");
                _navigationService.NavigateTo<EditAccountViewModel>();
            });
        }
    }
}