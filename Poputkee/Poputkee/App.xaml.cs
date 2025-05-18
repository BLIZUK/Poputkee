using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Windows;

namespace Poputkee;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public App()
    {
        // Конструктор вызывается при запуске приложения
        Debug.WriteLine("\n<-------------------------------------------->\n" +
            "             Конструктор App вызван" +
            "\n<-------------------------------------------->\n");
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        Debug.WriteLine("\n<-------------------------------------------->\n" + 
            "App.xaml загружен, стартовое окно открывается" +
            "\n<-------------------------------------------->\n");

    }
}

