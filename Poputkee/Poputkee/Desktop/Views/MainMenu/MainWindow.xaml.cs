using Poputkee.Core.Services;
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
        // Создаем экземпляр сервиса и передаем в ViewModel
        ITripService tripService = new MockTripService(); // или new TripService()
        DataContext = new MainWindowViewModel(tripService);  // Устанавливаем контекст данных
    }
}   