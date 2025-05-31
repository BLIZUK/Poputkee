using Poputkee.Core.Interfaces;
using Poputkee.Core.Services;
using Poputkee.Desktop.ViewModels.MainMenu;
using System.Windows;

namespace Poputkee.Desktop.Views.MainMenu;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow(MainWindowViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel; // Устанавливаем контекст данных
    }
}   