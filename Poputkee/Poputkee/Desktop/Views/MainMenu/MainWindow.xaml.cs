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
        DataContext = new MainWindowViewModel();  // Устанавливаем контекст данных
    }
}