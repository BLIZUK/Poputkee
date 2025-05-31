using Poputkee.Core.Interfaces;
using Poputkee.Core.Models;
using Poputkee.Desktop.ViewModels;
using System.Windows.Input;

namespace Poputkee.Desktop.ViewModels.MainMenu
{
    public class EditAccountViewModel : BaseViewModel
    {
        private readonly IAccountService _accountService;
        private readonly INavigationService _navigationService;

        public Account EditingAccount { get; set; }

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public EditAccountViewModel(
            IAccountService accountService,
            INavigationService navigationService)
        {
            _accountService = accountService;
            _navigationService = navigationService;

            // Создаем копию для редактирования
            EditingAccount = accountService.GetAccount().Clone();

            SaveCommand = new RelayCommand(SaveChanges);
            CancelCommand = new RelayCommand(CancelEditing);
        }

        private void SaveChanges(object obj)
        {
            _accountService.UpdateAccount(EditingAccount);
            _navigationService.GoBack();
        }

        private void CancelEditing(object obj)
        {
            _navigationService.GoBack();
        }
    }
}