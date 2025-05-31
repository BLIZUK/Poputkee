using Poputkee.Core.Interfaces;
using Poputkee.Desktop.ViewModels.Auth;
using System.Windows.Input;

namespace Poputkee.Desktop.ViewModels.MainMenu
{
    public class MainWindowViewModel : BaseViewModel
    {
        private readonly IAuthService _authService;
        private readonly INavigationService _navigationService;

        private BaseViewModel _currentView;
        public BaseViewModel CurrentView
        {
            get => _currentView;
            set => SetProperty(ref _currentView, value);
        }

        public ICommand LogoutCommand { get; }

        public MainWindowViewModel(
            IAuthService authService,
            INavigationService navigationService)
        {
            _authService = authService;
            _navigationService = navigationService;

            // Подписываемся на изменения навигации
            _navigationService.CurrentViewChanged += () =>
            {
                CurrentView = _navigationService.CurrentView;
            };

            // Определяем начальный экран
            if (_authService.IsAuthenticated)
            {
                _navigationService.NavigateTo<MainWindowViewModel>();
            }
            else
            {
                _navigationService.NavigateTo<LoginViewModel>();
            }

            LogoutCommand = new RelayCommand(_ => Logout());
        }

        private void Logout()
        {
            _authService.Logout();
            _navigationService.NavigateTo<LoginViewModel>();
        }
    }
}