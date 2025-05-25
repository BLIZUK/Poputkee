using Poputkee.Core.Interfaces;
using Poputkee.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;

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
            _accountService = accountService;
            _navigationService = navigationService;
            CurrentAccount = _accountService.GetAccount();

            EditCommand = new RelayCommand(_ =>
                _navigationService.NavigateTo<EditAccountViewModel>());
        }
    } 
}
