// Poputkee.Desktop/ViewModels/Auth/RegisterViewModel.cs
using Poputkee.Core.Interfaces;
using Poputkee.Desktop.ViewModels.MainMenu;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Poputkee.Desktop.ViewModels.Auth
{
    public class RegisterViewModel : BaseViewModel
    {
        private readonly IAuthService _authService;
        private readonly INavigationService _navigationService;

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public ICommand RegisterCommand { get; }
        public ICommand LoginCommand { get; }

        public RegisterViewModel(
            IAuthService authService,
            INavigationService navigationService)
        {
            _authService = authService;
            _navigationService = navigationService;

            RegisterCommand = new RelayCommand(async _ => await RegisterAsync());
            LoginCommand = new RelayCommand(_ => _navigationService.NavigateTo<LoginViewModel>());
        }

        private async Task RegisterAsync()
        {
            if (Password != ConfirmPassword)
            {
                MessageBox.Show("Пароли не совпадают");
                return;
            }

            try
            {
                await _authService.RegisterAsync(Name, Email, Password);
                _navigationService.NavigateTo<MainWindowViewModel>();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка регистрации: {ex.Message}");
            }
        }
    }
}