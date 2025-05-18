using Poputkee.Views;
using System.Windows.Input;

public class MainWindowViewModel : BaseViewModel
{
    private object _currentView;
    public object CurrentView
    {
        get => _currentView;
        set => SetField(ref _currentView, value);
    }

    // Команды для навигации
    public ICommand ShowBookRideCommand { get; }
    public ICommand ShowCreateRideCommand { get; }
    public ICommand ShowArchiveCommand { get; }
    public ICommand ShowAccountCommand { get; }

    public MainWindowViewModel()
    {
        // Инициализация команд
        ShowBookRideCommand = new RelayCommand(() => CurrentView = new BookRideView());
        ShowCreateRideCommand = new RelayCommand(() => CurrentView = new CreateRideView());
        ShowArchiveCommand = new RelayCommand(() => CurrentView = new ArchiveView());
        ShowAccountCommand = new RelayCommand(() => CurrentView = new AccountView());

        // Стартовая страница
        CurrentView = new BookRideView();
    }
}