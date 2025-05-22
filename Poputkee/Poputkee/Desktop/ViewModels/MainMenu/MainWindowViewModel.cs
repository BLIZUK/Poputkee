using Poputkee.Desktop.ViewModels;
using Poputkee.Core.Services;
using Poputkee.Desktop.ViewModels.MainMenu;
using System.Windows.Input;

public class MainWindowViewModel : BaseViewModel
{
    private readonly ITripService _tripService;

    public MainWindowViewModel(ITripService MocktripService)
    {
        _tripService = MocktripService;

        // Инициализация команд
        ShowBookRideCommand = new RelayCommand(_ => CurrentView = new BookRideViewModel());
        ShowCreateRideCommand = new RelayCommand(_ => CurrentView = new CreateRideViewModel());
        ShowArchiveCommand = new RelayCommand(_ => CurrentView = new ArchiveViewModel(_tripService));
    }

    public ICommand ShowBookRideCommand { get; }
    public ICommand ShowCreateRideCommand { get; }
    public ICommand ShowArchiveCommand { get; }

    private BaseViewModel _currentView;
    public BaseViewModel CurrentView
    {
        get => _currentView;
        set => SetProperty(ref _currentView, value);
    }
}