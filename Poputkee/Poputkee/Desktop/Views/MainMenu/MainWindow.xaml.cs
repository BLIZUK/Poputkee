using Poputkee.Core.Interfaces;
using Poputkee.Core.Services;
using Poputkee.Desktop.ViewModels;
using Poputkee.Desktop.ViewModels.MainMenu;
using System.Windows;

namespace Poputkee.Desktop.Views.MainMenu;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        // Создаем экземпляры сервисов и передаем в ViewModel
        INavigationService navigationService = new NavigationService(serviceProvider);
        ITripService tripService = new MockTripService();
        IAccountService accountService = new MockAccountService();
        DataContext = new MainWindowViewModel(tripService, accountService, navigationService);  // Устанавливаем контекст данных
    }


    public MainWindow(MainWindowViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel; // Устанавливаем контекст данных
    }

    public IServiceProvider serviceProvider { get; }
}   