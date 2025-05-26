// System namespaces
// Application components
using Poputkee.Core.Interfaces;
using Poputkee.Core.Services;
using System.Windows.Input;
using System.Windows.Navigation;


namespace Poputkee.Desktop.ViewModels.MainMenu
{
    /// <summary>
    /// ViewModel главного окна приложения, управляющая навигацией между представлениями
    /// </summary>
    public class MainWindowViewModel : BaseViewModel
    {
        private readonly ITripService _tripService;
        private BaseViewModel _currentView;

        private readonly IAccountService _accountService;
        private readonly INavigationService _navigationService;

        /// <summary>
        /// Конструктор с внедрением зависимости сервиса поездок
        /// </summary>
        /// <param name="MocktripService">Мок-реализация сервиса поездок (для тестирования/разработки)</param>
        public MainWindowViewModel(ITripService MocktripService)
        {
            _tripService = MocktripService;
            InitializeCommands();
        }

        #region Commands

        /// <summary>
        /// Команда для отображения экрана бронирования поездки
        /// </summary>
        public ICommand ShowBookRideCommand { get; private set; }

        /// <summary>
        /// Команда для отображения экрана создания поездки
        /// </summary>
        public ICommand ShowCreateRideCommand { get; private set; }

        /// <summary>
        /// Команда для отображения архива поездок
        /// </summary>
        public ICommand ShowArchiveCommand { get; private set; }

        /// <summary>
        /// Команда для отображения аккаунта пользователя
        /// </summary>
        public ICommand ShowAccountCommand { get; private set; }

    //    public ICommand NavigateToAccountCommand => new RelayCommand(_ =>
    //NavigationService.NavigateTo<AccountViewModel>());

        #endregion

        #region Properties

        /// <summary>
        /// Текущее активное представление в главном окне
        /// </summary>
        public BaseViewModel CurrentView
        {
            get => _currentView;
            set => SetProperty(ref _currentView, value);
        }

        #endregion

        /// <summary>
        /// Инициализация команд навигации
        /// </summary>
        private void InitializeCommands()
        {
            ShowBookRideCommand = new RelayCommand(_ =>
                CurrentView = new BookRideViewModel());

            ShowCreateRideCommand = new RelayCommand(_ =>
                CurrentView = new CreateRideViewModel());

            ShowArchiveCommand = new RelayCommand(_ =>
                CurrentView = new ArchiveViewModel(_tripService));

            ShowAccountCommand = new RelayCommand(_ =>
    CurrentView = new AccountViewModel(_accountService, _navigationService)
);
        }
    }
}