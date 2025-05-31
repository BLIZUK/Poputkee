// Poputkee.Desktop/ViewModels/Auth/LoginViewModel.cs
using Poputkee.Core.Interfaces;
using Poputkee.Desktop.ViewModels.MainMenu;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Poputkee.Desktop.ViewModels.Auth
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly IAuthService _authService;
        private readonly INavigationService _navigationService;

        public string Email { get; set; }
        public string Password { get; set; }

        public ICommand LoginCommand { get; }
        public ICommand RegisterCommand { get; }

        public LoginViewModel(
            IAuthService authService,
            INavigationService navigationService)
        {
            _authService = authService;
            _navigationService = navigationService;

            LoginCommand = new RelayCommand(async _ => await LoginAsync());
            RegisterCommand = new RelayCommand(_ => _navigationService.NavigateTo<RegisterViewModel>());
        }

        private async Task LoginAsync()
        {
            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
            {
                MessageBox.Show("Заполните все поля");
                return;
            }

            try
            {
                await _authService.LoginAsync(Email, Password);
                _navigationService.NavigateTo<MainWindowViewModel>();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка входа: {ex.Message}");
            }
        }
    }
}