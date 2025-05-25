using Poputkee.Core.Interfaces;
using Poputkee.Core.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Poputkee.Desktop.ViewModels
{
    public class EditAccountViewModel : BaseViewModel
    {
        private readonly IAccountService _accountService;
        private readonly INavigationService _navigationService;

        public Account EditableAccount { get; }

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public EditAccountViewModel(IAccountService accountService, INavigationService navigationService)
        {
            _accountService = accountService;
            _navigationService = navigationService;

            // Создаем копию для редактирования
            EditableAccount = CloneAccount(_accountService.GetAccount());

            SaveCommand = new RelayCommand(_ => SaveChanges());
            CancelCommand = new RelayCommand(_ => _navigationService.GoBack());
        }

        private Account CloneAccount(Account source) => new Account
        {
            Email = source.Email,
            Name = source.Name,
            BirthDate = source.BirthDate,
            Bio = source.Bio
        };

        private void SaveChanges()
        {
            if (string.IsNullOrWhiteSpace(EditableAccount.Name))
            {
                Debug.WriteLine("Name cannot be empty!");
                return;
            }

            _accountService.UpdateAccount(EditableAccount);
            _navigationService.GoBack();
        }
    }
}
